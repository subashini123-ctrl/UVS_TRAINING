using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ToDoListApp.MVVM.Model;

namespace ToDoListApp.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Task list — UI auto-refresh ■■■■■
        public ObservableCollection<ToDoItem> TodoItems { get; set; }
        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set { _newTaskTitle = value; OnPropertyChanged(nameof(NewTaskTitle)); }
        }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public MainViewModel()  
        {
            TodoItems = new ObservableCollection<ToDoItem>();
            // TextBox empty-■ ■■■■■■■■■ Add disable ■■■■■
            AddCommand = new RelayCommand(
            AddTask,
            _ => !string.IsNullOrWhiteSpace(NewTaskTitle));
            DeleteCommand = new RelayCommand(DeleteTask);
        }
        // ADD — ■■■■■■ task ■■■■■■■■■■
        private void AddTask(object obj)
        {
            TodoItems.Add(new ToDoItem { Title = NewTaskTitle });
            NewTaskTitle = string.Empty; // TextBox clear
        }
        // DELETE — selected task remove
        private void DeleteTask(object obj)             
        {
            if (obj is ToDoItem item)
                TodoItems.Remove(item);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
