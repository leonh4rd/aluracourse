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

			//XmlDocument document = new XmlDocument();
			//document.LoadXml(xml);

			XDocument document = XDocument.Parse(xml);

			IEnumerable<XElement> query =
				from f in document.Descendants("Movie")
				select f;

			Console.WriteLine("LINQ to XML");
			Console.WriteLine();

			foreach (var item in query)
			{
				Console.WriteLine(item.Element("Director").FirstNode);
				Console.WriteLine(item.Element("Title").FirstNode);
			}

			Console.ReadKey();
		}
	}
}
