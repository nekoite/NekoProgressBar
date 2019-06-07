using System;

namespace NekoProgressBar
{
	public class ProgressBarException : Exception
	{
		public ProgressBarException() : base() { }

		public ProgressBarException(string msg) : base(msg) { }

		public ProgressBarException(string msg, Exception innerException) : base(msg, innerException) { }
	}
}
