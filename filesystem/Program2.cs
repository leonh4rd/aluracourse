using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Program2
	{
		static void XMain(string[] args)
		{
			Console.WriteLine();

			//Writing file
			FileStream stream = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write);

			string message = "Hello Alura!";

			byte[] array = Encoding.UTF8.GetBytes(message);
			int offset = 0;
			int count = message.Length;
			stream.Write(array, offset, count);

			stream.Close();

			FileStream stream2 = new FileStream("output.txt", FileMode.Open, FileAccess.Read);

			byte[] bytesRead = new byte[stream2.Length];
			stream2.Read(bytesRead, 0, (int)stream2.Length);
			string value = Encoding.UTF8.GetString(bytesRead);

			stream2.Close();

			Console.WriteLine(value);

			Console.ReadKey();
		}
	}
}
