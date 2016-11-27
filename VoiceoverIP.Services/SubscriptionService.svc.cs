using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VoiceoverIP.Services.Model;
using VoiceOverIp.DataAccess;

namespace VoiceoverIP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubscriptionServiceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubscriptionServiceService.svc or SubscriptionServiceService.svc.cs at the Solution Explorer and start debugging.
    public class SubscriptionService : ISubscriptionService
    {
        private readonly DataContext _dataContext;

        public SubscriptionService()
        {
            _dataContext = new DataContext();
        }

        public int Create(Subscription subscription)
        {
            var model = new DataAccess.Entities.Subscription
            {
                Identifier = CreateIdentifier(),
                Name = subscription.Name,
                Price = subscription.Price,
                PriceIncVatAmount = subscription.PriceIncVatAmount,
                CallMinutes = subscription.CallMinutes
            };

            _dataContext.Subscriptions.Add(model);
            _dataContext.SaveChanges();
            return model.Id;
        }

        private string CreateIdentifier()
        {
            return Guid.NewGuid().ToString();
        }

        public void Put(Subscription subscription)
        {
            var model = new DataAccess.Entities.Subscription
            {
                Id = subscription.Id,
                Identifier = subscription.Identifier,
                Name = subscription.Name,
                Price = subscription.Price,
                PriceIncVatAmount = subscription.PriceIncVatAmount,
                CallMinutes = subscription.CallMinutes
            };
           
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscription = _dataContext.Subscriptions.FirstOrDefault(x => x.Id == id);
            _dataContext.Subscriptions.Remove(subscription);
            _dataContext.SaveChanges();
        }

        public List<Subscription> Get()
        {
            var result = _dataContext.Subscriptions;
            var list = result.Select(x => new Subscription
            {
                Id = x.Id,
                Identifier = x.Identifier,
                Name = x.Name,
                Price = x.Price,
                PriceIncVatAmount = x.PriceIncVatAmount,
                CallMinutes = x.CallMinutes

            }).ToList();

            return list;
        }

        public Subscription GetById(int id)
        {
            var subscription = _dataContext.Subscriptions.FirstOrDefault(x => x.Id == id);

            if (subscription == null)
                return null;

            return new Subscription
            {
                Id = subscription.Id,
                Identifier = subscription.Identifier,
                Name = subscription.Name,
                Price = subscription.Price,
                PriceIncVatAmount = subscription.PriceIncVatAmount,
                CallMinutes = subscription.CallMinutes
            };
        }
    }
}
