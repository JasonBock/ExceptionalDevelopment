using Exceptions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Unit
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

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateWithEmptyFirstName()
		{
			new Name(string.Empty, "Smith");
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateWithEmptyLastName()
		{
			new Name("Joe", string.Empty);
		}

		[TestMethod, ExpectedException(typeof(InvalidNameException))]
		public void CreateWithInvalidName()
		{
			new Name("Jason", "Bock");
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateWithNullFirstName()
		{
			new Name(null, "Smith");
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateWithNullLastName()
		{
			new Name("Joe", null);
		}
	}
}
