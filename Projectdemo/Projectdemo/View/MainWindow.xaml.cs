using Projectdemo.ViewModel;

namespace Projectdemo.View;

public partial class MainWindow : ContentPage
{
	public MainWindow()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
    }
}