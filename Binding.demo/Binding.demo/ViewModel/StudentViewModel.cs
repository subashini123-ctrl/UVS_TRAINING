using Binding.demo.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binding.demo.ViewModel
{
    public  partial class StudentViewModel : ObservableObject

    {
        private Student _student;

        private string _FirstName;

        public string FirstName
        {
            get => _student.FirstName;

            set
            {
                if (_student.FirstName != value)
                {
                    _student.FirstName = value;

                }

            }

        }
        public string LastName
        { 
            get => _student.LastName;

            set
            {
                if (_student.LastName != value)
                {
                    _student.LastName = value;
                }
            }   
        }
        private string _FullName = "Please Enter the Name";

        public string  FullName
        {
            get => _FullName;

            set
            {
                if (_FullName != value)
                {
                    _FullName = value;
                    //OnPropertyChanged();
                }
            }
        }
        
        public StudentViewModel()
        {
            _student = new Student();
                
        }
        private void GenerteName()
        {
            FullName = $"Hello,{FirstName}{LastName}RelayCommand Working";
        }


        
    
    }
}

  