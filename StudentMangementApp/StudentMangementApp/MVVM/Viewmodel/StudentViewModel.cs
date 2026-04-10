using StudentManagementApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudentManagementApp.MVVM.Viewmodel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>
        {
            new Student { Name="Arun", Mathematics=80, Physics=75, Chemistry=85 },
            new Student { Name="Priya", Mathematics=90, Physics=88, Chemistry=92 }
        };
        }
    }
}

