using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registr_avtorize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string parol = textBox2.Text;


            SqlConnection str = new SqlConnection(@"Data Source=WIN-LK1QRPRQTC6\SQLEXPRESS;Initial Catalog=Avtoriz_reg;Integrated Security=True");
            str.Open();
            SqlCommand command = new SqlCommand("select Фамилия,Имя,Отчество,Номер_телефона,Почта from Работники where(Логин='" + login + "' and Пароль='" + parol + "');", str);
            SqlDataReader reader = command.ExecuteReader();
            string fio = "";
            string telefon = "";
            string pochta = "";
            while (reader.Read())
            {
                fio = reader[1].ToString();
                fio+= " " + reader[0].ToString();
                fio += " " + reader[2].ToString();
                telefon = reader[3].ToString();
                pochta = reader[4].ToString();

            }
            reader.Close();
            str.Close();

            if (fio.Length > 5)
            {
                MessageBox.Show("Успешный вход !\n ваши данные: \n" + fio + "\n" + telefon + "\n" + pochta  );
            }
            else
            {
                MessageBox.Show("Нет такого пользователя");
            }
        }
    }
}
