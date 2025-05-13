using System.Text.Json;
using Green.ConsoleMVC.Models;

namespace Green.ConsoleMVC.Services;

public class AuthService
{
    private const String _usersFile = @"..\..\..\Infrastructure\Auth\users.json";
    private List<User> _users;

    public AuthService()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        try
        {
            if (File.Exists(_usersFile))
            {
                String json = File.ReadAllText(_usersFile);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            else
            {
                _users = new List<User>();
                SaveUsers();
            }
        }
        catch
        {
            _users = new List<User>();
        }
    }

    private void SaveUsers()
    {
        try
        {
            // Garante que o diretório existe
            String directory = Path.GetDirectoryName(_usersFile);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            // Serializa com formatação
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_usersFile, JsonSerializer.Serialize(_users, options));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar: {ex.Message}");
        }
    }

    public bool Login(String username, String password)
    {
        return _users.Any(u =>
                          u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                          u.Password == password);
    }

    public void Register(String username, String password)
    {
        // Verifica se usuário já existe
        if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Usuário já existe!");
        }

        _users.Add(new User
        {
            Username = username.Trim(),
            Password = password.Trim()
        });

        SaveUsers();
    }
}