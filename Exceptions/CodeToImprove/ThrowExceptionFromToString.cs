using System;

namespace CodeToImprove
{
	public sealed class ThrowExceptionFromToString
	{
		public override string ToString() => 
			throw new NotImplementedException();
	}
}
