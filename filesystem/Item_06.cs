using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_06
	{
		static void Main(string[] args)
		{
			//Stream exceptions
			try
			{
				string content = File.ReadAllText("arquivo.txt");
				Console.WriteLine("O conteúdo é :\n{0}", content);
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("O arquivo não foi encontrado.");
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			Console.ReadKey();
		}
	}
}
