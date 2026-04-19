using PersonalExpenseApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseApp.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null) return;

            var dbpath = Path.Combine(FileSystem.AppDataDirectory, "expense.db");
            db = new SQLiteAsyncConnection(dbpath);

            await db.CreateTableAsync<Expense>();
        }
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Category>().Wait();
        }

        public DatabaseService()
        {
        }

        public Task<List<Category>> GetCategories()
            => _db.Table<Category>().ToListAsync();

        
        public Task<int> AddCategory(Category category)
            => _db.InsertAsync(category);

       
        public Task<int> DeleteCategory(Category category)
            => _db.DeleteAsync(category);


        public async Task<List<Expense>> GetAll()
        {
            await Init();
            return await db.Table<Expense>().ToListAsync();
        }

        public async Task Add(Expense e)
        {
            await Init();
            await db.InsertAsync(e);
        }

        public async Task Delete(Expense e)
        {
            await Init();
            await db.DeleteAsync(e);
        }
    }
}
