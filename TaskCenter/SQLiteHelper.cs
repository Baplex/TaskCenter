using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskCenter.Model;



namespace TaskCenter
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<TaskData>();
        }

        public Task<int> CreateTask (TaskData taskData)
        {
            return db.InsertAsync(taskData);
        }

        public Task<List<TaskData>> ReadTasks()
        {
            return db.Table<TaskData>().ToListAsync();
        }
        public Task<int> UpdateTask(TaskData taskData) { 
            return db.UpdateAsync(taskData);
        }
        public Task<int> DeleteTask(TaskData taskData)
        {
            return db.DeleteAsync(taskData);
        }
    }
}
