using System;
using System.Collections.Generic;

interface IChart
{
    void Draw();
}

class LineChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Line Chart");
    }
}
class BarChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Bar Chart");
    }
}
class PieChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Pie Chart");
    }
}

abstract class ChartFactory
{
    public abstract IChart CreateChart();
}
class LineChartFactory : ChartFactory
{
    public override IChart CreateChart()
    {
        return new LineChart();
    }
}
class BarChartFactory : ChartFactory
{
    public override IChart CreateChart()
    {
        return new BarChart();
    }
}
class PieChartFactory : ChartFactory
{
    public override IChart CreateChart()
    {
        return new PieChart();
    }
}

class GraphFactory
{
    public static void Main()
    {
        Console.WriteLine("Enter the type of chart (Line/Bar/Pie): ");
        string chartType = Console.ReadLine();

        ChartFactory factory = null;
        switch (chartType.ToLower())
        {
            case "line":
                factory = new LineChartFactory();
                break;
            case "bar":
                factory = new BarChartFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid chart type.");
                return;
        }

        IChart chart = factory.CreateChart();
        chart.Draw();
    }
}
