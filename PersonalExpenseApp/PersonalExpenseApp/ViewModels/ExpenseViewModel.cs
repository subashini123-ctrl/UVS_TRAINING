using Microcharts;
using PersonalExpenseApp.Models;
using PersonalExpenseApp.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;


namespace PersonalExpenseApp.ViewModels
{
    public class ExpenseViewModel : BindableObject
    {
        DatabaseService db = new DatabaseService();

        public ObservableCollection<Expense> Expenses { get; set; } = new();

        public string Title { get; set; }
        public double Amount { get; set; }

       

        public List<string> Categories { get; set; } =
            new() { "Food", "Travel", "Shopping", "Bills" , "StationaryItems" };

        public string SelectedCategory { get; set; }
        public DateTime SelectedDate { get; set; } = DateTime.Now;

     

        public double Total => Expenses.Sum(x => x.Amount);

        public double TodayTotal =>
            Expenses.Where(x => x.Date.Date == DateTime.Today).Sum(x => x.Amount);

        public double MonthlyTotal =>
            Expenses.Where(x => x.Date.Month == DateTime.Now.Month).Sum(x => x.Amount);

        public List<Expense> RecentExpenses =>
            Expenses.OrderByDescending(x => x.Date).Take(3).ToList();
        public Expense SelectedExpense {  get; set; }
       
        public Chart ExpenseChart { get; set; }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ExpenseViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            AddCommand = new Command(async () => await Add());

            

            DeleteCommand = new Command<Expense>(async (e) => await Delete(e));

            Load();
        }

        

        async void Load()
        {
            Expenses.Clear();
            var list = await db.GetAll();

            Expenses.Clear();
            foreach (var item in list)
                Expenses.Add(item);

            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(TodayTotal));
            OnPropertyChanged(nameof(MonthlyTotal));
            OnPropertyChanged(nameof(RecentExpenses));

            GenerateChart();
        }
       
        

        async Task Add()
        {
            var exp = new Expense
            {
                Title = Title,
                Amount = Amount,
                Category = SelectedCategory,
                Date = SelectedDate
            };

            await db.Add(exp);
            Load();

            Title = "";
            Amount = 0;
            string Category = SelectedCategory;

            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Amount));
            OnPropertyChanged(nameof(Category));
        }

        async Task Delete(Expense e)
        {
            await db.Delete(e);
            Load();
        }

        void GenerateChart()
        {
            var data = Expenses
                .GroupBy(x => x.Date.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Total = g.Sum(x => x.Amount)
                })
                .ToList();

            var entries = new List<ChartEntry>();

            foreach (var item in data)
            {
                entries.Add(new ChartEntry((float)item.Total)
                {
                    Label = new DateTime(2024, item.Month, 1).ToString("MMM"),
                    ValueLabel = item.Total.ToString(),
                    Color = SkiaSharp.SKColor.Parse("#4CAF50")
                });
            }

            ExpenseChart = new BarChart
            {
                Entries = entries
            };
            OnPropertyChanged(nameof(ExpenseChart));
        }
    }
}
