using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Exceptions.Tests
{
	[TestClass]
	public sealed class InvalidNameExceptionTests
		: ExceptionTests<InvalidNameException, ArgumentException>
	{
		private const string Message = "What a bad move!";

		public InvalidNameExceptionTests()
			: base(InvalidNameExceptionTests.Message)
		{ }
 
		[TestMethod]
		public void CreateException()
		{
			this.CreateExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessage()
		{
			this.CreateExceptionWithMessageTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndInnerException()
		{
			this.CreateExceptionWithMessageAndInnerExceptionTest();
		}

		[TestMethod]
		public void RoundtripException()
		{
			this.RoundtripExceptionTest();
		}
	}
}
