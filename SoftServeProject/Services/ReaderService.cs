using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class ReaderService : IReaderService
    {
        UserDBContext db;
        IReaderStatistics readStat;
        IBookService bookService;
        public ReaderService(IReaderStatistics _readStat, UserDBContext _db, IBookService _bookService)
        {
            readStat = _readStat;
            db = _db;
            bookService = _bookService;
        }
        public Reader GetReaderById(int id)
        {
            Reader auth = db.Readers.Where(s => s.Id == id).Include(s => s.Requests).FirstOrDefault();
            return auth;
        }

        public List<Reader> GetReaderByName(string name)
        {
            List<Reader> auth = db.Readers.Where(s => s.Name == name).Include(s => s.Requests).ToList();
            return auth;
        }

        public ReaderStat GetOwnStatistics(int user_id)
        {
            return readStat.GetReaderStatistics(user_id);
        }

        public void RequestBook(int bookid, int readerid)
        {
                db.Requests
                .Add(new Request() { 
                    BookId = bookid, 
                    ReaderId = readerid,
                    Book = bookService.GetById(bookid),
                    Reader =  GetReaderById(readerid)
                });
                db.SaveChanges();
        }
        public void ReturnBook(int BookId)
        {
            var req = db.Requests.Where(req => req.BookId == BookId && req.IsApproved == true && req.DateOfReturning == null).FirstOrDefault();
            req.DateOfReturning = DateTime.Now;
            db.SaveChanges();
        }
    }
}
