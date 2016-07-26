using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProfilesController : BaseController
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var profiles = await _profileService.GetProfileForAsync().ConfigureAwait(false);
            return profiles.Any() ? Ok(profiles) : null;
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(Profile profile)
        {
            var result = await _profileService.UpdateProfileAsync(profile).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(Profile profile)
        {
            var result = await _profileService.InserProfiletAsync(profile).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(int idprofile)
        {
            var result = await _profileService.RemoveProfiletAsync(idprofile).ConfigureAwait(false);
            return Ok(result);
        }
    }
}