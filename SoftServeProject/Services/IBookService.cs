using Microsoft.AspNetCore.Mvc;

namespace SoftServeProject.Services
{
  public interface IBookService
  {
    public IActionResult GetInformationAboutAllBooks();
    public IActionResult GetAvailabilityOfBook(int id);
    public IActionResult GetBookByAuthor(string author);
    public IActionResult GetBookByTitle(string title);
    public IActionResult GetMostPopularBook();
    public IActionResult GetLeastPopularBook();
  }
}
