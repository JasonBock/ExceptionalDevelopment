using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Unit
{
	[TestClass]
	public sealed class PersonTests : CoreTests
	{
		[TestMethod]
		public void Create()
		{
			var person = new Person(new Name("Joe", "Smith"), 44);
			Assert.AreEqual(44, person.Age);
			Assert.AreEqual("Joe", person.Name.FirstName);
			Assert.AreEqual("Smith", person.Name.LastName);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateWithInvalidAge()
		{
			new Person(new Name("Joe", "Smith"), -44);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNullName()
		{
			new Person(null, 44);
		}
	}
}
