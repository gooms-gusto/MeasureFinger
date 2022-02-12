namespace EncryptTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._BtnEncrypt = new System.Windows.Forms.Button();
            this._BtnDecrypt = new System.Windows.Forms.Button();
            this._D_T1 = new System.Windows.Forms.TextBox();
            this._D_T2 = new System.Windows.Forms.TextBox();
            this._E_T2 = new System.Windows.Forms.TextBox();
            this._E_T1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _BtnEncrypt
            // 
            this._BtnEncrypt.Location = new System.Drawing.Point(110, 77);
            this._BtnEncrypt.Name = "_BtnEncrypt";
            this._BtnEncrypt.Size = new System.Drawing.Size(75, 23);
            this._BtnEncrypt.TabIndex = 0;
            this._BtnEncrypt.Text = "Encrypt";
            this._BtnEncrypt.UseVisualStyleBackColor = true;
            this._BtnEncrypt.Click += new System.EventHandler(this._BtnEncrypt_Click);
            // 
            // _BtnDecrypt
            // 
            this._BtnDecrypt.Location = new System.Drawing.Point(494, 77);
            this._BtnDecrypt.Name = "_BtnDecrypt";
            this._BtnDecrypt.Size = new System.Drawing.Size(75, 23);
            this._BtnDecrypt.TabIndex = 1;
            this._BtnDecrypt.Text = "Decrypt";
            this._BtnDecrypt.UseVisualStyleBackColor = true;
            this._BtnDecrypt.Click += new System.EventHandler(this._BtnDecrypt_Click);
            // 
            // _D_T1
            // 
            this._D_T1.Location = new System.Drawing.Point(136, 12);
            this._D_T1.Name = "_D_T1";
            this._D_T1.Size = new System.Drawing.Size(165, 20);
            this._D_T1.TabIndex = 2;
            // 
            // _D_T2
            // 
            this._D_T2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this._D_T2.Location = new System.Drawing.Point(136, 38);
            this._D_T2.Name = "_D_T2";
            this._D_T2.ReadOnly = true;
            this._D_T2.Size = new System.Drawing.Size(165, 20);
            this._D_T2.TabIndex = 3;
            // 
            // _E_T2
            // 
            this._E_T2.BackColor = System.Drawing.Color.Cyan;
            this._E_T2.Location = new System.Drawing.Point(457, 38);
            this._E_T2.Name = "_E_T2";
            this._E_T2.ReadOnly = true;
            this._E_T2.Size = new System.Drawing.Size(165, 20);
            this._E_T2.TabIndex = 5;
            // 
            // _E_T1
            // 
            this._E_T1.Location = new System.Drawing.Point(457, 12);
            this._E_T1.Name = "_E_T1";
            this._E_T1.Size = new System.Drawing.Size(165, 20);
            this._E_T1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Karakter Belum Encrypt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Karakter Sudah Encrypt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Karakter Sudah Encrypt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Karakter Belum Encrypt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 117);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._E_T2);
            this.Controls.Add(this._E_T1);
            this.Controls.Add(this._D_T2);
            this.Controls.Add(this._D_T1);
            this.Controls.Add(this._BtnDecrypt);
            this.Controls.Add(this._BtnEncrypt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Made by @kbar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _BtnEncrypt;
        private System.Windows.Forms.Button _BtnDecrypt;
        private System.Windows.Forms.TextBox _D_T1;
        private System.Windows.Forms.TextBox _D_T2;
        private System.Windows.Forms.TextBox _E_T2;
        private System.Windows.Forms.TextBox _E_T1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

