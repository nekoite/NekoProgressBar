using System.Text.RegularExpressions;

namespace NekoProgressBar.ProgressBars
{
	class ConsoleProgressBar : ProgressBar
	{
		private readonly ProgressBarConfig config;

		// [ <-barLength-> ] (<-wordsLength->)
		private int barLength;
		private int trueBarLength; // without [ and ], barLength - 2
		private int wordsLength;

		public ConsoleProgressBar(ProgressBarConfig config)
		{
			this.config = config;
			CalculateLengths();
		}

		private void CalculateLengths()
		{
			int lengthLeft = config.ConsoleBarLength;
			// if any status
			if (config.ShowStatus)
			{
				if (config.UsePercentage)
				{
					Regex r = new Regex(@"{0}");
					Match match = r.Match(config.StatusFormat);
					if (!match.Success)
						throw new ProgressBarException("Wrong status format.");

					wordsLength = config.StatusFormat.Length + 4; // len - 3 + 7
					lengthLeft -= wordsLength;
				}
				else
				{
					Regex r = new Regex(@"{0}.*{1}.*{2}");
					Match match = r.Match(config.StatusFormat);
					if (!match.Success)
						throw new ProgressBarException("Wrong status format");
					int numMaxLen = config.MaxValue.ToString().Length;
					// len - 9 + numMaxLen * 2 + 7
					wordsLength = config.StatusFormat.Length + 2 + numMaxLen * 2;
					lengthLeft -= wordsLength;
				}

				lengthLeft -= 1;
			}

			if (lengthLeft <= 5)
				throw new ProgressBarException("Length too short!");

			barLength = lengthLeft;
			trueBarLength = barLength - 2;
		}
	}
}
