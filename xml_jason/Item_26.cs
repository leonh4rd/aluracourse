using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace xml_jason
{
	class Item_26
	{
		static async Task XMain(string[] args)
		{
			//TAREFA:
			//1. LER UMA STRING CONTENDO DOCUMENTO XML:
			//		-DECLARAÇÃO XML
			//		-ELEMENTOS
			//		-TEXTOS
			//		-ATRIBUTOS
			//2. INTERPRETAR CADA NÓ DA ESTRUTURA XML
			//		-TIPO
			//		-NOME
			//		-VALOR

			string xml =
				"<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
				"<Movies>" +
					"<Movie Genre=\"Cop\">" +
						"<Director>Quentin Tarantino</Director>" +
						"<Title>Pulp Fiction</Title>" +
						"<Minutes>154</Minutes>" +
					"</Movie>" +
					"<Movie Genre=\"Science Fiction\">" +
						"<Director>James Cameron</Director>" +
						"<Title>Avatar</Title>" +
						"<Minutes>162</Minutes>" +
					"</Movie>" +
				"</Movies>";

			using (var reader = new StringReader(xml))
			{
				var xml_reader = new XmlTextReader(reader);

				while (xml_reader.Read())
				{
					ReadXml(xml_reader);

					if (xml_reader.HasAttributes)
					{
						while (xml_reader.MoveToNextAttribute())
						{
							ReadXml(xml_reader);
						}
					} 
				}
			}

			Console.ReadKey();
		}

		private static void ReadXml(XmlTextReader xml_reader)
		{
			Console.WriteLine("Tipo: {0}, Nome: {1}, Valor: {2}",
									xml_reader.NodeType.ToString(),
									xml_reader.Name,
									xml_reader.Value);
		}
	}
}
