﻿using System;
using System.Runtime.Serialization;

namespace Exceptions
{
	[Serializable]
	public sealed class InvalidNameException 
		: Exception
	{
		public InvalidNameException()
			: base()
		{ }

		private InvalidNameException(SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{ }

		public InvalidNameException(string message)
			: base(message)
		{ }

		public InvalidNameException(string message,
			string firstName, string lastName)
			: base(message)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public InvalidNameException(string message, Exception innerException)
			: base(message, innerException)
		{ }

		public InvalidNameException(string message, Exception innerException,
			string firstName, string lastName)
			: base(message, innerException)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName { get; }
		public string LastName { get; }
	}
}