using System;

namespace CodeToImprove
{
	public static class RethrowException
	{
		public static void Rethrow()
		{
			try
			{
				CreateExceptions.ThrowIt("2");
			}
			catch (ArgumentException e)
			{
				throw e;
			}
		}
	}
}