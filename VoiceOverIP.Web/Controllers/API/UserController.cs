using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VoiceOverIP.Web.Models;
using VoiceOverIP.Web.UserService;
using Subscription = VoiceOverIP.Web.Models.Subscription;
using User = VoiceOverIP.Web.Models.User;
using UserSubscription = VoiceOverIP.Web.Models.UserSubscription;


namespace VoiceOverIP.Web.Controllers.API
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<User>))]
        public HttpResponseMessage Get()
        {
            using (var client = new UserServiceClient())
            {
                var result = client.GetList().Select(x => new User
                     {
                         Id = x.Id,
                         Firstname = x.FirstName,
                         Lastname = x.LastName,
                         Email = x.Email,
                         Subscriptions = x.Subscriptions.Select(z => new Subscription
                         {
                             Id = z.Identifier,
                             Name = z.Name,
                             Price = z.Price,
                             Priceincvatamount = z.PriceIncVatAmount,
                             Callminutes = z.CallMinutes
                         }).ToList(),

                         Totalcallminutes = x.Subscriptions.Sum(t => t.CallMinutes),
                         Totalpriceincvatamount = x.Subscriptions.Sum(t => t.PriceIncVatAmount)

                     }).ToList();

                return Request.CreateResponse(result);
            }
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(User))]
        public HttpResponseMessage Get(int id)
        {

            using (var client = new UserServiceClient())
            {
                var result = client.GetById(id);

                if (result == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserId is not found");

                var user = new User
                {
                    Id = result.Id,
                    Firstname = result.FirstName,
                    Lastname = result.LastName,
                    Email = result.Email,
                    Subscriptions = result.Subscriptions.Select(z => new Subscription
                    {
                        Id = z.Identifier,
                        Name = z.Name,
                        Price = z.Price,
                        Priceincvatamount = z.PriceIncVatAmount,
                        Callminutes = z.CallMinutes
                    }).ToList(),

                    Totalcallminutes = result.Subscriptions.Sum(t => t.CallMinutes),
                    Totalpriceincvatamount = result.Subscriptions.Sum(t => t.PriceIncVatAmount)
                };

                return Request.CreateResponse(user);
            }
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserSubmission user)
        {
            var model = new UserService.User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email
            };

            using (var client = new UserServiceClient())
            {
                var userId = client.Create(model);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                var uri = Url.Link("UserApi", new { id = userId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        /// <summary>
        /// Add subscription to user
        /// </summary>
        /// <param name="userSubscription"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]UserSubscription userSubscription)
        {
            var model = new UserService.UserSubscription
            {
                SubscriptionId = userSubscription.Subscriptionid,
                UserId = userSubscription.Userid
            };

            using (var client = new UserServiceClient())
            {
                client.Addsubscription(model);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        /// <summary>
        /// Delate a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            using (var client = new UserServiceClient())
            {
                var user = client.GetById(id);

                if (user == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserId is not found");

                client.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}