using SQLMerge.EventAggregator;
using SQLMerge.EventAggregator.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.ViewModels
{
    public class DefaultStatusBarViewModel : UnityBindableBase
    {
        private string _StatusText = string.Empty;
        public string StatusText
        {
            get => _StatusText;
            set => SetProperty(ref _StatusText, value);
        }

        public DefaultStatusBarViewModel()
        {
            Subscriber<StatusBarMessageChangeEvent, StatusBarMessageValue>.Subscribe(x => StatusText = x.Value);
        }
        ~DefaultStatusBarViewModel()
        {
            Subscriber<StatusBarMessageChangeEvent, StatusBarMessageValue>.Unsubscribe(x => StatusText = x.Value);
        }
    }
}
