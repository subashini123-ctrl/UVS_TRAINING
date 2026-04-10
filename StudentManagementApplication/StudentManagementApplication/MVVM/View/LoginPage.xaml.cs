using StudentManagementApplication.MVVM.ViewModel;

namespace StudentManagementApplication.MVVM.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        BindingContext = new LoginViewModel();
    }
}