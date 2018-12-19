using AngleSharp.Parser.Html;
using PopBubbleMedia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace PopBubbleMedia.Services
{
    public class NewsFeedService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public List<NewsArticle> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "WebFeed_GetAll";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<NewsArticle> newsArticles = new List<NewsArticle>();
                    while (reader.Read())
                    {
                        NewsArticle newsArticle = new NewsArticle
                        {
                            Name = (string)reader["Name"],
                            Link = (string)reader["Link"],
                            Site = (string)reader["Site"]
                        };

                        newsArticles.Add(newsArticle);
                    }

                    return newsArticles;
                }
            }
        }

        public void InsertAll(NewsArticle newsArticle)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "WebFeed_Insert";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", newsArticle.Name);
                command.Parameters.AddWithValue("@Link", newsArticle.Link);
                command.Parameters.AddWithValue("@Site", newsArticle.Site);

                command.ExecuteNonQuery();
            }
        }

        public List<NewsArticle> RunScrapper()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var count = 0;
                var results = new List<NewsArticle>();
                //https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen

                var webClient = new WebClient();
                var html = webClient.DownloadString("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen");

                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var newsFeed = document.QuerySelectorAll("article");
                var baseURI = "https://news.google.com/";

                for (int i = 0; i < newsFeed.Length; i++)
                { 
                    var newsArticle = new NewsArticle();
                    newsArticle.Name = newsFeed[i].Children[1].Children[0].Children[0].Children[0].Children[0].TextContent;
                    newsArticle.Link = baseURI + newsFeed[i].Children[0].Attributes[1].Value;
                    newsArticle.Site = newsFeed[i].Children[2].Children[0].Children[0].TextContent;

                    results.Add(newsArticle);
                    count = i;
                }

                foreach (var item in results)
                {

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = "WebFeed_Insert";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Link", item.Link);
                    command.Parameters.AddWithValue("@Site", item.Site);

                    command.ExecuteNonQuery();
                }

                return results;
            };
        }
    }
}