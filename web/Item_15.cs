using System;
using System.Net;
using System.Threading.Tasks;

namespace web
{
	class Item_15
	{
		static async Task Main(string[] args)
		{
			// Tarefas de WebRequest
			// Conectar ao site Caelum (http://www.caelum.com.br)
			// Obter dados HTML de forma assíncrona

			string html = await DownloadHTML();

			Console.WriteLine(html);

			Console.ReadKey();
		}

		private static async Task<string> DownloadHTML()
		{
			WebClient client = new WebClient();

			var html = await client.DownloadStringTaskAsync("http://www.caelum.com.br");
			return html;
		}
	}
}
