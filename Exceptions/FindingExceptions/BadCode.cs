using Exceptions;
using System;
using System.Collections.Generic;

namespace FindingExceptions
{
	public sealed class BadCode
	{
		public void Execute(List<Person> persons)
		{
			int i = 0;
			
			foreach(var person in persons)
			{
				i += person.Age;
			}

			Console.Out.WriteLine(i / persons.Count);
		}
	}
}
