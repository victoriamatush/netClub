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
            var items = context.Books.Where(item => item.Title == title);
            return items.ToList();
        }

        public List<Request> GetRequests()
        {
            var requests = context.Requests.ToList();
            return requests;
        }

        public bool IsManager(int id)
        {
            var reader = context.Readers.First(u => u.Id == id);
            return reader.IsManager;
        }

        public void RegisterBookCopy(string title, string name, string surname)
        {
            //Error-----------------------------------------------------------------------------------
            context.Books.Add(new Book { Title = title} );
            context.Authors.Add(new Author { Name = name, Surname = surname });
            context.SaveChanges();

        }

        public void UpdateBookInformation(int bookid, string title, int authid, string name, string surname)
        {
            context.Books.Where(b => b.Bookid == bookid).ToList().ForEach(b => { b.Title = title; });

            context.Authors.Where(a => a.Authorid == authid).
                ToList().
                ForEach(a =>
                {
                    a.Name = name;
                    a.Surname = surname;
                });
            context.SaveChanges();
        }
    }
}
