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
    public partial class FormResult : Form
    {
        public List<JsonUserResult> list = new List<JsonUserResult>();
        
        public FormResult()
        {
            InitializeComponent();
        }

        private void FormResult_Shown(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            list = main.serverconnect.CheckMyAnswersPleeease(main.user_answers);

            foreach (JsonUserResult t in list)
            {
                string s = t.questioncontent + " ";
                foreach (JsonUserResultAnswer t2 in t.answers)
                {
                    s += t2.answer + " ";
                }
                s += t.result;
                listBox1.Items.Add(s);
            }

        }
    }
}
