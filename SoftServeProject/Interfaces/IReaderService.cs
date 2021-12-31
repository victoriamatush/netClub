using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SoftServeProject.Services
{
  public interface IReaderService
  {
    public void RequestBook(int bookid, int readerid);
    public void ReturnBook(int id);
    public ReaderStat GetOwnStatistics(int user_id);
    public Reader GetReaderById(int id);
    public List<Reader> GetReaderByName(string name);

    }
}
