using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    
    public class ReaderStatisticService : IReaderStatistics
    {
        UserDBContext db = new UserDBContext();
        public AllReadersStat GetAllReadersStatistics(DateTime startingDate, DateTime endingDate)
        {
            AllReadersStat stat = new AllReadersStat();
            stat.avgAgeOfClient = db.Readers
                .Select(s => s.Age)
                .Average();
            stat.avgTimeOfWorking = db.Readers
                .Select(s => Convert.ToInt32(DateTime.Now - s.RegisterDate))
                .Average();
            stat.avgNumOfRequest = db.Requests
                .Where(s => s.DateOfRequest >= startingDate || s.DateOfRequest <= endingDate)
                .Count();
            return stat;

        }

        public List<Reader> GetInfoAboutNotReturnedBooks()
        {
            List<Reader> users = db.Requests
                .Where(s => s.DateOfReturning == null && s.IsApproved == true)
                .Select(s => s.Reader).ToList();
            return users;
        }

        public ReaderStat GetReaderStatistics(int id)
        {
            
            List<Book> books = db.Requests
                .Where(s => s.ReaderId == id || s.IsApproved == true)
                .Select(s => s.Book)
                .ToList();
            double howLongSub = db.Readers
                .Where(s => s.Id == id)
                .Select(s => Convert.ToInt32(DateTime.Now - s.RegisterDate))
                .First();
            double howLongRead = db.Requests
                .Where(s => s.ReaderId == id)
                .Select(s => Convert.ToInt32(s.DateOfReturning - s.DateOfRequest))
                .Average();
            ReaderStat stat = new ReaderStat(books, howLongSub, howLongRead);
            return stat;
        }
    }
}
