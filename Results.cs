using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyToUsb
{
	public partial class Results : Form
	{
		public Results ()
		{
			InitializeComponent ();
		}

		public void AddLine (string line)
		{
			if (txtResultLog.Text.Length == 0)
				txtResultLog.Text = line;
			else
				txtResultLog.AppendText (Environment.NewLine + line);
		}

		private void btnOk_Click (object sender, EventArgs e)
		{
			Close ();
		}
	}
}
