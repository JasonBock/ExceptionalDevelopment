using Exceptions;
using Exceptions.Utilities.Extensions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Unit
{
	[TestClass]
	public sealed class ExceptionTests : CoreTests
	{
		private static ArgumentNullException Create(string name)
		{
			var exception = new ArgumentNullException(name);
			exception.Data.Add("Random", "DataValue");
			return exception;
		}

		private static void Throw()
		{
			throw ExceptionTests.Create("args");
		}

		[TestMethod]
		public void CreateAndPrint()
		{
			ExceptionTests.Create("args").Print();
		}

		[TestMethod]
		public void CreateThrowAndPrint()
		{
			try
			{
				ExceptionTests.Throw();
			}
			catch(ArgumentNullException e)
			{
				e.Print();
			}
		}

		[TestMethod]
		public void CreateThrowAndPrintWithInner()
		{
			try
			{
				try
				{
					ExceptionTests.Throw();
				}
				catch(ArgumentNullException e)
				{
					throw new InvalidNameException("Custom", e);
				}
			}
			catch(InvalidNameException e)
			{
				e.Print();
			}
		}

		[TestMethod]
		public void PrintRethrown()
		{
			try
			{
				ExceptionTests.RethrowException();
			}
			catch(ArgumentNullException e)
			{
				e.Print();
			}
		}

		[TestMethod]
		public void PrintRethrownWithReference()
		{
			try
			{
				ExceptionTests.RethrowExceptionWithReference();
			}
			catch(ArgumentNullException e)
			{
				e.Print();
			}
		}

		private static void RethrowException()
		{
			try
			{
				ExceptionTests.Throw();
			}
			catch(ArgumentNullException)
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
			catch(ArgumentNullException e)
			{
				throw e;
			}
		}
	}
}
