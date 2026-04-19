using PersonalExpenseApp.ViewModels;
namespace PersonalExpenseApp;

public partial class Settings : ContentPage
{
    public Settings()
    {


        InitializeComponent();

        BindingContext = new SettingsViewModel();
    }

}