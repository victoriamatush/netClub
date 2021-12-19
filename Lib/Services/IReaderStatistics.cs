using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
  public interface IReaderStatistics
  {
    public IActionResult GetReaderStatistics();
    public IActionResult GetAllReadersStatistics();
    public IActionResult GetInfoAboutNotReturnedBooks();

  }
}
