using Loymax.Models;
using TestLoymax.Models;

namespace Loymax.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
