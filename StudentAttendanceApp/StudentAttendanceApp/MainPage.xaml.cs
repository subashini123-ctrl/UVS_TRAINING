using CommunityToolkit.Maui.Views;

namespace StudentAttendanceApp;



public partial class MainPage : ContentPage
{
    StudentViewModel vm;

    public MainPage()
    {
        InitializeComponent();

        vm = new StudentViewModel();
        BindingContext = vm;

        vm.ShowPopupAction += ShowPopup; 
    }

 
    private async void ShowPopup()
    {
        var popup = new StudentPopup(); 

        var result = await this.ShowPopupAsync(popup);

        if (result != null)
        {
            vm.Name = result.ToString();
            vm.AddCommand.Execute(null); 
        }
    }
}