using Microsoft.Practices.Unity;
using System.Web.Http;
using SocialNetwork.Concrets;
using SocialNetwork.Contracts;
using Unity.WebApi;

namespace SocialNetwork.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserServices>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}