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
    public partial class FormTest : Form
    {
        private JsonTest data;

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Shown(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //throw new InvalidExpressionException();

            data = main.serverconnect.GetTestById(main.temp);

            label1.Text = data.name;
            for (int i = 0; i < data.questions.Count; i++)
            {
                comboBox1.Items.Add(data.questions[i].title);
            }
            comboBox1.SelectedIndex = 0;
            /*
            for (int i = 0; i<data.questions.Count; i++)
            {
                comboBox1.Items.Add(data.questions[i].id);
                comboBox1.Items.Add(data.questions[i].title);
                comboBox1.Items.Add(data.questions[i].content);
                for (int j = 0; i<data.questions[i].answers.Count; j++)
                {
                    comboBox1.Items.Add(data.questions[i].answers[i].id);
                    comboBox1.Items.Add(data.questions[i].answers[i].content);
                }
            }
            */

            /*
            foreach (JsonTestList t in data)
            {
                comboBoxTestList.Items.Add(t.name);
            }
            */
            
            
            //this.Close(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;




            int i = comboBox1.SelectedIndex;
            textBox1.Text = data.questions[i].content;
            for (int j = 0; j<data.questions[i].answers.Count; j++)
            {
                groupBox1.Controls[j].Visible = true;
                groupBox1.Controls[j].Text = data.questions[i].answers[j].content;
            }



        }
        
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count) comboBox1.SelectedIndex++;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count-1) comboBox1.SelectedIndex++;
        }

    }
}
