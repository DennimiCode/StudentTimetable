using System;

using StudentTimetable.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.View.ModalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLessonModalPage : ContentPage
    {
        public EditLessonModalPage(bool editMode)
        {
            InitializeComponent();

            if (editMode)
            {
                LessonButton.Text = AppResources.LessonPageDeleteButton;
                TitleLabel.Text = AppResources.EditLessonPageTitle;
            }
            else
            {
                LessonButton.Text = AppResources.LessonPageAddButton;
                TitleLabel.Text = AppResources.AddLessonPageTitle;
            }
        }

        private void LessonButtonOnClicked(object sender, EventArgs e)
        {
            
        }

        private async void EditCardOnTapped(object sender, EventArgs e)
        {
            if (MainStackLayout.FindByName("Course") as Frame == sender as Frame)
            {
                await Navigation.PushModalAsync(new EditDayElementModalPage(EditDayElementModalPage.ElementType.CourseLabel));
            }
            else if (MainStackLayout.FindByName("Office") as Frame == sender as Frame)
            {
                await Navigation.PushModalAsync(new EditDayElementModalPage(EditDayElementModalPage.ElementType.OfficeLabel));
            }
            else if (MainStackLayout.FindByName("WeekDay") as Frame == sender as Frame)
            {
                
            }
            else if (MainStackLayout.FindByName("StartTime") as Frame == sender as Frame)
            {
                
            }
            else if (MainStackLayout.FindByName("EndTime") as Frame == sender as Frame)
            {
                
            }
            else if (MainStackLayout.FindByName("Teacher") as Frame == sender as Frame)
            {
                await Navigation.PushModalAsync(new EditDayElementModalPage(EditDayElementModalPage.ElementType.TeacherLabel));
            }
            else if (MainStackLayout.FindByName("ClassType") as Frame == sender as Frame)
            {
                await Navigation.PushModalAsync(new EditDayElementModalPage(EditDayElementModalPage.ElementType.ClassTypeLabel));
            }
        }
    }
}