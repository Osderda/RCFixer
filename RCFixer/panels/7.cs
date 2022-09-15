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
    public partial class _7 : Form
    {
        public _7()
        {
            InitializeComponent();
            if (!lang.TR)
            {
                richTextBox1.Text = langEN.Repair7Title;
                ıconButton1.Text = langEN.Repair7Button;
            }
        }

        private void _1_Load(object sender, EventArgs e)
        {

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            Process.Start(RCFixer.Properties.Resources.topicURL);
        }
    }
}
