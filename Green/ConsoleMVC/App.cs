using Green.ConsoleMVC.Controllers;
using Green.ConsoleMVC.Services;
using Green.ConsoleMVC.Views;

namespace Green.ConsoleMVC;

public class App
{
    private readonly HeaderService _header;
    private readonly WelcomeScreen _welcomeScreen;

    private readonly AuthService _authService;

    //private readonly AuthController _authController;
    //private readonly MainMenuController _mainMenuController;

    private readonly ConsoleColor _originalConsoleColor;


    public App()
    {
        _originalConsoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;

        _header = new HeaderService();
        _welcomeScreen = new();

        _authService = new();
    }

    public void Run()
    {
        try
        {
            _welcomeScreen.Show();

            AuthController authController = new AuthController(_authService, _header);
            authController.Start();

            MainMenuController mainController = new MainMenuController(_header);
            mainController.Start();
        }
        finally
        {
            RestoreConsoleColor();
        }      
    }

    public void RestoreConsoleColor()
    {
        Console.ForegroundColor = _originalConsoleColor;
    }
}