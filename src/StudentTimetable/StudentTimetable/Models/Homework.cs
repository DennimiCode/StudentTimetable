using System;
using SQLite;

namespace StudentTimetable.Models
{
    public class Homework
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [NotNull] public int SubjectId { get; set; }
        [NotNull] public string Text { get; set; }
        [NotNull] public bool IsCompleted { get; set; }
        [NotNull] public DateTime DueDate { get; set; }
    }
}