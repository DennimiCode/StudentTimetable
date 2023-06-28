using System;
using System.IO;
using StudentTimetable.Data;
using StudentTimetable.Helpers;
using StudentTimetable.Views.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StudentTimetable
{
    public partial class App : Application
    {
        private static TimetableDb _timetableDb;

        public static TimetableDb TimetableDb =>
            _timetableDb ??= new TimetableDb(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TimetableDatabase.db3"));

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
