using Lecture14_2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_2.Core.Contracts
{
    public interface IBookService
    {
        void AddBook(Book book);
        Book GetBookById(int id);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> GetAllBooks();

        List<Book> SearchBooksByTitle(string title);
        List<Book> SearchBooksByAuthor(string author);
        List<Book> GetBooksByGenre(string genre);
        int CountBooksByGenre(string genre);
        List<Book> GetBooksPublishedBetween(int startYear, int endYear);
        List<Book> GetLatestBooks(int topNew);
    }
}
