using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Book
    {
        public Book()
        {
            Requests = new HashSet<Request>();
        }

        public int Bookid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
