using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    internal class SubscriptionService : ISubscriptionService
    {
        public IList<Subscription> GetSubscriptions(IList<int> ids)
        {
            IList<Subscription> result = new List<Subscription>();
            foreach (int id in ids)
            {
                var query = from subcription in Store.Subscriptions.Data
                            where subcription.Id == id
                            select subcription;
                result.Add(query.First());
            }
            return result;
        }

        public Subscription GetHighestPrioritySupscription(IList<Subscription> subscriptions)
        {
            SubscriptionTypes highestPriority = SubscriptionTypes.Free;
            Subscription result = new Subscription();
            foreach (Subscription subscription in subscriptions)
            {
                if (subscription.SubscriptionType >= highestPriority)
                {
                    highestPriority = subscription.SubscriptionType;
                    result = subscription;
                }
            }
            return result;
        }

        public IList<Subscription> GetCategoryAddictedSubscriptions(IList<Subscription> subscriptions)
        {
            List<Subscription> result = new List<Subscription>();
            foreach (Subscription subscription in subscriptions)
            {
                if (subscription.SubscriptionType == SubscriptionTypes.CategoryAddicted)
                {
                    result.Add(subscription);
                }
            }
            return result;
        }
    }
}
