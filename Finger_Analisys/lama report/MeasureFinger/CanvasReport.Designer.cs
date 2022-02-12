namespace MeasureFinger
{
    partial class CanvasReport
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
            this._CrView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // _CrView
            // 
            this._CrView.ActiveViewIndex = -1;
            this._CrView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._CrView.Cursor = System.Windows.Forms.Cursors.Default;
            this._CrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._CrView.Location = new System.Drawing.Point(0, 0);
            this._CrView.Name = "_CrView";
            this._CrView.ShowGotoPageButton = false;
            this._CrView.ShowGroupTreeButton = false;
            this._CrView.ShowParameterPanelButton = false;
            this._CrView.ShowRefreshButton = false;
            this._CrView.ShowTextSearchButton = false;
            this._CrView.Size = new System.Drawing.Size(788, 408);
            this._CrView.TabIndex = 0;
            this._CrView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CanvasReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 408);
            this.Controls.Add(this._CrView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CanvasReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CanvasReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer _CrView;
    }
}