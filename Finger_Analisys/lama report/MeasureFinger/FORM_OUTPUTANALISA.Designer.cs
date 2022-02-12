namespace MeasureFinger
{
    partial class FORM_OUTPUTANALISA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_OUTPUTANALISA));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btn_input_id = new EMap.VistaButton();
            this._BtnKecenderunganOtak = new EMap.VistaButton();
            this._BtnCetak = new EMap.VistaButton();
            this._BtnKeluar = new EMap.VistaButton();
            this._flex = new C1.Win.C1FlexGrid.C1FlexGrid();
            this._txt_usia = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this._txt_nama = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox1.Controls.Add(this._btn_input_id);
            this.groupBox1.Controls.Add(this._BtnKecenderunganOtak);
            this.groupBox1.Controls.Add(this._BtnCetak);
            this.groupBox1.Controls.Add(this._BtnKeluar);
            this.groupBox1.Controls.Add(this._flex);
            this.groupBox1.Controls.Add(this._txt_usia);
            this.groupBox1.Controls.Add(this.label56);
            this.groupBox1.Controls.Add(this.label57);
            this.groupBox1.Controls.Add(this._txt_nama);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.label55);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _btn_input_id
            // 
            this._btn_input_id.BackColor = System.Drawing.Color.Transparent;
            this._btn_input_id.BackImage = null;
            this._btn_input_id.ButtonColor = System.Drawing.Color.Brown;
            this._btn_input_id.ButtonText = "Input ID Pasien";
            this._btn_input_id.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_input_id.Image = null;
            this._btn_input_id.Location = new System.Drawing.Point(381, 195);
            this._btn_input_id.Name = "_btn_input_id";
            this._btn_input_id.Size = new System.Drawing.Size(207, 37);
            this._btn_input_id.TabIndex = 124;
            this._btn_input_id.Click += new System.EventHandler(this._btn_input_id_Click);
            // 
            // _BtnKecenderunganOtak
            // 
            this._BtnKecenderunganOtak.BackColor = System.Drawing.Color.Transparent;
            this._BtnKecenderunganOtak.BackImage = null;
            this._BtnKecenderunganOtak.ButtonColor = System.Drawing.Color.Brown;
            this._BtnKecenderunganOtak.ButtonText = "Entry kecenderungan otak";
            this._BtnKecenderunganOtak.Cursor = System.Windows.Forms.Cursors.Hand;
            this._BtnKecenderunganOtak.Image = null;
            this._BtnKecenderunganOtak.Location = new System.Drawing.Point(381, 140);
            this._BtnKecenderunganOtak.Name = "_BtnKecenderunganOtak";
            this._BtnKecenderunganOtak.Size = new System.Drawing.Size(207, 37);
            this._BtnKecenderunganOtak.TabIndex = 123;
            this._BtnKecenderunganOtak.Click += new System.EventHandler(this._BtnKecenderunganOtak_Click);
            // 
            // _BtnCetak
            // 
            this._BtnCetak.BackColor = System.Drawing.Color.Transparent;
            this._BtnCetak.BackImage = null;
            this._BtnCetak.ButtonColor = System.Drawing.Color.Brown;
            this._BtnCetak.ButtonText = "Cetak";
            this._BtnCetak.Cursor = System.Windows.Forms.Cursors.Hand;
            this._BtnCetak.Image = null;
            this._BtnCetak.Location = new System.Drawing.Point(381, 293);
            this._BtnCetak.Name = "_BtnCetak";
            this._BtnCetak.Size = new System.Drawing.Size(207, 37);
            this._BtnCetak.TabIndex = 122;
            this._BtnCetak.Click += new System.EventHandler(this._BtnCetak_Click);
            // 
            // _BtnKeluar
            // 
            this._BtnKeluar.BackColor = System.Drawing.Color.Transparent;
            this._BtnKeluar.BackImage = null;
            this._BtnKeluar.ButtonColor = System.Drawing.Color.RoyalBlue;
            this._BtnKeluar.ButtonText = "Keluar";
            this._BtnKeluar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._BtnKeluar.Image = null;
            this._BtnKeluar.Location = new System.Drawing.Point(507, 382);
            this._BtnKeluar.Name = "_BtnKeluar";
            this._BtnKeluar.Size = new System.Drawing.Size(69, 37);
            this._BtnKeluar.TabIndex = 121;
            this._BtnKeluar.Click += new System.EventHandler(this._BtnKeluar_Click);
            // 
            // _flex
            // 
            this._flex.AllowEditing = false;
            this._flex.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this._flex.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this._flex.AutoResize = true;
            this._flex.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this._flex.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this._flex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._flex.Location = new System.Drawing.Point(9, 69);
            this._flex.Name = "_flex";
            this._flex.Rows.DefaultSize = 20;
            this._flex.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flex.Size = new System.Drawing.Size(358, 350);
            this._flex.StyleInfo = resources.GetString("_flex.StyleInfo");
            this._flex.TabIndex = 120;
            // 
            // _txt_usia
            // 
            this._txt_usia.BackColor = System.Drawing.Color.Goldenrod;
            this._txt_usia.Location = new System.Drawing.Point(452, 39);
            this._txt_usia.Name = "_txt_usia";
            this._txt_usia.ReadOnly = true;
            this._txt_usia.Size = new System.Drawing.Size(108, 20);
            this._txt_usia.TabIndex = 98;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(434, 43);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(12, 13);
            this.label56.TabIndex = 97;
            this.label56.Text = ":";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(385, 43);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(31, 13);
            this.label57.TabIndex = 96;
            this.label57.Text = "Usia";
            // 
            // _txt_nama
            // 
            this._txt_nama.BackColor = System.Drawing.Color.Goldenrod;
            this._txt_nama.Location = new System.Drawing.Point(180, 38);
            this._txt_nama.Name = "_txt_nama";
            this._txt_nama.ReadOnly = true;
            this._txt_nama.Size = new System.Drawing.Size(187, 20);
            this._txt_nama.TabIndex = 95;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(162, 40);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(12, 13);
            this.label54.TabIndex = 94;
            this.label54.Text = ":";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(10, 40);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(40, 13);
            this.label55.TabIndex = 93;
            this.label55.Text = "Nama";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(6, 16);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(126, 16);
            this.label53.TabIndex = 92;
            this.label53.Text = "Identitas Pasien";
            // 
            // FORM_OUTPUTANALISA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 435);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_OUTPUTANALISA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hasil Analisa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txt_usia;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox _txt_nama;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private C1.Win.C1FlexGrid.C1FlexGrid _flex;
        private EMap.VistaButton _btn_input_id;
        private EMap.VistaButton _BtnKecenderunganOtak;
        private EMap.VistaButton _BtnCetak;
        private EMap.VistaButton _BtnKeluar;
    }
}