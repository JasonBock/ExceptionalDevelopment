using Exceptions;
using System;
using System.Collections.Generic;

namespace FindingExceptions.Generator
{
	public static class PersonListGenerator
	{
		public static List<Person> GetPersons()
		{
			var persons = new List<Person>();
			
			for(int i = 0; i < 1000; i++)
			{
				if(i == 567)
				{
					persons.Add(null);
				}
				else
				{
					persons.Add(new Person(
						new Name("Jason", i.ToString()), i));
				}
			}
			
			return persons;
		}
	}
}
