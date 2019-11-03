using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item__11
	{
		static void XMain(string[] args)
		{
			//Find path of My Documents directory
			//Combine path of My Documents to  file alunos.txt
			//Get only the directory of the file
			//Get only the file name
			//Get extension of the file
			//Modify extension of the file

			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			Console.WriteLine("Meus Documentos: {0}", documents);

			var fullPath = Path.Combine(documents, "alunos.txt");
			Console.WriteLine("Caminho completo: {0}", fullPath);

			var onlyDirectory = Path.GetDirectoryName(fullPath);
			Console.WriteLine("Diretório: {0}", onlyDirectory);

			var onlyFile = Path.GetFileName(fullPath);
			Console.WriteLine("Arquivo: {0}", onlyFile);

			var ext = Path.GetExtension(fullPath);
			Console.WriteLine("Extensão: {0}", ext);

			fullPath = Path.ChangeExtension(fullPath, ".csv");
			var newExt = Path.GetExtension(fullPath);
			Console.WriteLine("Nova extensão: {0}", newExt);

			Console.ReadKey();
		}
	}
}
