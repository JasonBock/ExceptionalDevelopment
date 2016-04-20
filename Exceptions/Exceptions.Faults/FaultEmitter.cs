using System;
using System.Collections.Generic;

namespace Exceptions.Faults
{
	public sealed class FaultEmitter
	{
		public IEnumerable<int> GetEnumerator(int max, int step)
		{
			try
			{
				for(int i = 0; i < max; i = i + step)
				{
					yield return i;
				}
			}
			finally
			{
				Console.Out.WriteLine("done");
			}
		}
	}
}
