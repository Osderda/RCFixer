using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using RCFixer.Properties;

namespace RCFixer.repair
{
    public partial class _7 : Form
    {
        public _7()
        {
            InitializeComponent();
            if (!RCFixer.Settings.Default.TR)
            {
                ıconButton1.Text = langEN.Repair1SolutionButton1;
                label1.Text = langEN.Repair1Solutionlabel1Repairing;
            }
            else
            {
                label1.Text = "Onarılıyor...";
            }
        }

        private void _1_Load(object sender, EventArgs e)
        {

        }

        private void _1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            if (!RCFixer.Settings.Default.TR)
            {
                ıconButton1.Text = langEN.Repair1SolutionButton1;
                label1.Text = langEN.Repair1Solutionlabel1Repairing;
            }
            else
            {
                label1.Text = "Onarılıyor...";
            }
            panel1.Visible = false;
            panel2.Visible = true;
            Remedy1.RunWorkerAsync();
        }
        private async void Remedy1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (!o.defender.api())
                {
                    await Task.Delay(1000);
                    panel1.Visible = true;
                    panel2.Visible = false;
                    return;
                }
               
                WebClient wc = new WebClient();
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri("https://github.com/realuix/Download/blob/master/RealUI-Installer.exe?raw=true"), "RealUI-Installer.exe");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private async void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // File.WriteAllBytes(Application.StartupPath+"\\RealUI-Installer.exe",RCFixer.Properties.Resources.RealUIInst);
            try
            {

                Process.Start(Application.StartupPath + "\\RealUI-Installer.exe");
                if (!RCFixer.Settings.Default.TR)
                {
                    label1.Text = langEN.Repair1Solutionlabel1Repaired;
                    MessageBox.Show(langEN.Repair1SolutionMsgBox1, "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label1.Text = "Onarım tamamlandı.";
                    MessageBox.Show("RealUI yükleyici başlatıldı, kurulumu tamamlayın ve sorununuzu tekrar deneyin.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                label1.Text = "....";
                MessageBox.Show(ex.Message.ToString(), "RCFixer",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            await Task.Delay(1300);
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private async void ıconButton2_Click(object sender, EventArgs e)
        {
          
        }

    }
}
