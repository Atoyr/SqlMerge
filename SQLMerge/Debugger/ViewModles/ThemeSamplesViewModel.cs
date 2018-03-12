using MetroRadiance.UI;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using SQLMerge.EventAggregator;
using SQLMerge.EventAggregator.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SQLMerge.Debugger.ViewModels
{
    public class ThemeSamplesViewModel : BindableBase
    {
        [Dependency]
        public IUnityContainer Container { get; set; }


        #region Windows 変更通知プロパティ

        private bool _ThemeWindows = ThemeService.Current.Theme == Theme.Windows;

        public bool ThemeWindows
        {
            get { return this._ThemeWindows; }
            set
            {
                if (this._ThemeWindows != value)
                {
                    SetProperty(ref this._ThemeWindows, value);
                    if (value) ThemeService.Current.ChangeTheme(Theme.Windows);
                }
            }
        }

        #endregion

        #region Light 変更通知プロパティ

        private bool _Light = ThemeService.Current.Theme == Theme.Light;

        public bool Light
        {
            get { return this._Light; }
            set
            {
                if (this._Light != value)
                {
                    SetProperty(ref _Light, value);
                    if (value) ThemeService.Current.ChangeTheme(Theme.Light);
                }
            }
        }

        #endregion

        #region Dark 変更通知プロパティ

        private bool _Dark = ThemeService.Current.Theme == Theme.Dark;

        public bool Dark
        {
            get { return this._Dark; }
            set
            {
                if (this._Dark != value)
                {
                    SetProperty(ref _Dark, value);
                    if (value) ThemeService.Current.ChangeTheme(Theme.Dark);
                }
            }
        }

        #endregion

        #region Windows 変更通知プロパティ

        private bool _AccentWindows = ThemeService.Current.Accent.SyncToWindows;

        public bool AccentWindows
        {
            get { return this._AccentWindows; }
            set
            {
                if (this._AccentWindows != value)
                {
                    this._AccentWindows = value;
                    this.RaisePropertyChanged();

                    if (value) ThemeService.Current.ChangeAccent(Accent.Windows);
                }
            }
        }

        #endregion

        #region Purple 変更通知プロパティ

        private bool _Purple = ThemeService.Current.Accent.Specified == Accent.SpecifiedColor.Purple;

        public bool Purple
        {
            get { return this._Purple; }
            set
            {
                if (this._Purple != value)
                {
                    this._Purple = value;
                    this.RaisePropertyChanged();

                    if (value) ThemeService.Current.ChangeAccent(Accent.Purple);
                }
            }
        }

        #endregion

        #region Blue 変更通知プロパティ

        private bool _Blue = ThemeService.Current.Accent.Specified == Accent.SpecifiedColor.Blue;

        public bool Blue
        {
            get { return this._Blue; }
            set
            {
                if (this._Blue != value)
                {
                    this._Blue = value;
                    this.RaisePropertyChanged();

                    if (value) ThemeService.Current.ChangeAccent(Accent.Blue);
                }
            }
        }

        #endregion

        #region Orange 変更通知プロパティ

        private bool _Orange = ThemeService.Current.Accent.Specified == Accent.SpecifiedColor.Orange;

        public bool Orange
        {
            get { return this._Orange; }
            set
            {
                if (this._Orange != value)
                {
                    this._Orange = value;
                    this.RaisePropertyChanged();

                    if (value) ThemeService.Current.ChangeAccent(Accent.Orange);
                }
            }
        }

        #endregion

        #region Red 変更通知プロパティ

        private bool _Red = ThemeService.Current.Accent.Color == Colors.Red;

        public bool Red
        {
            get { return this._Red; }
            set
            {
                if (this._Red != value)
                {
                    this._Red = value;
                    this.RaisePropertyChanged();

                    if (value) ThemeService.Current.ChangeAccent(Accent.FromColor(Colors.Red));
                }
            }
        }

        #endregion
    }
}
