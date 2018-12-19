using AngleSharp.Parser.Html;
using PopBubbleMedia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper
{
    class Program
    { 
        static void Main(string[] args)
        {
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
        }
    }
}
