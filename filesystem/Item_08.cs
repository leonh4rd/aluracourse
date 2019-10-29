using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_08
	{
		private const string FileName = "arquivo.txt";

		static void XMain(string[] args)
		{
			//Record data in a text file
			//Get information about the file:
			//	Name
			//	Full path
			//	Date and time of last access
			//	Size in bytes
			//	Attributes of the file
			//	Add readonly attribute
			//	Check attributes again
			//	Remove readonly attribute
			//	Check attributes one last time

			string content = "Texto inicial do arquivo";
			File.WriteAllText(FileName, content);

			FileInfo info = new FileInfo(FileName);

			Console.WriteLine("Nome do arquivo: {0}", info.Name);

			Console.WriteLine("Caminho do arquivo: {0}", info.FullName);

			Console.WriteLine("Hora do último acesso: {0}", info.LastAccessTime);

			Console.WriteLine("Tamanho do arquivo: {0} bytes", info.Length);

			Console.WriteLine("Atributos do arquivo: {0}", info.Attributes.ToString());

			info.Attributes = info.Attributes | FileAttributes.ReadOnly;

			Console.WriteLine("Atributos do arquivo(2): {0}", info.Attributes.ToString());

			info.Attributes = info.Attributes & ~FileAttributes.ReadOnly;

			Console.WriteLine("Atributos do arquivo(3): {0}", info.Attributes.ToString());

			Console.ReadKey();
		}
	}
}
