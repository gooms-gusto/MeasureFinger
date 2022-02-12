namespace MeasureFinger
{
    partial class FORM_ENTRY_PASIEN
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
            this._groupidentitas = new System.Windows.Forms.GroupBox();
            this._txtusia = new CUTE_CONTROL.NumericTexboxt(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txttanggalanalisa = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._txtnamapasien = new System.Windows.Forms.TextBox();
            this._groupsidik = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.r5 = new System.Windows.Forms.Button();
            this.r4 = new System.Windows.Forms.Button();
            this.r3 = new System.Windows.Forms.Button();
            this.r2 = new System.Windows.Forms.Button();
            this.r1 = new System.Windows.Forms.Button();
            this.l5 = new System.Windows.Forms.Button();
            this.l4 = new System.Windows.Forms.Button();
            this.l3 = new System.Windows.Forms.Button();
            this.l2 = new System.Windows.Forms.Button();
            this.l1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._r5 = new System.Windows.Forms.TextBox();
            this._r4 = new System.Windows.Forms.TextBox();
            this._r3 = new System.Windows.Forms.TextBox();
            this._r2 = new System.Windows.Forms.TextBox();
            this._r1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._l5 = new System.Windows.Forms.TextBox();
            this._l4 = new System.Windows.Forms.TextBox();
            this._l3 = new System.Windows.Forms.TextBox();
            this._l2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._l1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btnbatal = new EMap.VistaButton();
            this._btnsimpan = new EMap.VistaButton();
            this._OFD = new System.Windows.Forms.OpenFileDialog();
            this.label16 = new System.Windows.Forms.Label();
            this._groupidentitas.SuspendLayout();
            this._groupsidik.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupidentitas
            // 
            this._groupidentitas.Controls.Add(this.label16);
            this._groupidentitas.Controls.Add(this._txtusia);
            this._groupidentitas.Controls.Add(this.label4);
            this._groupidentitas.Controls.Add(this.label3);
            this._groupidentitas.Controls.Add(this._txttanggalanalisa);
            this._groupidentitas.Controls.Add(this.label2);
            this._groupidentitas.Controls.Add(this._txtnamapasien);
            this._groupidentitas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupidentitas.ForeColor = System.Drawing.Color.White;
            this._groupidentitas.Location = new System.Drawing.Point(3, 12);
            this._groupidentitas.Name = "_groupidentitas";
            this._groupidentitas.Size = new System.Drawing.Size(634, 97);
            this._groupidentitas.TabIndex = 0;
            this._groupidentitas.TabStop = false;
            this._groupidentitas.Text = "IDENTITAS PASIEN";
            // 
            // _txtusia
            // 
            this._txtusia.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtusia.Location = new System.Drawing.Point(221, 67);
            this._txtusia.Name = "_txtusia";
            this._txtusia.Size = new System.Drawing.Size(68, 23);
            this._txtusia.TabIndex = 7;
            this._txtusia.Tag = "idpasien";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "USIA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "TANGGAL ANALISA";
            // 
            // _txttanggalanalisa
            // 
            this._txttanggalanalisa.CustomFormat = "dd-MM-yyyy";
            this._txttanggalanalisa.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txttanggalanalisa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._txttanggalanalisa.Location = new System.Drawing.Point(221, 42);
            this._txttanggalanalisa.Name = "_txttanggalanalisa";
            this._txttanggalanalisa.Size = new System.Drawing.Size(106, 23);
            this._txttanggalanalisa.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "NAMA PASIEN";
            // 
            // _txtnamapasien
            // 
            this._txtnamapasien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtnamapasien.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtnamapasien.Location = new System.Drawing.Point(221, 17);
            this._txtnamapasien.Name = "_txtnamapasien";
            this._txtnamapasien.Size = new System.Drawing.Size(407, 23);
            this._txtnamapasien.TabIndex = 2;
            this._txtnamapasien.Tag = "idpasien";
            // 
            // _groupsidik
            // 
            this._groupsidik.Controls.Add(this.label15);
            this._groupsidik.Controls.Add(this.label1);
            this._groupsidik.Controls.Add(this.r5);
            this._groupsidik.Controls.Add(this.r4);
            this._groupsidik.Controls.Add(this.r3);
            this._groupsidik.Controls.Add(this.r2);
            this._groupsidik.Controls.Add(this.r1);
            this._groupsidik.Controls.Add(this.l5);
            this._groupsidik.Controls.Add(this.l4);
            this._groupsidik.Controls.Add(this.l3);
            this._groupsidik.Controls.Add(this.l2);
            this._groupsidik.Controls.Add(this.l1);
            this._groupsidik.Controls.Add(this.label10);
            this._groupsidik.Controls.Add(this.label11);
            this._groupsidik.Controls.Add(this.label12);
            this._groupsidik.Controls.Add(this.label13);
            this._groupsidik.Controls.Add(this.label14);
            this._groupsidik.Controls.Add(this._r5);
            this._groupsidik.Controls.Add(this._r4);
            this._groupsidik.Controls.Add(this._r3);
            this._groupsidik.Controls.Add(this._r2);
            this._groupsidik.Controls.Add(this._r1);
            this._groupsidik.Controls.Add(this.label9);
            this._groupsidik.Controls.Add(this.label8);
            this._groupsidik.Controls.Add(this.label7);
            this._groupsidik.Controls.Add(this.label6);
            this._groupsidik.Controls.Add(this._l5);
            this._groupsidik.Controls.Add(this._l4);
            this._groupsidik.Controls.Add(this._l3);
            this._groupsidik.Controls.Add(this._l2);
            this._groupsidik.Controls.Add(this.label5);
            this._groupsidik.Controls.Add(this._l1);
            this._groupsidik.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupsidik.ForeColor = System.Drawing.Color.White;
            this._groupsidik.Location = new System.Drawing.Point(3, 115);
            this._groupsidik.Name = "_groupsidik";
            this._groupsidik.Size = new System.Drawing.Size(634, 197);
            this._groupsidik.TabIndex = 1;
            this._groupsidik.TabStop = false;
            this._groupsidik.Text = "SIDIK JARI";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(413, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "TANGAN KANAN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "TANGAN KIRI";
            // 
            // r5
            // 
            this.r5.ForeColor = System.Drawing.Color.Black;
            this.r5.Location = new System.Drawing.Point(563, 144);
            this.r5.Name = "r5";
            this.r5.Size = new System.Drawing.Size(36, 23);
            this.r5.TabIndex = 35;
            this.r5.Tag = "btn";
            this.r5.Text = "...";
            this.r5.UseVisualStyleBackColor = true;
            this.r5.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // r4
            // 
            this.r4.ForeColor = System.Drawing.Color.Black;
            this.r4.Location = new System.Drawing.Point(563, 121);
            this.r4.Name = "r4";
            this.r4.Size = new System.Drawing.Size(36, 23);
            this.r4.TabIndex = 34;
            this.r4.Tag = "btn";
            this.r4.Text = "...";
            this.r4.UseVisualStyleBackColor = true;
            this.r4.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // r3
            // 
            this.r3.ForeColor = System.Drawing.Color.Black;
            this.r3.Location = new System.Drawing.Point(563, 98);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(36, 23);
            this.r3.TabIndex = 33;
            this.r3.Tag = "btn";
            this.r3.Text = "...";
            this.r3.UseVisualStyleBackColor = true;
            this.r3.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // r2
            // 
            this.r2.ForeColor = System.Drawing.Color.Black;
            this.r2.Location = new System.Drawing.Point(563, 75);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(36, 23);
            this.r2.TabIndex = 32;
            this.r2.Tag = "btn";
            this.r2.Text = "...";
            this.r2.UseVisualStyleBackColor = true;
            this.r2.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // r1
            // 
            this.r1.ForeColor = System.Drawing.Color.Black;
            this.r1.Location = new System.Drawing.Point(563, 50);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(36, 23);
            this.r1.TabIndex = 31;
            this.r1.Tag = "btn";
            this.r1.Text = "...";
            this.r1.UseVisualStyleBackColor = true;
            this.r1.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // l5
            // 
            this.l5.ForeColor = System.Drawing.Color.Black;
            this.l5.Location = new System.Drawing.Point(254, 145);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(36, 23);
            this.l5.TabIndex = 30;
            this.l5.Tag = "btn";
            this.l5.Text = "...";
            this.l5.UseVisualStyleBackColor = true;
            this.l5.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // l4
            // 
            this.l4.ForeColor = System.Drawing.Color.Black;
            this.l4.Location = new System.Drawing.Point(254, 122);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(36, 23);
            this.l4.TabIndex = 29;
            this.l4.Tag = "btn";
            this.l4.Text = "...";
            this.l4.UseVisualStyleBackColor = true;
            this.l4.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // l3
            // 
            this.l3.ForeColor = System.Drawing.Color.Black;
            this.l3.Location = new System.Drawing.Point(254, 99);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(36, 23);
            this.l3.TabIndex = 28;
            this.l3.Tag = "btn";
            this.l3.Text = "...";
            this.l3.UseVisualStyleBackColor = true;
            this.l3.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // l2
            // 
            this.l2.ForeColor = System.Drawing.Color.Black;
            this.l2.Location = new System.Drawing.Point(254, 76);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(36, 23);
            this.l2.TabIndex = 27;
            this.l2.Tag = "btn";
            this.l2.Text = "...";
            this.l2.UseVisualStyleBackColor = true;
            this.l2.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // l1
            // 
            this.l1.ForeColor = System.Drawing.Color.Black;
            this.l1.Location = new System.Drawing.Point(254, 53);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(36, 23);
            this.l1.TabIndex = 26;
            this.l1.Tag = "btn";
            this.l1.Text = "...";
            this.l1.UseVisualStyleBackColor = true;
            this.l1.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(339, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "R5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(339, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "R4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(339, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "R3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(339, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "R2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(339, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "R1";
            // 
            // _r5
            // 
            this._r5.BackColor = System.Drawing.Color.White;
            this._r5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._r5.Location = new System.Drawing.Point(379, 146);
            this._r5.Name = "_r5";
            this._r5.Size = new System.Drawing.Size(178, 23);
            this._r5.TabIndex = 20;
            this._r5.Tag = "sidik";
            // 
            // _r4
            // 
            this._r4.BackColor = System.Drawing.Color.White;
            this._r4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._r4.Location = new System.Drawing.Point(379, 122);
            this._r4.Name = "_r4";
            this._r4.Size = new System.Drawing.Size(178, 23);
            this._r4.TabIndex = 19;
            this._r4.Tag = "sidik";
            // 
            // _r3
            // 
            this._r3.BackColor = System.Drawing.Color.White;
            this._r3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._r3.Location = new System.Drawing.Point(379, 99);
            this._r3.Name = "_r3";
            this._r3.Size = new System.Drawing.Size(178, 23);
            this._r3.TabIndex = 18;
            this._r3.Tag = "sidik";
            // 
            // _r2
            // 
            this._r2.BackColor = System.Drawing.Color.White;
            this._r2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._r2.Location = new System.Drawing.Point(379, 76);
            this._r2.Name = "_r2";
            this._r2.Size = new System.Drawing.Size(178, 23);
            this._r2.TabIndex = 17;
            this._r2.Tag = "sidik";
            // 
            // _r1
            // 
            this._r1.BackColor = System.Drawing.Color.White;
            this._r1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._r1.Location = new System.Drawing.Point(379, 52);
            this._r1.Name = "_r1";
            this._r1.Size = new System.Drawing.Size(178, 23);
            this._r1.TabIndex = 16;
            this._r1.Tag = "sidik";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "L5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "L4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "L3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "L2";
            // 
            // _l5
            // 
            this._l5.BackColor = System.Drawing.Color.White;
            this._l5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._l5.Location = new System.Drawing.Point(67, 145);
            this._l5.Name = "_l5";
            this._l5.ReadOnly = true;
            this._l5.Size = new System.Drawing.Size(178, 23);
            this._l5.TabIndex = 11;
            this._l5.Tag = "sidik";
            // 
            // _l4
            // 
            this._l4.BackColor = System.Drawing.Color.White;
            this._l4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._l4.Location = new System.Drawing.Point(67, 122);
            this._l4.Name = "_l4";
            this._l4.ReadOnly = true;
            this._l4.Size = new System.Drawing.Size(178, 23);
            this._l4.TabIndex = 10;
            this._l4.Tag = "sidik";
            // 
            // _l3
            // 
            this._l3.BackColor = System.Drawing.Color.White;
            this._l3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._l3.Location = new System.Drawing.Point(67, 99);
            this._l3.Name = "_l3";
            this._l3.ReadOnly = true;
            this._l3.Size = new System.Drawing.Size(178, 23);
            this._l3.TabIndex = 9;
            this._l3.Tag = "sidik";
            // 
            // _l2
            // 
            this._l2.BackColor = System.Drawing.Color.White;
            this._l2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._l2.Location = new System.Drawing.Point(67, 76);
            this._l2.Name = "_l2";
            this._l2.ReadOnly = true;
            this._l2.Size = new System.Drawing.Size(178, 23);
            this._l2.TabIndex = 8;
            this._l2.Tag = "sidik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "L1";
            // 
            // _l1
            // 
            this._l1.BackColor = System.Drawing.Color.White;
            this._l1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._l1.Location = new System.Drawing.Point(67, 53);
            this._l1.Name = "_l1";
            this._l1.ReadOnly = true;
            this._l1.Size = new System.Drawing.Size(178, 23);
            this._l1.TabIndex = 1;
            this._l1.Tag = "sidik";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btnbatal);
            this.groupBox3.Controls.Add(this._btnsimpan);
            this.groupBox3.Location = new System.Drawing.Point(3, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // _btnbatal
            // 
            this._btnbatal.BackColor = System.Drawing.Color.Transparent;
            this._btnbatal.BackImage = null;
            this._btnbatal.ButtonText = "Tutup";
            this._btnbatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnbatal.Image = null;
            this._btnbatal.Location = new System.Drawing.Point(333, 14);
            this._btnbatal.Name = "_btnbatal";
            this._btnbatal.Size = new System.Drawing.Size(100, 32);
            this._btnbatal.TabIndex = 1;
            this._btnbatal.Click += new System.EventHandler(this._btnbatal_Click);
            // 
            // _btnsimpan
            // 
            this._btnsimpan.BackColor = System.Drawing.Color.Transparent;
            this._btnsimpan.BackImage = null;
            this._btnsimpan.ButtonText = "Simpan";
            this._btnsimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnsimpan.Image = null;
            this._btnsimpan.Location = new System.Drawing.Point(227, 14);
            this._btnsimpan.Name = "_btnsimpan";
            this._btnsimpan.Size = new System.Drawing.Size(100, 32);
            this._btnsimpan.TabIndex = 0;
            this._btnsimpan.Click += new System.EventHandler(this._btnsimpan_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(295, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 16);
            this.label16.TabIndex = 8;
            this.label16.Text = "Tahun";
            // 
            // FORM_ENTRY_PASIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(649, 378);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this._groupsidik);
            this.Controls.Add(this._groupidentitas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FORM_ENTRY_PASIEN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Data";
            this._groupidentitas.ResumeLayout(false);
            this._groupidentitas.PerformLayout();
            this._groupsidik.ResumeLayout(false);
            this._groupsidik.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupidentitas;
        private System.Windows.Forms.GroupBox _groupsidik;
        private CUTE_CONTROL.NumericTexboxt _txtusia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _txttanggalanalisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtnamapasien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _l1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _l5;
        private System.Windows.Forms.TextBox _l4;
        private System.Windows.Forms.TextBox _l3;
        private System.Windows.Forms.TextBox _l2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _r5;
        private System.Windows.Forms.TextBox _r4;
        private System.Windows.Forms.TextBox _r3;
        private System.Windows.Forms.TextBox _r2;
        private System.Windows.Forms.TextBox _r1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button l5;
        private System.Windows.Forms.Button l4;
        private System.Windows.Forms.Button l3;
        private System.Windows.Forms.Button l2;
        private System.Windows.Forms.Button l1;
        private System.Windows.Forms.Button r5;
        private System.Windows.Forms.Button r4;
        private System.Windows.Forms.Button r3;
        private System.Windows.Forms.Button r2;
        private System.Windows.Forms.Button r1;
        private System.Windows.Forms.GroupBox groupBox3;
        private EMap.VistaButton _btnsimpan;
        private EMap.VistaButton _btnbatal;
        private System.Windows.Forms.OpenFileDialog _OFD;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}