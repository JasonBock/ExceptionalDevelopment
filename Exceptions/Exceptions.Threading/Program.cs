using Nito.AsyncEx;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions.Threading
{
	class Program
	{
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += 
				(_, e) => Console.Out.WriteLine(e.IsTerminating.ToString());

			//Program.UseThreadPool();
			AsyncContext.Run(
				() => Program.UseTaskFactory());
		}

		private static void UseThreadPool()
		{
			Program.ThreadPoolRunner(2);
			Program.ThreadPoolRunner(1);
		}

		private static async Task UseTaskFactory()
		{
			await Program.TaskFactoryAsync(2);
			await Program.TaskFactoryAsync(1);
		}

		private static void ThreadPoolRunner(int data)
		{
			Console.Out.WriteLine($"{nameof(Program.ThreadPoolRunner)} with {data}...");

			var runState = new RunState(new ManualResetEvent(false), data);

			ThreadPool.QueueUserWorkItem(
				new WaitCallback(Program.Run), runState);
			
			runState.Handle.WaitOne();

			Console.Out.WriteLine($"{nameof(Program.ThreadPoolRunner)} with {data} done.");
		}
		
		private static void Run(object state)
		{
			var threadState = state as RunState;

			if(threadState.Data % 2 != 0)
			{
				throw new NotSupportedException("Only even data is supported.");
			}

			threadState.Handle.Set();
		}

		private static async Task TaskFactoryAsync(int data)
		{
			Console.Out.WriteLine($"{nameof(Program.TaskFactoryAsync)} with {data}...");

			await Task.Factory.StartNew(() =>
			{
				if (data % 2 != 0)
				{
					throw new NotSupportedException("Only even data is supported.");
				}
			});

			Console.Out.WriteLine($"{nameof(Program.TaskFactoryAsync)} with {data} done.");
		}
	}
}
