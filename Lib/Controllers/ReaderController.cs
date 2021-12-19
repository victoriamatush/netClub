using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
  public class ReaderController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
