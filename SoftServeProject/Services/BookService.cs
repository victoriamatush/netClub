using SoftServeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class BookService: IBookService
    {
        private readonly UserDBContext context = new();

        public BookService(UserDBContext _context)
        {
            context = _context;
        }

        public string GetAvailabilityOfBook(int id)
        {
            Request available = context.Requests.FirstOrDefault(r => r.BookId == id);
            if (available.DateOfRequest == null)
                return "available";
            return "not available";
        }

        public Book GetBookByAuthor(string name, string surname)
        {
            var response = from ba in context.Bookauthors
                           join auth in context.Authors on ba.Authorid equals auth.Authorid
                           join book in context.Books on ba.Bookid equals book.Bookid
                           where auth.Name == name && auth.Surname == surname
                           select new Book{ Bookid = book.Bookid, Title = book.Title };
            return (Book)response;
        }

        public Book GetBookByTitle(string title)
        {
            Book b = context.Books.FirstOrDefault(b => b.Title == title);
            return b;
        }

        public Book GetById(int id)
        {
            Book b = context.Books.FirstOrDefault(x => x.Bookid == id);
            return b;
        }

        public List<Book> GetInformationAboutAllBooks()
        {
            var books = context.Books;
            return books.ToList();
        }

        public string GetLeastPopularBook(string start, string end)
        {
            throw new NotImplementedException();
        }

        public string GetMostPopularBook(string start, string end)
        {
            //var response = from req in context.Requests
            //                  join book in context.Books on req.BookId equals book.Bookid
            //                  group req by book.Title into g
            //                  select new
            //                  {
            //                   Amount = g.Count(
            //                  t => t.DateOfRequest >= Convert.ToDateTime(start)
            //                  && t.DateOfReturning <= Convert.ToDateTime(end))
            //                  };
            //return response;

            throw new NotImplementedException();
        }
    }
}
