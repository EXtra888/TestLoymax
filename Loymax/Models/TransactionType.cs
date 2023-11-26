using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLoymax.Models
{
    public class TransactionType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
