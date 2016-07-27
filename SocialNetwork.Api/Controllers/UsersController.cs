using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;
using Thinktecture.IdentityModel.WebApi;

namespace SocialNetwork.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsersController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;

        public UsersController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }

        [HttpGet]
        [Route("api/allUsers")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync().ConfigureAwait(false);
            if (users.Any())
                return Ok(users);
            return NotFound();
        }

        [HttpGet]
        //[ResourceAuthorize("Visitante", "ContactDetails")]
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
        public async Task<IHttpActionResult> PutAsync(string username, string password, [FromBody] User profile)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(User newUser)
        {
            var newProfile = new Profile
            {
                User = newUser,
                Action = "Read",
                Alias = "Visitante",
                Enabled = true,
                Hierarchy = 4,
                Name = "Visitante",
                Secret = "secret"
            };

            var result = await _profileService.InserProfiletAsync(newProfile).ConfigureAwait(false);
            return Ok(result);
        }
    }
}