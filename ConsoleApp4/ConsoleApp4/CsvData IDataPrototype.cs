using System;
using System.Collections.Generic;

interface IDataPrototype
{
    IDataPrototype Clone();
    void DisplayData();
}

class CsvData : IDataPrototype
{
    public string CsvContent { get; set; }

    public IDataPrototype Clone()
    {
        return new CsvData { CsvContent = this.CsvContent };
    }

    public void DisplayData()
    {
        Console.WriteLine($"CSV Data: {CsvContent}");
    }
}

class XmlData : IDataPrototype
{
    public string XmlContent { get; set; }

    public IDataPrototype Clone()
    {
        return new XmlData { XmlContent = this.XmlContent };
    }

    public void DisplayData()
    {
        Console.WriteLine($"XML Data: {XmlContent}");
    }
}

class JsonData : IDataPrototype
{
    public string JsonContent { get; set; }

    public IDataPrototype Clone()
    {
        return new JsonData { JsonContent = this.JsonContent };
    }

    public void DisplayData()
    {
        Console.WriteLine($"JSON Data: {JsonContent}");
    }
}

class DataFormatAdapter : IDataPrototype
{
    private IDataPrototype adaptee;

    public DataFormatAdapter(IDataPrototype adaptee)
    {
        this.adaptee = adaptee;
    }

    public IDataPrototype Clone()
    {
        return new DataFormatAdapter(adaptee.Clone());
    }

    public void DisplayData()
    {
        Console.WriteLine("Adapted Data:");
        adaptee.DisplayData();
    }
}

class DataProcessor
{
    public static void Main()
    {
        Console.WriteLine("Choose the source data format (CSV/XML/JSON): ");
        string sourceFormat = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the source data content: ");
        string sourceContent = Console.ReadLine();

        IDataPrototype sourceData = CreateDataPrototype(sourceFormat, sourceContent);

        Console.WriteLine("\nChoose the target data format (CSV/XML/JSON): ");
        string targetFormat = Console.ReadLine().ToLower();

        IDataPrototype targetData = CreateDataPrototype(targetFormat, string.Empty);

        DataFormatAdapter adapter = new DataFormatAdapter(sourceData);
        targetData = adapter;

        Console.WriteLine("\nDisplaying Source Data:");
        sourceData.DisplayData();

        Console.WriteLine("\nDisplaying Target Data:");
        targetData.DisplayData();
    }

    private static IDataPrototype CreateDataPrototype(string format, string content)
    {
        switch (format)
        {
            case "csv":
                return new CsvData { CsvContent = content };
            case "xml":
                return new XmlData { XmlContent = content };
            case "json":
                return new JsonData { JsonContent = content };
            default:
                Console.WriteLine("Invalid data format.");
                return null;
        }
    }
}
