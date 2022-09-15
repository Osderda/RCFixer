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
    public partial class _1 : Form
    {
        public _1()
        {
            InitializeComponent();
            if (!RCFixer.Settings.Default.TR)
            {
                ıconButton1.Text = langEN.Repair1SolutionButton1;
                ıconButton2.Text = langEN.Repair1SolutionButton2;
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
                ıconButton2.Text = langEN.Repair1SolutionButton2;
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
            try
            {
                File.WriteAllText("C:\\Program Files (x86)\\fixxer.bat", Resources.commanddel);
                //  File.WriteAllText("C:\\Program Files (x86)\\fixxer.bat", Resources.commanddel);

                Process process = new Process();
                process.StartInfo.FileName = "C:\\Program Files (x86)\\fixxer.bat";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                process.WaitForExit();
                File.Delete("C:\\Program Files (x86)\\fixxer.bat");
                bool flag = !Directory.Exists("C:\\Windows\\System32\\drivers\\etc");
                if (flag)
                {
                    Directory.CreateDirectory("C:\\Windows\\System32\\drivers\\etc");
                }
                await Task.Delay(500);
                bool flag2 = File.Exists("C:\\Windows\\System32\\drivers\\etc\\networks");
                if (flag2)
                {
                    File.Copy("C:\\Windows\\System32\\drivers\\etc\\networks", "C:\\Windows\\System32\\drivers\\etc\\hosts.ics");
                    File.Copy("C:\\Windows\\System32\\drivers\\etc\\networks", "C:\\Windows\\System32\\drivers\\etc\\hosts");
                    Process.Start(new ProcessStartInfo("cmd", "/c echo|attrib +h +s +a %windir%\\System32\\drivers\\etc\\hosts.ics & echo|attrib +h +s +a \"%windir%\\System32\\drivers\\etc\\hosts.ics\" & echo|attrib +h +s +a %windir%\\System32\\drivers\\etc\\hosts & echo|attrib +h +s +a \"%windir%\\System32\\drivers\\etc\\hosts\"")
                    {
                        WindowStyle = ProcessWindowStyle.Normal
                    });
                }
                if (!RCFixer.Settings.Default.TR)
                {
                    MessageBox.Show(langEN.Repair1Solution2MsgBox1, "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlemler tamamlandı. Sorununuz düzeltilmiştir.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                bool flag3 = ex.Message == "'C:\\Program Files (x86)\\fixxer.bat' yoluna erişim reddedildi.";
                if (flag3)
                {
                    if (!RCFixer.Settings.Default.TR)
                    {
                        MessageBox.Show("Please start the repairer as administrator and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen onarıcıyı yönetici olarak başlatın ve tekrar deneyin.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else if (ex.Message == "Access denied to path 'C:\\Program Files (x86)\\connect.bat'.")
                {
                    if (!RCFixer.Settings.Default.TR)
                    {
                        MessageBox.Show("Please start the repairer as administrator and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen onarıcıyı yönetici olarak başlatın ve tekrar deneyin.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    //  MessageBox.Show("Error: "+ ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

    }
}
