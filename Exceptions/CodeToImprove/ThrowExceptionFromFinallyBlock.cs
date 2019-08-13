using System;

namespace CodeToImprove
{
	public static class ThrowExceptionFromFinallyBlock
	{
		public static void ThrowIt()
		{
			try
			{
				CreateExceptions.ThrowIt("2");
			}
			finally
			{
				throw new NotSupportedException();
			}
		}
	}
}