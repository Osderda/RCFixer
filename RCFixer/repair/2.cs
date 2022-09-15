using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RCFixer.repair
{
    public partial class _2 : Form
    {
        public _2()
        {
            InitializeComponent();
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = "Checking Servers...";
            }
            else
            {
            }
        }

        private void _1_Load(object sender, EventArgs e)
        {
            Thread s = new Thread(Proc);
            s.Start();
            //Remedy1.RunWorkerAsync();
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
        public bool ckURLRC()
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.realitycheats.com");
            httpReq.AllowAutoRedirect = false;
            try
            {

                HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
                //MessageBox.Show(httpRes.StatusCode.ToString());
                if (httpRes.StatusCode == HttpStatusCode.NotFound)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.InternalServerError)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.BadRequest)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.BadGateway)
                {
                    httpRes.Close();
                    return false;
                }

                // Close the response.
                httpRes.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ckURLReal()
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.realui.app");
            httpReq.AllowAutoRedirect = false;
            try
            {

                HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
                //MessageBox.Show(httpRes.StatusCode.ToString(), "Status");
                if (httpRes.StatusCode == HttpStatusCode.NotFound)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.InternalServerError)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.BadRequest)
                {
                    httpRes.Close();
                    return false;
                }
                else if (httpRes.StatusCode == HttpStatusCode.BadGateway)
                {
                    httpRes.Close();
                    return false;
                }

                // Close the response.
                httpRes.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
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
        void Proc()
        {
            if (IsConnectedToInternet())
            {

                Thread.Sleep(1300);
                Task.Run(() =>
                {
                    string sc = label1.Text;
                    if (ckURLRC())
                    {
                        Invoke(new Action(() =>
                        {
                            if (!RCFixer.Settings.Default.TR)
                            {
                                label1.Text = sc + "\n\n> " + langEN.Repair2SolutionServerRCSucces;
                            }
                            else
                            {
                                label1.Text = sc + "\n\n> realitycheats.com Sunucusu ile\niletişimde hiçbir sorun yok.\n";
                            }
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            if (!RCFixer.Settings.Default.TR)
                            {
                                label1.Text = sc + "\n\n> " + langEN.Repair2SolutionServerRCErr;
                            }
                            else
                            {
                                label1.Text = sc + "\n\n> realitycheats.com Sunucusu ile\niletişim kurmada bir sorun bulundu.\n";
                            }
                        }));
                    }
                    Thread.Sleep(1500);
                    if (ckURLReal())
                    {
                        Invoke(new Action(() =>
                        {
                            if (!RCFixer.Settings.Default.TR)
                            {
                                label1.Text = label1.Text + "\n> " + langEN.Repair2SolutionServerRealUISucces;
                            }
                            else
                            {
                                label1.Text = label1.Text + "\n> realui.app Sunucusu ile\niletişimde hiçbir sorun yok.\n";
                            }
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            if (!RCFixer.Settings.Default.TR)
                            {
                                label1.Text = label1.Text + "\n> " + langEN.Repair2SolutionServerRealUIErr;
                            }
                            else
                            {
                                label1.Text = label1.Text + "\n> realui.app Sunucusu ile\niletişim kurmada bir sorun bulundu.\n";
                            }
                        }));
                    }
                });
            }
            else
            {
                Thread.Sleep(1000);
                Invoke(new Action(() =>
                {
                    if (!RCFixer.Settings.Default.TR)
                    {
                        label1.Text = label1.Text + "\n\n> " + langEN.Repair2SolutionNoNetwork;
                    }
                    else
                    {
                        label1.Text = label1.Text + "\n\n> İnternete bağlanılamadı, Lütfen\nbir ağ bağlanın ve tekrar deneyin.";
                    }
                }));
                /* if (!RCFixer.Settings.Default.TR)
                 {
                     richTextBox1.Text = richTextBox1.Text + "\n> " + langEN.Repair2SolutionServerRCErr;
                 }
                 else
                 {
                     richTextBox1.Text = richTextBox1.Text + "\n> realitycheats.com Sunucusu ile\niletişim kurmada bir sorun bulundu.\n";
                 }
                 if (!RCFixer.Settings.Default.TR)
                 {
                     richTextBox1.Text = richTextBox1.Text + "\n> " + langEN.Repair2SolutionServerRealUIErr;
                 }
                 else
                 {
                     richTextBox1.Text = richTextBox1.Text + "\n> realui.app Sunucusu ile\niletişim kurmada bir sorun bulundu.\n";
                 }*/
            }
        }
        private void Remedy1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Proc();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            if (!RCFixer.Settings.Default.TR)
            {
                label1.Text = "Checking Servers...";
            }
            else
            {
                label1.Text = "Sunucular Kontrol Ediliyor...";
            }
            try
            {

                Remedy1.Dispose();
                Remedy1.Dispose();
                Remedy1.RunWorkerAsync();
            }
            catch (Exception)
            {

            }
        }

        private void _2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
