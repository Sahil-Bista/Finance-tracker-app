using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsework.Model
{
    internal class TransactionModel
    {
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public string TransactionType {  get; set; }//mandatory tags like credit,debit and debt
        public int TransactionAmount { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.Now;
        public string TransactionSource { get; set; }
        public string TransactionNotes { get; set; }
        public string TransactionCustomTags { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

    }
}
