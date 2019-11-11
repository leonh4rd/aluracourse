using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace xml_jason
{
	class Item_25
	{
		static async Task Main(string[] args)
		{
			//Consultar dados de um CEP no serviço da http://viacep.com.br e exibir os dados
			string cep = "21240110";
			string url = $"http://viacep.com.br/ws/{cep}/json/";

			using (var client = new HttpClient())
			{
				var income_json = await client.GetStringAsync(url);

				var address = JsonConvert.DeserializeObject<Endereco>(income_json);

				Console.WriteLine($"Logradouro: {address.Logradouro}" +
										$"\nBairro: {address.Bairro}" +
										$"\nMunicípo: {address.Localidade} " +
										$"\nUF: {address.UF}" +
										$"\nCEP: {address.CEP}");
			}

			Console.ReadKey();
		}
	}

	class Endereco
	{
		public string CEP { get; set; }
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
		public string Localidade { get; set; }
		public string UF { get; set; }
	}
}
