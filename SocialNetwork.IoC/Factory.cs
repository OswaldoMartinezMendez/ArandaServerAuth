using Microsoft.Practices.Unity;

namespace SocialNetwork.IoC
{
    public static class Factory
    {
        private static readonly DiContainer Container;


        static Factory()
        {
            Container = new DiContainer();
        }


        public static TServicio Resolver<TServicio>()
        {
            return Container.Current.Resolve<TServicio>();
        }
    }
}