using Projectdemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Projectdemo.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<TaskItem> Tasks { get; set; }

        private string _newTask = "";
        public string NewTask
        {
            get => _newTask;
            set
            {
                _newTask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewTask)));
            }
        }

        public ICommand AddTaskCommand { get; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();

            AddTaskCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(NewTask))
                {
                    Tasks.Add(new TaskItem { Title = NewTask });
                    NewTask = "";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewTask)));
                }
            });
        }
    }
}
