using PersonalExpenseApp.Services;
using PersonalExpenseApp.ViewModels;

namespace PersonalExpenseApp.Views;

public partial class Category : ContentPage
{
	public Category()
	{
        InitializeComponent();
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "expense.db3");
        var db = new DatabaseService(dbPath);

        BindingContext = new CategoryViewModel(db);
    }

  
}