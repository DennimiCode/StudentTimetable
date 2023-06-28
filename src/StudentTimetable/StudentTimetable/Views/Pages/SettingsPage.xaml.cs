using System;
using StudentTimetable.Helpers;
using StudentTimetable.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            
            IsColorProgressionSwitch.IsToggled = Settings.ColorProgression;
            IsColorProgressionSwitch.Toggled += IsColorProgressionOnToggled;

            switch (Settings.Theme)
            {
                case 0:
                    SystemThemeRadioButton.IsChecked = true;
                    break;
                case 1:
                    LightThemeRadioButton.IsChecked = true;
                    break;
                case 2:
                    DarkThemeRadioButton.IsChecked = true;
                    break;
            }
        }

        private async void TimetableButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(false);
        }

        private async void HomeTasksButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeworkPage(), false);
        }

        private async void IsColorProgressionOnToggled(object sender, ToggledEventArgs e)
        {
            Settings.ColorProgression = IsColorProgressionSwitch.IsToggled;
            bool restartAlert = await DisplayAlert(AppResources.SaveSettingAlertTitle, AppResources.SaveSettingAlertText,
                AppResources.SaveSettingAlertYes, AppResources.SaveSettingAlertNo);

            if (restartAlert)
                Application.Current.MainPage = new NavigationPage(new TimetablePage());
        }

        private void RadioButtonOnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            string value = (sender as RadioButton)?.Value.ToString();

            switch (value)
            {
                case "System":
                    Settings.Theme = 0;
                    break;
                case "Light":
                    Settings.Theme = 1;
                    break;
                case "Dark":
                    Settings.Theme = 2;
                    break;
            }
            
            Theme.SetTheme();
        }
    }
}