using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
