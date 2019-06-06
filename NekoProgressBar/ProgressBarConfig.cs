using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoProgressBar
{
	public class ProgressBarConfig
	{
		public ProgressBarConfig() { }

		public ProgressBarType PBType { get; set; } = ProgressBarType.Console;

		/// <summary>
		/// 是否使用百分比表示进度，如果是<see langword="false"></see>，
		/// 那么用最大最小值。如果是<see langword="true"></see>，那么不看最大最小值，使用0%与100%。
		/// </summary>
		public bool UsePercentage { get; set; } = false;

		public long MaxValue { get; set; } = 100;

		/// <summary>
		/// 是否用数字显示进度
		/// </summary>
		public bool ShowStatus { get; set; } = true;

		public string StatusFormat { get; set; } = "{0:D} / {1:D} ({2:P2})";

		#region Console Configs

		/// <summary>
		/// <para>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>且
		/// <see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>最小值。</para>
		/// </summary>
		public long MinValue { get; set; } = 0;

		public char StartChar { get; set; } = '[';

		public char EndChar { get; set; } = ']';

		public char CompletedChar { get; set; } = '=';

		public char Indicator { get; set; } = '>';

		#endregion

	}
}
