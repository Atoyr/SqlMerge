using Microsoft.Practices.Unity;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.EventAggregator
{
    public class Publisher<TEventType,V> where TEventType : PubSubEvent<V>, new()
    {
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }        
        public void Publish(V value)
        {
            this.EventAggregator
                .GetEvent<TEventType>()
                .Publish(value);
        }
    }
}
