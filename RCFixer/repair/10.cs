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
    public partial class _10 : Form
    {
        public _10()
        {
            InitializeComponent();
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = langEN.Repair4SolutionLabel1;
                label2.Text = langEN.Repair4SolutionLabel2;
            }
            else
            {
                label1.Text = "İndiriliyor...";
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

        private async void ıconButton1_Click(object sender, EventArgs e)
        {
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = langEN.Repair4SolutionLabel1;
            }
            else
            {
                label1.Text = "Onarılıyor...";
            }
            panel1.Visible = false;
            panel2.Visible = true; 
            try
            {
                WebClient wcRedist86 = new WebClient();
                wcRedist86.DownloadFileCompleted += wcRedist86_DownloadFileCompleted;
                wcRedist86.DownloadFileAsync(new Uri("https://aka.ms/vs/17/release/vc_redist.x86.exe"), Application.StartupPath + "\\vc_redist.x86.exe");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        private async void wcRedist86_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // File.WriteAllBytes(Application.StartupPath+"\\RealUI-Installer.exe",RCFixer.Properties.Resources.RealUIInst);
            try
            {

                Process.Start(Application.StartupPath + "\\vc_redist.x86.exe");
                if (!RCFixer.Settings.Default.TR)
                {
                    label1.Text = langEN.Repair1Solutionlabel1Repaired;
                    MessageBox.Show(langEN.Repair4SolutionMsgBox1, "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label1.Text = "Onarım tamamlandı.";
                    MessageBox.Show("Yazılım indirildi ve başlatıldı. Lütfen yazılım zaten kuruluysa \"onar\" butonuna tıklayın.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                await Task.Delay(1300);
                panel1.Visible = true;
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                label1.Text = "....";
                MessageBox.Show("Error: "+ex.Message.ToString(), "RCFixer",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                panel1.Visible = true;
                panel2.Visible = false;
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
            //https://aka.ms/vs/16/release/vc_redist.x64.exe
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = langEN.Repair4SolutionLabel1;
            }
            else
            {
                label1.Text = "Onarılıyor...";
            }
            panel1.Visible = false;
            panel2.Visible = true;
            try
            {
                WebClient wcRedist86 = new WebClient();
                wcRedist86.DownloadFileCompleted += wcRedist64_DownloadFileCompleted;
                wcRedist86.DownloadFileAsync(new Uri("https://aka.ms/vs/16/release/vc_redist.x64.exe"), Application.StartupPath + "\\vc_redist.x64.exe");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                await Task.Delay(1300);
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }
        private async void wcRedist64_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

                Process.Start(Application.StartupPath + "\\vc_redist.x64.exe");
                if (!RCFixer.Settings.Default.TR)
                {
                    label1.Text = langEN.Repair1Solutionlabel1Repaired;
                    MessageBox.Show(langEN.Repair4SolutionMsgBox1, "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label1.Text = "Onarım tamamlandı.";
                    MessageBox.Show("Yazılım indirildi ve başlatıldı. Lütfen yazılım zaten kuruluysa \"onar\" butonuna tıklayın.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                label1.Text = "....";
                MessageBox.Show("Error: " + ex.Message.ToString(), "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            await Task.Delay(1300);
            panel1.Visible = true;
            panel2.Visible = false;
        }
       
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
