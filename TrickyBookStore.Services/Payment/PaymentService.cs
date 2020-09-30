using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Payment
{
    internal class PaymentService : IPaymentService
    {
        ICustomerService CustomerService { get; }
        IPurchaseTransactionService PurchaseTransactionService { get; }
        ISubscriptionService SubscriptionService { get; }
        IBookService BookService { get; }

        public PaymentService(ICustomerService customerService,
            IPurchaseTransactionService purchaseTransactionService,
            ISubscriptionService subscriptionService,
            IBookService bookService)
        {
            CustomerService = customerService;
            PurchaseTransactionService = purchaseTransactionService;
            SubscriptionService = subscriptionService;
            BookService = bookService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            Customer customer = CustomerService.GetCustomerById(customerId);
            IList<Subscription> subscriptions = SubscriptionService.GetSortedSubscriptions(customer.SubscriptionIds);

            if (subscriptions.Count == 0)
            {
                subscriptions.Add(new Subscription
                {
                    Id = 1,
                    SubscriptionType = SubscriptionTypes.Free,
                    Priority = 1,
                    PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 0 },
                    { "OldBookDiscount", 10 },
                    { "NewBookDiscount", 0 },
                    { "NewBookDiscountAmmount", 0 }
                }
                });
            }

            IList<PurchaseTransaction> purchaseTransactions = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);

            IList<Book> books = BookService.GetBooks(purchaseTransactions);

            double totalSubscriptionPrice = SubscriptionService.GetTotalSubscriptionPrice(subscriptions);
            double totalTransactionPrice = PurchaseTransactionService.GetTotalTransactionPrice(books, subscriptions);
            return totalSubscriptionPrice + totalTransactionPrice;
        }
        
    }
}
