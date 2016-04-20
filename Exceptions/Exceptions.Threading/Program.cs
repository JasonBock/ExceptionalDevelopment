using System;
using System.Threading;

namespace Exceptions.Threading
{
	class Program
	{
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += 
				(_, e) => Console.Out.WriteLine(e.IsTerminating.ToString());

			Program.ThreadPoolRunner(2);
			Program.ThreadPoolRunner(1);			
		}

		private static void ThreadPoolRunner(int data)
		{
			Console.Out.WriteLine("ThreadPoolRunner with {0}...", data);
			
			var runState = new RunState(new ManualResetEvent(false), data);

			ThreadPool.QueueUserWorkItem(
				new WaitCallback(Program.Run), runState);
			
			runState.Handle.WaitOne();

			Console.Out.WriteLine("ThreadPoolRunner with {0} done.", data);
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
	}
}
