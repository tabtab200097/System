using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCP y = new TCP("192.168.10.7", 11000);
            string g = "SomeString";
            //Console.WriteLine("Полученый токен:{0}\n", y.Autorisation("admin", "admin"));
            //y.SendMessage(g);
            //y.SendMessageFromSocket(30000);

            byte[] gg = Encoding.UTF8.GetBytes(g);
            y.SendMessage1(gg);

        }
    }
}
