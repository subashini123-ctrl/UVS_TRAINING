using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudentManagementApp.MVVM.ViewModel
{
    internal class LoginViewModel

    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                if (Username == "admin" && Password == "1234")
                {

                    await Shell.Current.GoToAsync("//main");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Login", "OK");
                }
            });
        }
    }
}
