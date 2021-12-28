using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    
    public class ReaderStatisticService : IReaderStatistics
    {
        UserDBContext db;
        IBookService bookService;
        public ReaderStatisticService(UserDBContext _db, IBookService _bookService)
        {
            db = _db;
            bookService = _bookService;
        }
        public AllReadersStat GetAllReadersStatistics(DateTime startingDate, DateTime endingDate)
        {
            AllReadersStat stat = new AllReadersStat();
            stat.avgAgeOfClient = db.Readers
                .Select(s => s.Age)
                .Average();
            stat.avgTimeOfWorking = db.Readers
                .Select(s => (DateTime.Now - s.RegisterDate).Days)
                .Count();
            stat.avgNumOfRequest = db.Requests
                .Where(s => s.DateOfRequest >= startingDate || s.DateOfRequest <= endingDate)
                .Count();
            return stat;

        }

        public List<Book> GetInfoAboutNotReturnedBooks(int _readerId)
        {
            //List<int> users = db.Requests
            //    .Where(s => s.DateOfReturning == null && s.IsApproved == true && s.ReaderId == _readerId)
            //    .Select(s => s.ReaderId)
            //    .ToList();
            List<Book> books = new List<Book>();
            //foreach (int id in users)
            //    books.Add(bookService.GetById(id).);
            return books;
        }

        public ReaderStat GetReaderStatistics(int id)
        {
            
            List<Book> books = db.Requests
                .Where(s => s.ReaderId == id || s.IsApproved == true)
                .Select(s => s.Book)
                .ToList();
            double howLongSub = db.Readers
                .Where(s => s.Id == id)
                .Select(s => (DateTime.Now - s.RegisterDate).Days)
                .First();
            double howLongRead = db.Requests
                .Where(s => s.ReaderId == id && s.DateOfReturning != null)
                .Select(s => ((DateTime)s.DateOfReturning - s.DateOfRequest).Days)
                .ToList()
                .Average();
            return  new ReaderStat(books, howLongSub, howLongRead);
        }
    }
}
