using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using SocialNetwork.Data.Repositories;

namespace SocialNetwork.OAuth.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return BuidArrayClients();
        }

        private static IEnumerable<Client> BuidArrayClients()
        {
            var repo = new ProfileRepository();
            var clientsList = repo.GetForAsync();

            return clientsList.Result.ToList().Select(itemList => new Client
            {
                ClientId = itemList.Alias,
                ClientName = itemList.Name,
                ClientSecrets = new List<Secret>
                {
                    new Secret(itemList.Secret.Sha256())
                },
                Flow = Flows.ResourceOwner,
                AllowedScopes = new List<string> {Constants.StandardScopes.OpenId},
                Enabled = itemList.Enabled
            }).ToArray();
        }
    }
}