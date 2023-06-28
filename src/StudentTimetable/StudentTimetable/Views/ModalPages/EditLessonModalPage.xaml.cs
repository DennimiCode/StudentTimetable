using System;
using System.Linq;

using StudentTimetable.Models;
using StudentTimetable.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.Views.ModalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLessonModalPage : ContentPage
    {
        private readonly bool _isEditMode;
        private Timetable _timetable;
        public EditLessonModalPage(bool isEditMode, Timetable timetable = null)
        {
            _isEditMode = isEditMode;
            InitializeComponent();

            WeekDayPicker.Items.Add(AppResources.MondayTextLabel);
            WeekDayPicker.Items.Add(AppResources.TuesdayTextLabel);
            WeekDayPicker.Items.Add(AppResources.WednesdayTextLabel);
            WeekDayPicker.Items.Add(AppResources.ThursdayTextLabel);
            WeekDayPicker.Items.Add(AppResources.FridayTextLabel);
            
            if (isEditMode)
            {
                LessonButton.Text = AppResources.LessonPageDeleteButton;
                TitleLabel.Text = AppResources.EditLessonPageTitle;
                BindingContext ??= timetable;
                if (timetable != null) WeekDayPicker.SelectedIndex = timetable.Weekday - 1;
            }
            else
            {
                LessonButton.Text = AppResources.LessonPageAddButton;
                TitleLabel.Text = AppResources.AddLessonPageTitle;
            }
        }

        private async void LessonButtonOnClicked(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                if ((await App.TimetableDb.GetHomeworksAsync()).Any(h => h.SubjectId == ((Timetable)BindingContext).Id))
                {
                    await DisplayAlert(AppResources.EditLessonDeleteLessonAlertTitle,
                        AppResources.EditLessonDeleteLessonAlertText, AppResources.EditLessonDeleteLessonAlertAccept);
                    return;
                }
                await App.TimetableDb.DeleteTimetableAsync((Timetable)BindingContext);
                await Navigation.PopModalAsync(true);
            }
            else
            {
                if ((Timetable)BindingContext == null)
                {
                    if (WeekDayPicker.SelectedIndex != -1 && int.TryParse(OfficeEntry.Text, out int officeNumber) &&
                        !string.IsNullOrWhiteSpace(SubjectEntry.Text) && !string.IsNullOrWhiteSpace(TeacherEntry.Text))
                    {
                        _timetable = new Timetable
                        {
                            Weekday = WeekDayPicker.SelectedIndex + 1,
                            OfficeNumber = officeNumber,
                            SubjectName = SubjectEntry.Text,
                            StartTime = StartTimeTimePicker.Time,
                            EndTime = EndTimeTimePicker.Time,
                            TeacherFullName = TeacherEntry.Text
                        };
                        
                        BindingContext = _timetable;
                        await App.TimetableDb.SaveTimetableAsync(_timetable);
                        await Navigation.PopModalAsync(true);
                    }
                    else
                    {
                        await DisplayAlert(AppResources.AddLessonCheckEntriesAlertTitle,
                            AppResources.AddLessonCheckEntriesAlertText, AppResources.AddLessonCheckEntriesAlertAccept);
                    }
                }
            }
        }
        
        private async void EditLessonModalPageOnDisappearing(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                ((Timetable)BindingContext).Weekday = WeekDayPicker.SelectedIndex + 1;
                await App.TimetableDb.SaveTimetableAsync((Timetable)BindingContext);
            }
        }
    }
}