using Exceptions.Utilities;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests
{
	[TestClass]
	public sealed class CheckedAndUncheckedTests : CoreTests
	{
		[TestMethod]
		public void RunChecked()
		{
			ExceptionAssert.Throws<OverflowException>(
				() => CheckedAndUnchecked.CheckedAdd(int.MaxValue, int.MaxValue));
		}

		[TestMethod]
		public void RunUnchecked()
		{
			this.TestContext.WriteLine(
				CheckedAndUnchecked.UncheckedAdd(int.MaxValue, int.MaxValue).ToString());
		}
	}
}
