using System;
using System.Windows.Forms;

namespace ZombieTools
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class ZombieTools
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new mainForm());
		}
		
	}
}
