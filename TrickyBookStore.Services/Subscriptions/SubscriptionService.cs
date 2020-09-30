using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    internal class SubscriptionService : ISubscriptionService
    {
        public IList<Subscription> GetSortedSubscriptions(IList<int> ids)
        {
            IList<Subscription> result = new List<Subscription>();
            foreach (int id in ids)
            {
                var query = from subcription in Store.Subscriptions.Data
                            where subcription.Id == id
                            select subcription;
                result.Add(query.First());
            }
            IList<Subscription> sortedResult = result.OrderByDescending(c => c.Priority).ToList();   // mảng subscription có priority giảm dần
            return sortedResult;
        }
        public double GetTotalSubscriptionPrice(IList<Subscription> subscriptions)
        {
            double result = 0;
            foreach (Subscription subscription in subscriptions)
            {
                result += subscription.PriceDetails["FixPrice"];
            }
            return result;

        }
    }
}
