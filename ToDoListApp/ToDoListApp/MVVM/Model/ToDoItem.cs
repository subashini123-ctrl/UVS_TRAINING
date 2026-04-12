using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDoListApp.MVVM.Model
{
    public class ToDoItem : INotifyPropertyChanged
    {
        private string _Title;
        private bool _IsCompleted;
        private bool _isCompleted;

        public string Title
        {
            get => _Title;
            set { _Title = value; OnPropertyChanged(nameof(Title)); }
        }
        public bool IsCompleted
        {
            get => _IsCompleted;
            set { _isCompleted = value; OnPropertyChanged(nameof(IsCompleted)); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}