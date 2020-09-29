using System.Collections;
using System.Collections.Generic;
using TrickyBookStore.Models;

// KeepIt
namespace TrickyBookStore.Services.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerById(long id);
        IList<Subscription> GetSubscriptions(Customer customer);
    }
}
