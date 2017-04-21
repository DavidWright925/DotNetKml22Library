using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	public class PolyStyle : ColorStyle
	{
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "PolyStyle");

			base.WriteTo(writer);

			//writer.WriteElementString("width", Width.ToString());

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
