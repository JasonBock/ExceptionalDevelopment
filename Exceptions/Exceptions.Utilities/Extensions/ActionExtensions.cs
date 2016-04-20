using System;
using System.Diagnostics;

namespace Exceptions.Utilities.Extensions
{
	public static class ActionExtensions
	{
		public static TimeSpan Time(this Action @this)
		{
			Stopwatch watch = Stopwatch.StartNew();
			@this();
			watch.Stop();
			return watch.Elapsed;
		}
	}
}
