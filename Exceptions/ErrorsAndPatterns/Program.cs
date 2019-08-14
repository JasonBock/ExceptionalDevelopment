using System;

namespace ErrorsAndPatterns
{
	class Program
	{
		static void Main()
		{
			static void HandleError(Error error) =>
				Console.Out.WriteLine(error.Message);

			Program.HandleResult<string>(GetValidResult(), 
				value => Console.Out.WriteLine(value),
				error => HandleError(error));
			Program.HandleResult<string>(GetInvalidResult(), 
				value => Console.Out.WriteLine(value),
				error => HandleError(error));
		}

		private static void HandleResult<T>(Result<T> result, Action<T>? validHandler, Action<Error>? errorHandler) where T : class =>
			_ = result switch
			{
				{ Value: var value } when value != null => result.HandleValue(value => validHandler!(value)),
				{ Error: var error } => result.HandleError(error => errorHandler!(error))
			};

		private static Result<string> GetValidResult() =>
			new Result<string>("Valid");

		private static Result<string> GetInvalidResult() =>
			new Result<string>(new Error("Not good."));
	}
}
