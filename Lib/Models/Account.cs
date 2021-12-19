using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Account
    {
      [Key]
      public int Account_ID { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }

      public bool Is_manager { get; set; } = false;
      public DateTime Register_Date { get; set; }
    }
}
