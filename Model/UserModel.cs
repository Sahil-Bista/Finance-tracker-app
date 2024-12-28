using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Corsework.Model
{
    [Table("User")]
    public class UserModel
    {
        [PrimaryKey]
        [Column("user_id")]
        public Guid UserId { get; set; } = Guid.NewGuid();
        [Column("user_email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        public string UserEmail { get; set; }
        [Column("user_name")]
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; }
        [Column("user_password")]
        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }
        [Column("currency_type")]
        [Required(ErrorMessage = "Please select a currency type")]
        public string CurrencyType { get; set; }
        

    }
}
