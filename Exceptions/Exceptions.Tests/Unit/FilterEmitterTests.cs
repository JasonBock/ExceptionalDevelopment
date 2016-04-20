using Exceptions.Filters;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Unit
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

		[TestMethod, ExpectedException(typeof(DivideByZeroException))]
		public void DivideWithException()
		{
			new FilterEmitter().Divide(3, 0);
		}
	}
}
