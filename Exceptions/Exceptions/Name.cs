using System;

namespace Exceptions
{
	public sealed class Name
	{
		private Name()
			: base() { }

		public Name(string firstName, string lastName)
			: base()
		{
			if(string.IsNullOrEmpty(firstName))
			{
				throw new ArgumentException("A first name was not provided.", 
					nameof(firstName));
			}

			if(string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("A last name was not provided.", 
					nameof(lastName));
			}
			
			if(firstName == "Jason" && lastName == "Bock")
			{
				throw new InvalidNameException("What kind of name is this?!", 
					firstName, lastName);
			}
			
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		
		public string FirstName { get; }

		public string LastName { get; }
	}
}