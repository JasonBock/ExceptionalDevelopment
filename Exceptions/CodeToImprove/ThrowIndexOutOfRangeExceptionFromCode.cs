using System;

namespace CodeToImprove
{
	public static class ThrowIndexOutOfRangeExceptionFromCode
	{
		public static int AccessArray(int[] values, int index)
		{
			if(index < values.GetLowerBound(0) ||  index > values.GetUpperBound(0))
			{
				throw new IndexOutOfRangeException("Bad index value.");
			}

			return values[index];
		}
	}
}