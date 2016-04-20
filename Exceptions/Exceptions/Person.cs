using System;

namespace Exceptions
{
	public sealed class Person
	{
		private Person()
			: base()
		{
		}

		public Person(Name name, int age)
			: this()
		{
			if(name == null)
			{
				throw new ArgumentNullException("name");
			}

			if(age < 0)
			{
				throw new ArgumentException(
					"The age cannot be less than zero.", "age");
			}

			this.Name = name;
			this.Age = age;
		}

		public int Age
		{
			get;
			private set;
		}

		public Name Name
		{
			get;
			private set;
		}
	}
}
