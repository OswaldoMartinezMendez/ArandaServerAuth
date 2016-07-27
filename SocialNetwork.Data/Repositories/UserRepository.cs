using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Data.DataContext;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDb _userDbContext;

        public UserRepository()
        {
            _userDbContext = new UsersDb();
        }

        public async Task<User> GetAsync(string username, string password)
        {
            return
                await
                    _userDbContext.Users.FirstAsync(u => u.Username.Equals(username) && u.Password.Equals(password))
                        .ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userDbContext.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> GetAsync(string username)
        {
            return await _userDbContext.Users.FirstAsync(u => u.Username.Equals(username)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _userDbContext.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userDbContext.Users.FirstAsync(u => u.Email.Equals(email)).ConfigureAwait(false);
        }

        public User GetByEmail(string email)
        {
            return _userDbContext.Users.First(u => u.Email.Equals(email));
        }

        public async Task<int> InsertAsync(User newUser)
        {
            _userDbContext.Users.Add(newUser);
            await _userDbContext.SaveChangesAsync().ConfigureAwait(false);
            return newUser.Id;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var existing = await _userDbContext.Users.FirstAsync(c => c.Id.Equals(user.Id)).ConfigureAwait(false);

            if (existing == null) return false;
            existing.Address = user.Address;
            existing.Email = user.Email;
            existing.Name = user.Name;
            existing.Password = user.Password;
            existing.Phone = user.Phone;
            existing.Subject = user.Subject;
            existing.Username = user.Username;

            return await _userDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> RemoveAsync(int idUser)
        {
            var user = await _userDbContext.Users.FirstAsync(c => c.Id.Equals(idUser)).ConfigureAwait(false);
            _userDbContext.Users.Remove(user);
            return await _userDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }

    public interface IUserRepository
    {
        Task<User> GetAsync(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<int> InsertAsync(User newUser);
        Task<bool> UpdateAsync(User user);
        Task<IEnumerable<User>> GetAsync();
        User GetByEmail(string email);
    }
}