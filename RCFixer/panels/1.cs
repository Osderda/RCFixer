﻿using System;
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
    public partial class _1 : Form
    {
        public _1()
        {
            InitializeComponent();
            if (!lang.TR)
            {
                richTextBox1.Text = langEN.Repair1Title;
                ıconButton1.Text = langEN.Repair1Button;
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
            new repair._1().ShowDialog();
        }
    }
}
