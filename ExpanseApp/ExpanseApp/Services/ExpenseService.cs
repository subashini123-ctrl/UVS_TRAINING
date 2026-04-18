using ExpanseApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpanseApp.Services
{
    public class ExpenseService
    {
        private static List<Expense> _expenses = new();
        private static int _id = 1;

        public List<Expense> GetExpenses()
        {
            return _expenses;
        }

        public void AddExpense(Expense expense)
        {
            expense.Id = _id++;
            _expenses.Add(expense);
        }

        public void DeleteExpense(Expense expense)
        {
            _expenses.Remove(expense);
        }
    }
}
