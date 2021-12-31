using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SoftServeProject.Services
{
  public interface IManagerService
  {
        public bool IsManager(int id);
        public void RegisterBookCopy(string title, string name, string surname);
        public void UpdateBookInformation(int id, string title, int authid);
        public void UpdateAuthorInformation(int authId, string name, string surname);
        public void DeleteOneBookCopy(int id);
        public void DeleteAllBookCopies(string title);
        public void ApproveRequest(int id);
        public List<Book> GetBooksByTitle(string title);
        public List<Request> GetRequests();
    }


}

