using Microsoft.AspNetCore.Mvc;
using SoftServeProject;
using SoftServeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService books;
        private readonly UserDBContext db;

        public BookController(IBookService _books, UserDBContext userDBContext)
        {
            books = _books;
            db = userDBContext;
        }

        [HttpGet]
        [Route("books/{id}/")]
        public IActionResult GetById(int id)
        {
            Book book = books.GetById(id);
            if (book == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Book is not found"
                });
            }
            return Ok(book);
        }

        [HttpGet]
        [Route("bytitle/{title}/")]
        public IActionResult GetByTitle(string title)
        {
            Book book = books.GetBookByTitle(title);
            if (book == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Book is not found"
                });
            }
            return Ok(book);
        }

        [HttpGet]
        [Route("available/{id}/")]
        public IActionResult GetAvailability(int id)
        {
            if (db.Books.Find(id) == null)
                return NotFound();
            string book = books.GetAvailabilityOfBook(id);
            return Ok(book);
        }

        [HttpGet]
        [Route("byauthor/{id}/")]
        public IActionResult GetByAuthor(string name, string surname)
        {
            Book book = books.GetBookByAuthor(name, surname);
            if (book == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Book is not found"
                });
            }
            return Ok(book);
        }

        [HttpGet]
        [Route("books/")]
        public IActionResult GetAllBooks()
        {
            List<Book> book = books.GetInformationAboutAllBooks();
            if (book == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Books are not found"
                });
            }
            return Ok(book);
        }

        public IActionResult GetLeastPopularBook(string start, string end)
        {
            var res = books.GetLeastPopularBook(start, end);
            return Ok(res);
        }

        [HttpGet]
        [Route("popular/")]
        public IActionResult GetMostPopularBook(string start, string end)
        {
            var res = books.GetMostPopularBook(start, end);
            return Ok(res);
        }
    }
}
