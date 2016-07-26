using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public Task<Profile> GetForAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProfileRepository
    {
        Task<Profile> GetForAsync(User user);
        Task UpdateAsync(Profile profile);
    }
}