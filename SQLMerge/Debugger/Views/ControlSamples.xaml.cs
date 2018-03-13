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
    /// ControlSamples.xaml の相互作用ロジック
    /// </summary>
    public partial class ControlSamples : UserControl
    {
        public ControlSamples()
        {
            this.InitializeComponent();
            this.DataContext = new SampleValues();
        }

        private void HandleBlurWindowButtonClicked(object sender, RoutedEventArgs e)
        {
            //new BlurWindowSample().Show();
        }
    }

    public class SampleValues
    {
        public int Int32 { get; set; } = 32;
    }
}