namespace Green.ConsoleMVC.Views;

public class MainMenuScreen
{
    public string Show()
    {
        //Console.WriteLine("#01 - Dia de Sorte");
        //Console.WriteLine("#02 - Dupla Sena");
        //Console.WriteLine("#03 - Federal");
        //Console.WriteLine("#04 - Loteca");
        Console.WriteLine("#05 - Lotofácil");
        //Console.WriteLine("#06 - Lotogol");
        //Console.WriteLine("#07 - Lotomania");
        //Console.WriteLine("#08 - +Milionária");
        //Console.WriteLine("#09 - Mega-Sena");
        //Console.WriteLine("#10 - Quina");
        //Console.WriteLine("#11 - Super Sete");
        //Console.WriteLine("#12 - Timemania");

        Console.WriteLine("\n#0 - Sair\n");

        Console.Write("Opção: ");

        String? optionString = Console.ReadLine();

        return optionString ?? "";
    }
}