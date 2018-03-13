using Prism.Regions;
using SQLMerge.EventAggregator;
using SQLMerge.EventAggregator.Events;
using SQLMerge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.Debugger.ViewModels
{
    public class DebugViewModel : UnityBindableBase
    {
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
            Publisher<StatusBarMessageChangeEvent, StatusBarMessageValue>.Publish(new StatusBarMessageValue { Value = "" });
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            Publisher<StatusBarMessageChangeEvent, StatusBarMessageValue>.Publish(new StatusBarMessageValue { Value = "Debug" });
        }
    }
}
