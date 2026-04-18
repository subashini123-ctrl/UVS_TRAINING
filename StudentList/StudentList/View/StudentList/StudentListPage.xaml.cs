using CommunityToolkit.Maui.Views;
using StudentList.ViewModel;

namespace StudentList.ViewModel.StudentList;

public partial class StudentListPage : ContentPage
{
	private readonly StudentViewModel   _viewModel;
	public StudentListPage()
	{
		InitializeComponent();

		BindingContext = _viewModel =  new StudentViewModel();

	}
	protected override void OnAppearing()
	{
		base.OnAppearing();

		_viewModel.ShowPopup += vm_ShowPopup;
		
    }
	private async void vm_ShowPopup( object sender, Popup Popup)
	{
		await this.ShowPopupAsync(Popup);
	}
}