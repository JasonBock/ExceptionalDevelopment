using System;
using System.Runtime.CompilerServices;

[assembly: RuntimeCompatibilityAttribute(WrapNonExceptionThrows = true)]

public static class CallingBadClass
{
    public static void Main()
    {
        CallingBadClass.CatchWithNoException();
		Console.Out.WriteLine();
		Console.Out.WriteLine();

        CallingBadClass.CatchExceptionAndWithNoException();
		Console.Out.WriteLine();
		Console.Out.WriteLine();

        CallingBadClass.CatchException();
    }

    private static void CatchExceptionAndWithNoException()
    {
        Console.Out.WriteLine("CatchExceptionAndWithNoException called.");
        
        try
        {
            Console.Out.WriteLine("In try block...");
            var badClass = new BadClass();
            badClass.BadMethod();
            Console.Out.WriteLine("BadMethod called.");        
        }
        catch(Exception exception)
        {
            Console.Out.WriteLine($"Catch entered - exception type is {exception.GetType().FullName}");
        }
        finally
        {
            Console.Out.WriteLine("Finally entered.");
        }
    }
    
    private static void CatchException()
    {
        Console.Out.WriteLine("CatchException called.");
        
        try
        {
            Console.Out.WriteLine("In try block...");
            var badClass = new BadClass();
            badClass.BadMethod();
            Console.Out.WriteLine("BadMethod called.");        
        }
        catch(Exception exception)
        {
            Console.Out.WriteLine($"Catch entered - exception type is {exception.GetType().FullName}");
        }
        finally
        {
            Console.Out.WriteLine("Finally entered.");
        }
    }
    
    private static void CatchWithNoException()
    {
        Console.Out.WriteLine("CatchWithNoException called.");
        
        try
        {
            Console.Out.WriteLine("In try block...");
            var badClass = new BadClass();
            badClass.BadMethod();
            Console.Out.WriteLine("BadMethod called.");        
        }
        catch
        {
            Console.Out.WriteLine("Catch entered.");                        
        }
        finally
        {
            Console.Out.WriteLine("Finally entered.");
        }
    }
}