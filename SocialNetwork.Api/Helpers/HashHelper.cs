using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Concrets;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;
using SocialNetwork.IoC;

namespace SocialNetwork.Api.Helpers
{
    public class HashHelper
    {
        private readonly IUserService _userService;

        public HashHelper()
        {
            _userService = new UserServices();
        }

        public static string Sha512(string input)
        {
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public User GetCurrentUser(ClaimsPrincipal currentUser)
        {
            var email = currentUser
                .Claims
                .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                ?.Value;

            if (email == null)
            {
                return null;
            }

            var user = _userService.GetByEmail(email);

            return user;
        }
    }
}