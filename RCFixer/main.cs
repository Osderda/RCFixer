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
namespace RCFixer
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            WinAPI.AnimateWindow(this.Handle, 300, WinAPI.BLENDA);
            if (!lang.TR)
            {
                wtitle.Text = langEN.WindowTitle;
            }
        }
        private Form currentForm;
        public async void AddForm(Form childform)
        {
            currentForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Top;

            panel2.Controls.Add(childform);
            panel2.Tag = childform;
            childform.BringToFront();
            childform.Show();
            bunifuTransition1.ShowSync(childform);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void wtitle_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.TopMost = false;


            AddForm(new panels._1());
            AddForm(new panels.space());
            AddForm(new panels._2());
            AddForm(new panels.space());
            AddForm(new panels._3());
            AddForm(new panels.space());
            AddForm(new panels._4());
            AddForm(new panels.space());
            AddForm(new panels._5());
            AddForm(new panels.space());
            //AddForm(new panels._6());
            //AddForm(new panels.space());
            AddForm(new panels._7());
            AddForm(new panels.space());
          //  AddForm(new panels._8());
            //AddForm(new panels.space());
        //    AddForm(new panels._9());
         //   AddForm(new panels.space());
            AddForm(new panels._10());
            timer1.Start();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
           /* o.LangSelect lsz = new o.LangSelect();
            Form ls = Application.OpenForms.Cast<Form>().Where(f => f.GetType() == typeof(o.LangSelect)).FirstOrDefault();
            if (ls == null)
            {
                Invoke(new Action(() =>
                {
                    lsz.Show();
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    lsz.Activate();
                }));
            }*/
            
            o.LangSelect ls = new o.LangSelect();
            if (Application.OpenForms["LangSelect"] == null)
            {
                ls.ShowDialog();
            }
            else
            {
                ls.Activate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            timer1.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
