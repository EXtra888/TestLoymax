using Loymax.Data;
using Loymax.Dto;
using Loymax.Models;
using Microsoft.EntityFrameworkCore;
using TestLoymax.Models;

namespace Loymax.Interfaces
{
    public interface ITransactionPepository
    {
        Task<Transaction> CreateTransaction(Transaction t);

        Task<double> GetBalanceUser(int id);

    }
}
