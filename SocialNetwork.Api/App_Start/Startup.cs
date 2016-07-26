using System.Reflection;
using System.Web.Http;


using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(SocialNetwork.Api.Startup))]
namespace SocialNetwork.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            

            

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = ConfigurationManager.AppSettings["Authority"]
            });

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseWebApi(config);

        }
    }
}
