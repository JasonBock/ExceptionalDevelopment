using System;

namespace ErrorsAndPatterns
{
	public sealed class Error
	{
		public Error(string message) =>
			this.Message = message ?? throw new ArgumentNullException(nameof(message));

		public string Message { get; }
	}
}