using Microsoft.AspNetCore.Mvc;

namespace SoftServeProject.Services
{
  public interface IManagerService
  {
    public IActionResult RegisterBookCopy(int id);
    public IActionResult UpdateBookInformation(int id);
    public IActionResult DeleteOneBookCopy(int id);
    public IActionResult DeleteAllBookCopies(string title);
    public IActionResult ApproveRequest(int id);
    public IActionResult GetBooksByTitle(string title);


  }
}
