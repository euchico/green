using Green.ConsoleMVC.Controllers;
using Green.ConsoleMVC.Services;
using Green.ConsoleMVC.Views;

namespace Green.ConsoleMVC;

class Green
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Header header = new();
        AuthService authService = new();
        AuthController authController = new(authService, header);

        new WelcomeScreen().Show();
        authController.Start();

        // Após login
        header.SetScreenTitle("Painel Principal");
        header.ResetPath();
        header.UpdatePath("Lotofácil");
        header.UpdatePath("Gerar Sorteio");
        header.UpdatePath("Simples");
        header.ShowHeader();

        Console.WriteLine("Sistema principal...");
        Console.ReadKey();
    }
}