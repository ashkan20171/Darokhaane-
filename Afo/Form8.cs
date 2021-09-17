using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Afo
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Form8 f8 = new Form8();
            if (textBox1.Text =="1234")
            {
                Form8.ActiveForm.Hide();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("     —„“ Ê—Êœ «‘ »«Â «”      ");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1_Click(textBox1,e);
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}