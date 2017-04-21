using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies how the description balloon for placemarks is drawn. 
	/// The <see cref="BgColor"/>, if specified, is used as the background color of 
	/// the balloon. See Feature for a diagram illustrating how the 
	/// default description balloon appears in Google Earth.
	/// </summary>
	public class BalloonStyle : Object
	{
		// ----- static members -----

		static string ToDisplayModeString(DisplayMode displayMode)
		{
			switch (displayMode)
			{
				case DisplayMode.Default:
					return "default";
				case DisplayMode.Hide:
					return "hide";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "DisplayMode not implemented \"{0}\".", displayMode));
		}

		// ----- instance members -----
		/// <summary>
		/// Initialize a new instance of the <see cref="BalloonStyle"/> class.
		/// </summary>
		public BalloonStyle()
		{
			BgColor = Color.White;
			TextColor = Color.Black;
		}

		/// <summary>
		/// Background color of the balloon (optional).  The default is opaque white (ffffffff).
		/// </summary>
		public Color BgColor { get; set; }

		/// <summary>
		/// Foreground color for text. The default is black (ff000000).
		/// </summary>
		public Color TextColor { get; set; }

		/// <summary>
		/// Text displayed in the balloon. If no text is specified, 
		/// Google Earth draws the default balloon (with the Feature name 
		/// in boldface, the Feature description, links for driving directions, 
		/// a white background, and a tail that is attached to the point 
		/// coordinates of the Feature, if specified).
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// If <see cref="DisplayMode"/> is <see cref="DisplayMode.Default"/>, Google 
		/// Earth uses the information supplied in <see cref="Text"/> to create a balloon. 
		/// If <see cref="DisplayMode"/> is <see cref="DisplayMode.Hide"/>, 
		/// Google Earth does not display the balloon. In Google Earth, clicking 
		/// the List View icon for a Placemark whose balloon's <see cref="DisplayMode"/> 
		/// is hide causes Google Earth to fly to the Placemark.
		/// </summary>
		public DisplayMode DisplayMode { get; set; }

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "BalloonStyle");

			Color bgColor = BgColor;
			if (bgColor != null && bgColor != Color.White)
				writer.WriteElementString("bgColor", string.Format(CultureInfo.InvariantCulture, "{0}", bgColor));

			Color textColor = TextColor;
			if (textColor != null && textColor != Color.Black)
				writer.WriteElementString("textColor", string.Format(CultureInfo.InvariantCulture, "{0}", textColor));

			Kml.WriteElement(writer, "text", Text);

			if (DisplayMode != DisplayMode.Default)
				writer.WriteElementString("displayMode", ToDisplayModeString(DisplayMode));

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
