using Exceptions;
using Exceptions.Utilities.Extensions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Performance
{
	[TestClass]
	public sealed class CheckedAndUncheckedTests : CoreTests
	{
		private const int Iterations = 1500000000;

		[TestMethod]
		public void TimeCheckedAdd()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(int i = 0; i < CheckedAndUncheckedTests.Iterations; i++)
				{
					CheckedAndUnchecked.CheckedAdd(3, 33);
				}
			}).Time());
		}

		[TestMethod]
		public void TimeUncheckedAdd()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(int i = 0; i < CheckedAndUncheckedTests.Iterations; i++)
				{
					CheckedAndUnchecked.UncheckedAdd(3, 33);
				}
			}).Time());
		}
	}
}
