using Binding.demo.ViewModel;

namespace Binding.demo.View;

public partial class StudentView : ContentPage
{
	public StudentView(StudentViewModel studentViewModel)
	{
        InitializeComponent();

		BindingContext = studentViewModel;
	}
}