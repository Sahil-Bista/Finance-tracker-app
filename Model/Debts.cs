using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsework.Model
{
    internal class Debts
    {
        public Guid DebtId { get; set; }   = Guid.NewGuid();
        public string DebtSource { get; set; }
        public int DebtAmount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime ClearedDate { get; set; }
        public String DebtStatus {  get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
