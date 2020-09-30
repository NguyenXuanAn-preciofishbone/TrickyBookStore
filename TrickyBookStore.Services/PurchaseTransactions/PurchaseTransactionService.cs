using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    internal class PurchaseTransactionService : IPurchaseTransactionService
    {
        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            IList<PurchaseTransaction> result = new List<PurchaseTransaction>();
            var query = from transaction in Store.PurchaseTransactions.Data
                        where transaction.CustomerId == customerId && transaction.CreatedDate >= fromDate && transaction.CreatedDate <= toDate
                        select transaction;

            result = query.ToList();
            return result;
        }
        public double GetTotalTransactionPrice(IList<Book> books, IList<Subscription> sortedSubscriptions)
        {
            double result = 0;
            foreach (Book book in books)
            {
                if (book.IsOld)
                {
                    result += CalculateOldBookPrice(book, sortedSubscriptions);
                }
                else
                {
                    result += CalculateNewBookPrice(book, sortedSubscriptions);
                }
            }
            return result;
        }

        internal double CalculateOldBookPrice(Book book, IList<Subscription> subscriptions)
        {
            bool isCalculated = false;
            double result = 0;
            foreach (Subscription subscription in subscriptions)
            {
                if (book.CategoryId == subscription.BookCategoryId)
                {
                    result = 0;
                    isCalculated = true;
                }
                if (subscription.BookCategoryId == null)
                {
                    result = book.Price - book.Price * subscription.PriceDetails["OldBookDiscount"] / 100;
                    isCalculated = true;
                }
                if (isCalculated)
                {
                    break;
                }
            }
            // list subscription luôn có tối thiểu 1 object là subscription free account (có BookcategoryId == null)
            if (!isCalculated)
            {
                throw new Exception();
            }
            return result;
        }

        internal double CalculateNewBookPrice(Book book, IList<Subscription> subscriptions)
        {
            bool isCalculated = false;
            double result = 0;
            foreach (Subscription subscription in subscriptions)
            {
                if (book.CategoryId == subscription.BookCategoryId)
                {
                    if (subscription.PriceDetails["Quota"] > 0)
                    {
                        subscription.PriceDetails["Quota"]--;
                        result = book.Price - book.Price * subscription.PriceDetails["NewBookDiscount"] / 100;
                        isCalculated = true;
                    }
                }
                if (subscription.BookCategoryId == null)
                {
                    if (subscription.PriceDetails["Quota"] > 0)
                    {
                        subscription.PriceDetails["Quota"]--;
                        result = book.Price - book.Price * subscription.PriceDetails["NewBookDiscount"] / 100;
                        isCalculated = true;
                    }
                }
                if (isCalculated)
                {
                    break;
                }
            }
            if (!isCalculated)
            {
                result = book.Price;
            }
            return result;
        }
    }

}
