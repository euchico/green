namespace Green.ConsoleMVC.Views;

public class LotofacilMenuScreen
{
    public string Show()
    {
        Console.WriteLine("#1 - Sorteio Simples");
        //Console.WriteLine("#2 - Sorteio Parametrizado");
        //Console.WriteLine("#3 - Análise de Jogo");
        //Console.WriteLine("#4 - Histórico de Jogos\n");

        Console.WriteLine("\n#0 - Voltar\n");

        Console.Write("Opção: ");

        String? optionString = Console.ReadLine();

        return optionString ?? "";
    }
}