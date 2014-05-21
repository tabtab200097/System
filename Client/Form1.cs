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
        private TCP y = new TCP("localhost", 30000);

        public string login;
        public string password;
        private int token;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            token = y.Authorization("admin", "admin");
            if (token == 0)
                Console.WriteLine("Авторизация не прошла\n");
            else
                Console.WriteLine("Полученый токен:{0}\n", token);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string g = "SomeString";
            string gg = y.SendSimpleText(g);
            Console.WriteLine("Клиент: Ответ от сервера по тексту:{0}\n", gg);


        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {

            FormAuth f = new FormAuth();
            f.Owner = this;
            f.ShowDialog();

            Console.WriteLine("TESTTTTTTTTTTTTTTTTTTTT");

            if(login!="")
            {
                token = y.Authorization(login, password);
            }
            password = "";
            buttonAuth.Visible = false;
            Console.WriteLine("TESTTTTTTTTTTTTTTTTTTTT");

            /*secondForm = new SecondForm(tb_mainForm.Text.Trim());
            secondForm.ShowDialog();

            if (secondForm.DialogResult == DialogResult.OK)
                tb_mainForm.Text = secondForm.ReturnData();
             */
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            login = "";
            token = 0;
            buttonAuth.Visible = true;
        }
    }
}
