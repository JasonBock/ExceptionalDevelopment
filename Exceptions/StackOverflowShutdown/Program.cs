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
				//Program.CallMeWithArgs(4, 3);
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

		static void CallMe() => Program.CallThis();

		static void CallThis() => Program.CallThat();

		static void CallThat() => Program.CallThis();

		static void CallMeWithArgs(int a, int b) => Program.CallMeWithArgs(b, a);
	}
}