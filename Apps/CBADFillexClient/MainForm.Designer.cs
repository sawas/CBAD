/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 22/10/2015
 * Time: 12:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CBADFillexClient
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox userDomainName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox userPassword;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox uncFileMode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox uncFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox uncFilePath;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.userPassword = new System.Windows.Forms.TextBox();
			this.userDomainName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.userName = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.uncFileMode = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.uncFile = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.uncFilePath = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.userPassword);
			this.groupBox1.Controls.Add(this.userDomainName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.userName);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(267, 100);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Password";
			// 
			// userPassword
			// 
			this.userPassword.Location = new System.Drawing.Point(75, 69);
			this.userPassword.Name = "userPassword";
			this.userPassword.Size = new System.Drawing.Size(176, 20);
			this.userPassword.TabIndex = 4;
			this.userPassword.Text = "6!@zUh2Yj7JP";
			// 
			// userDomainName
			// 
			this.userDomainName.Location = new System.Drawing.Point(75, 13);
			this.userDomainName.Name = "userDomainName";
			this.userDomainName.Size = new System.Drawing.Size(176, 20);
			this.userDomainName.TabIndex = 3;
			this.userDomainName.Text = "corp-ais900";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Domain";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "User Name";
			// 
			// userName
			// 
			this.userName.Location = new System.Drawing.Point(75, 43);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(176, 20);
			this.userName.TabIndex = 0;
			this.userName.Text = "cpssftp";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.uncFileMode);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.uncFile);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.uncFilePath);
			this.groupBox2.Location = new System.Drawing.Point(13, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(267, 99);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "UNC File";
			// 
			// uncFileMode
			// 
			this.uncFileMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.uncFileMode.FormattingEnabled = true;
			this.uncFileMode.Items.AddRange(new object[] {
			"NET USE",
			"IMPERSONATE"});
			this.uncFileMode.Location = new System.Drawing.Point(76, 68);
			this.uncFileMode.Name = "uncFileMode";
			this.uncFileMode.Size = new System.Drawing.Size(175, 21);
			this.uncFileMode.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(10, 71);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Mode";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 20);
			this.label5.TabIndex = 9;
			this.label5.Text = "File";
			// 
			// uncFile
			// 
			this.uncFile.Location = new System.Drawing.Point(75, 45);
			this.uncFile.Name = "uncFile";
			this.uncFile.Size = new System.Drawing.Size(176, 20);
			this.uncFile.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Path";
			// 
			// uncFilePath
			// 
			this.uncFilePath.Location = new System.Drawing.Point(75, 19);
			this.uncFilePath.Name = "uncFilePath";
			this.uncFilePath.Size = new System.Drawing.Size(176, 20);
			this.uncFilePath.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 225);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(267, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Download";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(13, 283);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(267, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "Upload";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 254);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(267, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "Download As Bytes";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 325);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "CBADFillexClient";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
