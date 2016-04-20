using System;

namespace InconsistentState
{
	class Program
	{
		static void Main(string[] args)
		{
			decimal amount = 0;

			try
			{
				amount = decimal.Parse(args[0]);
			}
			catch
			{
			}
			
			Console.Out.WriteLine("The amount is " + amount);
		}
	}
}
