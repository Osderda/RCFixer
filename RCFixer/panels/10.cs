using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCFixer.panels
{
    public partial class _10 : Form
    {
        public _10()
        {
            InitializeComponent();
            if (!lang.TR)
            {
                richTextBox1.Text = langEN.Repair10Title;
                ıconButton1.Text = langEN.Repair10Button;
            }
        }

        private void _1_Load(object sender, EventArgs e)
        {

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            Process.Start(RCFixer.Properties.Resources.topicURL);
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            new repair._10().ShowDialog();
        }
    }
}
