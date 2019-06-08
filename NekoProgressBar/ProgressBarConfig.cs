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

		/// <summary>
		/// 进度条类型，见<see cref="ProgressBarType"/>。
		/// </summary>
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
		public int MaxValue { get; set; } = 100;

		/// <summary>
		/// <para>
		/// 仅在<see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>最小值。</para>
		/// </summary>
		public int MinValue { get; set; } = 0;

		/// <summary>
		/// 是否显示数字和百分比进度
		/// </summary>
		public bool ShowStatus { get; set; } = true;

		/// <summary>
		/// <para>仅在<see cref="ShowStatus"/>为真的情况下有效。显示数字或百分比进度的格式。</para>
		/// <para>
		/// 如果<see cref="UsePercentage"/>为真，那么只能有最多1个值。
		/// 如果为假，那么可以有最多3个值。</para>
		/// <para>
		/// 0和1代表当前值和总值，2代表百分比，都可以省略。
		/// </para>
		/// </summary>
		public string StatusFormat { get; set; } = "{0:D} / {1:D} ({2:P2})";

		#region Console Configs

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>起始字符。</para>
		/// </summary>
		public char StartChar { get; set; } = '[';

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>终止字符。</para>
		/// </summary>
		public char EndChar { get; set; } = ']';

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>已完成字符</para>
		/// </summary>
		public char CompletedChar { get; set; } = '=';

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>当前进度字符。</para>
		/// </summary>
		public char Indicator { get; set; } = '>';

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>未完成部分字符。</para>
		/// </summary>
		public char NotCompletedChar { get; set; } = ' ';

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>换行符，可以是<code>\r</code>，<code>\n</code>等。</para>
		/// </summary>
		public string LineBreak { get; set; } = "\r";

		/// <summary>
		/// <para>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>且
		/// <see cref="UsePercentage"/>为<see langword="false"></see>下有效。
		/// </para>
		/// <para>进度条的长度，默认为控制台宽度</para>
		/// </summary>
		public int ConsoleBarLength { get; set; } = Console.WindowWidth;

		/// <summary>
		/// 仅在<see cref="PBType"/>为<see cref="ProgressBarType.Console"/>下有效。
		/// <para>执行的函数，传入进度条字符串。</para>
		/// </summary>
		public Action<string> ConsoleShowCallback { get; set; } = Console.Write;

		#endregion

	}
}
