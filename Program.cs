using System.Globalization;
using ExpenseTracker.Services;
using ExpenseTracker.Utilities;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    /// <summary>
    /// 経費サービス
    /// </summary>
    private static IExpenseService? _expenseService;

    /// <summary>
    /// メイン処理
    /// </summary>
    static void Main()
    {

        // サービスのDI登録
        ConfigureServices();

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
        ProcessCommand(commands);
    }

    static void ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IExpenseService, ExpenseService>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        _expenseService = serviceProvider.GetService<IExpenseService>();
    }

    static void ProcessCommand(string[] commands)
    {
        if (commands.Length < 2)
        {
            ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
            return;
        }

        switch (commands[1])
        {
            case "add":
                HandleAddCommand(commands);
                break;
            case "list":
                HandleListCommand(commands);
                break;
            case "summary":
                HandleSummaryCommand(commands);
                break;
            case "delete":
                HandleDeleteCommand(commands);
                break;
            default:
                ConsoleMessage.PrintErrorMessage("不明なコマンドです。");
                break;
        }
    }

    /// <summary>
    /// 経費追加コマンド
    /// </summary>
    /// <param name="commands"></param>
    private static void HandleAddCommand(string[] commands)
    {
        if (!IsHandleAddCommandCorrect(8, commands))
        {
            return;
        }

        var description = commands[3].Trim('"');
        var amount = Decimal.Parse(commands[5]);
        var category = commands[7].Trim('"');

        var id = _expenseService?.AddExpense(description, amount, category);
        ConsoleMessage.PrintCommandMessage($"Expense added successfully (ID: {id})");
    }

    /// <summary>
    /// 経費追加コマンドチェック
    /// </summary>
    /// <param name="requiredLength"></param>
    /// <param name="commands"></param>
    /// <returns></returns>
    private static bool IsHandleAddCommandCorrect(int requiredLength, string[] commands)
    {
        if (commands.Length != requiredLength)
        {
            ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
            return false;
        }
        if (commands[2] != "--description")
        {
            ConsoleMessage.PrintErrorMessage("--descriptionを付けてください。");
            return false;
        }
        if (commands[4] != "--amount")
        {
            ConsoleMessage.PrintErrorMessage("--amountをつけてください。");
            return false;
        }
        if (commands[6] != "--category")
        {
            ConsoleMessage.PrintErrorMessage("--categoryをつけてください。");
            return false;
        }
        if (!Decimal.TryParse(commands[5], out _))
        {
            ConsoleMessage.PrintErrorMessage("金額の形式が不正です。");
            return false;
        }
        return true;
    }

    /// <summary>
    /// 経費削除コマンド
    /// </summary>
    /// <param name="commands"></param>
    private static void HandleDeleteCommand(string[] commands)
    {

        if (!IsHandleDeleteCommandCorrect(4, commands))
        {
            return;
        }
        var id = Int32.Parse(commands[3]);
        _expenseService?.DeleteExpense(id);
    }

    /// <summary>
    /// 経費削除コマンドチェック
    /// </summary>
    /// <param name="requiredLength"></param>
    /// <param name="commands"></param>
    /// <returns></returns>
    private static bool IsHandleDeleteCommandCorrect(int requiredLength, string[] commands)
    {
        if (commands.Length != requiredLength)
        {
            ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
            return false;
        }
        if (commands[2] != "--id")
        {
            ConsoleMessage.PrintErrorMessage("--idを付けてください。");
            return false;
        }
        if (!Int32.TryParse(commands[3], out _))
        {
            ConsoleMessage.PrintErrorMessage("idの形式が不正です。");
            return false;
        }
        return true;
    }

    private static void HandleSummaryCommand(string[] commands)
    {
        if (commands.Count() == 2)
        {
            var totalSummary = _expenseService?.GetExpenseSummary();
            ConsoleMessage.PrintCommandMessage($"Total expenses: ${totalSummary}");
            return;
        }

        if (!IsHandleSummaryCommandCorrect(4, commands))
        {
            return;
        }
        var month = Int32.Parse(commands[3]);
        var summary = _expenseService?.GetExpenseSummary(month);
        var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        ConsoleMessage.PrintCommandMessage($"Total expenses for {monthName}: ${summary}");
    }

    private static bool IsHandleSummaryCommandCorrect(int requiredLength, string[] commands)
    {
        if (commands.Length != requiredLength)
        {
            ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
            return false;
        }

        if (commands[2] != "--month")
        {
            ConsoleMessage.PrintErrorMessage("--monthを付けてください。");
            return false;
        }
        if (!Int32.TryParse(commands[3], out var _))
        {

            ConsoleMessage.PrintErrorMessage("monthの形式が不正です。");
            return false;
        }
        return true;
    }
    private static void HandleListCommand(string[] commands)
    {
        if (commands.Length != 2)
        {
            ConsoleMessage.PrintErrorMessage("コマンドが不正です。");
            return;
        }

        var expenses = _expenseService?.GetAllExpense();
        if (expenses == null) return;

        Console.WriteLine("ID   Date        Description  Amount");
        foreach (var expense in expenses)
        {
            Console.WriteLine($"{expense.Id,-4} {expense.CreatedAt:yyyy-MM-dd}  {expense.Description,-12} ${expense.Amount}");
        }
    }


}






