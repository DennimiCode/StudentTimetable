using System;
using StudentTimetable.Helpers;
using StudentTimetable.Models;
using StudentTimetable.Views.ModalPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace StudentTimetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayControl : ContentView
    {
        private const double MinWidthPerChar = 8.5d;
        public DayControl(Timetable timetable)
        {
            InitializeComponent();
            BindingContext = timetable;

            StartTimeLabel.Text = (new DateTime() + timetable.StartTime).ToShortTimeString();
            EndTimeLabel.Text = (new DateTime() + timetable.EndTime).ToShortTimeString();
            OfficeLabel.MinimumWidthRequest = timetable.OfficeNumber.ToString().Length * MinWidthPerChar;
            
            if (Preferences.Get(nameof(Settings.ColorProgression), true) && Convert.ToInt32(DateTime.Now.DayOfWeek) == timetable.Weekday)
            {
                if (DateTime.Now.TimeOfDay > timetable.EndTime)
                    DayControlFrame.BackgroundColor = Color.FromHex("#822c2b");
                else if (DateTime.Now.TimeOfDay >= timetable.StartTime && DateTime.Now.TimeOfDay <= timetable.EndTime)
                    DayControlFrame.BackgroundColor = Color.FromHex("#52992e");
                else if (DateTime.Now.TimeOfDay < timetable.StartTime)
                    DayControlFrame.SetOnAppTheme(BackgroundColorProperty, (Color)App.Current.Resources["CardBackgroundColor"],
                        (Color)App.Current.Resources["CardBackgroundColorDark"]);
            }
        }

        private async void DayControlOnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditLessonModalPage(true, (Timetable) BindingContext));
        }
    }
}