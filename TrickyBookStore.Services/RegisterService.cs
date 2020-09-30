using Microsoft.Extensions.DependencyInjection;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.Payment;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services
{
    public static class RegisterService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBookService), typeof(BookService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IPaymentService), typeof(PaymentService));
            services.AddScoped(typeof(IPurchaseTransactionService), typeof(PurchaseTransactionService));
            services.AddScoped(typeof(ISubscriptionService), typeof(SubscriptionService));
            return services;
        }
    }
}
