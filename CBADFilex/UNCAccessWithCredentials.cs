﻿/*
 * Created by sawangchai saroj.
 * User: sawangchai saroj
 * Date: 02/09/2015
 * Time: 16:22
 */
 
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BOOL = System.Boolean;
using DWORD = System.UInt32;
using LPWSTR = System.String;
using NET_API_STATUS = System.UInt32;

namespace CBADFilex
{
	public sealed class UNCAccessWithCredentials : IDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct USE_INFO_2
		{
			internal LPWSTR ui2_local;
			internal LPWSTR ui2_remote;
			internal LPWSTR ui2_password;
			internal DWORD ui2_status;
			internal DWORD ui2_asg_type;
			internal DWORD ui2_refcount;
			internal DWORD ui2_usecount;
			internal LPWSTR ui2_username;
			internal LPWSTR ui2_domainname;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct USER_INFO_10
		{
			internal LPWSTR usri10_name;
			internal LPWSTR usri10_comment;
			internal LPWSTR usri10_usr_comment;
			internal LPWSTR usri10_full_name;
		}

		[DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern NET_API_STATUS NetUseAdd(
			LPWSTR UncServerName,
			DWORD Level,
			ref USE_INFO_2 Buf,
			out DWORD ParmError);

		[DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern NET_API_STATUS NetUseDel(
			LPWSTR UncServerName,
			LPWSTR UseName,
			DWORD ForceCond);

		[DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern NET_API_STATUS NetUserGetInfo(
			LPWSTR servername,
			LPWSTR username,
			DWORD level,
			out IntPtr bufPtr);

		private bool disposed = false;

		private string sUNCPath;
		private string sUser;
		private string sPassword;
		private string sDomain;
		private int iLastError;

		/// <summary>
		/// A disposeable class that allows access to a UNC resource with credentials.
		/// </summary>
		public UNCAccessWithCredentials()
		{
		}

		/// <summary>
		/// The last system error code returned from NetUseAdd or NetUseDel.  Success = 0
		/// </summary>
		public string LastError {
			get { return string.Format("Win 32 Error Code = {0} : {1}", iLastError, new Win32Exception(iLastError).Message); }
		}

		public void Dispose()
		{
			if (!this.disposed) {
				NetUseDelete();
			}
			disposed = true;
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Connects to a UNC path using the credentials supplied.
		/// </summary>
		/// <param name="UNCPath">Fully qualified domain name UNC path</param>
		/// <param name="User">A user with sufficient rights to access the path.</param>
		/// <param name="Domain">Domain of User.</param>
		/// <param name="Password">Password of User</param>
		/// <returns>True if mapping succeeds.  Use LastError to get the system error code.</returns>
		public bool NetUseWithCredentials(string UNCPath, string User, string Domain, string Password)
		{
			sUNCPath = UNCPath;
			sUser = User;
			sPassword = Password;
			sDomain = Domain;
			return NetUseWithCredentials();
		}

		private bool NetUseWithCredentials()
		{
			uint returncode;

			try {
				USE_INFO_2 useinfo = new USE_INFO_2();

				useinfo.ui2_remote = sUNCPath;
				useinfo.ui2_username = sUser;
				useinfo.ui2_domainname = sDomain;
				useinfo.ui2_password = sPassword;
				useinfo.ui2_asg_type = 0;
				useinfo.ui2_usecount = 1;
				uint paramErrorIndex;

				returncode = NetUseAdd(null, 2, ref useinfo, out paramErrorIndex);
				iLastError = (int)returncode;

				return (returncode == 0 || returncode == 1219);
			} catch {
				iLastError = Marshal.GetLastWin32Error();
				return false;
			}
		}

		/// <summary>
		/// Ends the connection to the remote resource 
		/// </summary>
		/// <returns>True if it succeeds.  Use LastError to get the system error code</returns>
		public bool NetUseDelete()
		{
			uint returncode;
			try {
				returncode = NetUseDel(null, sUNCPath, 2);
				iLastError = (int)returncode;
				return (returncode == 0);
			} catch {
				iLastError = Marshal.GetLastWin32Error();
				return false;
			}
		}

		public bool NetUseGetUserInfo(ref string FullName)
		{
			uint returncode;
			try {
				USER_INFO_10 objUserInfo10 = new USER_INFO_10();
				IntPtr bufPtr;
				returncode = NetUserGetInfo(sDomain, sUser, 10, out bufPtr);
				if (returncode == 0) {
					objUserInfo10 = (USER_INFO_10)Marshal.PtrToStructure(bufPtr, typeof(USER_INFO_10));
					FullName = string.Format(" Full Name = {0}, Comment = {1}, User Name = {2}, User Comment = {3}", objUserInfo10.usri10_full_name, objUserInfo10.usri10_comment, objUserInfo10.usri10_name, objUserInfo10.usri10_usr_comment);
				}

				iLastError = (int)returncode;
				return returncode == 0;
			} catch {
				iLastError = Marshal.GetLastWin32Error();
				return false;
			}
		}

		~UNCAccessWithCredentials()
		{
			Dispose();
		}
	}
}
