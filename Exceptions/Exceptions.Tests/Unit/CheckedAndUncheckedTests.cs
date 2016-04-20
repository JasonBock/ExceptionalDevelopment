using Exceptions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Unit
{
	[TestClass]
	public sealed class CheckedAndUncheckedTests : CoreTests
	{
		[TestMethod, ExpectedException(typeof(OverflowException))]
		public void RunChecked()
		{
			CheckedAndUnchecked.CheckedAdd(int.MaxValue, int.MaxValue);
		}

		[TestMethod]
		public void RunUnchecked()
		{
			this.TestContext.WriteLine(
				CheckedAndUnchecked.UncheckedAdd(int.MaxValue, int.MaxValue).ToString());
		}
	}
}
