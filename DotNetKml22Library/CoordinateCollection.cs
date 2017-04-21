using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// A helper class to used to return a 2 or 3-tuple (ordered list of elements)
	/// of <see cref="IEnumerable(ICoordinate)"/> with a space separator.  The tuple 
	/// is used for <see cref="Geometry"/> classes like <see cref="LineString"/>
	/// that needs an <see cref="IEnumerable(ICoordinate)"/>.
	/// Each tuple is normally represented as "lon,lat,alt" where
	/// "lon" is longitide, "lat" is latitude and "alt" is altitude.
	/// </summary>
	public class CoordinateCollection : IEnumerable<ICoordinate>
	{
		readonly List<ICoordinate> _items = new List<ICoordinate>();

		//List<ICoordinate> Coordinates
		//{
		//    get { return _items; }
		//}

		public void Add(IEnumerable<ICoordinate> coordinates)
		{
			if (coordinates == null)
				return;

			foreach (ICoordinate coordinate in coordinates)
				Add(coordinate);
		}

		public void Add(ICoordinate coordinate)
		{
			Check.ArgumentNotNull(coordinate, "coordinate");
			_items.Add(coordinate);
		}

		public void Add(double longitude, double latitude)
		{
			Add(latitude, longitude, double.NaN);
		}

		public void Add(double latitude, double longitude, double altitude)
		{
			Add(new Coordinate(longitude, latitude, altitude));
		}

		public void Add(string longitudeLatitudeAltitudeTuples)
		{
			Add(longitudeLatitudeAltitudeTuples.Split(' '));
		}

		public void Add(IEnumerable<string> longitudeLatitudeAltitudeTuple)
		{
			if (longitudeLatitudeAltitudeTuple == null)
				return;

			foreach (string latLong in longitudeLatitudeAltitudeTuple)
			{
				string[] part = latLong.Split(',');

				switch (part.Length)
				{
					case 2:
						Add(double.Parse(part[1], CultureInfo.InvariantCulture), 
							double.Parse(part[0], CultureInfo.InvariantCulture), 
							double.NaN);
						continue;
					case 3:
						Add(double.Parse(part[1], CultureInfo.InvariantCulture),
							double.Parse(part[0], CultureInfo.InvariantCulture), 
							double.Parse(part[2], CultureInfo.InvariantCulture));
						continue;
				}
				throw new InvalidOperationException();
			}
		}

		public ICoordinate this[int index]
		{
			get { return _items[index]; }
		}

		public int Count { get { return _items.Count; } }


		public IEnumerator<ICoordinate> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
