using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftServeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Controllers
{
    public class ReaderStatisticController : Controller
    {
        private readonly UserDBContext db;
        private readonly IReaderStatistics statisticService;
        public ReaderStatisticController(UserDBContext _db, IReaderStatistics stats)
        {
            db = _db;
            statisticService = stats;
        }
        public IActionResult GetAllReadersStatistics(DateTime startTime, DateTime endTime)
        {
            return View(statisticService.GetAllReadersStatistics(startTime, endTime));
        }
        public IActionResult GetInfoAboutNotReturnedBook(int readerId)
        {
            if (db.Readers.Find(readerId) == null)
                return NotFound();
            var info = statisticService.GetInfoAboutNotReturnedBooks(readerId);
            if (info == null)
                return NotFound();
            return View(info);
        }
        public IActionResult GetReaderStatistics(int readerId)
        {
            if (db.Readers.Find(readerId) == null)
                return NotFound();
            return View(statisticService.GetReaderStatistics(readerId));
        }
    }
}
