using ExpenseTracker.ViewModels;
using ExpenseTrackerApp.ViewModel;

namespace ExpenseTracker.Views;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage(AddExpenseViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OnTypeChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is AddExpenseViewModel vm && sender is RadioButton rb)
        {
            vm.IsIncome = rb.Content?.ToString() == "Income" && e.Value;
        }
    }
}