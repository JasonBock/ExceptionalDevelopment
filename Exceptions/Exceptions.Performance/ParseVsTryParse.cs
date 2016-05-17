using BenchmarkDotNet.Attributes;
using System;

namespace Exceptions.Performance
{
	public class ParseVsTryParse
	{
		private const string BadValue = "7r83o4uf8ael";

		[Benchmark]
		public void Parse()
		{
			try
			{
				int.Parse(ParseVsTryParse.BadValue);
			}
			catch (FormatException) { }
		}

		[Benchmark]
		public void TryParse()
		{
			var result = 0;
			int.TryParse(ParseVsTryParse.BadValue, out result);
		}
	}
}
