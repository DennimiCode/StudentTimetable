using Xamarin.Essentials;

namespace StudentTimetable.Helpers
{
    public static class Settings
    {
        private const int _Theme = 0;
        private const bool _ColorProgression = true;

        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), _Theme);
            set => Preferences.Set(nameof(Theme), value);
        }

        public static bool ColorProgression
        {
            get => Preferences.Get(nameof(ColorProgression), _ColorProgression);
            set => Preferences.Set(nameof(ColorProgression), value);
        }
    }
}