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
            IList<Subscription> subscriptions = CustomerService.GetSubscriptions(customer);

            Subscription highestPrioritySubscription = SubscriptionService.GetHighestPrioritySupscription(subscriptions);
            IList<Subscription> categoryAddictedSubscriptions = SubscriptionService.GetCategoryAddictedSubscriptions(subscriptions);

            IList<PurchaseTransaction> purchaseTransactions = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);

            IList<Book> books = BookService.GetBooks(purchaseTransactions);

            double totalSubscriptionPrice = GetTotalSubscriptionPrice(highestPrioritySubscription, categoryAddictedSubscriptions);
            double totalTransactionPrice = GetTotalTransactionPrice(books, highestPrioritySubscription, categoryAddictedSubscriptions);
            return totalSubscriptionPrice + totalTransactionPrice;
        }

        internal double GetTotalSubscriptionPrice(Subscription highestPrioritySubscription, IList<Subscription> categoryAddictedSubscriptions)
        {
            double result = 0;
            result += highestPrioritySubscription.PriceDetails["FixPrice"];
            foreach (Subscription categoryAddicted in categoryAddictedSubscriptions)
            {
                result += categoryAddicted.PriceDetails["FixPrice"];
            }
            return result;
        }

        internal double GetTotalTransactionPrice(IList<Book> books, Subscription highestPrioritySubscription, IList<Subscription> categoryAddictedSubscriptions)
        {
            double result = 0;

            for (int i = 0; i < books.Count; i++)
            {
                bool isPriceCalculated = false;
                for (int j = 0; j < categoryAddictedSubscriptions.Count; j++)
                {
                    if (books[i].CategoryId == categoryAddictedSubscriptions[j].BookCategoryId)
                    {
                        result += CalculatePriceWithSubscription(books[i], categoryAddictedSubscriptions[j]);
                        isPriceCalculated = true;
                        break;
                    }
                }
                if (!isPriceCalculated)
                {
                    result += CalculatePriceWithSubscription(books[i], highestPrioritySubscription);
                }
            }

            return result;
        }

        internal double CalculatePriceWithSubscription(Book book, Subscription subscription)
        {
            if (book.IsOld)
            {
                return book.Price - book.Price * subscription.PriceDetails["OldBookDiscount"] / 100;
            }
            else
            {
                return book.Price - book.Price * subscription.PriceDetails["NewBookDiscount"] / 100;
            }
        }

    }
}
