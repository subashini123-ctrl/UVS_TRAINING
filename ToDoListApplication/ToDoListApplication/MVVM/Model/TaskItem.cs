using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDoListApplication.MVVM.Model
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        private bool isCompleted;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
