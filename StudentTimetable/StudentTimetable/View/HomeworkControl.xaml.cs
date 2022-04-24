using System;

using StudentTimetable.View.ModalPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeworkControl : ContentView
    {
        public readonly bool IsCompleted;
        public HomeworkControl(string title, string courseName, DateTime dueDate, bool isCompleted)
        {
            InitializeComponent();
            TitleLabel.Text = title;
            CourseNameLabel.Text = courseName;
            DueDateLabel.Text = dueDate.ToShortDateString();
            IsCompleted = isCompleted;

            if (isCompleted) return;
            if (dueDate < DateTime.Now)
            {
                HomeworkControlFrame.BackgroundColor = Color.Brown;
            }
            else if (dueDate - TimeSpan.FromDays(3) <= DateTime.Now)
            {
                HomeworkControlFrame.BackgroundColor = Color.Yellow;
            }
        }

        private async void HomeworkControlOnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditHomeworkModalPage());
        }
    }
}