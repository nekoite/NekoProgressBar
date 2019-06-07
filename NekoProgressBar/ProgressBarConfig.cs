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

		/// <summary>
		/// <para>
		/// 仅在<see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>最大值。</para>
		/// </summary>
		public long MaxValue { get; set; } = 100;

		/// <summary>
		/// <para>
		/// 仅在<see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>最小值。</para>
		/// </summary>
		public long MinValue { get; set; } = 0;

		/// <summary>
		/// 是否显示数字和百分比进度
		/// </summary>
		public bool ShowStatus { get; set; } = true;

		/// <summary>
		/// <para>仅在<see cref="ShowStatus"/>为真的情况下有效。显示数字或百分比进度的格式。</para>
		/// <para>如果设置了<see cref="UsePercentage"/>，那么只能有1个值。</para>
		/// </summary>
		public string StatusFormat { get; set; } = "{0} / {1} ({2})";

		#region Console Configs

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>且
		/// <see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// <para>起始字符。</para>
		/// </summary>
		public char StartChar { get; set; } = '[';

		public char EndChar { get; set; } = ']';

		public char CompletedChar { get; set; } = '=';

		public char Indicator { get; set; } = '>';

		public string LineBrake { get; set; } = "\r";

		/// <summary>
		/// <para>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>且
		/// <see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>进度条的长度，默认为控制台宽度</para>
		/// </summary>
		public int ConsoleBarLength { get; set; } = Console.WindowWidth;

		#endregion

	}
}
