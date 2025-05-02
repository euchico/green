namespace Green.ConsoleMVC.Views;

public class WelcomeScreen
{
    public void Show()
    {
        Console.Clear();
        ConfigureConsole();
        DisplayLogo();
        DisplayWelcomeMessage();
        DisplayLoadingAnimation();
        
        Thread.Sleep(2000);
        TransitionToMainMenu();
    }

    private void ConfigureConsole()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;
    }

    private void DisplayLogo()
    {
        Console.WriteLine(@"
 ██████╗ ██████╗ ███████╗███████╗███╗   ██╗
██╔════╝ ██╔══██╗██╔════╝██╔════╝████╗  ██║
██║  ███╗██████╔╝█████╗  █████╗  ██╔██╗ ██║
██║   ██║██╔══██╗██╔══╝  ██╔══╝  ██║╚██╗██║
╚██████╔╝██║  ██║███████╗███████╗██║ ╚████║
 ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═══╝");
        Console.Write("\n");
    }

    private void DisplayLoadingAnimation()
    {
        string loadingText = "Inicializando sistema";
        string startingText = "Sistema pronto!";
        string dots = "...";
        int animationDuration = 3;
        int delay = 500;

        Console.Write(loadingText);

        for (int i = 0; i < animationDuration; i++)
        {
            foreach (char dot in dots)
            {
                Console.Write(dot);
                Thread.Sleep(delay);
            }

            for (int j = 0; j < dots.Length; j++)
            {
                if (i == animationDuration - 1)
                {
                    break;
                }

                Console.Write("\b \b");
            }

            if (i < animationDuration - 1)
            {
                Thread.Sleep(delay);
            }
        }

        Console.Write("\n");
        Console.WriteLine(startingText);
    }

    private void DisplayWelcomeMessage()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] messages = {
        "Bem-vindo ao Green - As informações por trás dos números.",
        "Versão 0.1 - Copyleft (\u0254) 2025 Francisco de Paula."
    };

        foreach (var msg in messages)
        {
            Console.WriteLine(msg);
            Thread.Sleep(1000);
        }

        Console.Write("\n");
    }

    private void TransitionToMainMenu()
    {
        //Console.ResetColor();
        Console.Clear();
        // Chama o próximo componente (menu principal)
        //new MainMenu().Show();
    }
}
