using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Books
{
    internal class BookService : IBookService
    {
        public IList<Book> GetBooks(IList<PurchaseTransaction> transactions)
        {
            IList<Book> result = new List<Book>();
            foreach (PurchaseTransaction transaction in transactions)
            {
                var query = from book in Store.Books.Data
                            where book.Id == transaction.Id
                            select book;
                result.Add(query.First());
            }
            return result;
        }
    }
}
