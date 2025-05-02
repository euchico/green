namespace Green.ConsoleMVC.Views;

public class Header
{
    private String _currentPath = "";
    private String _screenTitle = "";
    private List<string> _helpMessages = new();

    public void ShowHeader()
    {
        Console.Clear();

        Console.WriteLine(@"  ___ ___ ___ ___ _  _ 
 / __| _ \ __| __| \| |
| (_ |   / _|| _|| .` |
 \___|_|_\___|___|_|\_|");

        Console.WriteLine($"\nFUNÇÃO: {_screenTitle}");
        Console.WriteLine($"CAMINHO: {_currentPath}\n");

        if (_helpMessages.Any())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.WriteLine("[!] AJUDA:");
            foreach (var msg in _helpMessages)
            {
                Console.WriteLine($" • {msg}");
            }
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Green;
        }
    }


    public void SetScreenTitle(string title)
    {
        _screenTitle = title;
    }

    public void UpdatePath(string newPathSegment)
    {
        if (string.IsNullOrEmpty(_currentPath))
        { 
            _currentPath = newPathSegment;
        }
        else
        { 
            _currentPath += $" > {newPathSegment}";
        }
    }

    public void ResetPath()
    {
        _currentPath = "";
    }

    public void SetHelpMessages(params string[] messages)
    {
        _helpMessages = messages.ToList();
    }

    public void AddHelpMessage(string message)
    {
        _helpMessages.Add(message);
    }

    public void ResetHelpMessages()
    {
        _helpMessages.Clear();
    }
}
