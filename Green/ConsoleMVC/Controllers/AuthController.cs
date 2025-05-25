using Green.ConsoleMVC.Resources;
using Green.ConsoleMVC.Services;
using Green.ConsoleMVC.Utils;
using Green.ConsoleMVC.Views;

namespace Green.ConsoleMVC.Controllers;

public class AuthController
{
    private readonly HeaderService _header;
    private readonly AuthScreen _authScreen;
    private readonly LoginScreen _loginScreen;
    private readonly RegisterScreen _registerScreen;

    private readonly AuthService _auth;

    public AuthController(AuthService auth, HeaderService header)
    {
        _header = header;
        _authScreen = new();
        _loginScreen = new();
        _registerScreen = new();

        _auth = auth;
    }

    public void Start()
    {
        while (true)
        {
            _header.SetScreenTitle("Autenticação");
            _header.ResetHelpMessages();
            _header.NavigateTo("Início");
            _header.Show();

            String optionString = _authScreen.Show();            
            if (int.TryParse(optionString, out int option))
            {
                switch (option)
                {
                    case 1:
                        if (HandleLogin()) return;
                        break;
                    case 2:
                        HandleRegister();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ConsoleMessage.Error(Messages.InvalidOption);
                        break;
                }
            }
            else
            {
                ConsoleMessage.Error(Messages.InvalidOption);
            }
        }
    }

    private bool HandleLogin()
    {
        _header.NavigateTo("Entrar");
        _header.SetHelpMessages(
                "Digite suas credenciais para acessar o sistema",
                "Informe um campo vazio para retornar");
        _header.Show();
       
        var (user, pass) = _loginScreen.Show();

        if (_auth.Login(user, pass))
        {
            ConsoleMessage.Success(Messages.LoginSuccess);
            return true;
        }
        
        if(String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass))
        {
            return false;
        }

        ConsoleMessage.Error(Messages.InvalidCredentials);
        return false;
    }

    private void HandleRegister()
    {
        _header.NavigateTo("Cadastro");
        _header.Show();
        
        var (user, pass) = _registerScreen.Show();

        if (String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass))
        {
            ConsoleMessage.Error(Messages.EmptyCredentials);
        }
        else
        {
            _auth.Register(user, pass);
            ConsoleMessage.Success(Messages.RegisterSuccess);
        }

        _header.GoBack();
    }
}