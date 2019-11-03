using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Exercise_8_3_7
	{
		static void XMain(string[] args)
		{
			using (var stream = Console.OpenStandardInput())
			using (var filestream = new FileStream("doconsole.txt", FileMode.Create))
			{
				var buffer = new byte[1024]; //buffer de 1kb
				while (true)
				{
					var readBytes = stream.Read(buffer, 0, 1024);
					filestream.Write(buffer, 0, readBytes);
					filestream.Flush();
					Console.WriteLine($"Bytes lidos do console: {readBytes}");
				}
			}
			Console.ReadKey();
		}
	}
}
