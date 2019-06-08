using System;
using System.CodeDom;
using System.Text;
using System.Text.RegularExpressions;

namespace NekoProgressBar.ProgressBars
{
	sealed class ConsoleProgressBar : ProgressBar
	{
		private readonly ProgressBarConfig config;

		// [ <-barLength-> ] (<-wordsLength->)
		private int barLength;
		private int trueBarLength; // without [ and ], barLength - 2
		private int wordsLength;

		private int completed;
		private int total;
		private int min;
		private int max;

		private Action<string> consoleCallback;

		public override int CurrentValue { get; protected set; }

		public override float CurrentPercentage { get; protected set; }

		public ConsoleProgressBar(ProgressBarConfig config)
		{
			this.config = config;
			Reset();

			CalculateLengths();
		}

		public override void SetValueAndRespond(int value)
		{
			SetValue(value);
			Respond();
		}

		public override void IncrementAndRespond(int delta)
		{
			Increment(delta);
			Respond();
		}

		public override void IncrementOneAndRespond()
		{
			IncrementOne();
			Respond();
		}

		public override void Respond()
		{
			consoleCallback(StringRepr());
		}

		public override void SetValue(int value)
		{
			CurrentValue = value;
			completed = value - min;
			CurrentPercentage = (float) completed / total;
			SetValidPercentage();
		}

		public override void Increment(int delta)
		{
			SetValue(CurrentValue + delta);
		}

		public override void IncrementOne()
		{
			CurrentValue += 1;
			completed += 1;
			CurrentPercentage = (float) completed / total;
			SetValidPercentage();
		}

		public override void SetPercentage(float percentage)
		{
			CurrentPercentage = percentage;
			SetValidPercentage();
		}

		public override void SetPercentageAndRespond(float percentage)
		{
			SetPercentage(percentage);
			Respond();
		}

		public override void Reset()
		{
			CurrentValue = config.MinValue;
			CurrentPercentage = 0f;
			consoleCallback = config.ConsoleShowCallback;

			completed = 0;
			total = config.MaxValue - config.MinValue;
			min = config.MinValue;
			max = config.MaxValue;
		}

		private string StringRepr()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(config.StartChar);

			int completedBar = (int)(trueBarLength * CurrentPercentage);

			sb.Append(config.CompletedChar, completedBar - 1);
			sb.Append(config.Indicator);
			sb.Append(config.NotCompletedChar, trueBarLength - completedBar);

			sb.Append(config.EndChar);
			if (config.ShowStatus)
			{
				sb.Append(' ');
				if (config.UsePercentage)
				{
					sb.Append(string.Format(config.StatusFormat, CurrentPercentage));
				}
				else
				{
					sb.Append(string.Format(config.StatusFormat, completed, total, CurrentPercentage));
				}
			}

			sb.Append(config.LineBreak);
			return sb.ToString();
		}

		private void CalculateLengths()
		{
			int lengthLeft = config.ConsoleBarLength;
			// if any status
			if (config.ShowStatus)
			{
				if (config.UsePercentage)
				{
					string test;
					try
					{
						test = string.Format(config.StatusFormat, 1f);
					}
					catch (FormatException fe)
					{
						throw new ProgressBarException("Wrong status format.", fe);
					}

					wordsLength = test.Length;
					lengthLeft -= wordsLength;
				}
				else
				{
					string test;
					try
					{
						test = string.Format(config.StatusFormat, config.MaxValue, config.MaxValue, 1f);
					}
					catch (FormatException fe)
					{
						throw new ProgressBarException("Wrong status format.", fe);
					}

					wordsLength = test.Length;
					lengthLeft -= wordsLength;
				}

				lengthLeft -= 1;
			}

			if (lengthLeft <= 5)
				throw new ProgressBarException("Length too short!");

			barLength = lengthLeft;
			trueBarLength = barLength - 2;
		}

		private void SetValidPercentage()
		{
			if (CurrentPercentage < 0f)
			{
				CurrentPercentage = 0f;
			}
			else if (CurrentPercentage > 1f)
			{
				CurrentPercentage = 1f;
			}
			
		}
	}
}
