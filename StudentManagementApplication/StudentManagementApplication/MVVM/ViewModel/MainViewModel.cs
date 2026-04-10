using StudentManagementApplication.MVVM.Model;
using System.Collections.ObjectModel;

namespace StudentManagementApplication.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel

    {
        public ObservableCollection<Student> Students { get; set; }

        public MainViewModel()
        {
            Students = new ObservableCollection<Student>
        {
            new Student { Name="Arun", RegisterNumber="101", Department="CSE", Tamil=80, English=75, Mathematics=90 },
            new Student { Name="Kumar", RegisterNumber="102", Department="IT", Tamil=70, English=65, Mathematics=85 }
        };
        }
    }
}

