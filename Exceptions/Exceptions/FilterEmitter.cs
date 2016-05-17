using System;

namespace Exceptions
{
	public sealed class FilterEmitter
	{
		public int Divide(int x, int y)
		{
			try
			{
				return x / y;
			}
			catch (DivideByZeroException) when (x % 2 == 0)
			{
				return 0;
			}
		}
	}
}
