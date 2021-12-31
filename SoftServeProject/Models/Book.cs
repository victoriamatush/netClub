using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Book
    {

        public int Bookid { get; set; }
        public string Title { get; set; }

        public ICollection<Request> Requests { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
