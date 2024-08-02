using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Domain.Users
{
    public class User : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public SubscriptionItem SubscriptionItem { get; private set; }
        public void SubscribeTo(string type)
        {
            //SubscriptionItem = new SubscriptionItem(type, Id);
            SubscriptionItem.ChangeSubscription(type);
        }
        public void SubscribeToNormal()
        {
            SubscriptionItem = new SubscriptionItem("Normal", Id);
        }
        public static User CreateUser(Guid id, string name)
        {
            return new User
            {
                Id = id,
                Name = name,
            };
        }
    }
}
