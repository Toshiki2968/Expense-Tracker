namespace ExpenseTracker.Utilities
{
    public static class ConsoleMessage
    {
        public static void PrintWelcomeMessage()
        {
            ConsoleMessage.PrintInfoMessage("こんにちは! GitHub Activity Consoleへようこそ。");
            ConsoleMessage.PrintInfoMessage("経費を入力してください。");
        }

        public static void PrintInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }

        public static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }

        public static void PrintCommandMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }
    }
}