using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private static string filePath { get; set; } = "expense.json";
        public List<string> GetAllCommands()
        {
            return [];
        }

        public int AddExpense(string description, decimal amount)
        {
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
            var expenses = GetExpensesFromJson();
            int newId = GetNextId(expenses);
            var newExpense = new Expense
            {
                Id = newId,
                Description = description,
                Amount = amount,
                CreatedAt = DateTime.Now
            };
            expenses.Add(newExpense);

            var json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            return newExpense.Id;
        }

        public int UpdateExpense(int id, string description, decimal amount)
        {
            return 1;
        }

        public int DeleteExpense(int id)
        {
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
            var expenses = GetExpensesFromJson();
            expenses.RemoveAll(x => x.Id == id);
            return id;
        }

        public List<Expense> GetAllExpense()
        {
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
            return GetExpensesFromJson();
        }

        public decimal GetExpenseSummary()
        {
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
            var expenses = GetExpensesFromJson();
            return expenses.Sum((item) => item.Amount);
        }

        public decimal GetExpenseSummary(int month)
        {
            return 1;
        }

        private static int GetNextId(List<Expense> expenses)
        {
            return expenses.Count > 0 ? expenses[^1].Id + 1 : 1; // 最後のID + 1、リストが空の場合は1
        }

        private static List<Expense> GetExpensesFromJson()
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
        }
    }
}