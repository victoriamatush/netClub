using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
  public interface IReaderService
  {
    public void RequestBook(int bookid, int readerid);
    public void ReturnBook(int id);
    public string GetOwnStatistics(int user_id);
  }
}
