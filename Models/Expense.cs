namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id {get; set;}
        public string Description {get; set;} = string.Empty;
        public decimal Amount {get; set;}
        public DateTime CreatedAt {get; set;}
        public string Category {get; set;} = string.Empty;
    }
}