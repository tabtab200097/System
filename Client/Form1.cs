﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JsonModel;

namespace Client
{
    public partial class Form1 : Form
    {
        public TCP serverconnect = new TCP("localhost", 30000);

        public string login = "";
        public string password = "";
        public int temp;
        private int token;
        public JsonUserTest user_answers = new JsonUserTest();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            token = serverconnect.Authorization("admin", "admin");
            if (token == 0)
                Console.WriteLine("Авторизация не прошла\n");
            else
                Console.WriteLine("Полученый токен:{0}\n", token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string g = "SomeString";
            string gg = serverconnect.SendSimpleText(g);
            Console.WriteLine("Клиент: Ответ от сервера по тексту:{0}\n", gg);
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {

            FormAuth f = new FormAuth();
            f.Owner = this;
            f.ShowDialog();
            if(login!="")
            {
                token = serverconnect.Authorization(login, password);
            }
            password = "";
            if (token != 0)
            {
                //авторизация удалась
                labelLogin.Text = login;
                labelToken.Text = token.ToString();
                buttonAuth.Visible = false;
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            login = "";
            token = 0;
            labelLogin.Text = "";
            labelToken.Text = "";
            buttonAuth.Visible = true;
        }

        private void buttonTheory_Click(object sender, EventArgs e)
        {

        }

        private void buttonTests_Click(object sender, EventArgs e)
        {
            if(token==0)
            {
                MessageBox.Show("Пожалуйста, войдите в систему");
                return;
            }
            FormSelectTest f = new FormSelectTest();
            f.Owner = this;
            f.ShowDialog();
            FormTest f2 = new FormTest();
            f2.Owner = this;
            f2.ShowDialog();


        }

        private void buttonJournal_Click(object sender, EventArgs e)
        {
            if (token==0)
            {
                MessageBox.Show("Пожалуйста, войдите в систему");
                return;
            }


        }
    }
}
