using System;

namespace Exceptions
{
	public sealed class Person
	{
		private Person()
			: base()
		{ }

		public Person(Name name, int age)
			: this()
		{
			this.Name = name ?? throw new ArgumentNullException(nameof(name));

			if (age < 0)
			{
				throw new ArgumentException(
					"The age cannot be less than zero.", nameof(age));
			}

			this.Age = age;
		}

		public int Age { get; }

		public Name Name { get; }
	}
}
