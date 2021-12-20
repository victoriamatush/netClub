using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class ReaderService : IReaderService
    {
        UserDBContext db = new UserDBContext();
        public ReaderStat GetOwnStatistics(int user_id)
        {
            ReaderStatisticService readStat = new ReaderStatisticService();
            return readStat.GetReaderStatistics(user_id);
            
        }

        public void RequestBook(int bookid, int readerid)
        {
            db.Requests.Add(new Request() { BookId = bookid, ReaderId = readerid});
            db.SaveChanges();
        }

        public void ReturnBook(int RequestId)
        {
            //need BookService to update
        }
    }
}
