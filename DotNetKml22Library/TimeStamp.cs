using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Represents a single moment in time. This is a simple element and contains no children. 
	/// Its value is a dateTime, specified in XML time (see XML Schema Part 2: Datatypes Second Edition). 
	/// The precision of the TimeStamp is dictated by the dateTime value in the <see cref="When"/> element.
	/// </summary>
	public class TimeStamp : TimePrimative
	{
		static string ToKmlDateTime(DateTime dateTime)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-ddTHH:mm:ssZ}", dateTime.ToUniversalTime());
		}

		static string ToDateTimeString(DateTime when, Format format)
		{
			switch (format)
			{
				case Format.DateTime:
					return ToKmlDateTime(when);
				case Format.Date:
					return string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd}", when.ToUniversalTime());
				case Format.Year:
					return string.Format(CultureInfo.InvariantCulture, "{0:yyyy}", when.ToUniversalTime());
				case Format.YearMonth:
					return string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM}", when.ToUniversalTime());
			}

			throw new NotImplementedException();
		}

		public TimeStamp()
		{
			When = DateTime.Now;
		}

		/// <summary>
		/// Specifies a single moment in time.
		/// </summary>
		public DateTime When { get; set; }

		/// <summary>
		/// Specifies a single moment in time. The value is a dateTime.
		/// </summary>
		public Format Format { get; set; }

		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "TimeStamp");

			if (When.Ticks != 0)
				writer.WriteElementString("when", ToDateTimeString(When, Format));

			writer.WriteEndElement();

			writer.Flush();
		}
	}

	public enum Format
	{
		/// <summary>
		/// YYYY-MM-DDThh:mm:ssZ
		/// </summary>
		DateTime,

		/// <summary>
		/// YYYY
		/// </summary>
		Year,

		/// <summary>
		/// YYYY-MM
		/// </summary>
		YearMonth,

		/// <summary>
		/// YYYY-MM-DD
		/// </summary>
		Date,
	}
}
