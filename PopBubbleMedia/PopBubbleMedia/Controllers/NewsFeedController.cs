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

        [HttpGet, Route("api/account")]
        public HttpResponseMessage GetAccount()
        {
            UserAccount userAccount = newsFeedService.GetAccount();
            if (userAccount == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, userAccount);
            }
        }

        [HttpGet, Route("api/login/{username}/{password}")]
        public HttpResponseMessage Login([FromUri]string username = "", [FromUri]string password = "")
        {
            if (newsFeedService.Login(username, password))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
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

        [HttpPut, Route("api/update")]
        public HttpResponseMessage UpdateAccount(UserAccountUpdate userAccountUpdate)
        {
            if (userAccountUpdate == null)
            {
                ModelState.AddModelError("", "No body data!");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            newsFeedService.UpdateAccount(userAccountUpdate);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/delete")]
        public HttpResponseMessage DeleteTopTen()
        {
            newsFeedService.DeleteTopTen();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}