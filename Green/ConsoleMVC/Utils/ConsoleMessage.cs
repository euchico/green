namespace Green.ConsoleMVC.Utils;

public static class ConsoleMessage
{
    public static void Error(string message)
    {
        PrintColored(message, ConsoleColor.Red);
    }

    public static void Success(string message)
    {
        PrintColored(message, ConsoleColor.Blue);
    }

    public static void Warning(string message)
    {
        PrintColored(message, ConsoleColor.Yellow);
    }

    private static void PrintColored(string message, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"\n{message}");
        Console.ForegroundColor = originalColor;

        Thread.Sleep(1500);
    }
}