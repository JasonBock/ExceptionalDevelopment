using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Exceptions.Tests
{
	public static class ExceptionTests
	{
		private static ArgumentNullException Create(string name)
		{
			var exception = new ArgumentNullException(name);
			exception.Data.Add("Random", "DataValue");
			return exception;
		}

		private static void Throw() => throw ExceptionTests.Create("args");

		[Test]
		public static void CreateAndPrint() => ExceptionTests.Create("args").Print();

		[Test]
		public static void CreateThrowAndPrint()
		{
			try
			{
				ExceptionTests.Throw();
			}
			catch (ArgumentNullException e)
			{
				e.Print();
			}
		}

		[Test]
		public static void CreateThrowAndPrintWithInner()
		{
			try
			{
				try
				{
					ExceptionTests.Throw();
				}
				catch (ArgumentNullException e)
				{
					throw new InvalidNameException("Custom", e);
				}
			}
			catch (InvalidNameException e)
			{
				e.Print();
			}
		}

		[Test]
		public static void PrintRethrown()
		{
			try
			{
				ExceptionTests.RethrowException();
			}
			catch (ArgumentNullException e)
			{
				e.Print();
			}
		}

		[Test]
		public static void PrintRethrownWithReference()
		{
			try
			{
				ExceptionTests.RethrowExceptionWithReference();
			}
			catch (ArgumentNullException e)
			{
				e.Print();
			}
		}

		[Test]
		public static async Task ThrowAndAwait()
		{
			try
			{
				ExceptionTests.RethrowExceptionWithReference();
			}
			catch (ArgumentNullException)
			{
				await ExceptionTests.RunAsync();
			}
		}

		private static Task RunAsync() => Task.CompletedTask;

		private static void RethrowException()
		{
			try
			{
				ExceptionTests.Throw();
			}
			catch (ArgumentNullException)
			{
				throw;
			}
		}

		private static void RethrowExceptionWithReference()
		{
			try
			{
				ExceptionTests.Throw();
			}
			catch (ArgumentNullException e)
			{
				throw e;
			}
		}
	}
}