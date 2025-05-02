namespace Green.ConsoleMVC.Views;

class RegisterScreen
{
    public (string user, string pass) Show()
    {
        Console.Write("Novo usuário: ");
        var user = Console.ReadLine() ?? "";
        Console.Write("Nova senha: ");
        var pass = Console.ReadLine() ?? "";
        
        return (user, pass);
    }
}
