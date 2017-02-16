/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 03/09/2015
 * Time: 15:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using CBADFilex;
using NUnit.Framework;

namespace CBADUnitTest
{
	[TestFixture]   
	public class CBADFilexTest
	{
		private const string uncPath = @"\\path";
		private const string uncDomain = "domain";
		private const string uncUser = "username";
		private const string uncPassword = "password";
		
		[Test]    
		public void UncAccess_Success_Test()
		{     
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));
			}
		}
		
		[Test]    
		public void UncAccess_Success_Fail()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				var canAccessToUnc = unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword);
				Assert.False(canAccessToUnc);
			}
		}
		
		[Test]    
		public void UncAccess_Success_Fail_With_LastError()
		{     
			using (var unc = new UNCAccessWithCredentials()) {
				var canAccessToUnc = unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword);
				Assert.False(canAccessToUnc);
				Assert.True(!string.IsNullOrEmpty(unc.LastError));
			}
		}
		
		[Test]    
		public void UncAccess_GetFileList()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));
				Assert.True(FileManager.GetFile(uncPath).Count > 0);
			}
		}
		
		[Test]    
		public void UncAccess_GetFile()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));
				Assert.True(!string.IsNullOrEmpty(FileManager.GetFile(uncPath, @"\\filepath")));
			}
		}
		
		[Test]    
		public void UncAccess_Upload()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));				
				FileManager.Upload(uncPath, @"D:", @"test.txt");
			}
		}
		
		[Test]    
		public void UncAccess_Download()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));
				FileManager.Download(uncPath, @"D:", @"New Text Document.txt", "test.txt");
			}
		}
		
		[Test]    
		public void UncAccess_DownloadAsBytes()
		{
			using (var unc = new UNCAccessWithCredentials()) {
				Assert.True(unc.NetUseWithCredentials(uncPath, uncUser, uncDomain, uncPassword));
				var bytes = FileManager.DownloadAsBytes(uncPath, @"New Text Document.txt");
				Assert.AreNotEqual(null, bytes);
				
				var destFileName = @"D:" + @"\" + @"test.txt";
				File.WriteAllBytes(@destFileName, bytes);
			}
		}
		
		[Test]    
		public void Imperson_Download_Success_Test()
		{     			
			using (var copy = new Impersonator()) {
				Assert.True(copy.Impersonate(uncDomain, uncUser, uncPassword));
				copy.Download(uncPath, @"D:", @"TEST.pdf", "test.pdf");
			}
		}
		
		[Test]    
		public void Imperson_Upload_Success_Test()
		{     			
			using (var copy = new Impersonator()) {
				Assert.True(copy.Impersonate(uncDomain, uncUser, uncPassword));
				copy.Upload(uncPath, @"D:", @"test.txt");
			}
		}
		
		[Test]    
		public void Imperson_DownloadAsBytes_Success_Test()
		{
			using (var copy = new Impersonator()) {
				Assert.True(copy.Impersonate(uncDomain, uncUser, uncPassword));
				var bytes = copy.DownloadAsBytes(uncPath, @"ST - AIN VC AGMT Jan_Jun2012.pdf");
				Assert.AreNotEqual(null, bytes);
				
				var destFileName = @"D:" + @"\" + @"test.pdf";
				File.WriteAllBytes(@destFileName, bytes);
			}
		}
		
		[Test]    
		public void Imperson_DownloadAsBytes_Failed_Test()
		{
			using (var copy = new Impersonator()) {
				Assert.True(copy.Impersonate(uncDomain, uncUser, uncPassword + "s"));
				var bytes = copy.DownloadAsBytes(uncPath, @"test.pdf");
				Assert.AreNotEqual(null, bytes);
				
				var destFileName = @"D:" + @"\" + @"test.pdf";
				File.WriteAllBytes(@destFileName, bytes);
			}
		}
	}
}