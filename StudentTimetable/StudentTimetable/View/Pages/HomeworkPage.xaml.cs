using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeworkPage : ContentPage
    {
        public HomeworkPage()
        {
            InitializeComponent();
            var homeworks = new List<HomeworkControl>
            {
                new HomeworkControl("Сделать", "Математика", new DateTime(2022, 5, 3), true),
                new HomeworkControl("Убрать", "Биология", new DateTime(2022, 4, 30), true),
                new HomeworkControl("Переделать", "Русский", new DateTime(2022, 04, 23), false),
                new HomeworkControl("Сдать", "Анлийский", new DateTime(2022, 04, 19), false)
            };

            foreach (var homeworkControl in homeworks)
            {
                if (homeworkControl.IsCompleted)
                    CompletedTasksStackLayout.Children.Add(homeworkControl);
                else
                    CurrentTasksStackLayout.Children.Add(homeworkControl);
            }
        }

        private async void TimetableButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(false);
        }

        private async void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), false);
        }
    }
}