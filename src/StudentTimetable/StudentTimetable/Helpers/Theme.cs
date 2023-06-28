using Xamarin.Forms;

namespace StudentTimetable.Helpers
{
    public static class Theme
    {
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }
    }
}