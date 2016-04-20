using Exceptions;
using Exceptions.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Exceptions.Tests.Unit
{
	[TestClass]
	public sealed class ExceptionFromFinallyTests : CoreTests
	{
		[SuppressMessage("Microsoft.Usage", "CA2219:DoNotRaiseExceptionsInExceptionClauses")]
		[TestMethod, ExpectedException(typeof(NotSupportedException))]
		public void ThrowExceptionFromFinallyBlock()
		{
			try
			{
				new Name(null, null);
			}
			finally
			{
				throw new NotSupportedException();
			}
		}
	}
}
