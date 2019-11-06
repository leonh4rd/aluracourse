using System;
using System.IO;
using System.Net;

namespace web
{
	class Program
	{
		static void XMain(string[] args)
		{
			// Tarefas de WebRequest
			// Conectar ao site Caelum (http://www.caelum.com.br)
			// Obter código html
			// Exibir código html

			WebRequest request = WebRequest.Create("http://www.caelum.com.br");

			WebResponse response = request.GetResponse();

			using (var stream = new StreamReader(response.GetResponseStream()))
			{
				string code = stream.ReadToEnd();
				Console.WriteLine(code);
			}

			Console.ReadKey();
		}
	}
}
