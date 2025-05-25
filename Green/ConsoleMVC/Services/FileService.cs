namespace Green.ConsoleMVC.Services;

public class FileService
{
    public void SalvarJogos(List<List<int>> jogos, string caminhoArquivo)
    {
        var linhas = jogos.Select(jogo => string.Join(" ", jogo));
        File.WriteAllLines(caminhoArquivo, linhas);
    }
}