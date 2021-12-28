using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SoftServeProject.Services
{
  public interface IBookService
  {
        public List<Bookauthor> GetById(int id);
        public List<Book> GetInformationAboutAllBooks();
        public bool GetAvailabilityOfBook(int id);
        public Book GetBookByAuthor(string name, string surname);
        public Book GetBookByTitle(string title);
        public object GetMostPopularBook(string start, string end);
        public object GetLeastPopularBook(string start, string end);
    }
}
