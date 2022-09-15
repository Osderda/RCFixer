using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCFixer.o
{
    public partial class LangSelect : Form
    {
        public LangSelect()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.TopMost = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LangSelect_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void ıconPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
            
        }

        private void LangSelect_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 20, WinAPI.BLENDA);

            if (RCFixer.Settings.Default.TR)
            {
                label1.Text = "Current Language:\n        Turkish";
            }
            else
            {

                label1.Text = "Current Language:\n        English";
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RCFixer.Settings.Default.TR = true;
            Settings.Default.Save();
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            RCFixer.Settings.Default.TR = false;
            Settings.Default.Save();
            Application.Restart();
        }
    }
}
