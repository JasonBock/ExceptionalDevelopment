using BenchmarkDotNet.Running;

namespace Exceptions.Performance
{
	class Program
	{
		static void Main() => BenchmarkRunner.Run<CheckedVsUnchecked>();
	}
}
