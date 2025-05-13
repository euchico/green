using Green.ConsoleMVC.Resources;
using Green.ConsoleMVC.Services;
using Green.ConsoleMVC.Utils;
using Green.ConsoleMVC.Views;

namespace Green.ConsoleMVC.Controllers;

public class LotofacilController
{
    private readonly HeaderService _header;
    private readonly LotofacilMenuScreen _lotofacilMenu;
    private readonly LotofacilDrawService _lotofacilDraw;

    public LotofacilController(HeaderService header)
    {
        _header = header;
        _lotofacilMenu = new();
        _lotofacilDraw = new();
    }

    public void Start()
    {
        while (true)
        {
            _header.SetScreenTitle("Lotofácil");
            _header.ResetHelpMessages();
            _header.NavigateTo("Menu de Tarefas");
            _header.Show();

            String optionString = _lotofacilMenu.Show();
            if (int.TryParse(optionString, out int option))
            {
                switch (option)
                {
                    case 1:
                        SimpleDraw();
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

    private void SimpleDraw()
    {
        _header.NavigateTo("Sorteio Simples");

        var numeros = _lotofacilDraw.GerarNumerosSimples(15, 1, 25);
        MostrarResultado("Sorteio Simples", numeros);
    }

    private void MostrarResultado(string titulo, List<int> numeros)
    {
        _header.Show();
        Console.WriteLine($"Números sorteados: {string.Join(" ", numeros)}");
        Console.ReadKey();
    }
}