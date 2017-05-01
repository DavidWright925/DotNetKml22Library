using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	public class PolyStyle : ColorStyle
	{
		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "PolyStyle");
			base.WriteTo(writer);
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
