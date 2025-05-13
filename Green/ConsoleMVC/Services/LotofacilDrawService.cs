namespace Green.ConsoleMVC.Services;

public class LotofacilDrawService
{
    private readonly Random _random = new();

    public List<int> GerarNumerosSimples(int quantidade, int inicio, int fim)
    {
        return Enumerable.Range(inicio, fim - inicio + 1)
                         .OrderBy(x => _random.Next())
                         .Take(quantidade)
                         .OrderBy(x => x)
                         .ToList();
    }

    public List<int> GerarNumerosComFixos(List<int> fixos, int quantidadeTotal, int inicio, int fim)
    {
        var numeros = new List<int>(fixos);

        while (numeros.Count < quantidadeTotal)
        {
            var numero = _random.Next(inicio, fim + 1);
            if (!numeros.Contains(numero))
            {
                numeros.Add(numero);
            }
               
        }

        return numeros.OrderBy(n => n).ToList();
    }

    public bool ValidarJogo(List<int> numeros, int minimo, int maximo, int inicioRange, int fimRange)
    {
        return numeros.Count >= minimo &&
               numeros.Count <= maximo &&
               numeros.All(n => n >= inicioRange && n <= fimRange);
    }
}