using System;

namespace StackOverflowShutdown
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Invoked.");

			try
			{
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