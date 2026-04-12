using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public string NewTaskText { get; set; }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand ToggleTaskCommand { get; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();

            AddTaskCommand = new Command(AddTask);
            DeleteTaskCommand = new Command<TaskItem>(DeleteTask);
            ToggleTaskCommand = new Command<TaskItem>(ToggleTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskText))
            {
                Tasks.Add(new TaskItem
                {
                    Title = NewTaskText,
                    IsCompleted = false
                });

                NewTaskText = string.Empty;
            }
        }

        private void DeleteTask(TaskItem task)
        {
            if (Tasks.Contains(task))
                Tasks.Remove(task);
        }

        private void ToggleTask(TaskItem task)
        {
            if (task != null)
                task.IsCompleted = !task.IsCompleted;
        }
    }
}
    

