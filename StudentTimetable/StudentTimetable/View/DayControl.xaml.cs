using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace StudentTimetable.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayControl : ContentView
    {
        public DateTime StartTime;
        public readonly int DayOfWeek;
        public DayControl(string startTime = "", string endTime = "", string subject = "", string office = "", string teacher = "", int dayOfWeek = 0)
        {
            InitializeComponent();
            StartTime = Convert.ToDateTime(startTime);
            DayOfWeek = dayOfWeek;
            StartTimeLabel.Text = startTime;
            EndTimeLabel.Text = endTime;
            SubjectLabel.Text = subject;
            OfficeLabel.Text = office;
            TeacherLabel.Text = teacher;

            if (Preferences.Get("IsColorProgression", true) == true && Convert.ToInt32(DateTime.Now.DayOfWeek) == dayOfWeek)
            {
                DateTime endDateTime = Convert.ToDateTime(endTime);
                DateTime startDateTime = Convert.ToDateTime(startTime);

                if (DateTime.Now > endDateTime)
                    DayControlFrame.BackgroundColor = Color.FromHex("#822c2b");
                else if (DateTime.Now >= startDateTime && DateTime.Now <= endDateTime)
                    DayControlFrame.BackgroundColor = Color.FromHex("#52992e");
                else if (DateTime.Now < startDateTime)
                    DayControlFrame.BackgroundColor = Color.FromHex("#57595c");
            }
        }
    }
}