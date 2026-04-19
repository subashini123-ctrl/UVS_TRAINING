using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace PersonalExpenseApp.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged


    {
        public string UserName { get; set; }

        public ICommand SaveProfileCommand => new Command(SaveProfile);
        private void ApplyTheme(bool dark)
        {
            Preferences.Set("Darkmode", dark);

            Application.Current.UserAppTheme =
                dark ? AppTheme.Dark : AppTheme.Light;
        }

        public SettingsViewModel()
        {
            
            UserName = Preferences.Get("username", "");
        }
        private bool IsDarkMode
        
        { 
            get => IsDarkMode;
            set
            {
                if (IsDarkMode != value)
                {
                    IsDarkMode = value;
                    OnPropertyChanged();
                    ApplyTheme(value);
                }
            }
        }


        private void SaveProfile()
        {
            Preferences.Set("username", UserName);

            Application.Current.MainPage.DisplayAlert(
                "Saved",
                "Profile updated successfully",
                "OK");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }

    
}

