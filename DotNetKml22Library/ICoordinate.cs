using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Represents a coordinate with a longitude, latitude and altitude.
	/// </summary>
	public interface ICoordinate
	{
		/// <summary>
		/// Gets the coordinate longitude.
		/// </summary>
		double Longitude { get; }

		/// <summary>
		/// Gets the coordinate latitude.
		/// </summary>
		double Latitude { get; }

		/// <summary>
		/// Gets the coordinate altitude in kilometers.
		/// </summary>
		double Altitude { get; }
	}
}
