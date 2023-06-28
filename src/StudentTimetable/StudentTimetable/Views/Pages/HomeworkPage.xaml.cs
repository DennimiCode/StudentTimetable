using System;
using System.Collections.Generic;
using System.Linq;
using StudentTimetable.Models;
using StudentTimetable.Views.ModalPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeworkPage : ContentPage
    {
        public HomeworkPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            CompletedTasksStackLayout.Children.Clear();
            CurrentTasksStackLayout.Children.Clear();
            
            var homeworks = new List<HomeworkControl>().OrderBy(hwc => ((Homework) hwc.BindingContext).DueDate).ToList();
            homeworks.AddRange(
                (await App.TimetableDb.GetHomeworksAsync()).Select(homework => new HomeworkControl(homework)));

            foreach (var homeworkControl in homeworks)
            {
                if (((Homework)homeworkControl.BindingContext).IsCompleted)
                    CompletedTasksStackLayout.Children.Add(homeworkControl);
                else
                    CurrentTasksStackLayout.Children.Add(homeworkControl);
            }
            base.OnAppearing();
        }

        private async void TimetableButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(false);
        }

        private async void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), false);
        }

        private async void HomeworkButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditHomeworkModalPage(false));
        }
    }
}