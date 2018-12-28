using AngleSharp.Parser.Html;
using PopBubbleMedia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace PopBubbleMedia.Services
{
    public class NewsFeedService
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        //Get News Articles for the client
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

                        object image = reader["Image"];
                        if (image != DBNull.Value)
                        {
                            newsArticle.Image = (string)image;
                        }

                        newsArticles.Add(newsArticle);
                    }

                    return newsArticles;
                }
            }
        }

        public List<NewsArticle> RunScrapper()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //Delete old news articles
                SqlCommand delcommand = con.CreateCommand();
                delcommand.CommandText = "WebFeed_DeleteOld";
                delcommand.CommandType = System.Data.CommandType.StoredProcedure;

                delcommand.ExecuteNonQuery();
                //Scrape data from Google News
                var count = 0;
                var results = new List<NewsArticle>();
                //https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen

                var webClient = new WebClient();
                var html = webClient.DownloadString("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen");

                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var newsFeed = document.QuerySelectorAll(".HKt8rc");
                var newsArticles = newsFeed[0].QuerySelectorAll("article");
                var baseURI = "https://news.google.com";

                for (int i = 0; i < newsArticles.Length; i++)
                { 
                    var newsArticle = new NewsArticle();
                    newsArticle.Name = newsArticles[i].Children[1].Children[0].Children[0].Children[0].Children[0].TextContent;
                    if (i < 11)
                    {
                        newsArticle.Image = newsFeed[0].Children[0].Children[0].Children[i].Children[0].QuerySelector("img").Attributes[1].Value;
                    }
                    newsArticle.Link = baseURI + newsArticles[i].Children[0].Attributes[1].Value;
                    newsArticle.Site = newsArticles[i].Children[2].Children[0].Children[0].TextContent;

                    results.Add(newsArticle);
                    count = i;
                }
                //Insert the news articles into the database
                foreach (var item in results)
                {

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = "WebFeed_Insert";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Image", item.Image);
                    command.Parameters.AddWithValue("@Link", item.Link);
                    command.Parameters.AddWithValue("@Site", item.Site);

                    command.ExecuteNonQuery();
                }

                return results;
            };
        }

        public UserAccountUpdate GetAccount(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "UserAccounts_SelectById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    UserAccountUpdate userAccount = new UserAccountUpdate
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                    };

                    return userAccount;
                }
            }
        }

        public UserAccountUpdate Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "UserAccounts_Login";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    UserAccountUpdate userAccount = new UserAccountUpdate
                    {
                        Id = (int)reader["Id"]
                    };

                    return userAccount;
                }
            }
        }

        public int CreateAccount(UserAccount request)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "UserAccounts_Insert";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", request.Username);
                command.Parameters.AddWithValue("@Password", request.Password);

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                int newId = (int)command.Parameters["@Id"].Value;
                return newId;
            }
        }

        public void UpdateAccount(UserAccountUpdate request)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "UserAccounts_Update";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", request.Id);
                command.Parameters.AddWithValue("@Username", request.Username);
                command.Parameters.AddWithValue("@Password", request.Password);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTopTen()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "WebFeed_DeleteTopTen";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAccount(int id)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "UserAccounts_Delete";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}