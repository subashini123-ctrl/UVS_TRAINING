using ExpanseApp.Services;
using ExpanseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ExpanseApp.ViewModel
{
    public class ExpenseViewModel :  BindableObject
    {
        private readonly ExpenseService _service;

        public ObservableCollection<Expense> Expenses { get; set; } = new();

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ExpenseViewModel()
        {
            _service = new ExpenseService();
            

            LoadCommand = new Command(LoadExpenses);
            AddCommand = new Command(async () => await Shell.Current.GoToAsync("AddExpensePage"));
            DeleteCommand = new Command<Expense>(DeleteExpense);
        }

        void LoadExpenses()
        {
            Expenses.Clear();
            var list = _service.GetExpenses();

            foreach (var item in list)
                Expenses.Add(item);
        }

        void DeleteExpense(Expense expense)
        {
            _service.DeleteExpense(expense);
            LoadExpenses();
        }
    }
}
    

