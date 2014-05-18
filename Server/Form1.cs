using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            Socketclass_server y = new Socketclass_server("localhost", 11000);
            y.AsServer();
            y.ListenMessage();


        }
    }
}
