using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_09
	{
		private const string directory = "New Directory";

		static void XMain(string[] args)
		{
			//Create a directory
			//Verify if its created
			//Delete the directory
			Directory.CreateDirectory(directory);
			if (Directory.Exists(directory))
			{
				Console.WriteLine($"O diretório \"{directory}\" existe");
			}

			Directory.Delete(directory);
			Console.WriteLine($"O diretório \"{directory}\" NÃO existe");

			Console.ReadKey();
		}
	}
}
