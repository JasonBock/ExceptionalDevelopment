using System;

namespace FaultsAndTransactions
{
	public sealed class Transaction : IDisposable
	{
		public void Commit()
		{
			Console.Out.WriteLine("Commit");
		}
		
		public void Dispose()
		{
			Console.Out.WriteLine("Dispose");
		}

		public void Rollback()
		{
			Console.Out.WriteLine("Rollback");
		}
	}
}
