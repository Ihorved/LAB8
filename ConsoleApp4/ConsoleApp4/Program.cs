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
