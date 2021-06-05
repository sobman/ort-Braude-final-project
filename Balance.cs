
using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace MultiFaceRec
{
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
        DataSet ds = new DataSet();
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
        string sql;
        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = default(string);
            DataTable Log_in = new DataTable();
            try
            {
                if (txtpin.Text == "")
                {
                    MessageBox.Show("Pls Enter Your Pin");

                }
                else
                {
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
                    sql = "SELECT * FROM tblinfo where  pin_code = " + txtpin.Text + "";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    da.SelectCommand = cmd;
                    da.Fill(Log_in);
                    if (Log_in.Rows.Count > 0)
                    {
                        string balance = default(string);

                        balance = (string)(Log_in.Rows[0]["balance"]);

                        Receipt1.Default.Show();
                        //Receipt1.lblaccno.Text = lblaccno.Text
                        Receipt1.Default.lblbal.Text = balance;
                        Receipt1.Default.Label4.Hide();
                        Receipt1.Default.Label3.Hide();
                        Receipt1.Default.lbldep.Hide();
                        Receipt1.Default.lblwith.Hide();
                        Receipt1.Default.Label6.Hide();
                        Receipt1.Default.lblnewbal.Hide();

                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Pincode is incorrect");

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            txtpin.Text = "";
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Txtpin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lblaccno_Click(object sender, EventArgs e)
        {

        }
    }
}
