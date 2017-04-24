using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// Defines the virtual camera that views the scene. This element defines the 
	/// position of the camera relative to the Earth's surface as well as the viewing 
	/// direction of the camera. The camera position is defined by <see cref="Longitude"/>, 
	/// <see cref="Latitude"/>, <see cref="Altitude"/> and <see cref="AltitudeMode"/>. 
	/// The viewing direction of the camera is defined by <see cref="Heading"/>, 
	/// <see cref="Tilt"/>, and <see cref="Roll"/>. <see cref="Camera"/> can be a child element 
	/// of any <see cref="Feature"/> or of <see cref="NetworkLinkControl"/>. A parent 
	/// element cannot contain both a <see cref="Camera"/> and a <see cref="LookAt"/> at 
	/// the same time.
	/// </summary>
	public class Camera : AbstractView
	{
		/// <summary>
		/// Longitude of the virtual camera (eye point). Angular distance in 
		/// degrees, relative to the Prime Meridian. Values west of the Meridian 
		/// range from −180 to 0 degrees. Values east of the Meridian range 
		/// from 0 to 180 degrees.
		/// </summary>
		public Angle180 Longitude { get; set; }

		/// <summary>
		/// Latitude of the virtual camera. Degrees north or south of the Equator 
		/// (0 degrees). Values range from −90 degrees to 90 degrees.
		/// </summary>
		public Angle90 Latitude { get; set; }

		/// <summary>
		/// Distance of the camera from the earth's surface, in meters. 
		/// Interpreted according to the Camera's <see cref="AltitudeMode"/>.
		/// </summary>
		public double Altitude { get; set; }

		/// <summary>
		/// Direction (azimuth) of the camera, in degrees. Default=0 (true North).
		/// Values range from 0 to 360 degrees.
		/// </summary>
		public Angle360 Heading { get; set; }

		/// <summary>
		/// Rotation, in degrees, of the camera around the X axis. A value of 0 indicates 
		/// that the view is aimed straight down toward the earth (the most common case). 
		/// A value for 90 for <see cref="Tilt"/> indicates that the view is aimed toward 
		/// the horizon. Values greater than 90 indicate that the view is pointed up into 
		/// the sky. Values for <see cref="Tilt"/> are clamped at +180 degrees.
		/// </summary>
		public AnglePos90 Tilt { get; set; }

		/// <summary>
		/// Rotation, in degrees, of the camera around the Z axis. Values range from −180 to +180 degrees.
		/// </summary>
		public Angle180 Roll { get; set; }

		/// <summary>
		/// Specifies how the <see cref="Altitude" /> specified 
		/// for the LookAt point is interpreted. 
		/// </summary>
		public AltitudeMode AltitudeMode { get; set; }

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Camera");
			writer.WriteElementString("longitude", Longitude.ToString());
			writer.WriteElementString("latitude", Latitude.ToString());
			writer.WriteElementString("altitude", Altitude.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("heading", Heading.ToString());
			writer.WriteElementString("tilt", Tilt.ToString());
			writer.WriteElementString("roll", Roll.ToString());
			Kml.WriteElement(writer, AltitudeMode);
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
