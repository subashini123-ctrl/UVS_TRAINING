using StudentManagementApplication.MVVM.ViewModel;

namespace StudentManagementApplication.MVVM.View;

public partial class MainPage : TabbedPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();

    }
}