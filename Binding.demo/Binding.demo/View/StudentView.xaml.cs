using Binding.demo.ViewModel;

namespace Binding.demo.View;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();

		// Use the view model from DI if available, otherwise create a new one
		var vm = Microsoft.Maui.Controls.Application.Current?.Handler?.MauiContext?.Services?.GetService(typeof(StudentViewModel)) as StudentViewModel;
		if (vm is null)
			vm = new StudentViewModel();

		BindingContext = vm;
	}
}
