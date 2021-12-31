using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SoftServeProject.Services
{
  public interface IBookService
  {
        public Book GetById(int id);
        public List<Book> GetInformationAboutAllBooks();
        public bool GetAvailabilityOfBook(int id);
        public List<Book> GetBooksByAuthor(string name, string surname);
        public List<Book> GetBooksByTitle(string title);
        public Book GetMostPopularBook(DateTime start, DateTime end);
        public Book GetLeastPopularBook(DateTime start, DateTime end);
    }
}
