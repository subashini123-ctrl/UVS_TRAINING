using PersonalExpenseApp.ViewModels;

namespace PersonalExpenseApp.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();

		try
		{
			BindingContext = new ExpenseViewModel();
		}
		catch(Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex.Message);
		}

    }
}