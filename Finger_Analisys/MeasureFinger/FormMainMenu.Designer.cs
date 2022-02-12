namespace MeasureFinger
{
    partial class FormMainMenu
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
            this.components = new System.ComponentModel.Container();
            EMap.DocInfo docInfo1 = new EMap.DocInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.header1 = new EMap.Header();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._txtstatustimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripV1 = new EMap.ToolStripV(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._Mnu_Ubah_Login = new System.Windows.Forms.ToolStripButton();
            this._mnu_utama_pasien = new System.Windows.Forms.ToolStripSplitButton();
            this._BtnTambahPasien = new System.Windows.Forms.ToolStripMenuItem();
            this._BtnUbahPasien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._BtnHapusPasien = new System.Windows.Forms.ToolStripMenuItem();
            this._mnu_utama_sidik = new System.Windows.Forms.ToolStripSplitButton();
            this._BtnHitungJarak = new System.Windows.Forms.ToolStripMenuItem();
            this._BtnHitungProsentase = new System.Windows.Forms.ToolStripMenuItem();
            this._mnu_tool = new System.Windows.Forms.ToolStripSplitButton();
            this._Btn_lisensi = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._BtnCari = new System.Windows.Forms.Button();
            this._TxtValue = new System.Windows.Forms.TextBox();
            this._DgPasien = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStripV1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DgPasien)).BeginInit();
            this.SuspendLayout();
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
            this.header1.Size = new System.Drawing.Size(821, 50);
            this.header1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._txtstatustimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(821, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _txtstatustimer
            // 
            this._txtstatustimer.ForeColor = System.Drawing.Color.White;
            this._txtstatustimer.Name = "_txtstatustimer";
            this._txtstatustimer.Size = new System.Drawing.Size(0, 17);
            this._txtstatustimer.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripV1
            // 
            this.toolStripV1.AutoSize = false;
            this.toolStripV1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripV1.ColorGlow = System.Drawing.Color.Red;
            this.toolStripV1.ColorNorthBackground = System.Drawing.Color.DarkRed;
            this.toolStripV1.ColorSouthBackground = System.Drawing.Color.Black;
            this.toolStripV1.ForeColor = System.Drawing.Color.White;
            this.toolStripV1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripV1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this._Mnu_Ubah_Login,
            this._mnu_utama_pasien,
            this._mnu_utama_sidik,
            this._mnu_tool});
            this.toolStripV1.Location = new System.Drawing.Point(0, 50);
            this.toolStripV1.Name = "toolStripV1";
            this.toolStripV1.Size = new System.Drawing.Size(821, 35);
            this.toolStripV1.TabIndex = 4;
            this.toolStripV1.Text = "toolStripV1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // _Mnu_Ubah_Login
            // 
            this._Mnu_Ubah_Login.ForeColor = System.Drawing.Color.White;
            this._Mnu_Ubah_Login.Image = ((System.Drawing.Image)(resources.GetObject("_Mnu_Ubah_Login.Image")));
            this._Mnu_Ubah_Login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Mnu_Ubah_Login.Name = "_Mnu_Ubah_Login";
            this._Mnu_Ubah_Login.Padding = new System.Windows.Forms.Padding(5);
            this._Mnu_Ubah_Login.Size = new System.Drawing.Size(151, 32);
            this._Mnu_Ubah_Login.Text = "Ubah Password Login";
            this._Mnu_Ubah_Login.Click += new System.EventHandler(this._Mnu_Ubah_Login_Click);
            // 
            // _mnu_utama_pasien
            // 
            this._mnu_utama_pasien.DropDownButtonWidth = 18;
            this._mnu_utama_pasien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._BtnTambahPasien,
            this._BtnUbahPasien,
            this.toolStripMenuItem1,
            this._BtnHapusPasien});
            this._mnu_utama_pasien.ForeColor = System.Drawing.Color.White;
            this._mnu_utama_pasien.Image = ((System.Drawing.Image)(resources.GetObject("_mnu_utama_pasien.Image")));
            this._mnu_utama_pasien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mnu_utama_pasien.Name = "_mnu_utama_pasien";
            this._mnu_utama_pasien.Padding = new System.Windows.Forms.Padding(5);
            this._mnu_utama_pasien.Size = new System.Drawing.Size(90, 32);
            this._mnu_utama_pasien.Text = "Pasien";
            // 
            // _BtnTambahPasien
            // 
            this._BtnTambahPasien.ForeColor = System.Drawing.Color.White;
            this._BtnTambahPasien.Name = "_BtnTambahPasien";
            this._BtnTambahPasien.Padding = new System.Windows.Forms.Padding(5);
            this._BtnTambahPasien.Size = new System.Drawing.Size(192, 26);
            this._BtnTambahPasien.Text = "Tambah pasien baru";
            this._BtnTambahPasien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BtnTambahPasien.Click += new System.EventHandler(this._BtnTambahPasien_Click);
            // 
            // _BtnUbahPasien
            // 
            this._BtnUbahPasien.ForeColor = System.Drawing.Color.White;
            this._BtnUbahPasien.Name = "_BtnUbahPasien";
            this._BtnUbahPasien.Padding = new System.Windows.Forms.Padding(5);
            this._BtnUbahPasien.Size = new System.Drawing.Size(192, 26);
            this._BtnUbahPasien.Text = "Ubah Pasien";
            this._BtnUbahPasien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BtnUbahPasien.Click += new System.EventHandler(this._BtnUbahPasien_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // _BtnHapusPasien
            // 
            this._BtnHapusPasien.ForeColor = System.Drawing.Color.White;
            this._BtnHapusPasien.Name = "_BtnHapusPasien";
            this._BtnHapusPasien.Padding = new System.Windows.Forms.Padding(5);
            this._BtnHapusPasien.Size = new System.Drawing.Size(192, 26);
            this._BtnHapusPasien.Text = "Hapus Pasien";
            this._BtnHapusPasien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BtnHapusPasien.Click += new System.EventHandler(this._BtnHapusPasien_Click);
            // 
            // _mnu_utama_sidik
            // 
            this._mnu_utama_sidik.DropDownButtonWidth = 18;
            this._mnu_utama_sidik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._BtnHitungJarak,
            this._BtnHitungProsentase});
            this._mnu_utama_sidik.ForeColor = System.Drawing.Color.White;
            this._mnu_utama_sidik.Image = ((System.Drawing.Image)(resources.GetObject("_mnu_utama_sidik.Image")));
            this._mnu_utama_sidik.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mnu_utama_sidik.Name = "_mnu_utama_sidik";
            this._mnu_utama_sidik.Padding = new System.Windows.Forms.Padding(5);
            this._mnu_utama_sidik.Size = new System.Drawing.Size(142, 32);
            this._mnu_utama_sidik.Text = "Analisa Sidik Jari";
            // 
            // _BtnHitungJarak
            // 
            this._BtnHitungJarak.ForeColor = System.Drawing.Color.White;
            this._BtnHitungJarak.Name = "_BtnHitungJarak";
            this._BtnHitungJarak.Padding = new System.Windows.Forms.Padding(5);
            this._BtnHitungJarak.Size = new System.Drawing.Size(214, 26);
            this._BtnHitungJarak.Text = "Analisa Jari";
            this._BtnHitungJarak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BtnHitungJarak.Click += new System.EventHandler(this._BtnHitungJarak_Click);
            // 
            // _BtnHitungProsentase
            // 
            this._BtnHitungProsentase.ForeColor = System.Drawing.Color.White;
            this._BtnHitungProsentase.Name = "_BtnHitungProsentase";
            this._BtnHitungProsentase.Padding = new System.Windows.Forms.Padding(5);
            this._BtnHitungProsentase.Size = new System.Drawing.Size(214, 26);
            this._BtnHitungProsentase.Text = "Hitung dan Hasil Analisa";
            this._BtnHitungProsentase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BtnHitungProsentase.Click += new System.EventHandler(this._BtnHitungProsentase_Click);
            // 
            // _mnu_tool
            // 
            this._mnu_tool.DropDownButtonWidth = 18;
            this._mnu_tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Btn_lisensi});
            this._mnu_tool.ForeColor = System.Drawing.Color.White;
            this._mnu_tool.Image = ((System.Drawing.Image)(resources.GetObject("_mnu_tool.Image")));
            this._mnu_tool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mnu_tool.Name = "_mnu_tool";
            this._mnu_tool.Padding = new System.Windows.Forms.Padding(5);
            this._mnu_tool.Size = new System.Drawing.Size(80, 32);
            this._mnu_tool.Text = "Tool";
            // 
            // _Btn_lisensi
            // 
            this._Btn_lisensi.ForeColor = System.Drawing.Color.White;
            this._Btn_lisensi.Name = "_Btn_lisensi";
            this._Btn_lisensi.Padding = new System.Windows.Forms.Padding(5);
            this._Btn_lisensi.Size = new System.Drawing.Size(164, 26);
            this._Btn_lisensi.Text = "Register Lisensi";
            this._Btn_lisensi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_lisensi.Click += new System.EventHandler(this._Btn_lisensi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._BtnCari);
            this.groupBox1.Controls.Add(this._TxtValue);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NAMA PASIEN";
            // 
            // _BtnCari
            // 
            this._BtnCari.ForeColor = System.Drawing.Color.Black;
            this._BtnCari.Location = new System.Drawing.Point(384, 11);
            this._BtnCari.Name = "_BtnCari";
            this._BtnCari.Size = new System.Drawing.Size(63, 23);
            this._BtnCari.TabIndex = 2;
            this._BtnCari.Text = "cari";
            this._BtnCari.UseVisualStyleBackColor = true;
            this._BtnCari.Click += new System.EventHandler(this._BtnCari_Click);
            // 
            // _TxtValue
            // 
            this._TxtValue.Location = new System.Drawing.Point(96, 13);
            this._TxtValue.Name = "_TxtValue";
            this._TxtValue.Size = new System.Drawing.Size(282, 20);
            this._TxtValue.TabIndex = 1;
            this._TxtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._TxtValue_KeyPress);
            // 
            // _DgPasien
            // 
            this._DgPasien.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this._DgPasien.AllowEditing = false;
            this._DgPasien.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this._DgPasien.Location = new System.Drawing.Point(12, 154);
            this._DgPasien.Name = "_DgPasien";
            this._DgPasien.Rows.DefaultSize = 19;
            this._DgPasien.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._DgPasien.Size = new System.Drawing.Size(797, 426);
            this._DgPasien.StyleInfo = resources.GetString("_DgPasien.StyleInfo");
            this._DgPasien.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(821, 605);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._DgPasien);
            this.Controls.Add(this.toolStripV1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.header1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEASURE FINGER rev header";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripV1.ResumeLayout(false);
            this.toolStripV1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DgPasien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EMap.Header header1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private EMap.ToolStripV toolStripV1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private C1.Win.C1FlexGrid.C1FlexGrid _DgPasien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _TxtValue;
        private System.Windows.Forms.Button _BtnCari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSplitButton _mnu_utama_pasien;
        private System.Windows.Forms.ToolStripMenuItem _BtnTambahPasien;
        private System.Windows.Forms.ToolStripMenuItem _BtnUbahPasien;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _BtnHapusPasien;
        private System.Windows.Forms.ToolStripSplitButton _mnu_utama_sidik;
        private System.Windows.Forms.ToolStripMenuItem _BtnHitungJarak;
        private System.Windows.Forms.ToolStripMenuItem _BtnHitungProsentase;
        private System.Windows.Forms.ToolStripSplitButton _mnu_tool;
        private System.Windows.Forms.ToolStripMenuItem _Btn_lisensi;
        private System.Windows.Forms.ToolStripButton _Mnu_Ubah_Login;
        private System.Windows.Forms.ToolStripStatusLabel _txtstatustimer;
        private System.Windows.Forms.Timer timer1;
    }
}