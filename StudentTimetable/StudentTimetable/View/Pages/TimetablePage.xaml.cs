using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace StudentTimetable.View.Pages
{
    public partial class TimetablePage : ContentPage
    {
        public TimetablePage()
        {
            InitializeComponent();
            var test = new DayControl("14:50", "16:20", "МДК 01.01 Разработка ПМ", "201", "Задеба А.А.", 5);
            var test2 = new DayControl("09:00", "10:30", "МДК 01.02 Разработка мобильных приложений", "407", "Егорова Н.Ю.", 5);
            var test3 = new DayControl("10:40", "11:25", "МДК 01.02 Разработка мобильных приложений", "407", "Егорова Н.Ю.", 5);
            var test4 = new DayControl("11:25", "12:30", "МДК 01.02 Разработка мобильных приложений", "407", "Егорова Н.Ю.", 5);
            var test5 = new DayControl("12:50", "13:35", "МДК 02.03 Математическое моделирование", "301", "Кузьмина О.Б.", 5);
            var test6 = new DayControl("13:55", "14:40", "МДК 02.03 Математическое моделирование", "301", "Кузьмина О.Б.", 5);

            var tests = new List<DayControl> { test, test2, test3, test4, test5, test6 }.OrderBy(dc => dc.StartTime).ToList();

            foreach (var dayControl in tests)
            {
                switch (dayControl.DayOfWeek)
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
        }

        private async void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), false);
        }

        private async void HomeTasksButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeworkPage(), false);
        }

        private async void EditLessonButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ModalPages.EditLessonModalPage(false));
        }
    }
}
