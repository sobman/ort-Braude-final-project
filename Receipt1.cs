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
    public partial class Receipt1 : Form
    {
        public Receipt1()
        {
            InitializeComponent();

        }
        private static Receipt1 defaultInstance;


        public static Receipt1 Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Receipt1();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
        DataTable dt = new DataTable();
        string sql;
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

        private void Receipt1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
            lbldate.Text = DateTime.Now.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (lblnewbal.Text == "")
            {
                this.Close();
                reg.Default.Show();

            }
            else
            {

                con.Open();
                int total = int.Parse(lblnewbal.Text);
                System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
                sql = "UPDATE tblinfo SET balance=\'" + total.ToString() + "\'" + " Where Firstname=\'" + lblname.Text + "\'";
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                this.Close();
                reg.Default.Show();

            }
        }
    }
}

