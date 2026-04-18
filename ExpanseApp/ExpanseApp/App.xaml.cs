using ExpanseApp.View;
using ExpanseApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ExpanseApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new View.Expense());

        }
    }

}