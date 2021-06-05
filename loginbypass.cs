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
    public partial class loginbypass : Form
    {
        public loginbypass()
        {
            InitializeComponent();
        }
        private static loginbypass defaultInstance;


        public static loginbypass Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new loginbypass();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }
        
        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public int  cnt=0;
        public int count = 0;
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
        DataSet ds = new DataSet();
        System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();

        private void Btnlogin_Click(object sender, EventArgs e)
        {
          
            string sql = default(string);
            string test = default(string);
            
            DataTable Log_in = new DataTable();
            DataTable pin = new DataTable();
            try
            {
                if (txtpin.Text == "")
                {
                    MessageBox.Show("Pls Enter both Fields");

                }
                else
                {
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
                    sql = "SELECT * FROM tblinfo where pin_code = " + txtpin.Text + "";
                    test = "SELECT pin_code FROM tblinfo where Firstname = " + Label2.Text + "";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    da.SelectCommand = cmd;
                    da.Fill(Log_in);
                    da.Fill(pin);
                    {
                        if (Log_in.Rows.Count > 0)
                        {
                            string Type;
                            string typetoblock;
                            string Fullname = default(string);
                            string accno = default(string);
                            int pincode;
                            Type = (string)(Log_in.Rows[0]["type"]);
                            Fullname = (string)(Log_in.Rows[0]["Firstname"]);
                            accno = Convert.ToString((Log_in.Rows[0]["account_no"]));
                            pincode = (int)(pin.Rows[0]["pin_code"]);
                            typetoblock = (string)(pin.Rows[0]["type"]);
                            if (Type == "admin")
                            {
                                MessageBox.Show("Welcome " + Fullname + " you login as Administrator ");
                                ADMIN.Default.Show();
                                this.Hide();
                                cnt = 1;
                            }
                            else if (Type == "Block" && typetoblock == "Block")
                            {
                                MessageBox.Show("Your account is currently Block");
                                MessageBox.Show("Contact the Administrator for Help");
                                MessageBox.Show("Admin number 054-6859535");

                            }


                            else if (Label2.Text == Fullname)
                            {
                               
                                MessageBox.Show("Welcome " + Fullname);
                                reg.Default.lblname.Text = Fullname;
                                reg.Default.lblaccno.Text = accno;
                                reg.Default.Show();
                                this.Hide();
                                cnt = 1;

                            }
                            else
                            {
                                count += 1;
                                MessageBox.Show("sorry not correct");
                                if (count == 3)
                                {
                                    MessageBox.Show("you are blocked");
                                    con.Open();
                                    System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
                                    sql = "UPDATE tblinfo SET type=\'" + "Block" + "\'" + " Where Firstname =\'" + Label2.Text + "\'";
                                    cmd.CommandText = sql;
                                    cmd.Connection = con;
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                    
                                    con.Close();
                                    


                                }
                                this.Hide();
                            }
                            
                            
                            
                        }

                        else
                        {
                            MessageBox.Show("Yuo are Not Registered!!!");
                            MessageBox.Show("Pls Register if You are New!");


                        }
                    }
                }
            }



            catch (Exception ex)
            {
                MessageBox.Show("there is no connection ");
            }

            txtpin.Text = "";
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

      

        private void Loginbypass_Load(object sender, EventArgs e)
        {
            

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
