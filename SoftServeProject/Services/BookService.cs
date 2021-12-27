using SoftServeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class BookService: IBookService
    {
        private readonly UserDBContext context;

        public BookService(UserDBContext _context)
        {
            context = _context;
        }

        public bool GetAvailabilityOfBook(int id)
        {
            List<Request> requests = context.Requests.Where(r => r.BookId == id).ToList();
            foreach (var r in requests)
                if (r.DateOfReturning == null && r.IsApproved == true)
                    return false;
            return true;
        }

        public Book GetBookByAuthor(string name, string surname)
        {
            var response = from ba in context.Bookauthors
                           join auth in context.Authors on ba.Authorid equals auth.Authorid
                           join book in context.Books on ba.Bookid equals book.Bookid
                           where auth.Name == name && auth.Surname == surname
                           select new Book
                           {
                               Bookid = book.Bookid,
                               Title = book.Title,
                               //Authors = new List<Author> { new Author { Name = auth.Name, Surname = auth.Surname } }
                           };
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

        public System.Object GetLeastPopularBook(string start, string end)
        {
            var response = (from req in context.Requests
                            join book in context.Books on req.BookId equals book.Bookid
                            where req.DateOfRequest >= Convert.ToDateTime(start)
                            && req.DateOfReturning <= Convert.ToDateTime(end)
                            group req by book.Title into g
                            select new
                            {
                                Title = g.Key,
                                Amount = g.Count()
                            }).Reverse().FirstOrDefault();
            return response;
        }

        public System.Object GetMostPopularBook(string start, string end)
        {
            var response = (from req in context.Requests
                            join book in context.Books on req.BookId equals book.Bookid
                            where req.DateOfRequest >= Convert.ToDateTime(start)
                            && req.DateOfReturning <= Convert.ToDateTime(end)
                            group req by book.Title into g
                            select new
                            {
                                Title = g.Key,
                                Amount = g.Count()
                            }).FirstOrDefault();
            return response;
        }
    }
}
