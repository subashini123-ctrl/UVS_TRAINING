using PersonalExpenseApp.Models;
using PersonalExpenseApp.ViewModels;

namespace PersonalExpenseApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new ExpenseViewModel();

		
	}
    
    
}