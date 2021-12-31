using System;
using System.Collections.Generic;

#nullable disable

namespace SoftServeProject
{
    public partial class Reader
    {
        public Reader()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsManager { get; set; }
        public DateTime RegisterDate { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
