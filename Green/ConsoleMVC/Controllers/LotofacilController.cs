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
    private readonly FileService _fileService;

    public LotofacilController(HeaderService header)
    {
        _header = header;
        _lotofacilMenu = new();
        _lotofacilDraw = new();
        _fileService = new FileService(); // Adicione esta linha
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
        _header.Show();

        // Pedir quantidade de jogos
        Console.Write("Quantos jogos deseja gerar? ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 1)
        {
            ConsoleMessage.Error("Quantidade inválida! Deve ser maior que 0");
            return;
        }

        // Gerar jogos
        var jogos = _lotofacilDraw.GerarMultiplosJogos(quantidade, 15, 1, 25);
        MostrarResultado(jogos);

        // Opção de salvar
        Console.Write("\nDeseja salvar os jogos? (S/N): ");
        if (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            SalvarJogos(jogos);
        }
    }

    private void MostrarResultado(List<List<int>> jogos)
    {
        _header.Show();
        Console.WriteLine("Jogos gerados:\n");

        for (int i = 0; i < jogos.Count; i++)
        {
            Console.WriteLine($"Jogo {i + 1}: {string.Join(" ", jogos[i])}");
        }
    }

    private void SalvarJogos(List<List<int>> jogos)
    {
        try
        {
            var dataAtual = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"jogos_lotofacil_{dataAtual}.txt");

            _fileService.SalvarJogos(jogos, caminho);

            ConsoleMessage.Success($"Jogos salvos em: {caminho}");
        }
        catch (Exception ex)
        {
            ConsoleMessage.Error($"Erro ao salvar: {ex.Message}");
        }
        Console.ReadKey();
    }
}