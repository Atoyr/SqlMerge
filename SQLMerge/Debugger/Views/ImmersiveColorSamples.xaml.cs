using MetroRadiance.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroRadiance.Media;
using System.Reflection;

namespace SQLMerge.Debugger.Views
{
    /// <summary>
    /// ImmersiveColorSamples.xaml の相互作用ロジック
    /// </summary>
    public partial class ImmersiveColorSamples : UserControl
    {
        public ImmersiveColorSamples()
        {
            InitializeComponent();
            this.DataContext = typeof(ImmersiveColorNames).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => (string)x.GetValue(null))
                .Select(name =>
                {
                    var background = new SolidColorBrush(ImmersiveColor.GetColorByTypeName(name));
                    var luminocity = Luminosity.FromRgb(background.Color);
                    var foreground = new SolidColorBrush(luminocity < 128 ? Colors.White : Colors.Black);

                    return new { name, background, foreground, };
                })
                .ToArray();
        }
    }
}
