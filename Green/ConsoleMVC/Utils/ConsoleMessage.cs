namespace Green.ConsoleMVC.Utils;

public static class ConsoleMessage
{
    public static void Error(String message)
    {
        PrintColored(message, ConsoleColor.Red);
    }

    public static void Success(String message)
    {
        PrintColored(message, ConsoleColor.Blue);
    }

    public static void Warning(String message)
    {
        PrintColored(message, ConsoleColor.Yellow);
    }

    private static void PrintColored(String message, ConsoleColor color)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"\n{message}");
        Console.ForegroundColor = originalColor;

        Thread.Sleep(1500);
    }
}