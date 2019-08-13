using System;

namespace CodeToImprove
{
	public sealed class ThrowExceptionFromTypeInitializer
	{
		static ThrowExceptionFromTypeInitializer() =>
			throw new NotSupportedException("Don't use me.");

		public Guid Id { get; set; }
	}
}