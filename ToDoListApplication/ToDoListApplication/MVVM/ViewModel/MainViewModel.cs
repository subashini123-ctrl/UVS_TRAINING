using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ToDoListApplication.MVVM.Model;

namespace ToDoListApplication.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string newTask;

        public string NewTask
        {
            get => newTask;
            set
            {
                newTask = value;
                OnPropertyChanged(nameof(NewTask));
            }
        }

        public ObservableCollection<TaskItem> Tasks { get; set; }

        public RelayCommand AddTaskCommand { get; }
        public RelayCommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();

            AddTaskCommand = new RelayCommand(AddTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        private void AddTask(object obj)
        {
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                Tasks.Add(new TaskItem { Title = NewTask });
                NewTask = "";
            }
        }

        private void DeleteTask(object obj)
        {
            if (obj is TaskItem task)
            {
                Tasks.Remove(task);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
