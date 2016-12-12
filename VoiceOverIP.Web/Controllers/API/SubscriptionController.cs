using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VoiceOverIP.Web.SubscriptionService;

namespace VoiceOverIP.Web.Controllers.API
{
    public class SubscriptionController : ApiController
    {
        /// <summary>
        /// Get all subscriptions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<Models.Subscription>))]
        public HttpResponseMessage Get()
        {
            using (var client = new SubscriptionServiceClient())
            {
                var result = client.Get().Select(x => new Models.Subscription
                {
                    Id = x.Identifier,
                    Name = x.Name,
                    Price = x.Price,
                    Priceincvatamount = x.PriceIncVatAmount,
                    Callminutes = x.CallMinutes
                }).ToList();

                return Request.CreateResponse(result);
            }
        }

        /// <summary>
        /// Get current subscription
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Models.Subscription))]
        public HttpResponseMessage Get(int id)
        {
            using (var client = new SubscriptionServiceClient())
            {
                var subscription = client.GetById(id);

                if (subscription == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Subscription id is not found");

                var result = new Models.Subscription
                {
                    Id = subscription.Identifier,
                    Name = subscription.Name,
                    Price = subscription.Price,
                    Priceincvatamount = subscription.PriceIncVatAmount,
                    Callminutes = subscription.CallMinutes
                };

                return Request.CreateResponse(result);
            }
        }

        /// <summary>
        /// Create subscription
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Models.SubscriptionSubmission subscription)
        {
            var model = new SubscriptionService.Subscription
            {
                Name = subscription.Name,
                PriceIncVatAmount = subscription.Price,
                Price = subscription.Price,
                CallMinutes = subscription.Callminutes
            };

            using (var client = new SubscriptionServiceClient())
            {
                var subscriptionId = client.Create(model);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                var uri = Url.Link("SubscriptionApi", new { id = subscriptionId });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Update subscription data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody]Models.SubscriptionSubmission subscription)
        {
            var model = new SubscriptionService.Subscription
            {
                Name = subscription.Name,
                PriceIncVatAmount = subscription.Price,
                Price = subscription.Price,
                CallMinutes = subscription.Callminutes
            };

            using (var client = new SubscriptionServiceClient())
            {
                var result = client.GetById(id);

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Subscription id is not found");

                model.Identifier = result.Identifier;
                model.Id = result.Id;
                client.Put(model);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete subscription
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            using (var client = new SubscriptionServiceClient())
            {
                var subscription = client.GetById(id);

                if (subscription == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Subscription id is not found");

                client.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }




    }
}