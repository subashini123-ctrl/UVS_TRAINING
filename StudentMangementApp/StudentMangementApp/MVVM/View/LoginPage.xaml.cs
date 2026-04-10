using StudentManagementApp;
using StudentManagementApp.MVVM.ViewModel;

namespace StudentMangementApp.MVVM.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}