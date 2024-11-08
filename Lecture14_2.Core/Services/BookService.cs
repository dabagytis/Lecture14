using Lecture14_2.Core.Contracts;
using Lecture14_2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_2.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookRepo;
        public BookService(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public void AddBook(Book book)
        {
            _bookRepo.AddBook(book);
        }

        public int CountBooksByGenre(string genre)
        {
            return _bookRepo.CountBooksByGenre(genre);
        }

        public void DeleteBook(int id)
        {
            _bookRepo.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepo.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepo.GetBookById(id);
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            return _bookRepo.GetBooksByGenre(genre);
        }

        public List<Book> GetBooksPublishedBetween(int startYear, int endYear)
        {
            return _bookRepo.GetBooksPublishedBetween(startYear, endYear);
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            return _bookRepo.SearchBooksByAuthor(author);
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            return _bookRepo.SearchBooksByTitle(title);
        }

        public void UpdateBook(Book book)
        {
            _bookRepo.UpdateBook(book);
        }

        public List<Book> GetLatestBooks(int topNew)
        {
            return _bookRepo.GetLatestBooks(topNew);
        }
    }
}
