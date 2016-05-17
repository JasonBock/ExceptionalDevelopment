using Exceptions.Utilities;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests
{
	[TestClass]
	public sealed class FilterEmitterTests : CoreTests
	{
		[TestMethod]
		public void DivideWithNoException()
		{
			Assert.AreEqual(0,
				new FilterEmitter().Divide(4, 0));
		}

		[TestMethod]
		public void DivideWithException()
		{
			ExceptionAssert.Throws<DivideByZeroException>(
				() => new FilterEmitter().Divide(3, 0));
		}
	}
}
