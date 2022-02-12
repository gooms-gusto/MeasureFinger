namespace MeasureFinger
{
    partial class FORM_UBAH_PASSWORD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txt_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btn_ubah = new System.Windows.Forms.Button();
            this._btn_batal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btn_batal);
            this.groupBox1.Controls.Add(this._btn_ubah);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._txt_password);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _txt_password
            // 
            this._txt_password.Location = new System.Drawing.Point(10, 32);
            this._txt_password.MaxLength = 10;
            this._txt_password.Name = "_txt_password";
            this._txt_password.Size = new System.Drawing.Size(230, 20);
            this._txt_password.TabIndex = 0;
            this._txt_password.UseSystemPasswordChar = true;
            this._txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_password_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximal 10 karakter";
            // 
            // _btn_ubah
            // 
            this._btn_ubah.Location = new System.Drawing.Point(62, 61);
            this._btn_ubah.Name = "_btn_ubah";
            this._btn_ubah.Size = new System.Drawing.Size(64, 23);
            this._btn_ubah.TabIndex = 2;
            this._btn_ubah.Text = "Ubah";
            this._btn_ubah.UseVisualStyleBackColor = true;
            this._btn_ubah.Click += new System.EventHandler(this._btn_ubah_Click);
            // 
            // _btn_batal
            // 
            this._btn_batal.Location = new System.Drawing.Point(132, 61);
            this._btn_batal.Name = "_btn_batal";
            this._btn_batal.Size = new System.Drawing.Size(64, 23);
            this._btn_batal.TabIndex = 3;
            this._btn_batal.Text = "Batal";
            this._btn_batal.UseVisualStyleBackColor = true;
            this._btn_batal.Click += new System.EventHandler(this._btn_batal_Click);
            // 
            // FORM_UBAH_PASSWORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 96);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_UBAH_PASSWORD";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masukkan password baru!";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btn_batal;
        private System.Windows.Forms.Button _btn_ubah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txt_password;
    }
}