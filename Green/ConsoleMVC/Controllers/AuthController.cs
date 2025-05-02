using Green.ConsoleMVC.Resources;
using Green.ConsoleMVC.Services;
using Green.ConsoleMVC.Utils;
using Green.ConsoleMVC.Views;

namespace Green.ConsoleMVC.Controllers;

public class AuthController
{
    private readonly AuthService _auth;
    private readonly Header _header;
    private readonly LoginScreen _loginScreen;
    private readonly RegisterScreen _registerScreen;

    public AuthController(AuthService auth, Header header)
    {
        _auth = auth;
        
        _header = header;
        _loginScreen = new();
        _registerScreen = new();
    }

    public void Start()
    {
        while (true)
        {
            _header.SetScreenTitle("Autenticação");
            _header.ResetPath();
            _header.ResetHelpMessages();
            _header.UpdatePath("Início");
            _header.ShowHeader();

            Console.WriteLine("#1 - Entrar");
            Console.WriteLine("#2 - Cadastrar\n");
            Console.WriteLine("#0 - Sair\n");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    if (HandleLogin()) return;
                    break;
                case "2":
                    HandleRegister();
                    break;
                
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleMessage.Error(Messages.InvalidOption);
                    break;
            }
        }
    }

    private bool HandleLogin()
    {
        _header.UpdatePath("Entrar");
        _header.SetHelpMessages(
            "Digite suas credenciais para acessar o sistema",
            "Informe um campo vazio para retornar");
        _header.ShowHeader();
       
        var (user, pass) = _loginScreen.Show();

        if (_auth.Login(user, pass))
        {
            ConsoleMessage.Success(Messages.LoginSuccess);
            return true;
        }
        
        if(string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
        {
            return false;
        }

        ConsoleMessage.Error(Messages.InvalidCredentials);
        return false;
    }

    private void HandleRegister()
    {
        _header.UpdatePath("Cadastro");
        _header.ShowHeader();
        
        var (user, pass) = _registerScreen.Show();

        if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
        {
            ConsoleMessage.Error(Messages.EmptyCredentials);
        }
        else
        {
            _auth.Register(user, pass);
            ConsoleMessage.Success(Messages.RegisterSuccess);
        }
    }
}