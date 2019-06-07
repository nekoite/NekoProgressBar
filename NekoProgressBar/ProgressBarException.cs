using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoProgressBar
{
	public class ProgressBarException : Exception
	{
		public ProgressBarException() : base() { }

		public ProgressBarException(string msg) : base(msg) { }
	}
}
