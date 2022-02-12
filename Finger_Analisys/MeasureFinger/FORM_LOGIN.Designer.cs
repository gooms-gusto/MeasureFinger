namespace MeasureFinger
{
    partial class FORM_LOGIN
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
            EMap.DocInfo docInfo1 = new EMap.DocInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btn_batal = new System.Windows.Forms.Button();
            this._btn_oke = new System.Windows.Forms.Button();
            this._txt_password = new System.Windows.Forms.TextBox();
            this.header1 = new EMap.Header();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btn_batal);
            this.groupBox1.Controls.Add(this._btn_oke);
            this.groupBox1.Controls.Add(this._txt_password);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(61, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Masukkan password";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // _btn_batal
            // 
            this._btn_batal.ForeColor = System.Drawing.Color.Black;
            this._btn_batal.Location = new System.Drawing.Point(138, 62);
            this._btn_batal.Name = "_btn_batal";
            this._btn_batal.Size = new System.Drawing.Size(40, 22);
            this._btn_batal.TabIndex = 7;
            this._btn_batal.Text = "Batal";
            this._btn_batal.UseVisualStyleBackColor = true;
            this._btn_batal.Click += new System.EventHandler(this._btn_batal_Click);
            // 
            // _btn_oke
            // 
            this._btn_oke.ForeColor = System.Drawing.Color.Black;
            this._btn_oke.Location = new System.Drawing.Point(96, 62);
            this._btn_oke.Name = "_btn_oke";
            this._btn_oke.Size = new System.Drawing.Size(36, 22);
            this._btn_oke.TabIndex = 6;
            this._btn_oke.Text = "Ok";
            this._btn_oke.UseVisualStyleBackColor = true;
            this._btn_oke.Click += new System.EventHandler(this._btn_oke_Click);
            // 
            // _txt_password
            // 
            this._txt_password.Location = new System.Drawing.Point(30, 36);
            this._txt_password.MaxLength = 10;
            this._txt_password.Name = "_txt_password";
            this._txt_password.Size = new System.Drawing.Size(210, 20);
            this._txt_password.TabIndex = 5;
            this._txt_password.UseSystemPasswordChar = true;
            this._txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_password_KeyPress);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(164)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            docInfo1.HTMLFileName = "";
            docInfo1.LocationFile = "C:\\Program Files\\Microsoft Visual Studio 8\\Common7\\IDE\\devenv.exe\\docs\\";
            this.header1.HDocInfo = docInfo1;
            this.header1.HeaderDetailLoc = new System.Drawing.Point(105, 28);
            this.header1.HeaderDetailText = null;
            this.header1.HeaderLoc = new System.Drawing.Point(90, 4);
            this.header1.HeaderText = null;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(408, 50);
            this.header1.TabIndex = 3;
            // 
            // FORM_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(408, 193);
            this.ControlBox = false;
            this.Controls.Add(this.header1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_LOGIN";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txt_password;
        private System.Windows.Forms.Button _btn_oke;
        private System.Windows.Forms.Button _btn_batal;
        private EMap.Header header1;
    }
}