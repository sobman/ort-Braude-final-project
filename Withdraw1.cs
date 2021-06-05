using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class Withdraw1 : Form
    {
        public Withdraw1()
        {
            InitializeComponent();
        }
        #region Default Instance
        private static Withdraw1 defaultInstance;
        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static Withdraw1 Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Withdraw1();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion
        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
        DataSet dset = new DataSet();
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        string balance;
        int num1;
        int num2;
        int total;
        private void Withdraw1_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString();
            lblaccno.Text = reg.Default.lblaccno.Text;
        }

        private void Btnok_Click(object sender, EventArgs e)
        {
            string sql = default(string);
            DataTable Log_in = new DataTable();

            try
            {



               con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
                sql = "SELECT * FROM tblinfo where  account_no = " + lblaccno.Text + "";

                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(Log_in);
                if (Log_in.Rows.Count > 0)
                {
                    balance = (string)(Log_in.Rows[0]["balance"]);
                    num1 = int.Parse(balance);
                    num2 = int.Parse(txtamount.Text);

                    if (num2 > 25000)
                    {
                        MessageBox.Show("You can Only Withdraw Php 25,000");
                    }
                    else if (num2 < 200)
                    {
                        MessageBox.Show(" Mininum withdrawal is 200");
                    }
                    else if (num1 < num2)
                    {
                        MessageBox.Show(" Insuffiecient balance");

                    }
                    else
                    {
                        total = num1 - num2;

                        Receipt1.Default.Show();

                        Receipt1.Default.lblbal.Text = balance;
                        Receipt1.Default.Label4.Hide();
                        Receipt1.Default.lbldep.Hide();
                        Receipt1.Default.lblwith.Text = num2.ToString();
                        Receipt1.Default.lblnewbal.Text = total.ToString();

                        Receipt1.Default.Label5.Show();
                        Receipt1.Default.Label6.Show();


                        Receipt1.Default.lblbal.Show();
                        Receipt1.Default.Label4.Hide();
                        Receipt1.Default.lbldep.Hide();
                        Receipt1.Default.lblwith.Show();
                        Receipt1.Default.lblnewbal.Show();
                        //MsgBox("success")
                        Receipt1.Default.lblname.Text = reg.Default.lblname.Text;
                        this.Hide();


                    }
                }
                else
                {


                }

            }
            catch (Exception)
            {
                MessageBox.Show(" Pls. Enter Ammount!");
                //MsgBox(ex.Message)
            }
            txtamount.Text = "";


        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            reg.Default.Show();
        }
    }
}
