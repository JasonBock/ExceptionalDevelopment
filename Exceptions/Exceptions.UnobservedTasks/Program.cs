using System;
using System.Threading.Tasks;

namespace Exceptions.UnobservedTasks
{
	class Program
	{
		static async Task Main()
		{
			TaskScheduler.UnobservedTaskException += async (s, e) =>
			{
				await Console.Out.WriteLineAsync($"{e.Exception.InnerException.GetType().Name}, {e.Observed}");
			};

			await GoodMethodAsync();

			for(var i = 0; i < 10; i++)
			{
#pragma warning disable CS4014 
				BadMethodAsync();
#pragma warning restore CS4014 
			}

			await Task.Delay(500);
			GC.Collect();
			GC.WaitForPendingFinalizers();

			await Console.Out.WriteLineAsync("Press Enter to continue...");
			await Console.In.ReadLineAsync();
		}

		private static Task GoodMethodAsync() => Task.CompletedTask;
		private static async Task BadMethodAsync()
		{
			await Task.Delay(100);
			throw new NotImplementedException();
		}
	}
}