using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in a KML file. 
	/// <see cref="Overlay"/> is the base type for image overlays drawn on the 
	/// planet surface or on the screen. <see cref="Icon"/> specifies the image 
	/// to use and can be configured to reload images based on a timer or by camera 
	/// changes. This element also includes specifications for stacking order of 
	/// multiple overlays and for adding color and transparency values to the base 
	/// image.
	/// </summary>
	public abstract class Overlay : Feature
	{
		public Overlay()
		{
			Color = DefaultColor;
		}

		/// <summary>
		/// Gets or sets the <see cref="Overlay"/> color.
		/// </summary>
		public Color Color { get; set; }

		/// <summary>
		/// This element defines the stacking order for the images in overlapping 
		/// overlays.  Overlays with higher DrawOrder values are drawn on top of 
		/// overlays with lower DrawOrder values.
		/// </summary>
		public int DrawOrder { get; set; }

		/// <summary>
		/// Defines the image associated with the Overlay. Icon defines the 
		/// location of the image to be used as the Overlay. This location can 
		/// be either on a local file system or on a web server. If this element 
		/// is omitted or contains no Icon, a rectangle is drawn using the 
		/// color and size defined by the ground or screen overlay.
		/// </summary>
		public Icon Icon { get; set; }

		/// <summary>
		/// Writes the contents of this <see cref="Overlay"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">An <see cref="XmlWriter"/>.</param>
		public override void WriteTo(XmlWriter writer)
		{
			base.WriteTo(writer);

			Color color = Color;
			if (color != null && color != DefaultColor)
				Kml.WriteElement(writer, "color", string.Format(CultureInfo.InvariantCulture, "{0}", color));

			if (DrawOrder != 0)
				writer.WriteElementString("drawOrder", string.Format(CultureInfo.InvariantCulture, "{0}", DrawOrder));

			if (Icon != null)
				Icon.WriteTo(writer);

			writer.Flush();
		}
	}
}
