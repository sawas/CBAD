/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 06/10/2015
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CBADFilex;

namespace CBADConsoleTest
{
	/// <summary>
	/// Description of CBADFile.
	/// </summary>
	public class CBADFile
	{
		private const string uncPath = @"\\path";
		private const string uncDomain = "domain";
		private const string uncUser = "username";
		private const string uncPassword = "password";
		
		public CBADFile()
		{
		}
		
		public void UncAccess_Upload()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				if (unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword)) {
					FileManager.Upload(uncPath, @"D:", @"text.txt");
				}
			}
		}
	}
}
