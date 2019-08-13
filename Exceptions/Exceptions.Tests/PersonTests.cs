using NUnit.Framework;
using System;

namespace Exceptions.Tests
{
	public static class PersonTests 
	{
		[Test]
		public static void Create()
		{
			var person = new Person(new Name("Joe", "Smith"), 44);
			Assert.AreEqual(44, person.Age);
			Assert.AreEqual("Joe", person.Name.FirstName);
			Assert.AreEqual("Smith", person.Name.LastName);
		}

		[Test]
		public static void CreateWithInvalidAge() => 
			Assert.That(() => new Person(new Name("Joe", "Smith"), -44), Throws.TypeOf<ArgumentException>());

		[Test]
		public static void CreateWithNullName() => 
			Assert.That(() => new Person(null, -44), Throws.TypeOf<ArgumentNullException>());
	}
}