using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies the drawing style (color, color mode, and line width) for all 
	/// line geometry. Line geometry includes the outlines of outlined polygons 
	/// and the extruded "tether" of Placemark icons (if extrusion is enabled).
	/// </summary>
	public class LineStyle : ColorStyle
	{
		/// <summary>
		/// Width of the line, in pixels.
		/// </summary>
		public double Width { get; set; }

		/// <summary>
		/// Writes this <see cref="Document"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">The <see cref="XmlWriter"> to write this <see cref="Document"/>.</see></param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "LineStyle");
			base.WriteTo(writer);
			if (Width > 0)
				writer.WriteElementString("width", Width.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
