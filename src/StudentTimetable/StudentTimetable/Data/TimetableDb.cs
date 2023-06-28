using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using StudentTimetable.Models;

namespace StudentTimetable.Data
{
    public class TimetableDb
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public TimetableDb(string connectionString)
        {
            _dbConnection = new SQLiteAsyncConnection(connectionString);
            _dbConnection.CreateTableAsync<Homework>().Wait();
            _dbConnection.CreateTableAsync<Timetable>().Wait();
        }

        public Task<List<Timetable>> GetTimetablesAsync()
        {
            return _dbConnection.Table<Timetable>().ToListAsync();
        }

        public Task<List<Homework>> GetHomeworksAsync()
        {
            return _dbConnection.Table<Homework>().ToListAsync();
        }

        public Task<Timetable> GetTimetableAsync(int id)
        {
            return _dbConnection.Table<Timetable>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<Homework> GetHomeworkAsync(int id)
        {
            return _dbConnection.Table<Homework>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveTimetableAsync(Timetable timetable)
        {
            if (timetable.Id != 0)
                return _dbConnection.UpdateAsync(timetable);
            return _dbConnection.InsertAsync(timetable);
        }

        public Task<int> SaveHomeworkAsync(Homework homework)
        {
            if (homework.Id != 0)
                return _dbConnection.UpdateAsync(homework);
            return _dbConnection.InsertAsync(homework);
        }

        public Task<int> DeleteTimetableAsync(Timetable timetable)
        {
            return _dbConnection.DeleteAsync(timetable);
        }
        
        public Task<int> DeleteHomeworkAsync(Homework homework)
        {
            return _dbConnection.DeleteAsync(homework);
        }
    }
}