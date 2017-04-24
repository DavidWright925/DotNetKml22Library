using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Represents a geographic coordinate with a latitude and longitude and optionally altitude.
	/// </summary>
	public struct Coordinate : ICoordinate, IEquatable<ICoordinate>
	{
		// ----- static members -----

		/// <summary>
		/// Equals operator.
		/// </summary>
		/// <param name="coordinate1"></param>
		/// <param name="coordinate2"></param>
		/// <returns></returns>
		public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
		{
			return coordinate1.Equals(coordinate2);
		}

		/// <summary>
		/// Not equals operator.
		/// </summary>
		/// <param name="coordinate1"></param>
		/// <param name="coordinate2"></param>
		/// <returns></returns>
		public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
		{
			return !(coordinate1 == coordinate2);
		}

		/// <summary>
		/// Returns true if <paramref name="coordinate"/> is empty.
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		public static bool IsEmpty(ICoordinate coordinate)
		{
			return coordinate != null && IsEmpty(coordinate.Longitude, coordinate.Latitude, coordinate.Altitude);
		}

		static bool IsEmpty(double longitude, double latitude, double altitude)
		{
			return (longitude == 0 && latitude == 0 && double.IsNaN(altitude));
		}

		/// <summary>
		/// An empty <see cref="Coordinate"/>.
		/// </summary>
		public static readonly Coordinate Empty = new Coordinate(0, 0);

		/// <summary>
		/// Returns a string for the coordinate.
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		internal static string ToTuple(ICoordinate coordinate)
		{
			Check.ArgumentNotNull(coordinate, "coordinate");
			if (double.IsNaN(coordinate.Altitude))
				return string.Format(CultureInfo.InvariantCulture, "{0},{1}", 
					coordinate.Longitude, coordinate.Latitude);
			return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", 
				coordinate.Longitude, coordinate.Latitude, coordinate.Altitude);
		}

		// ----- instance members -----

		double _longitude;
		double _latitude;
		double _altitude;

		/// <summary>
		/// Initializes a new Coordinate structure.
		/// </summary>
		/// <param name="longitude"></param>
		/// <param name="latitude"></param>
		public Coordinate(double longitude, double latitude) :
			this(longitude, latitude, double.NaN) { }

		/// <summary>
		/// Initializes a new Coordinate structure.
		/// </summary>
		/// <param name="longitude"></param>
		/// <param name="latitude"></param>
		/// <param name="altitude"></param>
		public Coordinate(double longitude, double latitude, double altitude)
		{
			Check.Argument(longitude >= -180 && longitude <= 180,
				"Longitude", "Longitude must be >= -180 and <= 180");
			_longitude = longitude;
			Check.Argument(latitude >= -90 && latitude <= 90,
				"Latitude", "Latitude must be >= -90 and <= 90");
			_latitude = latitude;
			_altitude = altitude;
		}

		/// <summary>
		/// Compares this <see cref="Coordinate"/> with <paramref name="other"/> for equality.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(ICoordinate other)
		{
			return (other != null &&
				other.Longitude == Longitude &&
				other.Latitude == Latitude &&
				other.Altitude == Altitude);
		}

		/// <summary>
		/// Compares this <see cref="Coordinate"/> with <paramref name="obj"/> for equality.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			ICoordinate coordinate = obj as ICoordinate;
			return coordinate != null && Equals(coordinate);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return Longitude.GetHashCode() ^ Latitude.GetHashCode() ^ Altitude.GetHashCode();
		}

		/// <summary>
		/// Returns true if this instance is empty.
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			return IsEmpty(this);
		}

		/// <summary>
		/// Gets the longitude of this coordinate.
		/// </summary>
		public double Longitude
		{
			get { return _longitude; }
		}

		/// <summary>
		/// Gets the latitude of this coordinate.
		/// </summary>
		public double Latitude
		{
			get { return _latitude; }
		}

		/// <summary>
		/// Gets the altitude of this coordinate.
		/// </summary>
		public double Altitude
		{
			get { return _altitude; }
		}

		/// <summary>
		/// Returns a string representation of this instance.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ToTuple(this);
		}
	}
}
