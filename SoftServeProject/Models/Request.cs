using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Request
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime? DateOfReturning { get; set; }
        public bool IsApproved { get; set; }

        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }

    }
}
