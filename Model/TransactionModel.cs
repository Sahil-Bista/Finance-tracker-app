using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Corsework.Model
{
    [Table("Transaction")]
    public class TransactionModel
    {
        [PrimaryKey]
        [Column("transaction_id")]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

		[Column("transaction_name")]
        [Required(ErrorMessage = "Transaction Name Required")]
        public string TransactionName { get; set; }
        
        [Required(ErrorMessage = "Transaction Type Required")]
        [Column("transaction_type")]
		public string TransactionType {  get; set; } = "Credit";

        [Required(ErrorMessage = "Enter a valid Tramsaction Amount")]
        [Range(1,double.MaxValue, ErrorMessage = "Amount cannot be less than 0")]
        [Column("transaction_amount")]
		public double TransactionAmount { get; set; }

        [Required(ErrorMessage = "Transaction Date Required")]
        [Column("transaction_time")]
        public DateTime TransactionTime { get; set; }

		[Column("transaction_source")]
        [Required(ErrorMessage = "Add the transaction Source")]
        public string TransactionSource { get; set; }

		[Column("transaction_notes")]
		public string TransactionNotes { get; set; }

        [Column("transaction_default_tag")]
        [Required(ErrorMessage = "Transaction Default Tag must be selected")]
        public string TransactionDefaultTag { get; set; } = "Food";

		[Column("transaction_custom_tags")]
		public string TransactionCustomTags { get; set; }

    }
}
