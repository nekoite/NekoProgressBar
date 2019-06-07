
using NekoProgressBar.ProgressBars;

namespace NekoProgressBar
{
	public abstract class ProgressBar
	{

		public static ProgressBar GetProgressBar(ProgressBarConfig config)
		{
			CheckConfig(config);
			ProgressBar pb = null;
			switch (config.PBType)
			{
				case ProgressBarType.Console:
					pb = new ConsoleProgressBar(config);
					break;
				case ProgressBarType.Gui:
					break;
			}
			return pb;
		}

		private static void CheckConfig(ProgressBarConfig config)
		{
			if (!config.UsePercentage)
			{
				if (config.MinValue <= 0 || config.MaxValue <= 0 || config.MinValue >= config.MaxValue) 
					throw new ProgressBarException("Min or max value is invalid.");
			}
		}
	}
}
