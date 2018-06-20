/*
 * Created by SharpDevelop.
 * User: Егор
 * Date: 12.10.2016
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace CGI_test1
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Content-type: text/plain\n\n");
			Console.Write("test: " + Environment.GetEnvironmentVariable("QUERY_STRING"));
		}
	}
}