﻿using System;
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
        private JsonUserTest result;
        private int currentQuestion = 0;
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Shown(object sender, EventArgs e)
        {
            label1.Text = data.name;
            for (int i = 0; i < data.questions.Count; i++)
            {
                comboBox1.Items.Add(data.questions[i].title);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            int i = comboBox1.SelectedIndex;
            textBox1.Text = data.questions[i].content;
            for (int j = 0; j < data.questions[i].answers.Count; j++)
            {
                groupBox1.Controls[j].Visible = true;
                groupBox1.Controls[j].Text = data.questions[i].answers[j].content;
            }
            currentQuestion = comboBox1.SelectedIndex;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            JsonUserQuestion tempquestion = new JsonUserQuestion();
            tempquestion.questionid = data.questions[currentQuestion].id;
            tempquestion.answers = new List<JsonUserAnswer>();

            int j = 0;
            foreach (RadioButton t in groupBox1.Controls)
            {
                if (j >= data.questions[currentQuestion].answers.Count)
                    break;

                if (t.Checked)
                {
                    JsonUserAnswer temp = new JsonUserAnswer();
                    temp.answerid = 1;
                    tempquestion.answers.Add(temp);
                }
            }
            result.questions[currentQuestion] = tempquestion;
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1) comboBox1.SelectedIndex++;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1) comboBox1.SelectedIndex++;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.user_answers = result;
            /*
             * ну или отправить
             * */
            FormResult f = new FormResult();
            f.Owner = main;
            //f.ShowDialog();

            Close();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //throw new InvalidExpressionException();

            data = main.serverconnect.GetTestById(main.temp);

            result = new JsonUserTest() { id = data.id };
            result.questions = new List<JsonUserQuestion>(data.questions.Count);
            for (int i = 0; i < data.questions.Count; i++)
                result.questions.Add(new JsonUserQuestion());
        }

    }
}
