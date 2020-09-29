using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    internal class PurchaseTransactionService : IPurchaseTransactionService
    {
        IBookService BookService { get; }

        public PurchaseTransactionService(IBookService bookService)
        {
            BookService = bookService;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            IList<PurchaseTransaction> result = new List<PurchaseTransaction>();
            var query = from transaction in Store.PurchaseTransactions.Data
                        where transaction.CustomerId == customerId && transaction.CreatedDate >= fromDate && transaction.CreatedDate <= toDate
                        select transaction;

            result = query.ToList();
            return result;
        }
    }
}
