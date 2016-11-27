using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI;
using AutoMapper;
using VoiceoverIP.Services.Model;
using VoiceOverIp.DataAccess;

namespace VoiceoverIP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService()
        {
            _dataContext = new DataContext();
        }

        public List<User> GetList()
        {
            var users = _dataContext.Users;

            var result = users.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Subscriptions = x.UserSubscription.Select(z => new Subscription
                {
                    Id = z.Subscription.Id,
                    Identifier = z.Subscription.Identifier,
                    Name = z.Subscription.Name,
                    Price = z.Subscription.Price,
                    PriceIncVatAmount = z.Subscription.PriceIncVatAmount,
                    CallMinutes = z.Subscription.CallMinutes
                }).ToList()
            }).ToList();

            return result;

        }

        public User GetById(int userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return null;

            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Subscriptions = user.UserSubscription.Select(z => new Subscription
                {
                    Id = z.Subscription.Id,
                    Identifier = z.Subscription.Identifier,
                    Name = z.Subscription.Name,
                    Price = z.Subscription.Price,
                    PriceIncVatAmount = z.Subscription.PriceIncVatAmount,
                    CallMinutes = z.Subscription.CallMinutes
                }).ToList()
            };

        }

        public int Create(User user)
        {
            var model = new DataAccess.Entities.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            _dataContext.Users.Add(model);
            _dataContext.SaveChanges();
            return model.Id;
        }

        public void Delete(int userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            _dataContext.Users.Remove(user);
            _dataContext.SaveChanges();
        }

        public void Addsubscription(UserSubscription subscription)
        {
            var model = new DataAccess.Entities.UserSubscription
            {
                SubscriptionId = subscription.SubscriptionId,
                UserId = subscription.UserId
            };
            _dataContext.UserSubscriptions.Add(model);
            _dataContext.SaveChanges();
        }
    }
}
