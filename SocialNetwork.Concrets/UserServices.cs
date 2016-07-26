using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Contracts;
using SocialNetwork.Data.DataContext;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.IoC;

namespace SocialNetwork.Concrets
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices()
        {
            _userRepository = Factory.Resolver<IUserRepository>();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email).ConfigureAwait(true);
        }

        public async Task<User> GetAuthenticationAsync(string username, string password)
        {
            return await _userRepository.GetAsync(username, password).ConfigureAwait(false);
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            return await _userRepository.GetAsync(username).ConfigureAwait(false);
        }

        public async Task<int> InsertUserAsync(User newUser)
        {
            return await _userRepository.InsertAsync(newUser).ConfigureAwait(false);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateAsync(user).ConfigureAwait(false);
        }
    }
}
