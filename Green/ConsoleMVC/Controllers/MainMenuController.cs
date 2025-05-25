using Green.ConsoleMVC.Views;
using Green.ConsoleMVC.Utils;
using Green.ConsoleMVC.Resources;
using Green.ConsoleMVC.Services;

namespace Green.ConsoleMVC.Controllers;

public class MainMenuController
{
    private readonly HeaderService _header;
    private readonly MainMenuScreen _menu;

    public MainMenuController(HeaderService header)
    {
        _header = header;
        _menu = new();
    }

    public void Start()
    {
        while (true)
        {
            _header.SetScreenTitle("Menu Principal");
            _header.GoBack();
            _header.ResetHelpMessages();
            _header.NavigateTo("Seleção de Jogo");
            _header.Show();

            String optionString = _menu.Show();
            if (int.TryParse(optionString, out int option))
            {
                switch (option)
                {
                    case 5:
                        OpenLotofacil();
                        break;

                    case 0:
                        return;
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

    private void OpenLotofacil()
    {
        try
        {
            var lotofacilController = new LotofacilController(_header);
            lotofacilController.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.ReadKey();
        }
    }
}