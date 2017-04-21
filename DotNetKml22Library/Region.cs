using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// A region contains a bounding box (<see cref="LatLonAltBox"/>) that describes an area of interest defined by geographic coordinates and altitudes. In addition, a Region contains an LOD (level of detail) extent (<see cref="Lod"/>) that defines a validity range of the associated Region in terms of projected screen size. A Region is said to be "active" when the bounding box is within the user's view and the LOD requirements are met. Objects associated with a Region are drawn only when the Region is active. When the <see cref="ViewRefreshMode"/> is onRegion, the Link or Icon is loaded only when the Region is active.
	/// </summary>
	public class Region : Object
	{
		LatLonAltBox _latLonAltBox = new LatLonAltBox();

		/// <summary>
		/// A bounding box that describes an area of interest defined by geographic coordinates and altitudes.
		/// </summary>
		public LatLonAltBox LatLonAltBox
		{
			get { return _latLonAltBox; }
			set
			{
				Check.ArgumentNotNull(value, "LatLonAltBox");
				if (_latLonAltBox != value)
					_latLonAltBox = value;
			}
		}

		public Lod Lod { get; set; }

		/// <include file='Documentation.xml' path='MyDocs/MyMembers[@name="WriteTo"]/*' />
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Region");

			if (LatLonAltBox != null)
				LatLonAltBox.WriteTo(writer);

			if (Lod != null)
				Lod.WriteTo(writer);

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
