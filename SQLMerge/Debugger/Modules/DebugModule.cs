using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SQLMerge.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Debugger.Modules
{
    public class DebugModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }
        public void Initialize()
        {
            this.Container.RegisterType<object, DebugView>(nameof(DebugView));
            this.RegionManager.RequestNavigate("MainRegion", nameof(DebugView));
        }
    }
}
