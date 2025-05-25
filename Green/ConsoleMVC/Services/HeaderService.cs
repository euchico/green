namespace Green.ConsoleMVC.Services;

public class HeaderService
{
    private readonly HeaderState _state = new();
    private readonly HeaderRender _render = new();
    private readonly Stack<String> _pathHistory = new();

    public void Show()
    {
        _render.Render(_state);
    }

    public void SetScreenTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Título inválido");
        }

        _state.ScreenTitle = title.Trim();
    }

    public void NavigateTo(string pathSegment)
    {
        if (string.IsNullOrWhiteSpace(pathSegment))
        {
            return;
        }            

        if (_pathHistory.Count == 0 || _pathHistory.Peek() != pathSegment)
        {
            _pathHistory.Push(pathSegment.Trim());
            UpdatePathDisplay();
        }
    }

    public void GoBack()
    {
        if (_pathHistory.Count > 0)
        {
            _pathHistory.Pop();
        }
        UpdatePathDisplay();
    }

    private void UpdatePathDisplay()
    {
        _state.CurrentPath = string.Join(" > ", _pathHistory.Reverse());
    }

    public void SetHelpMessages(params string[] messages)
    {
        _state.HelpMessages.Clear();
        foreach (var msg in messages)
        {
            AddHelpMessage(msg);
        }
    }

    public void AddHelpMessage(string message)
    {
        if (message.Length > 100)
        {
            throw new ArgumentException("Mensagem muito longa (máx. 100 caracteres)");
        }

        _state.HelpMessages.Add(message);
    }

    public void ResetHelpMessages()
    {
        _state.HelpMessages.Clear();
    }
}

// Classe interna para estado
internal class HeaderState
{
    public string ScreenTitle { get; set; } = "";
    public string CurrentPath { get; set; } = "";
    public List<string> HelpMessages { get; } = new();
}

// Classe interna para renderização
internal class HeaderRender
{
    public void Render(HeaderState state)
    {
        Console.Clear();
        Console.WriteLine(GetHeaderArt());
        Console.WriteLine($"\nFUNÇÃO: {state.ScreenTitle}");
        Console.WriteLine($"CAMINHO: {state.CurrentPath}\n");

        if (state.HelpMessages.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[!] AJUDA:");
            foreach (var msg in state.HelpMessages)
            {
                Console.WriteLine($" • {msg}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }
    }

    private string GetHeaderArt()
    {
        return @"  ___ ___ ___ ___ _  _ 
 / __| _ \ __| __| \| |
| (_ |   / _|| _|| .` |
 \___|_|_\___|___|_|\_|";
    }
}