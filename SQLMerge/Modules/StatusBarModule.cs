using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SQLMerge.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Modules
{
    public class StatusBarModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }
        public void Initialize()
        {
            //this.Container.RegisterType<MessageProvider>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, DefaultStatusBar>(nameof(DefaultStatusBar));

            this.RegionManager.RequestNavigate("StatusBarRegion", nameof(DefaultStatusBar));
        }
    }
}
