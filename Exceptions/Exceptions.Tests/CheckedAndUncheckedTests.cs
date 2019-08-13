using NUnit.Framework;
using System;

namespace Exceptions.Tests
{
	public static class CheckedAndUncheckedTests
	{
		[Test]
		public static void RunChecked() => Assert.That(() => CheckedAndUnchecked.CheckedAdd(int.MaxValue, int.MaxValue), 
			Throws.TypeOf<OverflowException>());

		[Test]
		public static void RunUnchecked() => Assert.That(() => CheckedAndUnchecked.UncheckedAdd(int.MaxValue, int.MaxValue),
			Throws.Nothing);
	}
}
