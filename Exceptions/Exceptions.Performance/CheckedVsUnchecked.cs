using BenchmarkDotNet.Attributes;

namespace Exceptions.Performance
{
	public class CheckedVsUnchecked
	{
		[Benchmark]
		public void Checked() => CheckedAndUnchecked.CheckedAdd(3, 33);

		[Benchmark]
		public void Unchecked() => CheckedAndUnchecked.UncheckedAdd(3, 33);
	}
}
