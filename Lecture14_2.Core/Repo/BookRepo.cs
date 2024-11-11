using Dapper;
using Lecture14_2.Core.Contracts;
using Lecture14_2.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_2.Core.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly string _connectionString;
        public BookRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Books (Title, Author, PublicationYear, Genre) VALUES (@Title, @Author, @PublicationYear, @Genre)", book);
            }
        }

        public int CountBooksByGenre(string genre)
        {
            int bookCount = 0;

            List<Book> countList = GetBooksByGenre(genre);
            foreach(Book a in countList)
            {
                bookCount++;
            }
            return bookCount;
        }

        public void DeleteBook(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Books WHERE Id = @id", new { id });
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allBooks = connection.Query<Book>("SELECT * FROM Books").ToList();
            }
            return allBooks;
        }

        public Book GetBookById(int id)
        {
            Book byId = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    byId = connection.QueryFirst<Book>("SELECT * FROM Books WHERE Id = @Id", new { Id = id });
                }
                catch
                {

                }
            }
            return byId;
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            List<Book> booksByGenre = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                booksByGenre = connection.Query<Book>("SELECT * FROM Books WHERE Genre = @Genre", new { Genre = genre }).ToList();
            }
            return booksByGenre;
        }

        public List<Book> GetBooksPublishedBetween(int startYear, int endYear)
        {
            List<Book> booksBetweenYears = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                booksBetweenYears = connection.Query<Book>("SELECT * FROM Books WHERE PublicationYear >= @startYear AND PublicationYear <= @endYear", new { startYear, endYear }).ToList();
            }
            return booksBetweenYears;
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                booksByAuthor = connection.Query<Book>("SELECT * FROM Books WHERE Author LIKE '%' + @Author + '%'", new { Author = author }).ToList();
            }
            return booksByAuthor;
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            List<Book> booksByTitle = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                booksByTitle = connection.Query<Book>("SELECT * FROM Books WHERE Title LIKE '%' + @Title + '%'", new { Title = title }).ToList();
            }
            return booksByTitle;
        }

        public void UpdateBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE Books SET Title = @Title , Author = @Author , PublicationYear = @PublicationYear , Genre = @Genre WHERE Id = @Id", book);
            }
        }

        public List<Book> GetLatestBooks(int topAmount)
        {
            List<Book> topBooks = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                topBooks = connection.Query<Book>("SELECT TOP(@topAmount) * FROM Books ORDER BY PublicationYear DESC", new { topAmount }).ToList();
            }
            return topBooks;
        }
    }
}
