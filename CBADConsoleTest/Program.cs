/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 06/10/2015
 * Time: 17:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CBADConsoleTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			var cFile = new CBADFile();
			cFile.UncAccess_Upload();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}