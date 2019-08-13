using System;

namespace StackOverflowShutdown
{
	class Program
	{
		// https://blogs.msdn.microsoft.com/clrcodegeneration/2009/05/11/tail-call-improvements-in-net-framework-4/
		// If this is run in Debug, the exception occurs.
		// If this is run in Release, the exception only occurs when you recursively call Main().
		static void Main()
		{
			Console.WriteLine("Invoked.");

			try
			{
				//Program.Main();
				Program.CallMe();
			}
			catch (StackOverflowException)
			{
				Console.WriteLine("Overflow!");
			}
			catch (Exception)
			{
				Console.WriteLine("BAD!");
			}
			finally
			{
				Console.WriteLine("Finally");
			}

			Console.WriteLine("Finished.");
		}

		static void CallMe() => Program.CallMe();
	}
}