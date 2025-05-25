namespace Green.ConsoleMVC.Views;

public class LoginScreen
{
    public (String user, String pass) Show()
    {
        Console.Write("Usuário: ");
        String user = Console.ReadLine() ?? "";

        Console.Write("Senha: ");
        String pass = Console.ReadLine() ?? "";
        
        return (user, pass);
    }
}