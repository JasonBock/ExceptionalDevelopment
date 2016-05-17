using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Exceptions.Performance
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<ParseVsTryParse>(
				ManualConfig
					.Create(DefaultConfig.Instance)
					.With(Job.LegacyJitX64));
			//BenchmarkRunner.Run<CheckedVsUnchecked>(
			//	ManualConfig
			//		.Create(DefaultConfig.Instance)
			//		.With(Job.LegacyJitX64));
		}
	}
}
