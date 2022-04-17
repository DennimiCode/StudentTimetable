using System;
using StudentTimetable.Helpers;
using StudentTimetable.View.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Theme.SetTheme();
            MainPage = new NavigationPage(new TimetablePage());
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            Theme.SetTheme();
            RequestedThemeChanged -= OnRequestedThemeChanged;
        }

        protected override void OnResume()
        {
            Theme.SetTheme();
            RequestedThemeChanged += OnRequestedThemeChanged;
        }
        
        private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Theme.SetTheme();
            });
        }
    }
}
