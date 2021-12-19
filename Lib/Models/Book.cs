using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
    }
}
