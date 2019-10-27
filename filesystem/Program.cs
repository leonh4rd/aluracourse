using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Program
	{
		static void XMain(string[] args)
		{
			//.Open file
			//.Read 10 bytes
			//.Print those bytes on console

			FileStream stream = new FileStream("Directors.txt", FileMode.Open, FileAccess.Read);

			//array to store the bytes read of the file
			byte[] array = new byte[10];

			//initial position on the file
			int offset = 0;

			//size of the block to read
			int count = 10;

			/*
			stream.Read(array, offset, count);

			foreach (var c in array)
			{
				Console.Write((char)c);
			}
			*/

			stream.Seek(10, SeekOrigin.Begin);

			stream.Position = 5;

			stream.Read(array, offset, count);

			foreach (var c in array)
			{
				Console.Write((char)c);
			}



			Console.WriteLine();
			Console.ReadKey();
		}
	}
}
