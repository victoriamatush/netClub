
using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Request
    {
        [Key]
        public int Request_ID { get; set; }
        public int Reader_ID { get; set; }
        public int Book_ID { get; set; }
        public DateTime Date_of_request { get; set; }
        public DateTime Date_of_returning { get; set; }
        public bool Is_approved { get; set; }

        public Request(int readerid, int bookid)
        {
          Reader_ID = readerid; 
          Book_ID = bookid;  
          Date_of_request = DateTime.Now;
          Is_approved = false;
        }
  }
}
