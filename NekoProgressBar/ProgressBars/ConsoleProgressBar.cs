using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoProgressBar.ProgressBars
{
	class ConsoleProgressBar : ProgressBar
	{
		private readonly ProgressBarConfig config;

		public ConsoleProgressBar(ProgressBarConfig config)
		{
			this.config = config;
		}


	}
}
