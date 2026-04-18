using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentList.Model;
using StudentList.View.StudentList;

namespace StudentList.ViewModel.StudentList
{
    public partial class StudentViewModel : ObservableObject
    {
       private readonly StudentPopup _studentPopup;


        [ObservableProperty]
        private ObservableCollection<StudentListModel> _studentList = new();

        public event EventHandler<Popup> ShowPopup;

        public ObservableCollection<StudentListModel> StudentList
        {
            get => _studentList;
            set => SetProperty(ref _studentList, value);
        }
        public StudentViewModel(StudentPopup studentPopup)
        {
            _studentPopup = studentPopup;
               LoadStudentData();
        }

        public StudentViewModel()
        {
        }

        private void LoadStudentData()
        {
            _studentList.Add(new StudentListModel { Id = 1, Name = "Jegadeesh", Email = "jegdeesh03@gmail.com", Department = "EEE" } );
            _studentList.Add(new StudentListModel { Id = 2, Name = "Suba", Email = "suba90@gmail.com", Department = "CSE" });
            _studentList.Add(new StudentListModel { Id = 3, Name = "Dharshini", Email = "dharshini90@gmail.com", Department = "IT" });
           
        }
        [RelayCommand]

        private void AddStudent()
        {
            ShowPopup?.Invoke(this, _studentPopup);
        }


    }

}


