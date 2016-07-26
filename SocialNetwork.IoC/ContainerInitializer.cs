using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SocialNetwork.Data.Repositories;

namespace SocialNetwork.IoC
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
