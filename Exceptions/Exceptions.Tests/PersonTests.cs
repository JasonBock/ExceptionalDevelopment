using Exceptions.Utilities;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests
{
	[TestClass]
	public sealed class PersonTests 
		: CoreTests
	{
		[TestMethod]
		public void Create()
		{
			var person = new Person(new Name("Joe", "Smith"), 44);
			Assert.AreEqual(44, person.Age);
			Assert.AreEqual("Joe", person.Name.FirstName);
			Assert.AreEqual("Smith", person.Name.LastName);
		}

		[TestMethod]
		public void CreateWithInvalidAge()
		{
			ExceptionAssert.Throws<ArgumentException>(
				() => new Person(new Name("Joe", "Smith"), -44));
		}

		[TestMethod]
		public void CreateWithNullName()
		{
			ExceptionAssert.Throws<ArgumentNullException>(
				() => new Person(null, 44));
		}
	}
}
