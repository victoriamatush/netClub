﻿using Microsoft.AspNetCore.Mvc;
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
        public ReaderService(IReaderStatistics _readStat, UserDBContext _db)
        {
            readStat = _readStat;
            db = _db;
        }
        
        public ReaderStat GetOwnStatistics(int user_id)
        {
            return readStat.GetReaderStatistics(user_id);
        }

        public void RequestBook(int bookid, int readerid)
        {
                db.Requests.Add(new Request() { BookId = bookid, ReaderId = readerid });
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