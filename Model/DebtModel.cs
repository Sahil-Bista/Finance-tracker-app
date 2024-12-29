using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Corsework.Model
{
    public class DebtModel
    {
        [PrimaryKey]
        [Column("debt_id")]
        public Guid DebtId { get; set; }   = Guid.NewGuid();
        [Column("debt_source")]
        [Required(ErrorMessage ="Add a debt source")]
        public string DebtSource { get; set; }
        [Column("debt_amount")]
        [Required(ErrorMessage = "Add a valid debt amount")]
        [Range(1,double.MaxValue,ErrorMessage ="Amount cannot be less than 0")]
        public double DebtAmount { get; set; }
        [Column("due_date")]
        [Required(ErrorMessage="Transaction Date Required")]
        public DateTime DueDate { get; set; }
        [Column("debt_status")]
        public bool IsCleared { get; set; } = false;
        [Column("cleared_date")]
        public DateTime ClearedDate { get; set; } = DateTime.Now;
    }
}
