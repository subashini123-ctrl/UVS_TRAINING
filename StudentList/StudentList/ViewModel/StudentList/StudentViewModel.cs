using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using StudentList.Model;

namespace StudentList.ViewModel.StudentList
{
    public partial class StudentViewModel : ObservableObject
    {
        
        public ObservableCollection<StudentListModel> StudentList { get; } = new();
        public StudentViewModel()
        {
            LoadStudentData();
        }
        private void LoadStudentData()
        {
            this.StudentList.Add(new StudentListModel { Id = 1, Name = "Jegadeesh", Email = "jegdeesh03@gmail.com", Department = "EEE" } );
            this.StudentList.Add(new StudentListModel { Id = 2, Name = "Suba", Email = "suba90@gmail.com", Department = "CSE" });
            this.StudentList.Add(new StudentListModel { Id = 3, Name = "Dharshini", Email = "dharshini90@gmail.com", Department = "IT" });
        }

    }

}


