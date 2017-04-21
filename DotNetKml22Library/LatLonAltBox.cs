using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// A bounding box that describes an area of interest defined by geographic coordinates and altitudes.
	/// </summary>
	public class LatLonAltBox
	{
		/// <summary>
		/// Specifies the latitude of the north edge of the bounding box, in decimal degrees from 0 to ±90.
		/// </summary>
		public Angle90 North { get; set; }

		/// <summary>
		/// Specifies the latitude of the south edge of the bounding box, in decimal degrees from 0 to ±90.
		/// </summary>
		public Angle90 South { get; set; }

		/// <summary>
		/// Specifies the longitude of the east edge of the bounding box, in decimal degrees from 0 to ±180. 
		/// (For overlays that overlap the meridian of 180° longitude, values can extend beyond that range.)
		/// </summary>
		public Angle180 East { get; set; }

		/// <summary>
		/// Specifies the longitude of the west edge of the bounding box, in decimal degrees from 0 to ±180. 
		/// (For overlays that overlap the meridian of 180° longitude, values can extend beyond that range.)
		/// </summary>
		public Angle180 West { get; set; }

		/// <summary>
		/// Specifies a rotation of the overlay about its center, in degrees. Values can be ±180. The 
		/// default is 0 (north). Rotations are specified in a counterclockwise direction.
		/// </summary>
		public Angle180 Rotation { get; set; }

		public void WriteTo(XmlWriter writer)
		{
			writer.WriteStartElement("LatLonBox");

			writer.WriteElementString("north", North.Value.ToString(CultureInfo.InvariantCulture));

			writer.WriteElementString("south", South.Value.ToString(CultureInfo.InvariantCulture));

			writer.WriteElementString("east", East.Value.ToString(CultureInfo.InvariantCulture));

			writer.WriteElementString("west", West.Value.ToString(CultureInfo.InvariantCulture));

			writer.WriteElementString("rotation", Rotation.Value.ToString(CultureInfo.InvariantCulture));

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
