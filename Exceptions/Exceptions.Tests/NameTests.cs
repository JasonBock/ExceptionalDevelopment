using NUnit.Framework;
using System;

namespace Exceptions.Tests
{
	public static class NameTests
	{
		[Test]
		public static void Create()
		{
			var name = new Name("Joe", "Smith");
			Assert.That(name.FirstName, Is.EqualTo("Joe"), nameof(name.FirstName));
			Assert.That(name.LastName, Is.EqualTo("Smith"), nameof(name.LastName));
		}

		[Test]
		public static void CreateWithEmptyFirstName() => 
			Assert.That(() => new Name(string.Empty, "Smith"), Throws.TypeOf< ArgumentException>());

		[Test]
		public static void CreateWithEmptyLastName() => 
			Assert.That(() => new Name("Joe", string.Empty), Throws.TypeOf<ArgumentException>());

		[Test]
		public static void CreateWithInvalidName() => 
			Assert.That(() => new Name("Jason", "Bock"), Throws.TypeOf<InvalidNameException>());

		[Test]
		public static void CreateWithNullFirstName() => 
			Assert.That(() => new Name(null, "Smith"), Throws.TypeOf<ArgumentException>());

		[Test]
		public static void CreateWithNullLastName() => 
			Assert.That(() => new Name("Joe", null), Throws.TypeOf<ArgumentException>());
	}
}