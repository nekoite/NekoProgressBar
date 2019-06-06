
using NekoProgressBar.ProgressBars;

namespace NekoProgressBar
{
	public abstract class ProgressBar
	{ 

		public static ProgressBar GetProgressBar(ProgressBarConfig config)
		{
			switch (config.PBType)
			{
				case ProgressBarType.Console:
					return new ConsoleProgressBar(config);
					break;
				case ProgressBarType.Gui:
					break;
			}
		}
	}
}
