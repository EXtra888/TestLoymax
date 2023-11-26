using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestLoymax.Models;

namespace Loymax.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        //public string Login {get; set; }
        //public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public double AmountMoney { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
