using System;
using Exceptions.Utilities.Extensions;
using FindingExceptions.Generator;

namespace FindingExceptions.Client
{
	class Program
	{
		static void Main()
		{
			AppDomain.CurrentDomain.FirstChanceException += (_, e) =>
			{
				e.Exception.Print(Console.Out);
			};

			try
			{
				new BadCode().Execute(
					PersonListGenerator.GetPersons());
			}
			catch (NullReferenceException)
			{
				Console.Out.WriteLine("ouch");
			}
		}
	}
}
