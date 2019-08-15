using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exceptions.StackTraces
{
	class Program
	{
		static async Task Main() => await Program.FirstLevelAsync();

		private static async Task FirstLevelAsync() => await Program.SecondLevelAsync();

		private static async Task SecondLevelAsync() => await Program.ThirdLevelAsync();

		private static async Task ThirdLevelAsync() => await Program.IterateAsync();

		private static async Task IterateAsync()
		{
			var values = new Dictionary<int, int>
			{
				{ 0, 1 },
				{ 1, 2 },
				{ 2, 3 },
				{ 4, 5 }
			};

			for(var i = 0; i < values.Count; i++)
			{
				await Task.Delay(50);
				await Console.Out.WriteLineAsync($"{i}, {values[i]}");
			}
		}
	}
}