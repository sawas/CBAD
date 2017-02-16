/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 15/09/2015
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CBADAssemblyInfo
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
		
		void DllBrowserBtnClick(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "dll files (*.dll)|*.dll";
			openFileDialog1.FilterIndex = 0;
			openFileDialog1.RestoreDirectory = true;
			
			var result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK) { 
				
				var asmForm = new AssemblyInfoForm();
				Assembly assembly = Assembly.LoadFrom(openFileDialog1.FileName);
				var assemblyInfo = new AssemblyInfo(assembly);
				var stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Company: " + assemblyInfo.Company);
				stringBuilder.AppendLine("Copyright: " + assemblyInfo.Copyright);
				stringBuilder.AppendLine("Description: " + assemblyInfo.Description);
				stringBuilder.AppendLine("Product: " + assemblyInfo.Product);
				stringBuilder.AppendLine("ProductTitle: " + assemblyInfo.ProductTitle);
				stringBuilder.AppendLine("Version: " + assemblyInfo.Version);
				
				asmForm.asmInfoText.Text = stringBuilder.ToString();
				asmForm.ShowDialog(this);
			}
		}
	}
}
