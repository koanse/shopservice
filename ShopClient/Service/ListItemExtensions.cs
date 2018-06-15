using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ShopClient.ShopServiceReference;

namespace ShopClient.Service
{
	public static class ListItemExtensions
	{
		public static string ToHtml(this List<Item> list)
		{
			var result = string.Empty;
			if (list == null || !list.Any())
			{
				return result;
			}

			result = "<table border=1 frame=hsides rules=rows width=\"100%\">";
			var listToJoin = list.Select(i =>
				$"<tr><td><font color=\"{(i.Price >= 20 ? ConsoleColor.Red.ToString() : ConsoleColor.Black.ToString())}\">{i.Description}</font></td><td>{i.Price}</td></tr>");
			result += string.Join(Environment.NewLine, listToJoin);
			result += "</table>";

			return result;
		}

		public static string SerializeToXml(this List<Item> list)
		{
			var result = string.Empty;
			if (list == null || !list.Any())
			{
				return result;
			}

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>));
			string content;

			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, list);
				result = textWriter.ToString();
			}

			return result;
		}
	}
}
