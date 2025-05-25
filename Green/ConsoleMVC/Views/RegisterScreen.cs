namespace Green.ConsoleMVC.Views;

class RegisterScreen
{
    public (String user, String pass) Show()
    {
        Console.Write("Novo Usuário: ");
        String user = Console.ReadLine() ?? "";

        Console.Write("Nova Senha: ");
        String pass = Console.ReadLine() ?? "";
        
        return (user, pass);
    }
}