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
    public partial class _5 : Form
    {
        public _5()
        {
            InitializeComponent();
            if (!lang.TR)
            {
                richTextBox1.Text = langEN.Repair5Title;
                ıconButton1.Text = langEN.Repair5Button;
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
            if (lang.TR)
            {
                if (MessageBox.Show("'Tamam' butonuna basarak Malwarebytes yazılımı pc nize kurun, 2 defa tekrarlı taratıp tüm virüsleri silin ve realUI Loader'i tekrar kurun. Sorununuz düzelecektir.","RCFixer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Process.Start("https://www.malwarebytes.com/mwb-download/thankyou/");
                }
               
            }
            else
            {
                if (MessageBox.Show(langEN.Repair5SolutionMsgBox1, "RCFixer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Process.Start("https://www.malwarebytes.com/mwb-download/thankyou/");
                }
            }
        }
    }
}
