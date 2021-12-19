
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [ForeignKey("Account.Account_ID")]
        public int Account_ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
