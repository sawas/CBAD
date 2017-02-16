/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 22/10/2015
 * Time: 12:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBADFillexClient
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			var uncPath = uncFilePath.Text;
			var _uncFile = uncFile.Text;
			var _uncFileMode = uncFileMode.Text;
			
			var uncUserDomain = userDomainName.Text;
			var uncUser = userName.Text;
			var uncPassword = userPassword.Text;
			
			try {
				using (var dialog = new SaveFileDialog()) {
					dialog.Filter = "jpeg files (*.jpg)|*.jpg|pdf files (*.pdf)|*.pdf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
					dialog.FilterIndex = 2;
					dialog.RestoreDirectory = true;

					if (dialog.ShowDialog() == DialogResult.OK) {
						var fi = new System.IO.FileInfo(dialog.FileName);
						switch (_uncFileMode) {
							case "NET USE":
								using (var unc = new CBADFilex.UNCAccessWithCredentials()) {
									if (unc.NetUseWithCredentials(@uncPath, uncUserDomain, uncUser, uncPassword)) {
										CBADFilex.FileManager.Download(@uncPath, @fi.DirectoryName, @_uncFile, @fi.Name);										
										MessageBox.Show("Dowload Complete " + @fi.DirectoryName + @fi.Name);
									} else {
										MessageBox.Show("Cannot Connected With Net Use.");
									}
								}
								break;
							case "IMPERSONATE":
								using (var copy = new CBADFilex.Impersonator()) {
									if (copy.Impersonate(uncUserDomain, uncUser, uncPassword)) {
										copy.Download(@uncPath, @fi.DirectoryName, @_uncFile, @fi.Name);
										MessageBox.Show("Dowload Complete " + @fi.DirectoryName + @fi.Name);
									} else {
										MessageBox.Show("Cannot Impersonate.");
									}
								}
								break;
							default :
								MessageBox.Show("Invalid Mode.");
								break;
						}
					}
				}
			} catch (Exception ex) {				
				MessageBox.Show(ex.Message);
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			var uncPath = uncFilePath.Text;
			var _uncFile = uncFile.Text;
			var _uncFileMode = uncFileMode.Text;
			
			var uncUserDomain = userDomainName.Text;
			var uncUser = userName.Text;
			var uncPassword = userPassword.Text;
			
			try {
				using (var dialog = new SaveFileDialog()) {
					dialog.Filter = "jpeg files (*.jpg)|*.jpg|pdf files (*.pdf)|*.pdf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
					dialog.FilterIndex = 2;
					dialog.RestoreDirectory = true;

					if (dialog.ShowDialog() == DialogResult.OK) {
						var fi = new System.IO.FileInfo(dialog.FileName);
						switch (_uncFileMode) {
							case "NET USE":
								using (var unc = new CBADFilex.UNCAccessWithCredentials()) {
									if (unc.NetUseWithCredentials(@uncPath, uncUserDomain, uncUser, uncPassword)) {
										var filBytes = CBADFilex.FileManager.DownloadAsBytes(@uncPath, @_uncFile);
										if (filBytes.Length > 0) {
											System.IO.File.WriteAllBytes(@fi.DirectoryName + @fi.Name, filBytes);
											MessageBox.Show("Dowload Complete " + @fi.DirectoryName + @fi.Name);
										} else {
											MessageBox.Show("Cannot Download File.");				
										}											
									} else {
										MessageBox.Show("Cannot Connected With Net Use.");
									}
								}
								break;
							case "IMPERSONATE":
								using (var copy = new CBADFilex.Impersonator()) {
									if (copy.Impersonate(uncUserDomain, uncUser, uncPassword)) {
										var filBytes = copy.DownloadAsBytes(@uncPath, @_uncFile);										
										if (filBytes.Length > 0) {
											System.IO.File.WriteAllBytes(@fi.DirectoryName + @fi.Name, filBytes);
											MessageBox.Show("Dowload Complete " + @fi.DirectoryName + @fi.Name);
										} else {
											MessageBox.Show("Cannot Download File.");
										}
									} else {
										MessageBox.Show("Cannot Impersonate.");
									}
								}
								break;
							default :
								MessageBox.Show("Invalid Mode.");
								break;
						}
					}
				}
			} catch (Exception ex) {				
				MessageBox.Show(ex.Message);
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			var uncPath = uncFilePath.Text;
			var _uncFile = uncFile.Text;
			var _uncFileMode = uncFileMode.Text;
			
			var uncUserDomain = userDomainName.Text;
			var uncUser = userName.Text;
			var uncPassword = userPassword.Text;
			
			var result1 = MessageBox.Show("The File Will Upload And Can't Undo, Are You Okay With This ?",
				                   "Important Question",
				                   MessageBoxButtons.YesNo);
			
			if (result1 == DialogResult.No) {
				return;
			}
			
			try {
				using (var dialog = new SaveFileDialog()) {
					dialog.Filter = "jpeg files (*.jpg)|*.jpg|pdf files (*.pdf)|*.pdf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
					dialog.FilterIndex = 2;
					dialog.RestoreDirectory = true;

					if (dialog.ShowDialog() == DialogResult.OK) {
						var fi = new System.IO.FileInfo(dialog.FileName);
						switch (_uncFileMode) {
							case "NET USE":
								using (var unc = new CBADFilex.UNCAccessWithCredentials()) {
									if (unc.NetUseWithCredentials(@uncPath, uncUserDomain, uncUser, uncPassword)) {
										CBADFilex.FileManager.Upload(@uncPath, @fi.DirectoryName, @fi.Name);
										MessageBox.Show("Upload Complete.");
									} else {
										MessageBox.Show("Cannot Connected With Net Use.");
									}
								}
								break;
							case "IMPERSONATE":
								using (var copy = new CBADFilex.Impersonator()) {
									if (copy.Impersonate(uncUserDomain, uncUser, uncPassword)) {
										copy.Upload(uncPath, @fi.DirectoryName, @fi.Name);
										MessageBox.Show("Upload Complete.");
									} else {
										MessageBox.Show("Cannot Impersonate.");
									}
								}
								break;
							default :
								MessageBox.Show("Invalid Mode.");
								break;
						}
					}
				}
			} catch (Exception ex) {				
				MessageBox.Show(ex.Message);
			}
		}
		
	}
}
