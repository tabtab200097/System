﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Server.DB;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socketclass_server y = new Socketclass_server();

        private void buttonStartServer_Click(object sender, EventArgs e)
        {

            y.Start();

        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            y.Stop();




        }
    }
}
