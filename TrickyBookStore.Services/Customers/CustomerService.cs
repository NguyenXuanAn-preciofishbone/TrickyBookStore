using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        ISubscriptionService SubscriptionService { get; }

        public CustomerService(ISubscriptionService subscriptionService)
        {
            SubscriptionService = subscriptionService;
        }

        public Customer GetCustomerById(long id)
        {
            Customer result = new Customer();
            var query = from customer in Store.Customers.Data
                        where customer.Id == id
                        select customer;
            result = query.First();
            return result;
        }

        public IList<Subscription> GetSubscriptions(Customer customer)
        {
            return SubscriptionService.GetSubscriptions(customer.SubscriptionIds);
        }
    }
}
