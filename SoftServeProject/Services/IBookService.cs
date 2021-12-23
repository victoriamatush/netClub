using Microsoft.AspNetCore.Mvc;
using SoftServeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public interface IBookService
    {
        public Book GetById(int id);
        public List<Book> GetInformationAboutAllBooks();
        public string GetAvailabilityOfBook(int id);
        public Book GetBookByAuthor(string name, string surname);
        public Book GetBookByTitle(string title);
        public string GetMostPopularBook(string start, string end);
        public string GetLeastPopularBook(string start, string end);
    }
}
