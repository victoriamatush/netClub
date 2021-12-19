using Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lib.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibContext libContext;



        public HomeController(LibContext context)
        {
            libContext = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            libContext.Authors.ToList();
            libContext.BookAuthors.ToList();
            libContext.Requests.ToList();
            libContext.Users.ToList();
            libContext.Books.ToList();
            libContext.Accounts.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}