using Microsoft.EntityFrameworkCore;
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

        public List<Book> GetBooksByAuthor(string name, string surname)
        {
            List<Book> books = context.Books
                .Include(s => s.Authors)
                .Where(s => s.Authors.Contains(new Author() { Name = name, Surname = surname }))
                .ToList();                
            return books;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> books = context.Books
                .Where(s => s.Title == title)
                .Include(s => s.Authors)
                .ToList();
            return books;
        }

        public Book GetById(int id)
        {
             Book b = context.Books.Where(s => s.Bookid == id).Include(s => s.Authors).FirstOrDefault();
            return b;
        }

        public List<Book> GetInformationAboutAllBooks()
        {
            var books = context.Books
                .Include(s => s.Authors)
                .ToList();
            return books.ToList();
        }

        public Book GetLeastPopularBook(DateTime start, DateTime end)
        {
            int id = GetPopularityOfEachBookInDescending(start, end)
                .First()
                .Key;
            Book book = GetById(id);
            return book;
        }

        public Book GetMostPopularBook(DateTime start, DateTime end)
        {
            int id = GetPopularityOfEachBookInDescending(start, end).
                Reverse()
                .FirstOrDefault().Key;
            Book book = GetById(id);
            return book;
        }
        private Dictionary<int, int> GetPopularityOfEachBookInDescending(DateTime start, DateTime end)
        {
            var groups = context.Requests
                .Where(s => s.DateOfRequest > start)
                .Include(s => s.Book)
                .GroupBy(s => s.BookId)
                .Select(group => new { id = group.Key, count = group.Count() })
                .ToDictionary(s => s.id, s => s.count);
            return groups;
                
        }
    }
}
