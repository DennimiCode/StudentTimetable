using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentTimetable.View.ModalPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDayElementModalPage : ContentPage
    {
        public enum ElementType
        {
            CourseLabel,
            OfficeLabel,
            TeacherLabel,
            ClassTypeLabel,
        }

        public EditDayElementModalPage(ElementType elementType)
        {
            InitializeComponent();

            switch (elementType)
            {
                case ElementType.CourseLabel:
                    break;
                case ElementType.OfficeLabel:
                    break;
                case ElementType.TeacherLabel:
                    break;
                case ElementType.ClassTypeLabel:
                    break;
            }
        }
    }
}