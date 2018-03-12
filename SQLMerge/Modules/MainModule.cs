using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SQLMerge.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SQLMerge.Modules
{
    public class MainModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }
        public void Initialize()
        {
            this.Container.RegisterType<object, TabView>(nameof(TabView));
            //this.RegionManager.RequestNavigate(Region.TabRegion, nameof(TabView));
        }
    }
}