namespace Green.ConsoleMVC;

public class Green
{
    static void Main()
    {
        App app = new App();
        app.Run();
        app.RestoreConsoleColor();
    }
}