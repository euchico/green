namespace Green.ConsoleMVC.Views;

class LoginScreen
{
    public (string user, string pass) Show()
    {
        Console.Write("Usuário: ");
        var user = Console.ReadLine() ?? "";
        Console.Write("Senha: ");
        var pass = Console.ReadLine() ?? "";
        
        return (user, pass);
    }
}
