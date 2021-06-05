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
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }
        #region Default Instance

        private static ADMIN defaultInstance;


        public static ADMIN Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ADMIN();
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
        DataTable dt = new DataTable();
        string sql;
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

        private void Btnok_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tblinfo where Firstname=\'" + txtfname.Text + "\'" + "and Lastname= \'" + txtlname.Text + "\'";
            try
            {

                con.Open();

                da = new System.Data.OleDb.OleDbDataAdapter(sql, con);

                da.Fill(dt);

                DataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                Interaction.MsgBox(ex.Message, MsgBoxStyle.Information, null);
            }

            con.Close();
            btnok.Enabled = false;

        }

        private void Btnedit_Click(object sender, EventArgs e)
        {
            GroupBox2.Enabled = true;
            btnedit.Enabled = false;
            Button4.Enabled = false;
            btnblock.Enabled = true;
            btnunblock.Enabled = true;
        }
        String NUM1 = " HELLO ";
        private void Button4_Click(object sender, EventArgs e)
        {
            txtfname.Enabled = true;
            txtlname.Enabled = true;
            btnok.Enabled = true;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            login.Default.Show();
            this.Hide();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = default(int);
            int j = default(int);

            i = e.RowIndex;
            j = e.ColumnIndex;
            if (j == 0)
            {
                txtAcctNo.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j].Value));
                txtfnme.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 1].Value));
                lblhide.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 1].Value));
                txtlnme.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 2].Value));
                //txtlname.Text = DataGridView1.Rows(i).Cells(j + 2).Value
                txtaddr.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 3].Value));
                txtcontact.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 4].Value));
                cbGender.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 5].Value));
                txtbday.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 6].Value));
                txtPincode.Text = Convert.ToString((DataGridView1.Rows[i].Cells[j + 7].Value));

            }
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
            Label11.Text = DateTime.Now.ToString();

            txtfname.Enabled = false;
            txtlname.Enabled = false;
            btnblock.Enabled = false;
            btnunblock.Enabled = false;
            GroupBox2.Enabled = false;
            btnok.Enabled = false;
        }

        private void Btnunblock_Click(object sender, EventArgs e)
        {
            con.Open();

            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);

            sql = "UPDATE tblinfo SET type=\'" + "active" + "\'" + " Where Firstname =\'" + txtfnme.Text + "\'";
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("success");

            con.Close();
            Button5_Click(sender, e);
        }

        private void Btnblock_Click(object sender, EventArgs e)
        {
            con.Open();
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
            sql = "UPDATE tblinfo SET balance=\'" + "Block" + "\'" + " Where Firstname =\'" + txtfnme.Text + "\'";
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("success");
            con.Close();
            Button5_Click(sender, e);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FrmPrincipal.Default.Show();
        }
    }
}
