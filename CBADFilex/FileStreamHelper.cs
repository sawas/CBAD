/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 16/10/2015
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace CBADFilex
{
	/// <summary>
	/// Description of FileStreamHelper.
	/// </summary>
	public static class FileStreamHelper
	{
		public static void CopyTo(this Stream input, Stream output)
		{
			byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
			int bytesRead;

			while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0) {
				output.Write(buffer, 0, bytesRead);
			}
		}
	}
}
