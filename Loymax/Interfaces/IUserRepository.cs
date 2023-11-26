using Loymax.Models;
using TestLoymax.Models;

namespace Loymax.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User u);
        Task<double> GetAmountMoney(int id);
    }
}
