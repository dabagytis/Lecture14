using Lecture14_2.Core.Contracts;
using Lecture14_2.Core.Repo;
using Lecture14_2.Core.Models;
using Lecture14_2.Core.Services;
using System;

namespace Lecture14_2;

public class Program
{
    public static void Main(string[] args)
    {
        IBookRepo bookRepo = new BookRepo("Server=localhost;Database=Lecture14;Trusted_Connection=True;TrustServerCertificate=true;");
        IBookService bookService = new BookService(bookRepo);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new book");
            Console.WriteLine("2. Update book information");
            Console.WriteLine("3. Show all books");
            Console.WriteLine("4. Filtered book search");
            Console.WriteLine("5. Count books by genre");
            Console.WriteLine("6. Delete book");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter book title:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter book author:");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter book publication year:");
                    int publicationYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter book genre:");
                    string genre = Console.ReadLine();
                    Console.WriteLine();

                    Book newBook = new Book
                    {
                        Title = title,
                        Author = author,
                        PublicationYear = publicationYear,
                        Genre = genre
                    };
                    bookService.AddBook(newBook);
                    continue;

                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter ID of the book you wish to update:");
                        int updateId = int.Parse(Console.ReadLine());
                        Book up = bookService.GetBookById(updateId);
                        if (up == null)
                        {
                            Console.WriteLine("Book not found, try again");
                            Console.WriteLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Enter book title:");
                            string uTitle = Console.ReadLine();
                            Console.WriteLine("Enter book author:");
                            string uAuthor = Console.ReadLine();
                            Console.WriteLine("Enter book publication year:");
                            int uPublicationYear = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter book genre:");
                            string uGenre = Console.ReadLine();
                            Console.WriteLine();

                            up.Title = uTitle;
                            up.Author = uAuthor;
                            up.PublicationYear = uPublicationYear;
                            up.Genre = uGenre;

                            bookRepo.UpdateBook(up);
                            Console.WriteLine("Book added");
                            Console.WriteLine();
                            break;
                        }
                    }
                    continue;

                case 3:
                    foreach(Book a in bookService.GetAllBooks())
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine();
                    continue;

                case 4:
                    Console.WriteLine("1. Search books by title");
                    Console.WriteLine("2. Search books by author");
                    Console.WriteLine("3. Search books by genre");
                    Console.WriteLine("4. Filter books by year range");
                    Console.WriteLine("5. List out books by recency");
                    Console.WriteLine();
                    int choice2 = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("Enter book title:");
                            string searchTitle = Console.ReadLine();
                            Console.WriteLine();

                            foreach(Book a in bookRepo.SearchBooksByTitle(searchTitle))
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine();
                            continue;

                        case 2:
                            Console.WriteLine("Enter book author:");
                            string searchAuthor = Console.ReadLine();
                            Console.WriteLine();

                            foreach (Book a in bookRepo.SearchBooksByAuthor(searchAuthor))
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine();
                            continue;

                        case 3:
                            Console.WriteLine("Enter book genre:");
                            string searchGenre = Console.ReadLine();
                            Console.WriteLine();

                            foreach (Book a in bookRepo.GetBooksByGenre(searchGenre))
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine();
                            continue;

                        case 4:
                            Console.WriteLine("Enter start year:");
                            int startYear = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("Enter end year:");
                            int endYear = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            foreach (Book a in bookRepo.GetBooksPublishedBetween(startYear, endYear))
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine();
                            continue;

                        case 5:
                            Console.WriteLine("How many of most recent books would you like to see?");
                            int topAmount = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            foreach (Book a in bookRepo.GetLatestBooks(topAmount))
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine();
                            continue;
                    }
                    continue;

                case 5:
                    Console.WriteLine("Enter book genre:");
                    string genreForCount = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine($"There are {bookRepo.CountBooksByGenre(genreForCount)} books listed in the genre of {genreForCount}");
                    Console.WriteLine();
                    continue;

                case 6:
                    while (true)
                    {
                        Console.WriteLine("Enter ID of the book you wish to delete:");
                        int deleteId = int.Parse(Console.ReadLine());
                        Book deletion = bookService.GetBookById(deleteId);
                        Console.WriteLine();
                        if (deletion == null)
                        {
                            Console.WriteLine("Book not found, try again");
                            Console.WriteLine();
                            continue;
                        }
                        else
                        {
                            bookRepo.DeleteBook(deleteId);
                            Console.WriteLine("Book deleted");
                            Console.WriteLine();
                            break;
                        };
                    }
                    continue;

                case 7:
                    return;

            }
        }
    }
}