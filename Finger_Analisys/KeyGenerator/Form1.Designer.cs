namespace KeyGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._TxtNomorSeri = new System.Windows.Forms.TextBox();
            this._TxtKey = new System.Windows.Forms.TextBox();
            this._BtnGenerate = new System.Windows.Forms.Button();
            this._BtnExit = new System.Windows.Forms.Button();
            this._btn_new = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Seri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Key";
            // 
            // _TxtNomorSeri
            // 
            this._TxtNomorSeri.Location = new System.Drawing.Point(81, 12);
            this._TxtNomorSeri.Name = "_TxtNomorSeri";
            this._TxtNomorSeri.Size = new System.Drawing.Size(245, 20);
            this._TxtNomorSeri.TabIndex = 2;
            // 
            // _TxtKey
            // 
            this._TxtKey.Location = new System.Drawing.Point(81, 38);
            this._TxtKey.Name = "_TxtKey";
            this._TxtKey.Size = new System.Drawing.Size(245, 20);
            this._TxtKey.TabIndex = 3;
            // 
            // _BtnGenerate
            // 
            this._BtnGenerate.Location = new System.Drawing.Point(170, 64);
            this._BtnGenerate.Name = "_BtnGenerate";
            this._BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this._BtnGenerate.TabIndex = 4;
            this._BtnGenerate.Text = "Generate";
            this._BtnGenerate.UseVisualStyleBackColor = true;
            this._BtnGenerate.Click += new System.EventHandler(this._BtnGenerate_Click);
            // 
            // _BtnExit
            // 
            this._BtnExit.Location = new System.Drawing.Point(251, 64);
            this._BtnExit.Name = "_BtnExit";
            this._BtnExit.Size = new System.Drawing.Size(75, 23);
            this._BtnExit.TabIndex = 5;
            this._BtnExit.Text = "Exit";
            this._BtnExit.UseVisualStyleBackColor = true;
            this._BtnExit.Click += new System.EventHandler(this._BtnExit_Click);
            // 
            // _btn_new
            // 
            this._btn_new.Location = new System.Drawing.Point(81, 64);
            this._btn_new.Name = "_btn_new";
            this._btn_new.Size = new System.Drawing.Size(75, 23);
            this._btn_new.TabIndex = 6;
            this._btn_new.Text = "New";
            this._btn_new.UseVisualStyleBackColor = true;
            this._btn_new.Click += new System.EventHandler(this._btn_new_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 108);
            this.Controls.Add(this._btn_new);
            this.Controls.Add(this._BtnExit);
            this.Controls.Add(this._BtnGenerate);
            this.Controls.Add(this._TxtKey);
            this.Controls.Add(this._TxtNomorSeri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Keygen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _TxtNomorSeri;
        private System.Windows.Forms.TextBox _TxtKey;
        private System.Windows.Forms.Button _BtnGenerate;
        private System.Windows.Forms.Button _BtnExit;
        private System.Windows.Forms.Button _btn_new;
    }
}

