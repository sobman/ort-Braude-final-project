namespace MultiFaceRec
{
    partial class Withdraw1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.lblaccno = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabel1.Location = new System.Drawing.Point(359, 40);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(56, 20);
            this.LinkLabel1.TabIndex = 37;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Home";
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Label4.Location = new System.Drawing.Point(113, 128);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(277, 15);
            this.Label4.TabIndex = 36;
            this.Label4.Text = "Maximum Withdraw amount is Php 25,000";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(32, 102);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(76, 20);
            this.Label3.TabIndex = 35;
            this.Label3.Text = "Amount:";
            // 
            // txtamount
            // 
            this.txtamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamount.Location = new System.Drawing.Point(116, 99);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(268, 26);
            this.txtamount.TabIndex = 34;
            // 
            // lblaccno
            // 
            this.lblaccno.AutoSize = true;
            this.lblaccno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaccno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblaccno.Location = new System.Drawing.Point(33, 63);
            this.lblaccno.Name = "lblaccno";
            this.lblaccno.Size = new System.Drawing.Size(32, 18);
            this.lblaccno.TabIndex = 33;
            this.lblaccno.Text = "no.";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldate.Location = new System.Drawing.Point(259, 63);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(41, 15);
            this.lbldate.TabIndex = 32;
            this.lbldate.Text = "Date:";
            // 
            // btnok
            // 
            this.btnok.BackColor = System.Drawing.Color.Silver;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(183, 164);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(88, 47);
            this.btnok.TabIndex = 31;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Click += new System.EventHandler(this.Btnok_Click);
            // 
            // Withdraw1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 250);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.lblaccno);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.btnok);
            this.Name = "Withdraw1";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Withdraw1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.LinkLabel LinkLabel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtamount;
        internal System.Windows.Forms.Label lblaccno;
        internal System.Windows.Forms.Label lbldate;
        internal System.Windows.Forms.Button btnok;
    }
}