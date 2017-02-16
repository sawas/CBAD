/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 15/09/2015
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CBADAssemblyInfo
{
	partial class AssemblyInfoForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox asmInfoText;
		
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
			this.asmInfoText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// asmInfoText
			// 
			this.asmInfoText.Location = new System.Drawing.Point(13, 13);
			this.asmInfoText.Multiline = true;
			this.asmInfoText.Name = "asmInfoText";
			this.asmInfoText.Size = new System.Drawing.Size(267, 248);
			this.asmInfoText.TabIndex = 0;
			// 
			// AssemblyInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.asmInfoText);
			this.Name = "AssemblyInfoForm";
			this.Text = "AssemblyInfoForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
