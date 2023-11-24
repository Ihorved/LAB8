using System;

interface IScreen
{
    void Display();
}

class SmartphoneScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Smartphone Screen Displaying...");
    }
}

class LaptopScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Laptop Screen Displaying...");
    }
}

interface IProcessor
{
    void Process();
}

class SmartphoneProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Smartphone Processor Processing...");
    }
}

class LaptopProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Laptop Processor Processing...");
    }
}

interface ICamera
{
    void Capture();
}

class SmartphoneCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Smartphone Camera Capturing...");
    }
}

class LaptopCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Laptop Camera Capturing...");
    }
}

interface IDeviceFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}

class SmartphoneFactory : IDeviceFactory
{
    public IScreen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public ICamera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

class LaptopFactory : IDeviceFactory
{
    public IScreen CreateScreen()
    {
        return new LaptopScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public ICamera CreateCamera()
    {
        return new LaptopCamera();
    }
}

class DeviceAssembler
{
    public static void Main()
    {
        Console.WriteLine("Choose the type of device (Smartphone/Laptop): ");
        string deviceType = Console.ReadLine();

        IDeviceFactory factory = null;
        switch (deviceType.ToLower())
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Invalid device type.");
                return;
        }

        IScreen screen = factory.CreateScreen();
        IProcessor processor = factory.CreateProcessor();
        ICamera camera = factory.CreateCamera();

        Console.WriteLine("\nAssembling the Device:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
