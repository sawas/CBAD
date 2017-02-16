/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 02/09/2015
 * Time: 18:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace CBADFilex
{
	public static class FileManager
	{
		public static List<string> GetFile(string uncFilePath)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			return (from file in Directory.GetFiles(uncFilePath)
			        select file).ToList();
		}
		
		public static string GetFile(string uncFilePath, string fileName)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			return (from file in Directory.GetFiles(uncFilePath)
			        where file == fileName
			        select file).FirstOrDefault();
		}
		
		public static bool Exists(string uncPath, string fileName)
		{
			string destFileName = uncPath + @"\" + fileName;
			return File.Exists(@destFileName);
		}
		
		public static void Download(string uncFilePath, string localFilePath, string srcFilename, string destfileName)
		{
			byte[] bytes = null;
			Download(uncFilePath, srcFilename, out bytes);
			string destFileName = localFilePath + @"\" + destfileName;
			File.WriteAllBytes(@destFileName, bytes);
		}
		
		public static byte[] DownloadAsBytes(string uncFilePath, string srcFilename)
		{
			byte[] bytes = null;
			Download(uncFilePath, srcFilename, out bytes);
			return bytes;
		}
		
		public static void Upload(string uncFilePath, string localFilePath, string fileName)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			string sourceFileName = localFilePath + @"\" + fileName;
			string destFileName = uncFilePath + @"\" + fileName;
			
			File.Copy(@sourceFileName, @destFileName);				
		}
		
		public static bool CanAccess(string path)
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
		
		private static void Download(string uncFilePath, string fileName, out byte[] bytes)
		{
			if (!CanAccess(uncFilePath)) {
				throw new Exception("Cannot Access Through Path : " + uncFilePath);
			}
			
			string sourceFileName = uncFilePath + @"\" + fileName;
			
			bytes = File.ReadAllBytes(@sourceFileName);
		}
	}
}
