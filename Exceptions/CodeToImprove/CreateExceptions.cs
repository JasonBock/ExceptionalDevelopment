using System;

namespace CodeToImprove
{
	public static class CreateExceptions
	{
		public static void ThrowIt(string value)
		{
			if (value == "2")
			{
				throw new ArgumentException("Nothing works", nameof(value));
			}
		}

		public static void ThrowNonPublicException() => throw new NonPublicCustomException();

		public static void CreateArgumentExceptionWithWrongArgumentName(int index)
		{
			if(index == 0)
			{
				throw new ArgumentException("index", "This is a bad index value.");
			}
		}

		public static void CreateArgumentExceptionWithNoParameters(int index)
		{
			if (index == 0)
			{
				throw new ArgumentException();
			}
		}
	}
}