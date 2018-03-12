using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using SQLMerge.Modules;
using SQLMerge.Debugger.Modules;

namespace SQLMerge
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => this.Container.Resolve<Views.Shell>();
        protected override void InitializeShell() => ((Window)this.Shell).Show();

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(StatusBarModule));
            catalog.AddModule(typeof(MenuModule));
            catalog.AddModule(typeof(MainModule));
#if DEBUG
            catalog.AddModule(typeof(DebugModule));
#endif
        }
    }
}
