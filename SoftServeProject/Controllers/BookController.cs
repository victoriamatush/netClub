using Microsoft.AspNetCore.Mvc;
using SoftServeProject.Services;
using System;
using System.Collections.Generic;

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
            return View(book);
        }

        [HttpGet]
        [Route("bytitle/{title}/")]
        public IActionResult GetByTitle(string title)
        {
            List<Book> book = books.GetBooksByTitle(title);
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
                return NotFound("Such book not found");
            bool isAvailable = books.GetAvailabilityOfBook(id);
            return Ok(isAvailable);
        }

        [HttpGet]
        [Route("byauthor/{id}/")]
        public IActionResult GetByAuthor(string name, string surname)
        {
            List<Book> book = books.GetBooksByAuthor(name, surname);
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
            return View(book);
        }

        public IActionResult GetLeastPopularBook(DateTime start, DateTime end)
        {
            var res = books.GetLeastPopularBook(start, end);
            return Ok(res);
        }

        public IActionResult GetMostPopularBook(DateTime start, DateTime end)
        {
            var res = books.GetMostPopularBook(start, end);
            return Ok(res);
        }
    }
}
