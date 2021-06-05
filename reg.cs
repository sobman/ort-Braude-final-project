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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.sob;
        }
        private static reg defaultInstance;


        public static reg Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new reg();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }
        
        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
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
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
                sql = "SELECT * FROM tblinfo where  account_no = " + lblaccno.Text + "";
                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(Log_in);
                if (Log_in.Rows.Count > 0)
                {
                    string balance = default(string);
                    balance = (string)(Log_in.Rows[0]["balance"]);
                    Receipt1.Default.Show();
                   
                    Receipt1.Default.lblname.Text = lblname.Text;
                    //Receipt11.lblaccno.Text = lblaccno.Text
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btndep_Click(object sender, EventArgs e)
        {
            
            dep.Default.Show();
            this.Hide();
        }

        private void Btnwith_Click(object sender, EventArgs e)
        {
            Withdraw1.Default.Show();
            this.Hide();
        }

        private void Btnlogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
          
            trans.Default.Show();
           



        }
        
        public void Lblaccno_Click(object sender, EventArgs e)
        {
            
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString();
        }

        public void Label4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
