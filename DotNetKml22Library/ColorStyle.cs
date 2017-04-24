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
	/// <see cref="https://developers.google.com/kml/documentation/kmlreference#colorstyle"/>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="ColorStyle"/> class.
		/// </summary>
		public ColorStyle()
		{
			Color = DefaultColor;
		}

		/// <summary>
		/// Gets or sets the color of this <see cref="ColorStyle"/>.
		/// </summary>
		public Color Color { get; set; }

		/// <summary>
		/// Gets or sets the color mode.
		/// </summary>
		public ColorMode ColorMode { get; set; }

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
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
