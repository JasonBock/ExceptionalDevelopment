using NUnit.Framework;
using System;

namespace Exceptions.Tests
{
	public static class ExceptionFromFinallyTests 
	{
		[Test]
		public static void ThrowExceptionFromFinallyBlock() => 
			Assert.That(() =>
			{
				try
				{
					new Name(null, null);
				}
				finally
				{
					throw new NotSupportedException();
				}
			}, Throws.TypeOf<NotSupportedException>());
	}
}