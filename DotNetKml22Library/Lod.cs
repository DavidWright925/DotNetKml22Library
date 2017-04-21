using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Lod is an abbreviation for Level of Detail.
	/// </summary>
	public class Lod
	{
		public Lod()
		{
			MaxLodPixels = -1;  //set to the default.
		}

		/// <summary>
		/// Measurement in screen pixels that represents the minimum 
		/// limit of the visibility range for a given Region. Google 
		/// Earth calculates the size of the Region when projected onto 
		/// screen space. Then it computes the square root of the Region's 
		/// area (if, for example, the Region is square and the viewpoint 
		/// is directly above the Region, and the Region is not tilted, 
		/// this measurement is equal to the width of the projected Region). 
		/// If this measurement falls within the limits defined by 
		/// <see cref="MinLodPixels"/> and <see cref="MaxLodPixels"/> 
		/// (and if the <see cref="LatLonAltBox"/> is in view), the Region 
		/// is active. If this limit is not reached, the associated geometry 
		/// is considered to be too far from the user's viewpoint to be drawn.
		/// </summary>
		public double MinLodPixels { get; set; }

		/// <summary>
		/// Measurement in screen pixels that represents the maximum limit of the visibility range for a given Region. 
		/// A value of −1, the default, indicates "active to infinite size."
		/// </summary>
		public double MaxLodPixels { get; set; }

		/// <summary>
		/// Distance over which the geometry fades, from fully opaque to fully transparent. This ramp value, expressed in screen pixels, is applied at the minimum end of the LOD (visibility) limits.
		/// </summary>
		public double MinFadeExtent { get; set; }

		/// <summary>
		/// Distance over which the geometry fades, from fully transparent to fully opaque. This ramp value, expressed in screen pixels, is applied at the maximum end of the LOD (visibility) limits.
		/// </summary>
		public double MaxFadeExtent { get; set; }

		public void WriteTo(XmlWriter writer)
		{
			writer.WriteStartElement("Lod");

			writer.WriteElementString("minLodPixels", MinLodPixels.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("maxLodPixels", MaxLodPixels.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("minFadeExtent", MinFadeExtent.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("maxFadeExtent", MaxFadeExtent.ToString(CultureInfo.InvariantCulture));

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
