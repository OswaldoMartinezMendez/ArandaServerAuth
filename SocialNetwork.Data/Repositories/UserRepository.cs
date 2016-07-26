using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using SocialNetwork.Data.DataContext;

using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly UsersDb _userDbContext;

        public UserRepository(string connectionString)
        {
            _userDbContext = new UsersDb();
        }

        public async Task<User> GetAsync(string username, string password)
        {
            return await _userDbContext.Users.FirstAsync(u => u.Username.Equals(username) && u.Password.Equals(password)).ConfigureAwait(false);
        }
        public async Task<User> GetAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserRepository
    {
        
        Task<User> GetAsync(string username, string password);
        Task<User> GetAsync(string username);
        Task<User> GetByEmailAsync(string email);
    }
}