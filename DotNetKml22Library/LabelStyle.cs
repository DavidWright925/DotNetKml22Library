using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies how the name of a Feature is drawn in the 3D viewer. A custom color, 
	/// color mode, and scale for the label (name) can be specified.
	/// </summary>
	public class LabelStyle : ColorStyle
	{
		double _scale = 1;

		/// <summary>
		/// Resizes the icon.
		/// </summary>
		public double Scale
		{
			get { return _scale; }
			set { _scale = value; }
		}

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "LabelStyle");

			base.WriteTo(writer);

			if (Scale != 1)
				Kml.WriteElement(writer, "scale", Scale.ToString(CultureInfo.InvariantCulture));

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
