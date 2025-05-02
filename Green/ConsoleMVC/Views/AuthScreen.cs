namespace Green.ConsoleMVC.Views;

public class AuthScreen
{
    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("[ GREEN - LOTERIAS ]\n");
        Console.WriteLine("1. Entrar");
        Console.WriteLine("2. Cadastrar");
        Console.WriteLine("3. Sair\n");
    }

    public (string user, string pass) GetCredentials()
    {
        Console.Write("Usuário: ");
        var user = Console.ReadLine() ?? "";
        Console.Write("Senha: ");
        var pass = Console.ReadLine() ?? "";
        return (user, pass);
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"\n{message}");
        Thread.Sleep(1500);
    }
}