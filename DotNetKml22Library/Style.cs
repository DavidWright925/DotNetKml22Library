using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// A <see cref="Style"/> defines an addressable style group that can be referenced 
	/// by StyleMaps and <see cref="Feature"/>s. <see cref="Style"/>s affect how Geometry is presented 
	/// in the 3D viewer and how Features appear in the Places panel of the 
	/// List view. Shared styles are collected in a <see cref="Document"/> and must have an 
	/// id defined for them so that they can be referenced by the individual 
	/// Features that use them.
	/// 
	/// Use an id to refer to the style from a <see cref="StyleUrl"/>.
	/// </summary>
	public class Style : StyleSelector
	{
		public IconStyle IconStyle { get; set; }

		public LabelStyle LabelStyle { get; set; }

		public LineStyle LineStyle { get; set; }

		public PolyStyle PolyStyle { get; set; }

		public BalloonStyle BalloonStyle { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Style");

			if (IconStyle != null)
				IconStyle.WriteTo(writer);

			if (LabelStyle != null)
				LabelStyle.WriteTo(writer);

			if (LineStyle != null)
				LineStyle.WriteTo(writer);

			if (PolyStyle != null)
				PolyStyle.WriteTo(writer);

			if (BalloonStyle != null)
				BalloonStyle.WriteTo(writer);

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
