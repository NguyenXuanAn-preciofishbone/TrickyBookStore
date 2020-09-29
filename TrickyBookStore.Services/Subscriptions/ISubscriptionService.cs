using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        IList<Subscription> GetSubscriptions(IList<int> subscriptionIds);
        Subscription GetHighestPrioritySupscription(IList<Subscription> subscriptions);
        IList<Subscription> GetCategoryAddictedSubscriptions(IList<Subscription> subscriptions);
    }
}
