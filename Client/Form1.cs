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
        private int token = 0;
        private TCP y = new TCP();


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
            g = y.SendSimpleText(g);
            Console.WriteLine("Клиент: Ответ от сервера по тексту:{0}\n", g);


        }
    }
}
