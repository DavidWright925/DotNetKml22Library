using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// Represents an extent in time bounded by begin and end dateTimes.
	/// </summary>
	public class TimeSpan : TimePrimative
	{
		/// <summary>
		/// Describes the beginning instant of a time period. If absent, the beginning of the period is unbounded.
		/// </summary>
		public DateTime Begin { get; set; }

		/// <summary>
		/// Describes the ending instant of a time period. If absent, the end of the period is unbounded.
		/// </summary>
		public DateTime End { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "TimeSpan");

			if (Begin.Ticks != 0)
				Kml.WriteElement(writer, "begin", Begin);

			if (End.Ticks != 0)
				Kml.WriteElement(writer, "end", Begin);

			writer.WriteEndElement();

			writer.Flush();

		}
	}
}
