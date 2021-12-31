using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserDBContext context;

        public ManagerService(UserDBContext _context)
        {
            context = _context;
        }
        public void ApproveRequest(int id)
        {
            var request = context.Requests.FirstOrDefault(u => u.Id == id);
            request.IsApproved = true;
            context.SaveChanges();
        }

        public void DeleteAllBookCopies(string title)
        {
            var items = context.Books.Where(item => item.Title == title);
            context.Books.RemoveRange(items);
            context.SaveChanges();
        }

        public void DeleteOneBookCopy(int id)
        {
            var item = context.Books.Where(item => item.Bookid == id).Single();
            context.Books.Remove(item);
            context.SaveChanges();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var items = context.Books
                .Where(item => item.Title == title)
                .Include(s => s.Authors)
                .ToList();
            return items;
        }

        public List<Request> GetRequests()
        {
            var requests = context.Requests
                .Include(s => s.Book)
                .Include(s => s.Reader)
                .ToList();
            return requests;
        }

        public bool IsManager(int id)
        {
            var reader = context.Readers.First(u => u.Id == id);
            return reader.IsManager;
        }

        public void RegisterBookCopy(string title, string name, string surname)
        {
            Author auth;
            Book book;
            if (context.Authors.Where(s => s.Name == name && s.Surname == surname).Count() != 0)
                auth = context.Authors
                    .Where(s => s.Name == name && s.Surname == surname)
                    .FirstOrDefault();
            else
                auth = new Author() { Name = name, Surname = surname };
            book = new Book { Title = title, Authors = new List<Author> { auth } };
            context.Books.Add(book);
            context.Authors.Add(auth);
            context.SaveChanges();

        }

        public void UpdateBookInformation(int bookid, string title, int authid)
        {
            context.Books.Where(b => b.Bookid == bookid).ToList().ForEach(b => { b.Title = title; });
            context.SaveChanges();
        }


        public void UpdateAuthorInformation(int authId, string name, string surname)
        {
             context.Authors.Where(a => a.Authorid == authId).
                 ToList().
                 ForEach(a =>
                 {
                     a.Name = name;
                     a.Surname = surname;
                 });
        }

        
    }
}
