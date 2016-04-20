using System;
using System.Threading;

namespace Exceptions.Threading
{
	internal sealed class RunState
	{
		internal RunState(EventWaitHandle handle, int data)
			: base()
		{
			this.Handle = handle;
			this.Data = data;
		}

		internal int Data
		{
			get;
			private set;
		}

		internal EventWaitHandle Handle
		{
			get;
			private set;
		}
	}
}
