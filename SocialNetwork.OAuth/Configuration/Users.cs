using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using SocialNetwork.Data.Repositories;

namespace SocialNetwork.OAuth.Configuration
{
    public class Users
    {
        public static List<InMemoryUser> GetUsers()
        {
            return BuidListUsers();
        }

        private static List<InMemoryUser> BuidListUsers()
        {
            var repo = new UserRepository();
            var clientsList = repo.GetAsync();

            return clientsList.Result.ToList().Select(itemList => new InMemoryUser
            {
                Subject = itemList.Email,
                Username = itemList.Username,
                Password = itemList.Password,
                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.Name, itemList.Name)
                },
                Enabled = true
            }).ToList();
        }
    }
}