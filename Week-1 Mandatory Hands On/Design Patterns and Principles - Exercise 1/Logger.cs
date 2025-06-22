using System;

public sealed class Logger
{
    private static readonly Logger _instance = new Logger();

    private Logger()
    {
        Console.WriteLine("Logger Initialized.");
    }

    public static Logger GetInstance()
    {
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}.");
    }
}
