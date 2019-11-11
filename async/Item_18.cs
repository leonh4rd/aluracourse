using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace async
{
	class Item_18
	{
		static async Task XMain(string[] args)
		{
			//Capturar exceção gerado pelo método assíncrono

			byte[] data = new byte[100];

			try
			{
				await SaveByteAsync("output>.dat", data);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Writing failed.");
			}

			Console.ReadKey();
		}

		static async Task SaveByteAsync(string filename, byte[] items)
		{
			using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
			{
				await stream.WriteAsync(items, 0, items.Length);
			}
		}
	}
}
