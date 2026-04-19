using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Services;
using ExpenseTrackerApp.Model;

namespace ExpenseTrackerApp.ViewModel;

public partial class AddExpenseViewModel : ObservableObject
{
    readonly DatabaseService _db;

    [ObservableProperty] string title = string.Empty;
    [ObservableProperty] string amountText = string.Empty;
    [ObservableProperty] string selectedCategory = "Food";
    [ObservableProperty] bool isIncome;
    [ObservableProperty] DateTime date = DateTime.Now;
    [ObservableProperty] string note = string.Empty;

    public List<string> Categories { get; } =
        new() { "Food", "Transport", "Shopping", "Bills", "Health", "Income", "Other" };

    public AddExpenseViewModel(DatabaseService db) => _db = db;

    [RelayCommand]
    async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Title) ||
            !double.TryParse(AmountText, out double amount) || amount <= 0)
        {
            await Shell.Current.DisplayAlert("Error", "Enter a valid title and amount.", "OK");
            return;
        }

        await _db.AddAsync(new Expense
        {
            Title = title,
            Amount = amount,
            Category = selectedCategory,
            IsIncome = isIncome,
            Date = date,
            Note = note
        });

        await Shell.Current.GoToAsync("..");
    }
}
