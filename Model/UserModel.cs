using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsework.Model
{
    internal class UserModel
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string CurrencyPreference { get; set; }
    }
}
