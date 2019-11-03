using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filesystem
{
	class Item_10
	{
		static void XMain(string[] args)
		{
			//Using DirectInfo class
			//Create directory
			//Verify if it exists
			//Show attributes of the directory
			//Show last access
			//Delete directory

			DirectoryInfo dir = new DirectoryInfo("local");
			dir.Create();
			if (dir.Exists)
			{
				Console.WriteLine($"O diretório \"{dir.Name}\" existe.");
				Console.WriteLine("Atributos: {0}", dir.Attributes);
				Console.WriteLine("Último acesso: {0}", dir.LastAccessTime);
				dir.Delete();
			}
			else
			{
				return;
			}
			Console.WriteLine("O diretório foi removido.");

			Console.ReadKey();
		}
	}
}
