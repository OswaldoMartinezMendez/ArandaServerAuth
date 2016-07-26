using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetwork.Api.Helpers;
using SocialNetwork.Contracts;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Domain.Entities;
using Thinktecture.IdentityModel.WebApi;

namespace SocialNetwork.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;

        public UsersController(IProfileService profileService, IUserService userService)
        {
            this._profileService = profileService;
            this._userService = userService;
        }

        [HttpGet]
        [ResourceAuthorize("Total", "ContactDetails")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var email = ((ClaimsPrincipal) User)
                .Claims
                .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                ?.Value;

            if (email == null)
            {
                return NotFound();
            }

            //var user = await userRepository.GetAsync(email);
            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            //var profile = await profileRepository.GetForAsync(user);

            //if (profile == null)
            //{
            //    return NotFound();
            //}

            //var profile = new Profile
            //{
            //    Action = "Action",
            //};

            return Ok(user);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(string username, string password)
        {
            throw new NotImplementedException();

        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(string username, string password, [FromBody]Profile profile)
        {
            throw new NotImplementedException();
        }

    }
}