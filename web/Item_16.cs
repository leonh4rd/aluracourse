using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace web
{
	class Item_16
	{
		static async Task XMain(string[] args)
		{
			// Tarefas de WebRequest
			// Conectar ao site Caelum (http://www.caelum.com.br)
			// Obter dados HTML de forma assíncrona para rodar em:
			// - Aplicações Windows (Windows Form, WPF)
			// - Aplicações Web (ASP.NET e ASP.NET Core)
			// - Xamarin (mobile)
			// - Windows Universal Application

			HttpClient client = new HttpClient();

			var result = await client.GetStringAsync("http://www.caelum.com.br");

			Console.WriteLine(result);

			Console.ReadKey();
		}

	}
}
