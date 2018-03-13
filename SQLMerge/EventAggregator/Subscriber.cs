using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.EventAggregator
{
    public static class Subscriber<TEventType, V> where TEventType : PubSubEvent<V>, new()
    {
        public static void Subscribe(Action<V> action)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator?.GetEvent<TEventType>()?.Subscribe(action);
        }
        public static void Unsubscribe(Action<V> action)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator?.GetEvent<TEventType>()?.Unsubscribe(action);
        }
    }
}
