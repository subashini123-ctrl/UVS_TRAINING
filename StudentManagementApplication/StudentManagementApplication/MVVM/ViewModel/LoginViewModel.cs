using System.Windows.Input;

namespace StudentManagementApplication.MVVM.ViewModel;

public class LoginViewModel : BaseViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public ICommand LoginCommand { get; }

    [Obsolete]
    public LoginViewModel()
    {

        LoginCommand = new Command(async () =>
        {
            if (Username == "Suba" && Password == "1234")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.MainPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid Login", "OK");
            }
        });
    }
}

