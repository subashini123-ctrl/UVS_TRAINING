using Microsoft.Extensions.DependencyInjection;
using Projectdemo.View;

namespace Projectdemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainWindow());
        }
    }
}