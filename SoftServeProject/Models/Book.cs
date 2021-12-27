using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Book
    {

        public int Bookid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Bookauthor> Bookauthors { get; set; }
    }
}
