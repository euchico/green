namespace Green.ConsoleMVC.Services;

public class LotofacilDrawService
{
    private readonly Random _random = new();

    public List<List<int>> GerarMultiplosJogos(int quantidadeJogos, int numerosPorJogo, int inicioRange, int fimRange)
    {
        var jogos = new List<List<int>>();

        for (int i = 0; i < quantidadeJogos; i++)
        {
            jogos.Add(GerarJogoUnico(numerosPorJogo, inicioRange, fimRange));
        }

        return jogos;
    }

    private List<int> GerarJogoUnico(int quantidade, int inicio, int fim)
    {
        return Enumerable.Range(inicio, fim - inicio + 1)
            .OrderBy(_ => _random.Next())
            .Take(quantidade)
            .OrderBy(n => n)
            .ToList();
    }
}