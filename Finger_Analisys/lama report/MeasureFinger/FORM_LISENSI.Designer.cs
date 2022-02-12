namespace MeasureFinger
{
    partial class FORM_LISENSI
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
            this._txt_no_seri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txt_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._btn_register = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._txt_perusahaan = new System.Windows.Forms.TextBox();
            this._Btn_Batal = new System.Windows.Forms.Button();
            this.header1 = new EMap.Header();
            this._CkTrial = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _txt_no_seri
            // 
            this._txt_no_seri.BackColor = System.Drawing.Color.Orange;
            this._txt_no_seri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txt_no_seri.Location = new System.Drawing.Point(35, 109);
            this._txt_no_seri.Multiline = true;
            this._txt_no_seri.Name = "_txt_no_seri";
            this._txt_no_seri.ReadOnly = true;
            this._txt_no_seri.Size = new System.Drawing.Size(268, 156);
            this._txt_no_seri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Silahkan copy nomer seri dibawah ini :";
            // 
            // _txt_key
            // 
            this._txt_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txt_key.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txt_key.Location = new System.Drawing.Point(35, 298);
            this._txt_key.Name = "_txt_key";
            this._txt_key.Size = new System.Drawing.Size(455, 20);
            this._txt_key.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Masukkan nomer lisensi dibawah ini, format ( XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXX" +
                "X-XXXX )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "REGISTER PRODUK";
            // 
            // _btn_register
            // 
            this._btn_register.ForeColor = System.Drawing.Color.Black;
            this._btn_register.Location = new System.Drawing.Point(166, 417);
            this._btn_register.Name = "_btn_register";
            this._btn_register.Size = new System.Drawing.Size(120, 23);
            this._btn_register.TabIndex = 5;
            this._btn_register.Text = "Ok";
            this._btn_register.UseVisualStyleBackColor = true;
            this._btn_register.Click += new System.EventHandler(this._btn_register_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "3. Masukkan nama perusahaan anda";
            // 
            // _txt_perusahaan
            // 
            this._txt_perusahaan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txt_perusahaan.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txt_perusahaan.Location = new System.Drawing.Point(35, 356);
            this._txt_perusahaan.Name = "_txt_perusahaan";
            this._txt_perusahaan.Size = new System.Drawing.Size(282, 20);
            this._txt_perusahaan.TabIndex = 7;
            // 
            // _Btn_Batal
            // 
            this._Btn_Batal.ForeColor = System.Drawing.Color.Black;
            this._Btn_Batal.Location = new System.Drawing.Point(292, 417);
            this._Btn_Batal.Name = "_Btn_Batal";
            this._Btn_Batal.Size = new System.Drawing.Size(120, 23);
            this._Btn_Batal.TabIndex = 8;
            this._Btn_Batal.Text = "Batal";
            this._Btn_Batal.UseVisualStyleBackColor = true;
            this._Btn_Batal.Click += new System.EventHandler(this._Btn_Batal_Click);
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
            this.header1.Size = new System.Drawing.Size(582, 50);
            this.header1.TabIndex = 9;
            // 
            // _CkTrial
            // 
            this._CkTrial.AutoSize = true;
            this._CkTrial.Location = new System.Drawing.Point(23, 391);
            this._CkTrial.Name = "_CkTrial";
            this._CkTrial.Size = new System.Drawing.Size(190, 17);
            this._CkTrial.TabIndex = 10;
            this._CkTrial.Text = "Saya ingin melakukan trial program";
            this._CkTrial.UseVisualStyleBackColor = true;
            this._CkTrial.CheckedChanged += new System.EventHandler(this._CkTrial_CheckedChanged);
            // 
            // FORM_LISENSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(582, 452);
            this.ControlBox = false;
            this.Controls.Add(this._CkTrial);
            this.Controls.Add(this.header1);
            this.Controls.Add(this._Btn_Batal);
            this.Controls.Add(this._txt_perusahaan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._btn_register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txt_key);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txt_no_seri);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_LISENSI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisensi Sofware";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txt_no_seri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txt_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btn_register;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txt_perusahaan;
        private System.Windows.Forms.Button _Btn_Batal;
        private EMap.Header header1;
        private System.Windows.Forms.CheckBox _CkTrial;
    }
}