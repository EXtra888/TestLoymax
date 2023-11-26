using Loymax.Data;
using Loymax.Interfaces;
using Loymax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestLoymax.Models;

namespace Loymax.Repository
{
    public class TransactionRepository : ITransactionPepository
    {
        private readonly ApplicationContext _context;

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == transaction.UserId);
            //Обновление баланса у usera
            if (user != null)
            {
                if (transaction.Amount > 0)
                    user.AmountMoney  +=  transaction.Amount;
                else user.AmountMoney -= -transaction.Amount;

            }
            _context.Transactions.Add(transaction);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<double> GetBalanceUser(int id)
        {
            var result = await (from t in _context.Transactions
                                where t.UserId == id
                                select t.Amount).SumAsync();

            return result;
        }

    }
}
