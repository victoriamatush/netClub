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

        public ManagerController(IManagerService _manager, UserDBContext _context)
        {
            manager = _manager;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("approve/{id}/")]
        public IActionResult ApproveRequest(int id)
        {
            if (context.Requests.Where(r => r.Id == id).FirstOrDefault() == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Request is not found"
                });
            }
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
            return Ok();
        }
    }
}
