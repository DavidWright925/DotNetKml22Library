using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Defines a virtual camera that is associated with any element derived from 
	/// <see cref="Feature"/>. The LookAt element positions the "camera" in relation to 
	/// the object that is being viewed. In Google Earth, the view "flies to" this LookAt 
	/// viewpoint when the user double-clicks an item in the Places panel or double-clicks 
	/// an icon in the 3D viewer.
	/// </summary>
	public class LookAt : AbstractView
	{
		public LookAt()
		{
			Altitude = double.NaN;
		}

		/// <summary>
		/// Longitude of the point the camera is looking at. Angular distance in degrees, 
		/// relative to the Prime Meridian. Values west of the Meridian range from −180 to 
		/// 0 degrees. Values east of the Meridian range from 0 to 180 degrees.
		/// </summary>
		public Angle180 Longitude { get; set; }

		/// <summary>
		/// Latitude of the point the camera is looking at. Degrees north or south 
		/// of the Equator (0 degrees). Values range from −90 degrees to 90 degrees.
		/// </summary>
		public Angle90 Latitude { get; set; }

		/// <summary>
		/// Distance from the earth's surface, in meters. 
		/// Interpreted according to the LookAt's altitude mode.
		/// </summary>
		public double Altitude { get; set; }

		/// <summary>
		/// Direction (that is, North, South, East, West), in degrees. Default=0 (North). 
		/// Values range from 0 to 360 degrees.
		/// </summary>
		public Angle360 Heading { get; set; }

		/// <summary>
		/// Angle between the direction of the LookAt position and the normal to the surface 
		/// of the earth. Values range from 0 to 90 degrees. Values for <see cref="tilt"/> cannot 
		/// be negative. A <see cref="tilt"/> value of 0 degrees indicates viewing from 
		/// directly above. A <see cref="tilt"/> value of 90 degrees indicates viewing along the horizon.
		/// </summary>
		public AnglePos90 Tilt { get; set; }

		/// <summary>
		/// REQUIRED: Distance in meters from the point specified by 
		/// <see cref="Longitude" />, <see cref="Latitude" />, 
		/// and <see cref="Altitude" /> to the LookAt position.
		/// </summary>
		public double Range { get; set; }

		/// <summary>
		/// Specifies how the <see cref="Altitude" /> specified 
		/// for the LookAt point is interpreted. 
		/// </summary>
		public AltitudeMode AltitudeMode { get; set; }

		/// <summary>
		/// Writes this <see cref="LookAt"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this <see cref="LookAt"/>.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "LookAt");

			writer.WriteElementString("longitude", Longitude.ToString());

			writer.WriteElementString("latitude", Latitude.ToString());

			if (!double.IsNaN(Altitude))
				writer.WriteElementString("altitude", Altitude.ToString(CultureInfo.InvariantCulture));

			writer.WriteElementString("heading", Heading.ToString());

			writer.WriteElementString("tilt", Tilt.ToString());

			Check.Argument(!double.IsNaN(Range), "Range is a required value.");
			writer.WriteElementString("range", Range.ToString(CultureInfo.InvariantCulture));
			
			Kml.WriteElement(writer, AltitudeMode);

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
