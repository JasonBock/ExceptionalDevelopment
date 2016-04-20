using System;

namespace Exceptions
{
	public static class CheckedAndUnchecked
	{
		public static int CheckedAdd(int x, int y)
		{
			return checked(x + y);
		}

		public static int UncheckedAdd(int x, int y)
		{
			return unchecked(x + y);
		}
	}
}
