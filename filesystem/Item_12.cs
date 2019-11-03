using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_12
	{
		static void Main(string[] args)
		{
			//Obter diretório do início do projeto (Parte 8)
			//Listar todos os diretórios do projeto
			//Listar todos os arquivos fontes do projeto

			DirectoryInfo info = new DirectoryInfo(@"..\..\..");
			ListDirectories(info);

			Console.ReadKey();
		}

		private static void ListDirectories(DirectoryInfo info)
		{
			foreach (var dir in info.GetDirectories())
			{
				Console.WriteLine(dir.FullName);

				foreach (var file in dir.GetFiles("*.cs"))
				{
					Console.WriteLine(file.FullName);
				}

				//Recursividade
				ListDirectories(dir);
			}
		}
	}
}
