using Microsoft.AspNetCore.Mvc;

namespace SoftServeProject.Services
{
  public interface IReaderStatistics
  {
    public IActionResult GetReaderStatistics();
    public IActionResult GetAllReadersStatistics();
    public IActionResult GetInfoAboutNotReturnedBooks();

  }
}
