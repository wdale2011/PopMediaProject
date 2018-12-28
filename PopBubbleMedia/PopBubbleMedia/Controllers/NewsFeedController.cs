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

        [HttpGet, Route("api/account/{id:int}")]
        public HttpResponseMessage GetAccount(int id)
        {
            UserAccountUpdate userAccount = newsFeedService.GetAccount(id);
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
            UserAccountUpdate userAccount = newsFeedService.Login(username, password);
            if (userAccount == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, userAccount);
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

        [HttpDelete, Route("api/delete/{id:int}")]
        public HttpResponseMessage DeleteAccount(int id)
        {
            newsFeedService.DeleteAccount(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}