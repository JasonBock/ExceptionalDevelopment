using BenchmarkDotNet.Attributes;
using System;

namespace Exceptions.Performance
{
	[MemoryDiagnoser]
	public class ParseVsTryParse
	{
		private const string BadValue = "7r83o4uf8ael";

		[Benchmark]
		public int Parse()
		{
			try
			{
				return int.Parse(ParseVsTryParse.BadValue);
			}
			catch (FormatException) { }

			return 0;
		}

		[Benchmark]
		public int TryParse() => 
			int.TryParse(ParseVsTryParse.BadValue, out var result) ? result : 0;
	}
}
