using System;

class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private string _logMode;
    private string _databaseConnectionString;

    private ConfigurationManager()
    {
        _logMode = "Debug";
        _databaseConnectionString = "DefaultConnection";
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public string LogMode
    {
        get { return _logMode; }
        set { _logMode = value; }
    }

    public string DatabaseConnectionString
    {
        get { return _databaseConnectionString; }
        set { _databaseConnectionString = value; }
    }
}

class Program
{
    static void Main()
    {       
        ConfigurationManager configManager = ConfigurationManager.Instance;

        Console.WriteLine($"Log Mode: {configManager.LogMode}");
        Console.WriteLine($"Database Connection String: {configManager.DatabaseConnectionString}");

        Console.Write("Enter new Log Mode: ");
        configManager.LogMode = Console.ReadLine();

        Console.Write("Enter new Database Connection String: ");
        configManager.DatabaseConnectionString = Console.ReadLine();

        Console.WriteLine("\nUpdated Configuration:");
        Console.WriteLine($"Log Mode: {configManager.LogMode}");
        Console.WriteLine($"Database Connection String: {configManager.DatabaseConnectionString}");

        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        Console.WriteLine("\nChecking Another Instance:");
        Console.WriteLine($"Log Mode: {anotherConfigManager.LogMode}");
        Console.WriteLine($"Database Connection String: {anotherConfigManager.DatabaseConnectionString}");
    }
}
