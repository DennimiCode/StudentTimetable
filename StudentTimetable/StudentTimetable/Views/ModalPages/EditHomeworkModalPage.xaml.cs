using System;
using System.Linq;
using StudentTimetable.Models;
using StudentTimetable.Resources;
using StudentTimetable.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.Views.ModalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHomeworkModalPage : ContentPage
    {
        private readonly bool _isEditMode;
        private readonly Homework _homework;
        public EditHomeworkModalPage(bool isEditMode, Homework homework = null)
        {
            _isEditMode = isEditMode;
            _homework = homework;
            InitializeComponent();
            EditHomeworkModalPageOnLoading();
        }

        private async void EditHomeworkModalPageOnLoading()
        {
            foreach (var timetable in (await App.TimetableDb.GetTimetablesAsync()).OrderBy(timetable => timetable.Id))
                SubjectPicker.Items.Add(timetable.SubjectName);
            
            if (_isEditMode)
            {
                HomeworkButton.Text = AppResources.HomeworkPageModalDeleteButton;
                TitleLabel.Text = AppResources.HomeworkEdtPageModalTitle;
                BindingContext ??= _homework;
                SubjectPicker.SelectedIndex = _homework.SubjectId - 1;
            }
            else
            {
                HomeworkButton.Text = AppResources.HomeworkPageModalAddButton;
                TitleLabel.Text = AppResources.HomeworkAddModalPageTitle;
            }
        }

        private async void HomeworkButtonOnClicked(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                await App.TimetableDb.DeleteHomeworkAsync((Homework) BindingContext);
                await Navigation.PopModalAsync(true);
            }
            else
            {
                if (SubjectPicker.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(HomeworkTextEntry.Text))
                {
                    Homework homework = new Homework
                    {
                        Text = HomeworkTextEntry.Text,
                        SubjectId = SubjectPicker.SelectedIndex + 1,
                        IsCompleted = IsCompletedCheckBox.IsChecked,
                        DueDate = DueDateDatePicker.Date
                    };
                    BindingContext = homework;
                    await App.TimetableDb.SaveHomeworkAsync((Homework) BindingContext);
                    await Navigation.PopModalAsync(true);
                }
                else
                {
                    await DisplayAlert(AppResources.EditHomeworkCheckEntriesAlertTitle,
                        AppResources.EditHomeworkCheckEntriesAlertText,
                        AppResources.EditHomeworkCheckEntriesAlertAccept);
                }
            }
        }

        private async void EditHomeworkModalPageOnDisappearing(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                await App.TimetableDb.SaveHomeworkAsync((Homework) BindingContext);
            }
        }
    }
}