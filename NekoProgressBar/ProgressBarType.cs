using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoProgressBar
{
	public enum ProgressBarType : byte
	{
		/// <summary>
		/// 控制台
		/// </summary>
		Console,

		/// <summary>
		/// [未完成] GUI进度条
		/// </summary>
		[Obsolete] Gui
	}
}
