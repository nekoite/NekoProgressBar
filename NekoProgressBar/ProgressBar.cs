
using NekoProgressBar.ProgressBars;

namespace NekoProgressBar
{
	public abstract class ProgressBar
	{
		public abstract int CurrentValue { get; protected set; }

		public abstract float CurrentPercentage { get; protected set; }

		public abstract void SetValueAndRespond(int value);

		public abstract void IncrementAndRespond(int delta);

		public abstract void IncrementOneAndRespond();

		public abstract void Respond();

		public abstract void SetValue(int value);

		public abstract void SetPercentage(float percentage);

		public abstract void SetPercentageAndRespond(float percentage);

		public abstract void Increment(int delta);

		public abstract void IncrementOne();

		public abstract void Reset();

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
