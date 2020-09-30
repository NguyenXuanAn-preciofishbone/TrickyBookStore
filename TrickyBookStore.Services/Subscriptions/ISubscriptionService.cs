using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        IList<Subscription> GetSortedSubscriptions(IList<int> subscriptionIds);
        double GetTotalSubscriptionPrice(IList<Subscription> subscriptions);
    }
}
