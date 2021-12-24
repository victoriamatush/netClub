using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftServeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService readerService;
        private readonly UserDBContext db;
        public ReaderController(IReaderService _readerService, UserDBContext _db)
        {
            readerService = _readerService;
            db = _db;
        }
        public IActionResult GetOwnStatistics(int readerId)
        {
            if (db.Readers.Find(readerId) == null)
                return NotFound();
            var stat = readerService.GetOwnStatistics(readerId);
            return View(stat);
        }
        public IActionResult RequestBook(int bookId, int readerId)
        {
            if (db.Books.Find(bookId) == null || db.Readers.Find(readerId) == null)
                return NotFound();
            readerService.RequestBook(bookId, readerId);
            return Ok();
        }
        public IActionResult ReturnBook(int bookId)
        {
            if (db.Books.Find(bookId) == null)
                return NotFound();
            return Ok();
            
        }
        
    }
}
