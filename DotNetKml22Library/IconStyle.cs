using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies how icons for point Placemarks are drawn, both in the 
	/// Places panel and in the 3D viewer of Google Earth. The <see cref="Icon"/> 
	/// element specifies the icon image. The <see cref="Scale"/> element specifies the x, 
	/// y scaling of the icon. The color specified in the <see cref="Color"/> element of 
	/// <see cref="IconStyle"/> is blended with the color of the <see cref="Icon"/>.
	/// </summary>
	public class IconStyle : ColorStyle
	{
		double _scale = 1;
		double _heading;

		/// <summary>
		/// Gets or sets the x, y scaling of the icon.
		/// </summary>
		public double Scale
		{
			get { return _scale; }
			set { _scale = value; }
		}

		/// <summary>
		/// Gets or sets the direction (that is, North, South, East, West), in degrees. Default=0 (North). Values range from 0 to 360 degrees.
		/// </summary>
		public double Heading
		{
			get { return _heading; }
			set
			{
				if (value < 0 || value > 360)
					throw new ArgumentOutOfRangeException("Heading", "Heading must be in range 0-360");
				if (_heading == value)
					return;
				_heading = value;
			}
		}

		/// <summary>
		/// A custom Icon.
		/// </summary>
		public Icon Icon { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "IconStyle");

			base.WriteTo(writer);

			if (Scale != 1)
				Kml.WriteElement(writer, "scale", Scale.ToString(CultureInfo.InvariantCulture));

			if (Heading != 0)
				Kml.WriteElement(writer, "heading", Heading.ToString(CultureInfo.InvariantCulture));

			if (Icon != null)
				Icon.WriteTo(writer);

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
