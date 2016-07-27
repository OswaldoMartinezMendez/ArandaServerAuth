using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Contracts
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAuthenticationAsync(string username, string password);
        Task<User> GetByUserNameAsync(string username);
        Task<int> InsertUserAsync(User newUser);
        Task<bool> UpdateUserAsync(User user);
        User GetByEmail(string email);
    }
}