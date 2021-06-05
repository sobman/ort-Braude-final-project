using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace MultiFaceRec
{
    public partial class trans : Form
    {
        public trans()
        {
            InitializeComponent();
        }
        private static trans defaultInstance;
        public static trans Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new trans();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }





        public void TextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        public void Label4_Click(object sender, EventArgs e)
        {

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            con.Open();

            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
            DataSet data = new DataSet();
            ad.Fill(data, "info");
            DataGridView1.DataSource = data.Tables["info"].DefaultView;

            data.Dispose();
            ad.Dispose();
            con.Close();
        }



        private void Trans_Load(object sender, EventArgs e)
        {
            label4.Text = reg.Default.lblaccno.Text;
        }
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
        DataSet ds = new DataSet();
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
        /*****************************/


        string balance;
        int num1;
        int num2;
        int total;
        string totalfinal;
        public int flag = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = default(string);
            string test = default(string);
            DataTable Log_in = new DataTable();
            DataTable pin = new DataTable();
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Pls Enter both Fields");

                }
                else
                {
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
                    sql = "SELECT * FROM tblinfo where account_no = " + textBox1.Text + "";

                    
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    da.SelectCommand = cmd;
                    da.Fill(Log_in);
                    da.Fill(pin);
                    {
                        if (Log_in.Rows.Count > 0)
                        {
                          
                           
                            string accno = default(string);
                           
                            accno = Convert.ToString((Log_in.Rows[0]["account_no"]));
                            balance = (string)(Log_in.Rows[0]["balance"]);
                            num1 = int.Parse(balance);
                            num2 = int.Parse(textBox2.Text);
                            total = num1 + num2;
                            totalfinal = Convert.ToString(total);
                            
                            label5.Text = totalfinal;
                            con.Open();
                            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
                            sql = "UPDATE tblinfo SET balance=\'" + "hello" + "\'" + " Where account_no =\'" + textBox1.Text + "\'";
                            cmd.CommandText = sql;
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            Button5_Click(sender, e);
                            con.Close();







                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        public void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


                

            



 
            


