using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	//http://code.google.com/apis/kml/documentation/kmlreference.html#point
	/// <summary>
	/// A geographic location defined by longitude, latitude, and (optional) 
	/// altitude. When a Point is contained by a Placemark, the point itself 
	/// determines the position of the Placemark's name and icon. When a Point 
	/// is extruded, it is connected to the ground with a line. This "tether" 
	/// uses the current LineStyle.
	/// </summary>
	public class Point : Geometry, ICoordinate
	{
		// ----- static members -----

		public static string Format(ICoordinate coordinate)
		{
			return coordinate == null ? null :  Format(coordinate.Latitude, coordinate.Longitude);
		}

		static string Format(double latitude, double longitude)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0.00},{1:0.00}", latitude, longitude);
		}

		// ----- instance members -----
		double _latitude;
		double _longitude;
		double _altitude;

		public Point() :
			this(0, 0, double.NaN) { }

		/// <summary>
		/// Initialize a new instance of the <see cref="Point"/> class with
		/// <see cref="Latitude"/> set to <paramref name="latitude"/>
		/// and <see cref="Longitude"/> set to <paramref name="longitude"/>.
		/// </summary>
		/// <param name="longitude">latitude ≥ −90 and ≤ 90</param>
		/// <param name="latitude">longitude ≥ −180 and <= 180</param>
		public Point(double longitude, double latitude) :
			this(longitude, latitude, double.NaN) { }

		/// <summary>
		/// Initialize a new instance of the <see cref="Point"/> class with
		/// <see cref="Latitude"/> set to <paramref name="latitude"/>, 
		/// <see cref="Longitude"/> set to <paramref name="longitude"/> and 
		/// <see cref="Altitude"/> set to <paramref name="altitude"/>.
		/// </summary>
		/// <param name="longitude">latitude ≥ −90 and ≤ 90</param>
		/// <param name="latitude">longitude ≥ −180 and <= 180</param>
		/// <param name="altitude">altitude values are in meters above sea level</param>
		public Point(double longitude, double latitude, double altitude)
		{
			Latitude = latitude;
			Longitude = longitude;
			Altitude = altitude;
		}

		/// <summary>
		/// Boolean value. Specifies whether to connect the point to the ground 
		/// with a line. To extrude a Point, the value for <see cref="AltitudeMode"/> 
		/// must be either relativeToGround, relativeToSeaFloor, or absolute. The 
		/// point is extruded toward the center of the Earth's sphere.
		/// </summary>
		public bool Extrude { get; set; }

		/// <summary>
		/// Specifies how altitude components in the coordinates element are interpreted.
		/// </summary>
		public AltitudeMode AltitudeMode { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Latitude"/> in degrees.
		/// </summary>
		public double Latitude
		{
			get { return _latitude; }
			set
			{
				if (value != _latitude)
				{
					Check.Argument(value >= -90 && value <= 90,
						"Latitude", "Latitude must be >= -90 and <= 90");
					_latitude = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="Longitude"/> in degrees.
		/// </summary>
		public double Longitude
		{
			get { return _longitude; }
			set
			{
				if (value != _longitude)
				{
					Check.Argument(value >= -180 && value <= 180,
						"Longitude", "Longitude must be >= -180 and <= 180");
					_longitude = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="Altitude"/> values (optional) are in 
		/// meters above sea level
		/// </summary>
		public double Altitude
		{
			get { return _altitude; }
			set { _altitude = value; }
		}

		/// <summary>
		/// Writes this <see cref="Point"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this <see cref="Point"/>.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Point");

			if (Extrude)
				writer.WriteElementString("extrude", Extrude ? "1" : "0");

			Kml.WriteElement(writer, AltitudeMode);

			Kml.WriteElement(writer, new ICoordinate[] { this });

			writer.WriteEndElement();

			writer.Flush();
		}

		/// <summary>
		/// Returns a single tuple consisting of floating point values for 
		/// longitude, latitude, and altitude (in that order).
		/// </summary>
		/// <example>-90.86948943473118,48.25450093195546 or -90.86948943473118,48.25450093195546,50</example>
		/// <returns>A tuple.</returns>
		public override string ToString()
		{
			return Format(this);
		}
	}
}
