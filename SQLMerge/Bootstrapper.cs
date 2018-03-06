using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLMerge
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => this.Container.Resolve<Views.Shell>();
        protected override void InitializeShell() => ((Window)this.Shell).Show();
    }
}
