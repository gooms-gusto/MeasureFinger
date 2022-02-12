namespace MeasureFinger
{
    partial class FORM_INPUT_ID
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
            this.label1 = new System.Windows.Forms.Label();
            this._TxtNomorCetak = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._BtnBatal = new System.Windows.Forms.Button();
            this._BtnSimpan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masukkan Nomor Cetak Pasien";
            // 
            // _TxtNomorCetak
            // 
            this._TxtNomorCetak.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtNomorCetak.Location = new System.Drawing.Point(165, 13);
            this._TxtNomorCetak.Name = "_TxtNomorCetak";
            this._TxtNomorCetak.Size = new System.Drawing.Size(176, 27);
            this._TxtNomorCetak.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox1.Controls.Add(this._BtnBatal);
            this.groupBox1.Controls.Add(this._BtnSimpan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._TxtNomorCetak);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // _BtnBatal
            // 
            this._BtnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._BtnBatal.Location = new System.Drawing.Point(255, 51);
            this._BtnBatal.Name = "_BtnBatal";
            this._BtnBatal.Size = new System.Drawing.Size(85, 29);
            this._BtnBatal.TabIndex = 3;
            this._BtnBatal.Text = "Batal";
            this._BtnBatal.UseVisualStyleBackColor = true;
            this._BtnBatal.Click += new System.EventHandler(this._BtnBatal_Click);
            // 
            // _BtnSimpan
            // 
            this._BtnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._BtnSimpan.Location = new System.Drawing.Point(165, 51);
            this._BtnSimpan.Name = "_BtnSimpan";
            this._BtnSimpan.Size = new System.Drawing.Size(85, 29);
            this._BtnSimpan.TabIndex = 2;
            this._BtnSimpan.Text = "Simpan nomor";
            this._BtnSimpan.UseVisualStyleBackColor = true;
            this._BtnSimpan.Click += new System.EventHandler(this._BtnSimpan_Click);
            // 
            // FORM_INPUT_ID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 90);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FORM_INPUT_ID";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENTRY ID CETAK";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _TxtNomorCetak;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _BtnSimpan;
        private System.Windows.Forms.Button _BtnBatal;
    }
}