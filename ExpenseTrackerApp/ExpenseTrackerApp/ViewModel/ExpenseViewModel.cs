using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Services;
using ExpenseTrackerApp.Model;
using System.Collections.ObjectModel;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel : ObservableObject
{
    readonly DatabaseService _db;

    [ObservableProperty] double totalBalance;
    [ObservableProperty] double totalIncome;
    [ObservableProperty] double totalExpenses;

    public ObservableCollection<Expense> Expenses { get; } = new();

    public MainViewModel(DatabaseService db)
    {
        _db = db;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        var list = await _db.GetAllAsync();
        Expenses.Clear();
        foreach (var e in list) Expenses.Add(e);

        TotalIncome = list.Where(e => e.IsIncome).Sum(e => e.Amount);
        TotalExpenses = list.Where(e => !e.IsIncome).Sum(e => e.Amount);
        TotalBalance = TotalIncome - TotalExpenses;
    }

    [RelayCommand]
    public async Task DeleteExpense(Expense expense)
    {
        await _db.DeleteAsync(expense);
        await LoadDataAsync();
    }

    [RelayCommand]
    public async Task GoToAddExpense()
    {
        await Shell.Current.GoToAsync("AddExpensePage");
    }
}