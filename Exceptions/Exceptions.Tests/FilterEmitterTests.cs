using NUnit.Framework;
using System;

namespace Exceptions.Tests
{
	public static class FilterEmitterTests
	{
		[Test]
		public static void DivideWithNoException() => Assert.That(
			new FilterEmitter().Divide(4, 0), Is.EqualTo(0));

		[Test]
		public static void DivideWithException() => Assert.That(
			() => new FilterEmitter().Divide(3, 0), Throws.TypeOf<DivideByZeroException>());
	}
}
