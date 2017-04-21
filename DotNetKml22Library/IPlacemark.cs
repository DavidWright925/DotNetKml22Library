using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Properties required to create a "simple" <see cref="Kml"/> <see cref="Placemark"/>
	/// with the <see cref="Placemark.Geometry"/> set as a single <see cref="Point"/>.
	/// </summary>
	public interface IPlacemark : ICoordinate
	{
        /// <summary>
        /// Gets the <see cref="Placemark"/> name.
        /// </summary>
		string Name { get; }
	}
}
