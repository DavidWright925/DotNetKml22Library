using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in a KML file. 
	/// It provides elements for specifying the color and color mode of extended style types.
	/// </summary>
	public abstract class ColorStyle : Object
	{
		// ----- static members -----

		static string ToColorModeString(ColorMode colorMode)
		{
			switch (colorMode)
			{
				case ColorMode.Normal:
					return "normal";
				case ColorMode.Random:
					return "random";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "ColorMode not implemented \"{0}\".", colorMode));
		}

		// ----- instance members -----

		public ColorStyle()
		{
			Color = DefaultColor;
		}

		public Color Color { get; set; }

		public ColorMode ColorMode { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			Color color = Color;
			if (color != null && color != DefaultColor)
				Kml.WriteElement(writer, "color", string.Format(CultureInfo.InvariantCulture, "{0}", color));

			if (ColorMode != ColorMode.Normal)
				writer.WriteElementString("colorMode", ToColorModeString(ColorMode));

			writer.Flush();
		}
	}
}
