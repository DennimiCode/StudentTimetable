﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudentTimetable.Helpers;

namespace StudentTimetable.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            
            IsColorProgressionSwitch.IsToggled = Settings.ColorProgression;

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

        private void IsColorProgressionOnToggled(object sender, ToggledEventArgs e)
        {
            Settings.ColorProgression = IsColorProgressionSwitch.IsToggled;
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