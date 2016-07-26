using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace SocialNetwork.OAuth.Configuration
{
    public class Users
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "oswaldo1088@gmail.com",
                    Username = "oswaldo1088@gmail.com",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "Oswaldo Martinez"),
                        new Claim(Constants.ClaimTypes.Role, "Geek")
                    },
                    Enabled = true
                }
            };
        }
    }
}