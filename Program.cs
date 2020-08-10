using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Management;
using xNet;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace ScraperRaper
{
	//	Made by Binza#3408
	//	Help me get Coder and GodLike by leaving a like!
	class Program
	{
		static string hwid;
		//static string key;
		private static string gethwid()
		{
			if (string.IsNullOrEmpty(hwid))
			{
				DriveInfo[] drives = DriveInfo.GetDrives();
				int num = drives.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					DriveInfo driveInfo = drives[i];
					if (driveInfo.IsReady)
					{
						hwid = driveInfo.RootDirectory.ToString();
						break;
					}
				}
			}
			if (!string.IsNullOrEmpty(hwid) && hwid.EndsWith(":\\"))
			{
				hwid = hwid.Substring(0, hwid.Length - 2);
			}
			string result;
			using (ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + hwid + ":\""))
			{
				managementObject.Get();
				result = managementObject["VolumeSerialNumber"].ToString();
			}
			return result;
		}


		static void Main()
		{
			Console.Clear();
			Console.Title = "Impure Scraper | Impure Development Team! ";
			var Anon = new string[]
			{
				"Developed By Binza#3408",


			};

			foreach (string line in Anon) { Console.WriteLine(line, Color.Red); }
			Console.WriteLine();
			Console.WriteLine("keyword to use:");
			string resp = Console.ReadLine();
			int count = 0;
			List<string> Links = new List<string>();
			using (WebClient wc = new WebClient())
			{
				string s = wc.DownloadString("https://www.google.com/search?q=site:anonfile.com+" + resp);
				Regex r = new Regex(@"https:\/\/anonfile.com\/\w+\/\w+");
				foreach (Match m in r.Matches(s))
				{
					count++;
					Links.Add(m.ToString());
				}
			}

			using (TextWriter tw = new StreamWriter(@"links.txt"))
			{
				foreach (string line in Links)
				{
					tw.WriteLine(line.ToString());
				}
			}

			Console.WriteLine();
			Console.WriteLine("Scraped " + count.ToString() + " links!");
			Console.ReadLine();
		}
	}
}
