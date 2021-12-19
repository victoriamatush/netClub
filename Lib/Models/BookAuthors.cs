
using Microsoft.EntityFrameworkCore;

namespace Lib.Models
{
    [Keyless]
    public class BookAuthors
    {

        public int BookID { get; set; }
        public string AuthorID { get; set; }
    }
}
