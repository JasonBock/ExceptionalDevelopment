using System;

namespace CodeToImprove
{
	public static class CatchingGeneralExceptionType
	{
		public static void CatchIt()
		{
			try
			{
				CreateExceptions.ThrowIt("2");
			}
			// Uncomment to show compiler warning/error.
			// catch (Exception e) { }
			catch (Exception) { }
		}
	}
}