using System;

namespace Exceptions
{
	public sealed class Locks
	{
		private Guid id = Guid.Empty;
		private object @lock = new object();
		
		public void LockIt()
		{
			lock(this.@lock)
			{
				this.id = Guid.NewGuid();
			}
		}
	}
}
