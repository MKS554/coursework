using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Registr_avtorize
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = textBox6.Text;
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
            {
               
                string parol = textBox7.Text;


               
                String allowchar = " ";
                allowchar = "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, y, z, 1,2,3,4,5,6,7,8,9,0,";

          
                String[] ar = allowchar.Split(',');

                String temp = " "; 
                Random r = new Random();

                int kol = 4; 

                for (int i = 0; i < kol; i++)
                {
                   
                    temp = ar[r.Next(0, ar.Length)];
                    parol += temp;
                   
                }
              
           

                long readTotal = 0;
                int len;
                int tempSize = 100;
                byte[] bin = new byte[tempSize];    
                while (readTotal < parol.Length)
                {
                    Aes aes = Aes.Create();
                    string ivSecret;
                    len = parol.Length;                  
                    readTotal = readTotal + len;
                    
                   
                }



                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                SqlConnection str = new SqlConnection(@"Data Source=WIN-LK1QRPRQTC6\SQLEXPRESS;Initial Catalog=Avtoriz_reg;Integrated Security=True");
                str.Open();
                SqlCommand command = new SqlCommand($" insert into Работники (Имя,Фамилия,Отчество,Номер_телефона,Почта,Логин,Пароль,Пароль_шифрованый) values ('" + ti.ToTitleCase(textBox2.Text) + "' , '" + ti.ToTitleCase(textBox1.Text) + "' , '" + ti.ToTitleCase(textBox3.Text) + "' , '" + ti.ToTitleCase(textBox4.Text) + "' , '" + ti.ToTitleCase(textBox5.Text) + "' , '" + ti.ToTitleCase(textBox6.Text) + "' , '" + ti.ToTitleCase(textBox7.Text)  + (parol+"WE4gk$%") + "')" , str);
                command.ExecuteNonQuery();
                str.Close();
                this.Hide();
                MessageBox.Show("Регистрация прошла успешно !!");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Reg_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
