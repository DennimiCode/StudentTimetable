using System;
using StudentTimetable.Models;
using StudentTimetable.Views.ModalPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeworkControl : ContentView
    {
        public HomeworkControl(Homework homework)
        {
            BindingContext = homework;
            InitializeComponent();
            HomeworkControlOnLoading();
        }

        private async void HomeworkControlOnLoading()
        {
            SubjectLabel.Text = (await App.TimetableDb.GetTimetableAsync(((Homework) BindingContext).SubjectId))
                .SubjectName;

            DueDateLabel.Text = ((Homework) BindingContext).DueDate.ToShortDateString();
            
            if (((Homework) BindingContext).IsCompleted) return;
            if (((Homework) BindingContext).DueDate < DateTime.Now)
            {
                HomeworkControlFrame.BackgroundColor = Color.Brown;
            }
            else if (((Homework) BindingContext).DueDate - TimeSpan.FromDays(3) <= DateTime.Now)
            {
                HomeworkControlFrame.BackgroundColor = Color.Yellow;
            }
        }

        private async void HomeworkControlOnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditHomeworkModalPage(true, (Homework) BindingContext));
        }
    }
}