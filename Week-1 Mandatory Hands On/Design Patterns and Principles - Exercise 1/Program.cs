using System;

public class Program
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("logger1");
        logger2.Log("logger2");

        if (logger1 == logger2)
        {
            Console.WriteLine("logger1 and logger2 are the same instance.");
        }
        else
        {
            Console.WriteLine("Different instances - Singleton pattern is not working!");
        }

        
    }
}
