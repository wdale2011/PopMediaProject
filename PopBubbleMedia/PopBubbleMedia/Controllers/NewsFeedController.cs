using PopBubbleMedia.Models;
using PopBubbleMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PopBubbleMedia.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewsFeedController : ApiController
    {
        readonly NewsFeedService newsFeedService = new NewsFeedService();

        [HttpGet, Route("api/newsFeed")]
        public List<NewsArticle> GetAll()
        {
            List<NewsArticle> newsArticles = newsFeedService.GetAll();

            return newsArticles;
        }

        [HttpPut, Route("api/newsFeed")]


        [HttpGet, Route("api/newsFeed/scrapper")]
        public List<NewsArticle> RunScrapper()
        {
            List<NewsArticle> newsArticles = newsFeedService.RunScrapper();

            return newsArticles;
        }

        [HttpPost, Route("api/register")]
        public HttpResponseMessage CreateAccount(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                ModelState.AddModelError("", "missing body data!");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int newId = newsFeedService.CreateAccount(userAccount);

            return Request.CreateResponse(HttpStatusCode.OK, newId);
        }

    }
}