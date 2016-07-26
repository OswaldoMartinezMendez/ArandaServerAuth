using Microsoft.Practices.Unity;

namespace SocialNetwork.IoC
{
    public class DiContainer
    {
        public DiContainer()
        {
            Current = new UnityContainer();
            Current.InitializeContainer();
        }

        public IUnityContainer Current { get; set; }
    }
}