using Loymax.Data;
using Loymax.Interfaces;
using Loymax.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;

namespace Loymax.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;


        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        
        public async Task<double> GetAmountMoney(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            var result = user.AmountMoney;

            return (result);
        }
    }
}
