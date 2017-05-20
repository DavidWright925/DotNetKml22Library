using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	public class Polygon : Geometry
	{
		ICollection<InnerBoundaryIs> _innerBoundaryIsList;

		/// <summary>
		/// Boolean value. Specifies whether to connect the Polygon to the ground. To extrude a Polygon, the altitude mode must be either relativeToGround, relativeToSeaFloor, or absolute. Only the vertices are extruded, not the geometry itself (for example, a rectangle turns into a box with five faces. The vertices of the Polygon are extruded toward the center of the Earth's sphere.
		/// </summary>
		public bool Extrude { get; set; }

		/// <summary>
		/// This field is not used by Polygon. To allow a Polygon to follow the terrain (that is, to enable tessellation) specify an altitude mode of clampToGround or clampToSeaFloor.
		/// </summary>
		public bool Tessellate { get; set; }

		public AltitudeMode AltitudeMode { get; set; }

		public OuterBoundaryIs OuterBoundaryIs { get; set; }

		public ICollection<InnerBoundaryIs> InnerBoundaryIs
		{
			get { return _innerBoundaryIsList ?? (_innerBoundaryIsList = new List<InnerBoundaryIs>()); }
		}

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Polygon");
			if (Extrude)
				writer.WriteElementString("extrude", "1");
			if (Tessellate)
				writer.WriteElementString("tessellate", "1");
			Kml.WriteElement(writer, AltitudeMode);
			OuterBoundaryIs outerBoundaryIs = OuterBoundaryIs;
			Check.Operation(outerBoundaryIs != null, "OuterBoundaryIs not set");
			if (outerBoundaryIs != null)
				outerBoundaryIs.WriteTo(writer);
			if (_innerBoundaryIsList != null)
			{
				foreach (InnerBoundaryIs innerBoundaryIs in _innerBoundaryIsList)
					innerBoundaryIs.WriteTo(writer);
			}
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
