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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        #region Default Instance

        private static Form3 defaultInstance;


        public static Form3 Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Form3();
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
        string constr;
        System.Data.OleDb.OleDbDataAdapter adapt;
        System.Data.OleDb.OleDbDataAdapter adapt1 = new System.Data.OleDb.OleDbDataAdapter();
        System.Data.OleDb.OleDbConnection conn;
        DataSet dset = new DataSet();

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtAcctNo.Text == "" && txtPincode.Text == "" && txtcontact.Text == "" && txtfname.Text == "" && txtlname.Text == "" && txtaddr.Text == "" && txtcontact.Text == "" && cbGender.Text == "" && cbday.Text == "" && cbmonth.Text == "" && cbyear.Text == "")
            {
                MessageBox.Show("Enter All Fields");

            }
            else if (txtAcctNo.Text == "" || txtPincode.Text == "" || txtcontact.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtaddr.Text == "" || txtcontact.Text == "" || cbGender.Text == "" || cbday.Text == "" || cbmonth.Text == "" || cbyear.Text == "")
            {
                MessageBox.Show("Pls Complete all Fields");

            }
            else
            {
                System.Data.OleDb.OleDbDataAdapter adapt1 = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo where Firstname=\'" + txtfname.Text + "\'", conn);
                DataSet dset1 = new DataSet();
                adapt1.Fill(dset1);
                if (dset1.Tables[0].Rows.Count != 0)
                {
                    MessageBox.Show("Account name already exist");
                }
                else
                {
                    string dbcommand = "INSERT into tblinfo (account_no, Firstname, Lastname, Address, Contact_no, Gender, Birthday, pin_code , type, balance)" + " VALUES (\'" + (txtAcctNo.Text + "\',\'") + txtfname.Text + "\',\'" + txtlname.Text + "\',\'" + txtaddr.Text + "\',\'" + txtcontact.Text + "\',\'" + cbGender.Text + "\',\'" + (cbmonth.Text + cbday.Text + cbyear.Text) + "\',\'" + txtPincode.Text + "\',\'" + "Active" + "\',\'" + "1000" + "\')";
                    System.Data.OleDb.OleDbDataAdapter adapt = new System.Data.OleDb.OleDbDataAdapter(dbcommand, conn);
                    DataSet dset = new DataSet();
                    adapt.Fill(dset);
                    MessageBox.Show("You Have Succesfully Registered!");
                    this.Hide();
                    login.Default.Show();
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString();

            conn.ConnectionString = constr;
            conn.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Default.Show();
        }
    }
}
