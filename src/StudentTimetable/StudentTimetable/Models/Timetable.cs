using System;
using SQLite;

namespace StudentTimetable.Models
{
    public class Timetable
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [NotNull] public string SubjectName { get; set; }
        [NotNull] public int Weekday { get; set; }
        [NotNull] public int OfficeNumber { get; set; }
        [NotNull] public string TeacherFullName { get; set; }
        [NotNull] public TimeSpan StartTime { get; set; }
        [NotNull] public TimeSpan EndTime { get; set; }
    }
}