using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// References a KML file or KMZ archive on a local or 
	/// remote network. Use the Link element to specify the 
	/// location of the KML file. Within that element, you can 
	/// define the refresh options for updating the file, based 
	/// on time and camera change. NetworkLinks can be used in 
	/// combination with Regions to handle very large datasets efficiently.
	/// </summary>
	public class NetworkLink : Feature
	{
		public bool RefreshVisibility { get; set; }

		public bool FlyToView { get; set; }

		public Link Link { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "NetworkLink");

			base.WriteTo(writer);

			if (RefreshVisibility)
				writer.WriteElementString("refreshVisibility", RefreshVisibility ? "1" : "0");

			if (FlyToView)
				writer.WriteElementString("flyToView", FlyToView ? "1" : "0");

			Check.Operation(Link != null, "Link must be set");

			if (Link != null)
				Link.WriteTo(writer);

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
