using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public interface IExpenseService
    {
        List<string> GetAllCommands(); 
        int AddExpense(string description, decimal amount);
        int UpdateExpense(int id, string description, decimal amount);
        int DeleteExpense(int id);
        List<Expense> GetAllExpense();
        decimal GetExpenseSummary();
        decimal GetExpenseSummary(int month);
    }
}