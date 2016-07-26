using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace SocialNetwork.IoC
{
    public static class Factory
    {
        private static readonly DiContainer Container;


        public static TServicio Resolver<TServicio>()
        {
            return Container.Current.Resolve<TServicio>();
        }

        

        static Factory()
        {
            Container = new DiContainer();
        }
    }
}
