using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_05
	{
		static void XMain()
		{
			string filePath = "arquivo.txt";

			//Record and read data from file using Class File
			string content = "Conteúdo inicial do arquivo";
			string anotherContent = "\nMais conteúdo pro arquivo";

			File.WriteAllText(filePath, content);

			File.AppendAllText(filePath, anotherContent);

			if (File.Exists(filePath))
			{
				Console.WriteLine($"O arquivo {filePath} existe:\n");
				Console.WriteLine(File.ReadAllText(filePath));
			}
	
			File.Copy(filePath, "copy.txt", overwrite: true);

			using (var stream = File.OpenText("copy.txt"))
			{
				Console.WriteLine(stream.ReadToEnd());
			}

			Console.ReadKey();
		}
	}
}
