using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text=="")
                return;
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                main.login = textBoxLogin.Text;
                main.password = textBoxPass.Text;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAuth_Shown(object sender, EventArgs e)
        {
            textBoxLogin.Focus();
        }
    }
}
