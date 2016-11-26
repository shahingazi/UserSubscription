using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VoiceOverIP.Web.UserService;
using Subscription = VoiceoverIP.Models.Subscription;
using User = VoiceoverIP.Models.User;


namespace VoiceOverIP.Web.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<User>))]
        public HttpResponseMessage Get()
        {
            using (var client = new UserServiceClient())
            {
                var result = client.GetList().Select(x => new VoiceoverIP.Models.User
                {
                    Id = x.Id,
                    Firstname = x.FirstName,
                    Lastname = x.LastName,
                    Email = x.Email,
                    Subscriptions = x.Subscriptions.Select(z => new Subscription
                    {
                        Id = z.Identifier,
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

        [HttpGet]
        [ResponseType(typeof(VoiceoverIP.Models.User))]
        public HttpResponseMessage Get(int id)
        {

            using (var client = new UserServiceClient())
            {
                var result = client.GetById(id);

                if (result == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "UserId is not found");

                var user = new VoiceoverIP.Models.User
                {
                    Id = result.Id,
                    Firstname = result.FirstName,
                    Lastname = result.LastName,
                    Email = result.Email,
                    Subscriptions = result.Subscriptions.Select(z => new Subscription
                    {
                        Id = z.Identifier,
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

        [HttpPost]
        public HttpResponseMessage Post([FromBody]VoiceoverIP.Models.UserSubmission user)
        {
            var model = new UserService.User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email
            };

            using (var client = new UserServiceClient())
            {
                client.Create(model);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put([FromBody]VoiceoverIP.Models.UserSubscription userSubscription)
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

            return Request.CreateResponse(HttpStatusCode.OK);
        }



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