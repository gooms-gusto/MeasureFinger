// TestClock application
// Written by : Sriram Chitturi (c) Copyright 2004
// Purpose : Used for demo and testing DigitalClockCtrl

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SriClocks;

namespace SriClocks
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class TestClockForm : System.Windows.Forms.Form
	{

		private System.Windows.Forms.Button CountDownBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox MilliSecs;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton DigitColorRed;
		private System.Windows.Forms.RadioButton DigitColorGreen;
		private System.Windows.Forms.RadioButton DigitColorBlue;
		private System.Windows.Forms.TextBox Alarmtime;
		private System.Windows.Forms.Button SetAlarmBtn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.Label label5;
		private SriClocks.DigitalClockCtrl digitalClockCtrl1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton DisplayTimeRBtn;
		private System.Windows.Forms.RadioButton StartStopWatchBtn;
		private System.Windows.Forms.RadioButton FreezeClockBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox FormatCombo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestClockForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			// add the delegates for count down and alarm test cases
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TestClockForm));
			this.CountDownBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.MilliSecs = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SetAlarmBtn = new System.Windows.Forms.Button();
			this.Alarmtime = new System.Windows.Forms.TextBox();
			this.DigitColorRed = new System.Windows.Forms.RadioButton();
			this.DigitColorGreen = new System.Windows.Forms.RadioButton();
			this.DigitColorBlue = new System.Windows.Forms.RadioButton();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.digitalClockCtrl1 = new SriClocks.DigitalClockCtrl();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.FormatCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FreezeClockBtn = new System.Windows.Forms.RadioButton();
			this.StartStopWatchBtn = new System.Windows.Forms.RadioButton();
			this.DisplayTimeRBtn = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// CountDownBtn
			// 
			this.CountDownBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.CountDownBtn.BackColor = System.Drawing.SystemColors.Control;
			this.CountDownBtn.Location = new System.Drawing.Point(168, 82);
			this.CountDownBtn.Name = "CountDownBtn";
			this.CountDownBtn.Size = new System.Drawing.Size(100, 22);
			this.CountDownBtn.TabIndex = 1;
			this.CountDownBtn.Text = "Count Down";
			this.CountDownBtn.Click += new System.EventHandler(this.SetClockType);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(90, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Milliseconds";
			// 
			// MilliSecs
			// 
			this.MilliSecs.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.MilliSecs.Location = new System.Drawing.Point(26, 82);
			this.MilliSecs.Name = "MilliSecs";
			this.MilliSecs.Size = new System.Drawing.Size(58, 20);
			this.MilliSecs.TabIndex = 3;
			this.MilliSecs.Text = "1000";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.SetAlarmBtn);
			this.groupBox1.Controls.Add(this.Alarmtime);
			this.groupBox1.Controls.Add(this.MilliSecs);
			this.groupBox1.Controls.Add(this.CountDownBtn);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.DigitColorRed);
			this.groupBox1.Controls.Add(this.DigitColorGreen);
			this.groupBox1.Controls.Add(this.DigitColorBlue);
			this.groupBox1.Location = new System.Drawing.Point(138, 159);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 118);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.Location = new System.Drawing.Point(24, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Display color :";
			// 
			// SetAlarmBtn
			// 
			this.SetAlarmBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SetAlarmBtn.BackColor = System.Drawing.SystemColors.Control;
			this.SetAlarmBtn.Location = new System.Drawing.Point(168, 52);
			this.SetAlarmBtn.Name = "SetAlarmBtn";
			this.SetAlarmBtn.Size = new System.Drawing.Size(100, 22);
			this.SetAlarmBtn.TabIndex = 7;
			this.SetAlarmBtn.Text = "Set Alarm";
			this.SetAlarmBtn.Click += new System.EventHandler(this.OnSetAlarm);
			// 
			// Alarmtime
			// 
			this.Alarmtime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Alarmtime.Location = new System.Drawing.Point(24, 52);
			this.Alarmtime.Name = "Alarmtime";
			this.Alarmtime.Size = new System.Drawing.Size(136, 20);
			this.Alarmtime.TabIndex = 6;
			this.Alarmtime.Text = "02/14/2004 10:00:00 PM";
			// 
			// DigitColorRed
			// 
			this.DigitColorRed.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DigitColorRed.BackColor = System.Drawing.Color.Red;
			this.DigitColorRed.Location = new System.Drawing.Point(104, 18);
			this.DigitColorRed.Name = "DigitColorRed";
			this.DigitColorRed.Size = new System.Drawing.Size(54, 22);
			this.DigitColorRed.TabIndex = 5;
			this.DigitColorRed.Text = "Red";
			this.DigitColorRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DigitColorRed.CheckedChanged += new System.EventHandler(this.OnColorChange);
			// 
			// DigitColorGreen
			// 
			this.DigitColorGreen.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DigitColorGreen.BackColor = System.Drawing.Color.LawnGreen;
			this.DigitColorGreen.Location = new System.Drawing.Point(158, 18);
			this.DigitColorGreen.Name = "DigitColorGreen";
			this.DigitColorGreen.Size = new System.Drawing.Size(54, 22);
			this.DigitColorGreen.TabIndex = 6;
			this.DigitColorGreen.Text = "Green";
			this.DigitColorGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DigitColorGreen.CheckedChanged += new System.EventHandler(this.OnColorChange);
			// 
			// DigitColorBlue
			// 
			this.DigitColorBlue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DigitColorBlue.BackColor = System.Drawing.Color.RoyalBlue;
			this.DigitColorBlue.Location = new System.Drawing.Point(212, 18);
			this.DigitColorBlue.Name = "DigitColorBlue";
			this.DigitColorBlue.Size = new System.Drawing.Size(54, 22);
			this.DigitColorBlue.TabIndex = 7;
			this.DigitColorBlue.Text = "Blue";
			this.DigitColorBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DigitColorBlue.CheckedChanged += new System.EventHandler(this.OnColorChange);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CloseBtn.BackColor = System.Drawing.Color.Gray;
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CloseBtn.Location = new System.Drawing.Point(164, 287);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(106, 26);
			this.CloseBtn.TabIndex = 10;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.Click += new System.EventHandler(this.OnClose);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.Location = new System.Drawing.Point(10, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 14);
			this.label5.TabIndex = 11;
			this.label5.Text = "Demo here :";
			// 
			// digitalClockCtrl1
			// 
			this.digitalClockCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.digitalClockCtrl1.BackColor = System.Drawing.Color.Black;
			this.digitalClockCtrl1.CountDownTime = 10000;
			this.digitalClockCtrl1.Location = new System.Drawing.Point(12, 7);
			this.digitalClockCtrl1.Name = "digitalClockCtrl1";
			this.digitalClockCtrl1.SetClockType = SriClocks.ClockType.DigitalClock;
			this.digitalClockCtrl1.Size = new System.Drawing.Size(406, 116);
			this.digitalClockCtrl1.TabIndex = 12;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.groupBox2.Controls.Add(this.FormatCombo);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.FreezeClockBtn);
			this.groupBox2.Controls.Add(this.StartStopWatchBtn);
			this.groupBox2.Controls.Add(this.DisplayTimeRBtn);
			this.groupBox2.Location = new System.Drawing.Point(10, 157);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(124, 120);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			// 
			// FormatCombo
			// 
			this.FormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FormatCombo.Items.AddRange(new object[] {
															 "12 Hour",
															 "24 Hour"});
			this.FormatCombo.Location = new System.Drawing.Point(56, 92);
			this.FormatCombo.Name = "FormatCombo";
			this.FormatCombo.Size = new System.Drawing.Size(64, 21);
			this.FormatCombo.TabIndex = 16;
			this.FormatCombo.SelectedIndexChanged += new System.EventHandler(this.OnFormatChange);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 14);
			this.label2.TabIndex = 15;
			this.label2.Text = "Format :";
			// 
			// FreezeClockBtn
			// 
			this.FreezeClockBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.FreezeClockBtn.Location = new System.Drawing.Point(8, 66);
			this.FreezeClockBtn.Name = "FreezeClockBtn";
			this.FreezeClockBtn.Size = new System.Drawing.Size(108, 16);
			this.FreezeClockBtn.TabIndex = 14;
			this.FreezeClockBtn.Text = "Freeze the clock!";
			this.FreezeClockBtn.CheckedChanged += new System.EventHandler(this.SetClockType);
			// 
			// StartStopWatchBtn
			// 
			this.StartStopWatchBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.StartStopWatchBtn.Location = new System.Drawing.Point(8, 42);
			this.StartStopWatchBtn.Name = "StartStopWatchBtn";
			this.StartStopWatchBtn.Size = new System.Drawing.Size(104, 16);
			this.StartStopWatchBtn.TabIndex = 13;
			this.StartStopWatchBtn.Text = "Start stop watch";
			this.StartStopWatchBtn.CheckedChanged += new System.EventHandler(this.SetClockType);
			// 
			// DisplayTimeRBtn
			// 
			this.DisplayTimeRBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DisplayTimeRBtn.Location = new System.Drawing.Point(8, 20);
			this.DisplayTimeRBtn.Name = "DisplayTimeRBtn";
			this.DisplayTimeRBtn.Size = new System.Drawing.Size(104, 16);
			this.DisplayTimeRBtn.TabIndex = 12;
			this.DisplayTimeRBtn.Text = "Display Time";
			this.DisplayTimeRBtn.CheckedChanged += new System.EventHandler(this.SetClockType);
			// 
			// TestClockForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(428, 317);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.digitalClockCtrl1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TestClockForm";
			this.Text = "DigitalClockCtrl Demo Application";
			this.Load += new System.EventHandler(this.OnLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TestClockForm());
		}

		// delegate to be called once the count down is done
		private void OnCountDownDone()
		{
			MessageBox.Show("Count down finished !", "Count down success");
		}
		// delegate called when an alarm is raised
		private void OnRaiseAlarm()
		{
			MessageBox.Show("Hello, you've set an alarm !", "Get up");
		}
		private void SetClockType(object sender, System.EventArgs e)
		{
			if (sender.Equals(DisplayTimeRBtn))
				digitalClockCtrl1.SetClockType = ClockType.DigitalClock;
			if (sender.Equals(StartStopWatchBtn))
				digitalClockCtrl1.SetClockType = ClockType.StopWatch;
			if (sender.Equals(FreezeClockBtn))
				digitalClockCtrl1.SetClockType = ClockType.Freeze;
			if (sender.Equals(CountDownBtn))
			{
				digitalClockCtrl1.CountDownTime = Int32.Parse(this.MilliSecs.Text);
				digitalClockCtrl1.SetClockType = ClockType.CountDown;
			}
		}
		private void OnColorChange(object sender, System.EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			if (rb.Checked)
			{
				if (rb.Equals(this.DigitColorRed))
					digitalClockCtrl1.SetDigitalColor = DigitalColor.RedColor;
				else if (rb.Equals(this.DigitColorGreen))
					digitalClockCtrl1.SetDigitalColor = DigitalColor.GreenColor;
				else if (rb.Equals(this.DigitColorBlue))
					digitalClockCtrl1.SetDigitalColor = DigitalColor.BlueColor;
			}
		}

		private void OnLoad(object sender, System.EventArgs e)
		{
			Alarmtime.Text = DateTime.Now.ToString("G");
			digitalClockCtrl1.CountDownDone += 
				new DigitalClockCtrl.CountDown(OnCountDownDone);
			digitalClockCtrl1.RaiseAlarm +=
				new DigitalClockCtrl.Alarm(OnRaiseAlarm);
			DigitColorRed.Checked = true;  // default red color
			FormatCombo.SelectedIndex = 0; // default 12 hr format
			DisplayTimeRBtn.Checked = true; // default normal clock
		}

		private void OnSetAlarm(object sender, System.EventArgs e)
		{
			try
			{
				digitalClockCtrl1.AlarmTime = DateTime.Parse(Alarmtime.Text);
			} 
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void OnFormatChange(object sender, System.EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			digitalClockCtrl1.ClockDisplayFormat = 
				(cb.SelectedIndex == 0) ? ClockFormat.TwelveHourFormat
									: ClockFormat.TwentyFourHourFormat;
		}
		private void OnClose(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
