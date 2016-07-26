using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Contracts
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);
    }
}
