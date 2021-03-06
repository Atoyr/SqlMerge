﻿using MetroRadiance.UI.Controls;
using Prism.Regions;
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
using System.Windows.Shapes;

namespace SQLMerge.Views
{
    /// <summary>
    /// Shell.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell : MetroWindow
    {
        public Shell()
        {
            InitializeComponent();
            RegionManager.SetRegionName(Menu, Region.MenuRegion);
            RegionManager.SetRegionName(Main, Region.MainRegion);
            RegionManager.SetRegionName(StatusBar, Region.StatusBarRegion);
        }
    }
}
