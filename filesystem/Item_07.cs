using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_07
	{
		private const int kb = 1024;

		static void Main(string[] args)
		{
			//DRIVE:
			//Drive name
			//Check if drive is ready
			//Type of drive
			//Drive format
			//Free space

			var drives = DriveInfo.GetDrives();
			foreach (var drive in drives)
			{
				Console.WriteLine("Name: {0}", drive.Name);

				Console.WriteLine();

				if (!drive.IsReady)
				{
					Console.WriteLine("Drive is NOT ready to use");
					continue;
				}
				Console.WriteLine("Drive is ready to use");

				Console.WriteLine("Type: {0}", drive.DriveType);

				Console.WriteLine("Format: {0}", drive.DriveFormat);

				Console.WriteLine("Free space: ");
				double bytes = drive.TotalFreeSpace;
				Console.WriteLine("\t{0:N2} bytes", bytes);

				double kbytes = bytes / kb;
				Console.WriteLine("\t{0:N2} KB", kbytes);

				double megabytes = kbytes / kb;
				Console.WriteLine("\t{0:N2} MB", megabytes);

				double gigabytes = megabytes / kb;
				Console.WriteLine("\t{0:N2} GB", gigabytes);

				double terabytes = gigabytes / kb;
				Console.WriteLine("\t{0:N2} TB", terabytes);

			}

			Console.ReadKey();
		}
	}
}
