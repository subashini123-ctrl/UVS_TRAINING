using ToDoListApp.MVVM.View;

namespace ToDoApp
{
    public partial class App : Application
    {
        protected override void OnStart()
        {
            base.OnStart();

            MainWindow window = new MainWindow();
            window.Show();
        }
    }   
}