﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    
    public class ReaderStatisticService : IReaderStatistics
    {
        UserDBContext db;
        public ReaderStatisticService(UserDBContext _db)
        {
            db = _db;
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

        public List<Reader> GetInfoAboutNotReturnedBooks(int _readerId)
        {
            List<Reader> users = db.Requests
                .Where(s => s.DateOfReturning == null && s.IsApproved == true && s.ReaderId == _readerId)
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
