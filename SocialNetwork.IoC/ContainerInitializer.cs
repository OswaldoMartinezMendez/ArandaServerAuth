using Microsoft.Practices.Unity;

using SocialNetwork.Data.Repositories;

namespace SocialNetwork.IoC
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
        }
    }
}