using MetroRadiance.UI;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.EventAggregator.Events
{
    public class ThemeValueEvent : PubSubEvent<ThemeValue>
    {
    }

    public class ThemeValue
    {
        public Theme Theme { get; set; }
    }
}
