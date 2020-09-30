using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        public Customer GetCustomerById(long id)
        {
            Customer result = new Customer();
            var query = from customer in Store.Customers.Data
                        where customer.Id == id
                        select customer;
            result = query.First();
            return result;
        }
    }
}
