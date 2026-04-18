using ExpanseApp.ViewModel;

namespace ExpanseApp.View;

public partial class Expense : ContentPage
{
	public Expense()
	{
		InitializeComponent();

		BindingContext = new ExpenseViewModel();
	}
}
