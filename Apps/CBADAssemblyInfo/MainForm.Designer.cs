/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 15/09/2015
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CBADAssemblyInfo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button dllBrowserBtn;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.dllBrowserBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dllBrowserBtn
			// 
			this.dllBrowserBtn.Location = new System.Drawing.Point(12, 12);
			this.dllBrowserBtn.Name = "dllBrowserBtn";
			this.dllBrowserBtn.Size = new System.Drawing.Size(75, 23);
			this.dllBrowserBtn.TabIndex = 0;
			this.dllBrowserBtn.Text = "Browse";
			this.dllBrowserBtn.UseVisualStyleBackColor = true;
			this.dllBrowserBtn.Click += new System.EventHandler(this.DllBrowserBtnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 78);
			this.Controls.Add(this.dllBrowserBtn);
			this.Name = "MainForm";
			this.Text = "CBADAssemblyInfo";
			this.ResumeLayout(false);

		}
	}
}
