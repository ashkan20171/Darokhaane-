using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Afo
{
    public partial class Form1 : Form
    {
        public class win7
        {
            [DllImport("user32.dll",SetLastError=true)]
            public static extern int LoadKeyboardLayoutA(string pwszKLID, int Flags);
        }
  
        Form2 f2 = new Form2();
        Form3 f3 = new Form3();
        Form4 f4 = new Form4();
        Form5 f5 = new Form5();
        Form6 f6 = new Form6();
        Form7 f7 = new Form7();
       

        public Form1()
        {
            InitializeComponent();
        }

        

        private void بیمههایطرفقراردادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
          
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();

        }

        private void کارخانههایطرفقراردادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3.ShowDialog();
        }

        private void پزشکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4.ShowDialog();
        }

        private void داروهایخریدداریشدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5.ShowDialog();
        }

        private void اجناسخریدیغیرداروییToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.ShowDialog();
        }

        private void انتقالبهانباردیگریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f7.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      
    }
}