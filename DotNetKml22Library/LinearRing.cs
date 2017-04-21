using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// Defines a closed line string, typically the outer boundary of a 
	/// Polygon. Optionally, a LinearRing can also be used as the inner
	/// boundary of a Polygon to create holes in the Polygon. A Polygon 
	/// can contain multiple LinearRing elements used as inner boundaries.
	/// </summary>
	public class LinearRing : Geometry
	{
		/// <summary>
		/// Boolean value. Specifies whether to connect the LineString to the ground. 
		/// To extrude a LineString, the altitude mode must be either relativeToGround, 
		/// relativeToSeaFloor, or absolute. The vertices in the LineString are extruded 
		/// toward the center of the Earth's sphere.
		/// </summary>
		public bool Extrude { get; set; }

		/// <summary>
		/// Boolean value. Specifies whether to allow the LineString to follow the terrain. 
		/// To enable tessellation, the altitude mode must be clampToGround or clampToSeaFloor. 
		/// Very large LineStrings should enable tessellation so that they follow the curvature 
		/// of the earth (otherwise, they may go underground and be hidden).
		/// </summary>
		public bool Tessellate { get; set; }

		/// <summary>
		/// Specifies how altitude components in the <see cref="Coordinates"/> element are interpreted. 
		/// </summary>
		public AltitudeMode AltitudeMode { get; set; }

		/// <summary>
		/// Four or more tuples, each consisting of floating point values for longitude, 
		/// latitude, and altitude. The altitude component is optional. Do not include 
		/// spaces within a tuple. The last coordinate must be the same as the first 
		/// coordinate. Coordinates are expressed in decimal degrees only.
		/// </summary>
		public IEnumerable<ICoordinate> Coordinates { get; set; }

		/// <summary>
		/// Writes this <see cref="LinearRing"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "LinearRing");

			if (Extrude)
				writer.WriteElementString("extrude", Extrude ? "1" : "0");

			if (Tessellate)
				writer.WriteElementString("tessellate", Tessellate ? "1" : "0");

			Kml.WriteElement(writer, AltitudeMode);

			Kml.WriteElement(writer, Coordinates);

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
