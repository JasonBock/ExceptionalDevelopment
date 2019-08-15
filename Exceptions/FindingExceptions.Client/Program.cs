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
				Console.Out.WriteLine($"{nameof(AppDomain.FirstChanceException)}");
				e.Exception.Print(Console.Out);
			};

			AppDomain.CurrentDomain.UnhandledException += (_, e) =>
			{
				Console.Out.WriteLine($"{nameof(AppDomain.UnhandledException)}");
				((Exception)e.ExceptionObject).Print(Console.Out);
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
