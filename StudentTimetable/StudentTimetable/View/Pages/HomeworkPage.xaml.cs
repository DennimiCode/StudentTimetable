using System;

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