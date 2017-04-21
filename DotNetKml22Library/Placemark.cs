using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// A <see cref="Placemark"/> is a <see cref="Feature"/> with associated 
	/// <see cref="Geometry"/>. In Google Earth, 
	/// a Placemark appears as a list item in the Places panel. A Placemark 
	/// with a Point has an icon associated with it that marks a point on the 
	/// Earth in the 3D viewer. (In the Google Earth 3D viewer, a Point Placemark 
	/// is the only object you can click or roll over. Other Geometry objects 
	/// do not have an icon in the 3D viewer. To give the user something to click 
	/// in the 3D viewer, you would need to create a MultiGeometry object that 
	/// contains both a Point and the other Geometry object.)
	/// </summary>
	public class Placemark : Feature
	{
		public static Placemark Create(IPlacemark placemark)
		{
			Check.ArgumentNotNull(placemark, "placemark");

			return Create(placemark.Name, placemark.Longitude, placemark.Latitude);
		}

		public static Placemark Create(string name, double longitude, double latitude)
		{
			return new Placemark()
			{
				Name = name,
				Geometry = new Point(longitude, latitude),
			};
		}

		// ----- instance members -----
		public Geometry Geometry { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public MultiGeometry MultiGeometry { get; set; }

		/// <summary>
		/// Writes this object to <paramref name="writer"/>
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Placemark");

			base.WriteTo(writer);

			if (Geometry != null)
				Geometry.WriteTo(writer);

			if (MultiGeometry != null)
				MultiGeometry.WriteTo(writer);

			writer.WriteEndElement();

			writer.Flush();
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}", Name);
		}
	}
}
