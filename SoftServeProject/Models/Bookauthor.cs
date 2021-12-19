using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Bookauthor
    {
        public int Bookid { get; set; }
        public int Authorid { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
