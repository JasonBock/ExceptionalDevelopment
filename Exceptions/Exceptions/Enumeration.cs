using System;
using System.Collections.Generic;

namespace Exceptions
{
	public static class Enumeration
	{
		public static void Enumerate(IList<Person> persons)
		{
			foreach(var person in persons)
			{
				Console.Out.WriteLine(person.Name);
			}
		}
	}
}
