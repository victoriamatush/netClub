using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserDBContext context = new();

        public ManagerService(UserDBContext _context)
        {
            context = _context;
        }
        public void ApproveRequest(int id)
        {
            var request = context.Requests.First(u => u.BookId == id);
            request.IsApproved = true;
        }

        public void DeleteAllBookCopies(string title)
        {
            var items = context.Books.Where(item => item.Title == title);
            context.Books.RemoveRange(items);
        }

        public void DeleteOneBookCopy(int id)
        {
            var item = context.Books.Where(item => item.Bookid == id).Single();
            context.Books.Remove(item);
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var items = context.Books.Where(item => item.Title == title);
            return items.ToList();
        }

        public bool IsManager(int id)
        {
            var reader = context.Readers.First(u => u.Id == id);
            return reader.IsManager;
        }

        public void RegisterBookCopy(string title, string name, string surname)
        {

        }

        public void UpdateBookInformation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
