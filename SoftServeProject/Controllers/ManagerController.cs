using Microsoft.AspNetCore.Mvc;
using SoftServeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService manager;
        private readonly UserDBContext context;
        private readonly IBookService bookService;

        public ManagerController(IManagerService _manager, UserDBContext _context, IBookService _bookService)
        {
            manager = _manager;
            context = _context;
            bookService = _bookService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("approve/{id}/")]
        public IActionResult ApproveRequest(int id)
        {
            
            manager.ApproveRequest(id);
            return Ok(new { status = Ok().StatusCode, message = "Request is approved" });
        }


        [Route("deleteall/{title}/")]
        public IActionResult DeleteAllBookCopies(string title)
        {
            manager.DeleteAllBookCopies(title);
            return Ok();
        }

        [Route("delete/{id}/")]
        public IActionResult DeleteOneBookCopy(int id)
        {
            manager.DeleteOneBookCopy(id);
            return Ok();
        }

        [Route("all/{title}/")]
        public IActionResult GetBooksByTitle(string title)
        {
            return Ok(manager.GetBooksByTitle(title));
        }

        [Route("bookcopy/{title}/{name}/{surname}/")]
        public IActionResult RegisterBookCopy(string title, string name, string surname)
        {
            manager.RegisterBookCopy(title, name, surname);
            return Ok("success");
        }

        

        [Route("updatebook/{bookid}/{title}/{authid}/{name}/{surname}/")]
        public IActionResult UpdateBookInformation(
            int bookid, 
            string title, 
            int authid, 
            string name,
            string surname)
        {
            manager.UpdateBookInformation(bookid, title, authid, name, surname);
            return Ok("success");
        }
        [Route("requests/")]
        public IActionResult GetAllRequests()
        {
            if (context.Requests.ToList() == null)
                return NotFound();
            return View(manager.GetRequests());
        }
    }
}
