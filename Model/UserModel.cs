using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsework.Model
{
    internal class UserModel
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string CurrencyPreference { get; set; }
    }
}
