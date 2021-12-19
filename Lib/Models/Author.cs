
using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        
    }
}
