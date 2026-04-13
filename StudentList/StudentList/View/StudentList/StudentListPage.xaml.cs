using StudentList.ViewModel.StudentList;

namespace StudentList.View.StudentList;

public partial class StudentListPage : ContentPage
{
	private readonly StudentViewModel _viewModel;
	public StudentListPage()
	{
		InitializeComponent();

		BindingContext=_viewModel=new StudentViewModel();
	}
}