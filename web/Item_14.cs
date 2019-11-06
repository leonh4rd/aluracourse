using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace web
{
	class Item_14
	{
		static void Main(string[] args)
		{
			// Tarefas de WebRequest
			// Conectar ao site Caelum (http://www.caelum.com.br)
			// Obter dados HTML mais simples

			WebClient client = new WebClient();

			var html = client.DownloadString("http://www.caelum.com.br");

			Console.WriteLine(html);

			Console.ReadKey();
		}
	}
}
