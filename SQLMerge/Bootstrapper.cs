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
        }
    }
}
