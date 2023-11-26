using Loymax.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLoymax.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int TransactionTypeId { get; set; }
        public virtual User? User { get; set; }
        public virtual TransactionType? TransactionType { get; set; }

    }
}
