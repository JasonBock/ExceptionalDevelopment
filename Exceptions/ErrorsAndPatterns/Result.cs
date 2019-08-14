using System;

namespace ErrorsAndPatterns
{
	public sealed class Result<T>
		where T : class
	{
		public Result(T value) =>
			this.Value = value ?? throw new ArgumentNullException(nameof(value));

		public Result(Error error) =>
			this.Error = error ?? throw new ArgumentNullException(nameof(error));

		public Error? Error { get; }
		public T? Value { get; }

		public Ignore HandleValue(Action<T> handler)
		{
			handler(this.Value!);
			return Ignore.Use();
		}

		public Ignore HandleError(Action<Error> handler)
		{
			handler(this.Error!);
			return Ignore.Use();
		}
	}
}