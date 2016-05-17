using System;
using System.Diagnostics;

namespace Exceptions.Utilities.Extensions
{
	public static class ActionExtensions
	{
		public static TimeSpan Time(this Action @this)
		{
			if(@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			var watch = Stopwatch.StartNew();
			@this();
			watch.Stop();
			return watch.Elapsed;
		}
	}
}
