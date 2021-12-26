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
        [Route("request/{bookId}/{readerId}")]
        public IActionResult RequestBook(int bookId, int readerId)
        {
            if (db.Books.Find(bookId) == null || db.Readers.Find(readerId) == null)
                return NotFound();
            readerService.RequestBook(bookId, readerId);
            return Ok();
        }
        [Route("return/{bookId}/")]
        public IActionResult ReturnBook(int bookId)
        {
            if (db.Requests.Where(r => r.BookId == bookId) == null)
                return NotFound("failed to find book");
            if (db.Requests.Where(s => s.BookId == bookId && s.IsApproved == true && s.DateOfReturning == null).FirstOrDefault() == null)
                return NotFound("No such request found");
            readerService.ReturnBook(bookId);
            return Ok("success");
            
        }
        
    }
}
