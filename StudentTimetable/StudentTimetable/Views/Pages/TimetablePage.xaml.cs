using System;
using System.Collections.Generic;
using System.Linq;
using StudentTimetable.Models;
using StudentTimetable.Views.ModalPages;
using Xamarin.Forms;

namespace StudentTimetable.Views.Pages
{
    public partial class TimetablePage : ContentPage
    {
        public TimetablePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            Monday.Children.Clear();
            Tuesday.Children.Clear();
            Wednesday.Children.Clear();
            Thursday.Children.Clear();
            Friday.Children.Clear();
            
            var lessons = new List<DayControl>().OrderBy(dc => ((Timetable)dc.BindingContext).StartTime).ToList();
            lessons.AddRange(
                (await App.TimetableDb.GetTimetablesAsync()).Select(timetable => new DayControl(timetable)));

            foreach (var dayControl in lessons)
            {
                switch (((Timetable)dayControl.BindingContext).Weekday)
                {
                    case 1:
                        Monday.Children.Add(dayControl);
                        break;
                    case 2:
                        Tuesday.Children.Add(dayControl);
                        break;
                    case 3:
                        Wednesday.Children.Add(dayControl);
                        break;
                    case 4:
                        Thursday.Children.Add(dayControl);
                        break;
                    case 5:
                        Friday.Children.Add(dayControl);
                        break;
                }
            }

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    MondayFrame.BackgroundColor = Color.FromHex("306dc9");
                    MondayDateLabel.TextColor = Color.FromHex("FFFFFF");
                    MondayTextLabel.TextColor = Color.FromHex("FFFFFF");

                    MondayDateLabel.Text = DateTime.Now.ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(1).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(2).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(3).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(4).ToShortDateString();
                    break;
                case DayOfWeek.Tuesday:
                    TuesdayFrame.BackgroundColor = Color.FromHex("306dc9");
                    TuesdayDateLabel.TextColor = Color.FromHex("FFFFFF");
                    TuesdayTextLabel.TextColor = Color.FromHex("FFFFFF");

                    MondayDateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(1).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(2).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(3).ToShortDateString();
                    break;
                case DayOfWeek.Wednesday:
                    WednesdayFrame.BackgroundColor = Color.FromHex("306dc9");
                    WednesdayDateLabel.TextColor = Color.FromHex("FFFFFF");
                    WednesdayTextLabel.TextColor = Color.FromHex("FFFFFF");

                    MondayDateLabel.Text = DateTime.Now.AddDays(-2).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(1).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(2).ToShortDateString();
                    break;
                case DayOfWeek.Thursday:
                    ThursdayFrame.BackgroundColor = Color.FromHex("306dc9");
                    ThursdayDateLabel.TextColor = Color.FromHex("FFFFFF");
                    ThursdayTextLabel.TextColor = Color.FromHex("FFFFFF");

                    MondayDateLabel.Text = DateTime.Now.AddDays(-3).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(-2).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(1).ToShortDateString();
                    break;
                case DayOfWeek.Friday:
                    FridayFrame.BackgroundColor = Color.FromHex("306dc9");
                    FridayDateLabel.TextColor = Color.FromHex("FFFFFF");
                    FridayTextLabel.TextColor = Color.FromHex("FFFFFF");

                    MondayDateLabel.Text = DateTime.Now.AddDays(-4).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(-3).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(-2).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.ToShortDateString();
                    break;
                case DayOfWeek.Saturday:
                    MondayDateLabel.Text = DateTime.Now.AddDays(-5).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(-4).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(-3).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(-2).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    break;
                case DayOfWeek.Sunday:
                    MondayDateLabel.Text = DateTime.Now.AddDays(-6).ToShortDateString();
                    TuesdayDateLabel.Text = DateTime.Now.AddDays(-5).ToShortDateString();
                    WednesdayDateLabel.Text = DateTime.Now.AddDays(-4).ToShortDateString();
                    ThursdayDateLabel.Text = DateTime.Now.AddDays(-3).ToShortDateString();
                    FridayDateLabel.Text = DateTime.Now.AddDays(-2).ToShortDateString();
                    break;
            }
            base.OnAppearing();
        }

        private async void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), false);
        }

        private async void HomeTasksButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeworkPage(), false);
        }

        private async void LessonButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditLessonModalPage(false));
        }
    }
}
