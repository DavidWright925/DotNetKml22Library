using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	public struct Vec2
	{
		public double X { get; set; }
		public Units XUnits { get; set; }

		public double Y { get; set; }
		public Units YUnits { get; set; }

		public void WriteTo(XmlWriter writer)
		{
			writer.WriteAttributeString("x", string.Format(CultureInfo.InvariantCulture, "{0}", X));
			writer.WriteAttributeString("y", string.Format(CultureInfo.InvariantCulture, "{0}", Y));
			writer.WriteAttributeString("xunits", Kml.ToUnitString(XUnits));
			writer.WriteAttributeString("yunits", Kml.ToUnitString(YUnits));

			writer.Flush();
		}
	}
}
