using System;

namespace Exceptions
{
	public sealed class DisposableResource 
		: IDisposable
	{
		public void Use() { }

		public void Dispose() { }
	}
}
