using ExpenseTrackerApp.Model;
using SQLite;

namespace ExpenseTracker.Services;

public class DatabaseService
{
    SQLiteAsyncConnection? _db;

    async Task InitAsync()
    {
        if (_db != null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "expenses.db");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Expense>();
    }

    public async Task<List<Expense>> GetAllAsync()
    {
        await InitAsync();
        return await _db!.Table<Expense>()
                         .OrderByDescending(e => e.Date)
                         .ToListAsync();
    }

    public async Task<int> AddAsync(Expense expense)
    {
        await InitAsync();
        return await _db!.InsertAsync(expense);
    }

    public async Task<int> DeleteAsync(Expense expense)
    {
        await InitAsync();
        return await _db!.DeleteAsync(expense);
    }
}