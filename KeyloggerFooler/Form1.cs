using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyloggerFooler
{
    public partial class Form1 : Form
    {
        string password = "";
        public Form1()
        {
            InitializeComponent();
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (password.Length > textBox1.Text.Length)
            {
                password = textBox1.Text;
                return;
            }
            //if (textBox1.Text.Length - password.Length > 0) return;
            password += textBox1.Text.Substring(textBox1.Text.Length - 1);
            textBox2.Select();
            textBox2.Focus();
           SendKeys.SendWait(RandomString(random.Next(15) + 6));
            textBox1.Select();
            textBox1.Focus();
            textBox1.SelectionStart = password.Length;
            textBox1.Text = password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password = "";
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(password);
        }
    }
}
