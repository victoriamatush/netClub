using Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
  public class ReaderService: IReaderService
  {
    public LibContext libContext;
    public void RequestBook(int bookid, int readerid)
    {
      Request request = new Request(readerid, bookid);
      libContext.Requests.Add(request);
      libContext.SaveChanges();
    }

    public void ReturnBook(int bookid)
    {
      foreach(var request in libContext.Requests)
      {
        if (request.Book_ID == bookid)
          request.Date_of_returning = DateTime.Now;
      }
    }

    public string GetOwnStatistics(int user_id)
    {
      return($"Amount of books {GetAmountOfBooks(user_id)}, Days of reading {GetDaysOfReading(user_id)}, " +
      $"Current Book {GetCurrentBook(user_id)}");
    }

    public int GetAmountOfBooks(int user_id)
    {
      int count = 0;

      foreach(var request in libContext.Requests)
      if(request.Date_of_returning!=null && request.Is_approved && request.Reader_ID == user_id )
      {
          count++;
      }
      return count;
    }

    public int GetDaysOfReading(int user_id)
    {
      return (int)(from request in libContext.Requests.ToList()
                     where request.Reader_ID==user_id
                     select request).Average(r=>r.Date_of_returning.Day - r.Date_of_request.Day);
    }

    public Book GetCurrentBook(int user_id)
    {
      foreach(var request in libContext.Requests)
      {
        if (request.Reader_ID == user_id && request.Date_of_returning == null && request.Is_approved)
        {
          foreach(var book in libContext.Books)
          {
            if (book.BookID == request.Book_ID)
              return book;
          }
        }
      }
      return null;
    }

  }
}
