using MetroRadiance.Media;
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

namespace SQLMerge.Debugger.Views
{
    /// <summary>
    /// HsvSamples.xaml の相互作用ロジック
    /// </summary>
    public partial class HsvSamples : UserControl
    {
        public HsvSamples()
        {
            InitializeComponent();
            this.hSlider.ValueChanged += (sender, e) => this.Update();
            this.sSlider.ValueChanged += (sender, e) => this.Update();
            this.vSlider.ValueChanged += (sender, e) => this.Update();

            this.Update();
        }

        private void Update()
        {
            var h = this.hSlider.Value;
            var s = this.sSlider.Value / 100.0;
            var v = this.vSlider.Value / 100.0;

            var hsv = HsvColor.FromHsv(h, s, v);
            var c = hsv.ToRgb();

            var l = Luminosity.FromRgb(c);
            var w = l <= 128;

            this.colorbox.Background = new SolidColorBrush(c);
            this.colorbox.Foreground = w ? Brushes.White : Brushes.Black;
            this.colorbox.Text = $"Color: {c}, Luminosity: {l}";
        }
    }
}
