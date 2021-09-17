using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Afo
{
    public partial class Form2 : Form
    {

        public class Win32
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int LoadKeyboardLayoutA(string pwszKLID, int Flags);
        }

        public string ww;
          
        public Form2()
        {
            InitializeComponent();
        }
        public void con(string s,int num)
        {
            OleDbConnection co = new OleDbConnection();
            co.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\daro.mdb;Persist Security Info=False;Jet OLEDB:Database Password=daro;";
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = s;
            cmd.Connection = co;
            switch (num)
            {
                case 1:
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("     عملیات با موفقیت انجام شد     ");
                        }
                        catch
                        {
                            MessageBox.Show("     عملیات با موفقیت انجام نشد     ");
                        }

                        break;
                    }
                case 2:
                    {
                        OleDbDataReader dr = cmd.ExecuteReader();
                        object[] o1 = new object[6];
                        while (dr.Read())
                        {
                            dr.GetValues(o1);
                            dataGridView1.Rows.Add(o1);


                        }

                        break;
                    }
                
                    
                   

            }
            
             co.Close();
           

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Win32.LoadKeyboardLayoutA("00000429", 1);
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

        }

        private void toolStripButton5_Click(object sender, EventArgs e)

        {
            Win32.LoadKeyboardLayoutA("00000429", 1);
            textBox1 .Text ="";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            label0.Text = "     آماده برای اضافه کردن     ";



        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DateTime.Compare(Convert.ToDateTime(textBox4.Text), Convert.ToDateTime(textBox5.Text)) >= 0)
            {
                MessageBox.Show("مدت قرار داد معتبر نیست...");
               goto h;


            }
            err.Clear();
            if (textBox1.Text == "")
            {
                err.SetError(textBox1, "کد بیمه را وارد کنید");
                goto h;
            }
            else if (textBox2.Text == "")
            {
                err.SetError(textBox2, "نام بیمه را را وارد کنید");
                goto h;
            }
            else if (textBox3.Text == "")
            {
                err.SetError(textBox3, "نوع بیمه را وارد کیند");
                goto h;
            }
            else if (textBox4.Text == "")
            {
                err.SetError(textBox4, "تاریخ ");
                goto h;
            }
            else if (textBox5.Text == "")
            {
                err.SetError(textBox5, "تاریخ ");
                goto h;
            }

            //*************************************

            con("Insert Into beme Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", 1);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label0.Text = "  اطلاعات اضافه شد  ";
        h:
            {
            }
               
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true; 
            button1.Enabled = false ;
            button2.Enabled = true ;
            button3.Enabled = false;
            label0.Text = "     آماده برای ویرایش      ";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == string.Empty)
                dataGridView1.Rows.Clear();
            else
            {
                dataGridView1 .Rows.Clear();
                con("Select * from beme Where code like '" + textBox7.Text + "%'", 2);
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a1, a2, a3, a4, a5, a6;
            a1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            a2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            a3 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            a4 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            a5 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            a6 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            con("Update beme Set name='" + a2 + "',type='" + a3 + "',data='" + a4 + "',ta='" + a5 + "',re='" + a6 + "' Where code='" + a1 + "'", 1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            dataGridView1.Rows.Clear();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false ;
            button3.Enabled = true ;
            label0.Text = "    آماده برای حذف       ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("آیا حذف شود", " عملیات حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {                
                
                con("Delete from beme Where code='" +ww+ "'", 1);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Refresh();
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            dataGridView1.Rows.Clear();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            label0.Text = "    جستجو    ";
        }



        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 27)
                if (char.IsDigit(e.KeyChar) == false )
                {
                    e.KeyChar = Convert.ToChar(0);

                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar > 27)
                if (char.IsDigit  (e.KeyChar) == false)
                {
                    e.KeyChar = Convert.ToChar(0);

                }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar > 27)
                if (char.IsLetter(e.KeyChar) == false)
                {
                    e.KeyChar = Convert.ToChar(0);

                }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 27)
                if (char.IsLetter(e.KeyChar) == false)
                {
                    e.KeyChar = Convert.ToChar(0);

                }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 27)
                if (char.IsDigit(e.KeyChar) == true)
                {
                    e.KeyChar = Convert.ToChar(0);

                }
        }



        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToLongDateString ();
        }

        

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 27)
                if (char.IsDigit(e.KeyChar) == false)
                {
                    e.KeyChar = Convert.ToChar(0);

                }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToLongDateString();
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string a1, a2, a3, a4, a5, a6;
            a1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            a2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            a3 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            a4 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            a5 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            a6 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            ww = a1;
          // button3.Enabled = true;
        }

     

    }
} 