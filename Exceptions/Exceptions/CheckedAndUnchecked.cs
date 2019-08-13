namespace Exceptions
{
	public static class CheckedAndUnchecked
	{
		public static int CheckedAdd(int x, int y) => checked(x + y);

		public static int UncheckedAdd(int x, int y) => unchecked(x + y);
	}
}
