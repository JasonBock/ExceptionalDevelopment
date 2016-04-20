using Exceptions.Utilities.Extensions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exceptions.Tests.Performance
{
	[TestClass]
	public sealed class ParseTests : CoreTests
	{
		private const int Iterations = 100000;

		[TestMethod]
		public void TimeIntTryParseWithBadData()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(var i = 0; i < ParseTests.Iterations; i++)
				{
					var result = 0;
					Assert.IsFalse(int.TryParse(
						i.ToString() + "a", out result));
				}
			}).Time());
		}

		[TestMethod]
		public void TimeIntTryParseWithGoodData()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(var i = 0; i < ParseTests.Iterations; i++)
				{
					var result = 0;
					Assert.IsTrue(int.TryParse(i.ToString(), out result));
				}
			}).Time());
		}

		[TestMethod]
		public void TimeIntParseWithBadData()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(var i = 0; i < ParseTests.Iterations; i++)
				{
					try
					{
						int.Parse(i.ToString() + "a");
					}
					catch(ArgumentNullException)
					{
					}
					catch(FormatException)
					{
					}
					catch(OverflowException)
					{
					}
				}
			}).Time());
		}

		[TestMethod]
		public void TimeIntParseWithCleanData()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(var i = 0; i < ParseTests.Iterations; i++)
				{
					int.Parse(i.ToString());
				}
			}).Time());
		}

		[TestMethod]
		public void TimeIntParseWithCleanDataAndExceptionHandling()
		{
			this.TestContext.WriteLine("Total time: " + new Action(() =>
			{
				for(var i = 0; i < ParseTests.Iterations; i++)
				{
					try
					{
						int.Parse(i.ToString());
					}
					catch(ArgumentNullException)
					{
					}
					catch(FormatException)
					{
					}
					catch(OverflowException)
					{
					}
				}
			}).Time());
		}
	}
}
