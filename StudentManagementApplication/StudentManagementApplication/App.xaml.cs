namespace StudentManagementApplication;

using StudentManagementApplication.MVVM.View;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();


        MainPage = new NavigationPage(new LoginPage());
    }


}