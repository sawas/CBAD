using System;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.IO;

namespace CBADFilex
{
	public class Impersonator : IDisposable
	{
		#region Assembly Functions
		[DllImport("advapi32.dll")]
		public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
	
		[DllImport("kernel32.dll")]
		public static extern bool CloseHandle(IntPtr handle);
		#endregion
	
		#region Private Variables
		private IntPtr _TokenHandle = new IntPtr(0);
		private WindowsImpersonationContext _WindowsImpersonationContext;
		private string sUser;
		private string sPassword;
		private string sDomain;
		#endregion
	
		#region Constructors
		public Impersonator()
		{			
		}
		#endregion
	
		#region Methods
		public bool Impersonate(string domain, string username, string password)
		{
			sDomain = domain;
			sUser = username;
			sPassword = password;		
			return Impersonate();
		}
		
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private bool Impersonate()
		{
			bool returnValue = false;
	
			try {
				const int LOGON32_PROVIDER_DEFAULT = 3;
				const int LOGON32_LOGON_INTERACTIVE = 9;
	
				_TokenHandle = IntPtr.Zero;
	
				//Call LogonUser to obtain a handle to an access token.
				returnValue = LogonUser(sUser, sDomain, sPassword, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _TokenHandle);
				if (returnValue) {
					WindowsIdentity newId = new WindowsIdentity(_TokenHandle);
					_WindowsImpersonationContext = newId.Impersonate();
				}
			} catch (Exception) {
				UndoImpersonate();
			}
			
			return returnValue;
		}
	
		private void UndoImpersonate()
		{
			if (_WindowsImpersonationContext != null) {
				_WindowsImpersonationContext.Undo();
				if (!_TokenHandle.Equals(IntPtr.Zero)) {
					CloseHandle(_TokenHandle);
				}
			}
		}
	
		public bool PutFile(FileStream source, string destRemoteFilename, bool overwrite)
		{
			try {
				if (!Directory.Exists(Path.GetDirectoryName(destRemoteFilename)))
					Directory.CreateDirectory(Path.GetDirectoryName(destRemoteFilename));
				using (FileStream dest = File.OpenWrite(destRemoteFilename)) {
					source.Seek(0, SeekOrigin.Begin);
					source.CopyTo(dest);
				}
				return true;
			} catch {
				return false;
			}
		}
	
		public bool GetFile(string sourceRemoteFilename, FileStream dest, bool overwrite)
		{
			try {
				using (FileStream source = File.OpenRead(sourceRemoteFilename)) {
					source.Seek(0, SeekOrigin.Begin);
					source.CopyTo(dest);
				}
				return true;
			} catch {
				return false;
			}
		}
	    
		public void Download(string uncFilePath, string localFilePath, string srcFilename, string destfileName)
		{
			byte[] bytes = null;
			DownloadCore(uncFilePath, srcFilename, out bytes);
			string destFileName = localFilePath + @"\" + destfileName;
			File.WriteAllBytes(@destFileName, bytes);
		}
	    
		public byte[] DownloadAsBytes(string uncFilePath, string srcFilename)
		{
			byte[] bytes = null;
			DownloadCore(uncFilePath, srcFilename, out bytes);
			return bytes;
		}
	    
		private void DownloadCore(string uncFilePath, string fileName, out byte[] bytes)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			string sourceFileName = uncFilePath + @"\" + fileName;
			
			bytes = File.ReadAllBytes(@sourceFileName);
		}
	    
		public void Upload(string uncFilePath, string localFilePath, string fileName)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			string sourceFileName = localFilePath + @"\" + fileName;
			string destFileName = uncFilePath + @"\" + fileName;
			
			File.Copy(@sourceFileName, @destFileName);				
		}
	    
		public bool CanAccess(string path)
		{
			bool haveAccess = false;
			
			var di = new DirectoryInfo(path);

			if (di.Exists) {
				try {
					var acl = di.GetAccessControl();
					haveAccess = true;
				} catch (UnauthorizedAccessException uae) {
					haveAccess |= uae.Message.Contains("read-only");
				}
			}

			return haveAccess;
		}
	    
		#endregion
	
		#region IDisposable
		public void Dispose()
		{
			UndoImpersonate();
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}