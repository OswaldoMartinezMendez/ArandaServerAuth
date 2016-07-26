using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Management;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;
using SocialNetwork.IoC;

namespace SocialNetwork.OAuth.Configuration
{
    public class Clients
    {
        private readonly IProfileService _profileService;
        public Clients()
        {
            _profileService = Factory.Resolver<IProfileService>();
        }
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "socialnetwork",
                    ClientName = "SocialNetwork",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    AllowedScopes  = new List<string> { Constants.StandardScopes.OpenId},
                    Enabled = true
                },

                new Client
                {
                    ClientId = "socialnetwork_implicit",
                    ClientName = "SocialNetwork",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:28037/private",
                        "http://localhost:28037",
                        "http://pluralsight-web.azurewebsites.net",
                        "http://pluralsight-web.azurewebsites.net/private"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:28037",
                        "http://pluralsight-web.azurewebsites.net"
                    },
                    AllowedScopes  = new List<string> { Constants.StandardScopes.OpenId, Constants.StandardScopes.Profile },
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    IdentityTokenLifetime = 3600,
                    AccessTokenLifetime = 3600
                }
            };
        }

        public Task<IEnumerable<Profile>> GetProfiles(int iduser)
        {
            return _profileService.GetByHierarchyAsync(iduser);
        }
    }
}