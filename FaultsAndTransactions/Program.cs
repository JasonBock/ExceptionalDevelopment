using System;

namespace FaultsAndTransactions
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Transaction transaction = null;
			
			try
			{
				transaction = new Transaction();
				
				int x = int.Parse(args[0]);
				int y = int.Parse(args[1]);
				
				Console.Out.WriteLine(Calculations.Divide(x, y));
				
				transaction.Commit();
			}
			catch(IndexOutOfRangeException)
			{
				Console.Out.WriteLine("IndexOutOfRangeException");

				if(transaction != null)
				{
					transaction.Rollback();
				}
			}
			catch(DivideByZeroException)
			{
				Console.Out.WriteLine("DivideByZeroException");

				if(transaction != null)
				{
					transaction.Rollback();
				}
			}
			catch(FormatException)
			{
				Console.Out.WriteLine("FormatException");

				if(transaction != null)
				{
					transaction.Rollback();
				}
			}
			finally
			{
				if(transaction != null)
				{
					transaction.Dispose();			
				}
			}	
		}
	}
}