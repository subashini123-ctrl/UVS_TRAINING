using SQLite;

namespace ExpenseTrackerApp.Model
{
    public class Expense
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Category { get; set; } = "Other";
        public bool IsIncome { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Note { get; set; } = string.Empty;

        public string AmountDisplay =>
       IsIncome ? $"+₹{Amount:N2}" : $"-₹{Amount:N2}";

        public Color AmountColor =>
            IsIncome ? Colors.Green : Colors.Red;



    }
}
