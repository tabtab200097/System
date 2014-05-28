using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JsonModel;
using Newtonsoft.Json;

namespace Client
{
    public partial class FormSelectTest : Form
    {
        //private JsonTestList testlist = new JsonTestList();
        private List<JsonTestList> data;
        
        public FormSelectTest()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if(comboBoxTestList.SelectedIndex>-1)
            {
                main.temp = data[comboBoxTestList.SelectedIndex].id;
            }
            this.Close(); 
        }

        private void FormSelectTest_Shown(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            data = main.serverconnect.GetTestList();
            foreach (JsonTestList t in data)
            {
                comboBoxTestList.Items.Add(t.name);
            }

        }
    }
}
