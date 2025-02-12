using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public interface IExpenseService
    {
        int AddExpense(string description, decimal amount, string Category);
        int DeleteExpense(int id);
        List<Expense> GetAllExpense();
        decimal GetExpenseSummary();
        decimal GetExpenseSummary(int month);
        List<Expense> GetExpenseByCategory(string category);
    }
}