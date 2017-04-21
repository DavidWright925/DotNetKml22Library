using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DotNetKml22Library
{
	public struct Coordinate : ICoordinate, IEquatable<ICoordinate>
	{
		// ----- static members -----

		public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
		{
			return coordinate1.Equals(coordinate2);
		}

		public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
		{
			return !(coordinate1 == coordinate2);
		}

		public static bool IsEmpty(ICoordinate coordinate)
		{
			return coordinate != null && IsEmpty(coordinate.Longitude, coordinate.Latitude, coordinate.Altitude);
		}

		static bool IsEmpty(double longitude, double latitude, double altitude)
		{
			return (longitude == 0 && latitude == 0 && double.IsNaN(altitude));
		}

		public static readonly Coordinate Empty = new Coordinate(0, 0);

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

		public Coordinate(double longitude, double latitude) :
			this(longitude, latitude, double.NaN) { }

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

		public bool Equals(ICoordinate other)
		{
			return (other != null &&
				other.Longitude == Longitude &&
				other.Latitude == Latitude &&
				other.Altitude == Altitude);
		}

		public override bool Equals(object obj)
		{
			ICoordinate coordinate = obj as ICoordinate;
			return coordinate != null && Equals(coordinate);
		}

		public override int GetHashCode()
		{
			return Longitude.GetHashCode() ^ Latitude.GetHashCode() ^ Altitude.GetHashCode();
		}

		public bool IsEmpty()
		{
			return IsEmpty(this);
		}

		public double Longitude
		{
			get { return _longitude; }
		}

		public double Latitude
		{
			get { return _latitude; }
		}

		public double Altitude
		{
			get { return _altitude; }
		}

		public override string ToString()
		{
			return ToTuple(this);
		}
	}
}
