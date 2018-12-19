using PopBubbleMedia.Models;
using PopBubbleMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PopBubbleMedia.Web.Controllers
{
    public class NewsFeedController : ApiController
    {
        readonly NewsFeedService newsFeedService = new NewsFeedService();

        [HttpGet, Route("api/newsFeed")]
        public List<NewsArticle> GetAll()
        {
            List<NewsArticle> newsArticles = newsFeedService.GetAll();

            return newsArticles;
        }

        [HttpGet, Route("api/newsFeed/scrapper")]
        public List<NewsArticle> RunScrapper()
        {
            List<NewsArticle> newsArticles = newsFeedService.RunScrapper();

            return newsArticles;
        }

    }
}