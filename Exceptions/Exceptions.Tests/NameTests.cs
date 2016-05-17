using Exceptions;
using Exceptions.Utilities;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests
{
	[TestClass]
	public sealed class NameTests : CoreTests
	{
		[TestMethod]
		public void Create()
		{
			var name = new Name("Joe", "Smith");
			Assert.AreEqual("Joe", name.FirstName);
			Assert.AreEqual("Smith", name.LastName);
		}

		[TestMethod]
		public void CreateWithEmptyFirstName()
		{
			ExceptionAssert.Throws<ArgumentException>(
				() => new Name(string.Empty, "Smith"));
		}

		[TestMethod]
		public void CreateWithEmptyLastName()
		{
			ExceptionAssert.Throws<ArgumentException>(
				() => new Name("Joe", string.Empty));
		}

		[TestMethod]
		public void CreateWithInvalidName()
		{
			ExceptionAssert.Throws<InvalidNameException>(
				() => new Name("Jason", "Bock"));
		}

		[TestMethod]
		public void CreateWithNullFirstName()
		{
			ExceptionAssert.Throws<ArgumentException>(
				() => new Name(null, "Smith"));
		}

		[TestMethod]
		public void CreateWithNullLastName()
		{
			ExceptionAssert.Throws<ArgumentException>(
				() => new Name("Joe", null));
		}
	}
}
