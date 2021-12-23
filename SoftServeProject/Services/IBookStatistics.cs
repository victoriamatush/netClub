using Microsoft.AspNetCore.Mvc;

namespace SoftServeProject.Services
{
  public interface IBookStatistics
  {
    public IActionResult GetStatisticsByBook(string title);
    public IActionResult GetStatisticsByAllBooks();
    public IActionResult GetBooksByPeriod(string start , string end);
  }
}
