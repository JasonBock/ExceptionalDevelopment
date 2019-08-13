using System;

namespace CodeToImprove
{
	internal sealed class NonPublicCustomException
		: Exception
	{
		public NonPublicCustomException() { }

		public NonPublicCustomException(string message) 
			: base(message) { }

		public NonPublicCustomException(string message, Exception innerException) 
			: base(message, innerException) { }
	}
}