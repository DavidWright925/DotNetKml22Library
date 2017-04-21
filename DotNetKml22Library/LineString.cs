using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// Defines a connected set of line segments.
	/// </summary>
	public class LineString : Geometry
	{
		/// <summary>
		/// Boolean value. Specifies whether to connect the LineString to the ground. To 
		/// extrude a LineString, the altitude mode must be either relativeToGround, relativeToSeaFloor, 
		/// or absolute. The vertices in the LineString are extruded toward the center of the Earth's 
		/// sphere.
		/// </summary>
		public bool Extrude { get; set; }

		/// <summary>
		/// Boolean value. Specifies whether to allow the LineString to follow the terrain. To enable 
		/// tessellation, the altitude mode must be clampToGround or clampToSeaFloor. Very large 
		/// LineStrings should enable tessellation so that they follow the curvature of the earth 
		/// (otherwise, they may go underground and be hidden).
		/// </summary>
		public bool Tessellate { get; set; }

		public AltitudeMode AltitudeMode { get; set; }

		public IEnumerable<ICoordinate> Coordinates { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "LineString");

			if (Extrude)
				writer.WriteElementString("extrude", Extrude ? "1" : "0");

			if (Tessellate)
				writer.WriteElementString("tessellate", Tessellate ? "1" : "0");

			Kml.WriteElement(writer, AltitudeMode);

			if (Coordinates != null)
				Kml.WriteElement(writer, Coordinates);

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
