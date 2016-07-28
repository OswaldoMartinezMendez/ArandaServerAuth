using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SocialNetwork.Concrets;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace SocialNetwork.Api
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        private static UserServices _instance;
        private readonly IProfileService _profileService;

        public AuthorizationManager()
        {
            _profileService = new ProfileService();
        }

        public static UserServices userServices
        {
            get { return _instance ?? (_instance = new UserServices()); }
        }

        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "ContactDetails":
                    return AuthorizeContactDetails(context);
                default:
                    return Nok();
            }
        }

        private async Task<bool> AuthorizeContactDetails(ResourceAuthorizationContext context)
        {
            var user = GetCurrentUser(context.Principal);
            var profiles = _profileService.GetByHierarchy(user.Id);
            var currentProfile = profiles.First().Name;

            switch (context.Action.First().Value)
            {
                case "Visitante":
                    return await Eval(context.Principal.HasClaim("client_id", currentProfile));
                case "Autenticado":
                    return await Eval(context.Principal.HasClaim("client_id", currentProfile));
                case "Editor":
                    return await Eval(context.Principal.HasClaim("client_id", currentProfile));
                case "Administrador":
                    return await Eval(context.Principal.HasClaim("client_id", currentProfile));
                default:
                    return await Nok();
            }
        }

        private User GetCurrentUser(ClaimsPrincipal currentUser)
        {
            var email = currentUser
                .Claims
                .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                ?.Value;

            if (email == null)
            {
                return null;
            }

            var user = userServices.GetByEmail(email);

            return user;
        }
    }
}