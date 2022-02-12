namespace MeasureFinger
{
    partial class FORM_LEGAL
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
            this._btn_hapus_lisensi = new System.Windows.Forms.Button();
            this._btn_keluar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtcompany = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btn_hapus_lisensi
            // 
            this._btn_hapus_lisensi.Location = new System.Drawing.Point(50, 98);
            this._btn_hapus_lisensi.Name = "_btn_hapus_lisensi";
            this._btn_hapus_lisensi.Size = new System.Drawing.Size(114, 23);
            this._btn_hapus_lisensi.TabIndex = 0;
            this._btn_hapus_lisensi.Text = "Hapus Lisensi";
            this._btn_hapus_lisensi.UseVisualStyleBackColor = true;
            this._btn_hapus_lisensi.Click += new System.EventHandler(this._btn_hapus_lisensi_Click);
            // 
            // _btn_keluar
            // 
            this._btn_keluar.Location = new System.Drawing.Point(170, 98);
            this._btn_keluar.Name = "_btn_keluar";
            this._btn_keluar.Size = new System.Drawing.Size(114, 23);
            this._btn_keluar.TabIndex = 1;
            this._btn_keluar.Text = "Keluar";
            this._btn_keluar.UseVisualStyleBackColor = true;
            this._btn_keluar.Click += new System.EventHandler(this._btn_keluar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sofware ini telah dilisensi oleh:";
            // 
            // _txtcompany
            // 
            this._txtcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtcompany.Location = new System.Drawing.Point(12, 51);
            this._txtcompany.Name = "_txtcompany";
            this._txtcompany.Size = new System.Drawing.Size(320, 23);
            this._txtcompany.TabIndex = 3;
            this._txtcompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FORM_LEGAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(340, 133);
            this.ControlBox = false;
            this.Controls.Add(this._txtcompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btn_keluar);
            this.Controls.Add(this._btn_hapus_lisensi);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_LEGAL";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informasi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btn_hapus_lisensi;
        private System.Windows.Forms.Button _btn_keluar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _txtcompany;
    }
}