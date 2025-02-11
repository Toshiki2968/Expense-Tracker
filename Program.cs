using ExpenseTracker.Services;
using ExpenseTracker.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

// サービスのDI登録
var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IExpenseService, ExpenseService>();
var serviceProvider = serviceCollection.BuildServiceProvider();
var _expenseService = serviceProvider.GetService<IExpenseService>();

ConsoleMessage.PrintWelcomeMessage();
var command = Console.ReadLine();

if (string.IsNullOrEmpty(command))
{
    ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
    return;
}

var commands = command.Split(" ");
if (commands[0] != "expense-tracker")
{
    ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
    return;
}

switch (commands[1])
{
    case "add":
        if (commands[2] != "--description")
        {
            ConsoleMessage.PrintErrorMessage("--descriptionを付けてください。");
            break;
        }
        Console.WriteLine(commands[4]);
        if (commands[4] != "--amount")
        {
            ConsoleMessage.PrintErrorMessage("--amountをつけてください。");
            return;
        }
        Decimal.TryParse(commands[5], out var amount);
        var id = _expenseService?.AddExpense(commands[3].Replace("\"", ""), amount);
        ConsoleMessage.PrintCommandMessage($"Expense added successfully (ID: {id})");
        break;
    case "list":
        var expenses = _expenseService?.GetAllExpense();
        if (expenses == null) return;

        Console.WriteLine("ID   Date        Description  Amount");
        foreach (var expense in expenses)
        {
            Console.WriteLine($"{expense.Id,-4} {expense.CreatedAt:yyyy-MM-dd}  {expense.Description,-12} ${expense.Amount}");
        }
        break;
    case "summary":
        var summary = _expenseService?.GetExpenseSummary();
        ConsoleMessage.PrintCommandMessage($"Total expenses: ${summary}");
        break;
    case "delete":
        if (commands[2] != "--id")
        {
            ConsoleMessage.PrintErrorMessage("--idを付けてください。");
            break;
        }
        Int32.TryParse(commands[3], out var deleteExpenseId);
        if (deleteExpenseId == 0) return;
        _expenseService?.DeleteExpense(deleteExpenseId);
        break;
    default:
        break;
}






