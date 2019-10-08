using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace linqtoxml
{
	class Program
	{
		static void Main(string[] args)
		{
			string xml =
				"<Movies>" +
					"<Movie>" +
						"<Director>Quentin Tarantino</Director>" +
						"<Title>Pulp Fiction</Title>" +
						"<Minutes>154</Minutes>" +
					"</Movie>" +
					"<Movie>" +
						"<Director>James Cameron</Director>" +
						"<Title>Avatar</Title>" +
						"<Minutes>162</Minutes>" +
					"</Movie>" +
				"</Movies>";

			//XmlDocument xmlDocument = new XmlDocument();
			//xmlDocument.Load("data/aluratunes.xml");

			XDocument document = XDocument.Parse(xml);

			Console.WriteLine("LINQ to XML");
			Console.WriteLine();

			IEnumerable<XElement> query =
				from f in document.Descendants("Movie")
				select f;

			foreach (var item in query)
			{
				Console.WriteLine(item.Element("Director").FirstNode);
				Console.WriteLine(item.Element("Title").FirstNode);
			}

			Console.WriteLine();

			IEnumerable<XElement> query2 =
				from f in document.Descendants("Movie")
				//where f.Element("Director").FirstNode.ToString() == "James Cameron"
				where (string)f.Element("Director") == "James Cameron"
				select f;

			foreach (var item in query2)	
			{
				Console.WriteLine( (string)item.Element("Director") );
				Console.WriteLine( (string)item.Element("Title") );
			}

			Console.WriteLine();

			IEnumerable<XElement> query3 =
				document.Descendants("Movie")
				.Where(element => (string)element.Element("Director") == "Quentin Tarantino");

			foreach (var item in query3)
			{
				Console.WriteLine((string)item.Element("Director"));
				Console.WriteLine((string)item.Element("Title"));
			}

			Console.ReadKey();
		}
	}
}
