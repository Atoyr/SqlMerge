using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.EventAggregator
{
    public static class Publisher<TEventType,V> where TEventType : PubSubEvent<V>, new()
    {
        public static void Publish(V value)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator?.GetEvent<TEventType>()?.Publish(value);
        }
    }
}
