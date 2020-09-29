using System.Collections.Generic;
using TrickyBookStore.Models;

// KeepIt
namespace TrickyBookStore.Services.Books
{
    public interface IBookService
    {
        Book GetBook(long id);
        IList<Book> GetBooks(IList<PurchaseTransaction> transactions);
    }
}
