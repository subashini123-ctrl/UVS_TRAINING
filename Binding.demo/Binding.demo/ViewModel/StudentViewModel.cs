using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Binding.demo.ViewModel
{
    public partial class StudentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string fullName = "Please Enter the Name";

        public StudentViewModel()
        {
        }

        [RelayCommand]
        private void GenerateName()
        {
            fullName = $"Hello, {firstName} {lastName} - RelayCommand Working";
        }
    }
}

  