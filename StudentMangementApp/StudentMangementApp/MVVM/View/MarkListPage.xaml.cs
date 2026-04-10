using StudentManagementApp.MVVM.Viewmodel;

namespace StudentMangementApp.MVVM.View.Viewmodel
{
    public partial class MarkListPage : ContentPage
    {
        public MarkListPage()
        {
            InitializeComponent();

            BindingContext = new StudentViewModel();

        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
