namespace Green.ConsoleMVC.Views;

public class AuthScreen
{
    public string Show()
    {
        Console.WriteLine("#1 - Entrar");
        Console.WriteLine("#2 - Cadastrar\n");

        Console.WriteLine("#0 - Sair\n");

        Console.Write("Opção: ");

        String? optionString = Console.ReadLine();

        return optionString ?? "";
    }
}