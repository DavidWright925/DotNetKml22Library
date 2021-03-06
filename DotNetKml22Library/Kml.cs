﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Ionic.Zip;
using System.Globalization;

//
// http://code.google.com/apis/KML/documentation/kmlreference.html
//
// http://code.google.com/apis/KML/documentation/topicsinkml.html
//

namespace DotNetKml22Library
{
	/// <summary>
	/// The root element of a Kml file. This element is required. It follows 
	/// the xml declaration at the beginning of the file. The hint attribute 
	/// is used as a signal to Google Earth to display the file as celestial data.
	/// <see cref="Kml"/> can contains 0 or 1 <see cref="Feature"/>
	/// and 0 or 1 <see cref="NetworkLinkControl"/>. 
	/// <a href="http://code.google.com/apis/KML/documentation/kmlreference.html">Kml reference</a>
	/// </summary>
	public class Kml : IDisposable
	{
		// ----- static members -----

		static void WriteToZip(Stream stream, string zipEntryFileName, string zipFileName)
		{
			using (ZipFile zipFile = new ZipFile())
			{
				zipFile.AddEntry(zipEntryFileName, stream);
				zipFile.Save(zipFileName);
			}
		}

		static void WriteToZipStream(Stream stream, MemoryStream memoryStream, string zipEntryName)
		{
			using (ZipOutputStream zipOutputStream = new ZipOutputStream(stream))
			{
				Check.Operation(memoryStream.Length <= int.MaxValue);
				zipOutputStream.PutNextEntry(zipEntryName);
				zipOutputStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
			}
		}

		static char[] SpecialXmlCharacters { get { return new char[] { '<', '>', '&', '\'', '"' }; } }

		internal static void WriteElement(XmlWriter writer, string elementName, string elementValue)
		{
			WriteElement(writer, elementName, elementValue, false);
		}

		static string ToAltitudeModeString(AltitudeMode altitudeMode)
		{
			switch (altitudeMode)
			{
				case AltitudeMode.Absolute:
					return "absolute";
				case AltitudeMode.ClampToGround:
					return "clampToGround";
				case AltitudeMode.RelativeToGround:
					return "relativeToGround";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "AltitudeMode not implemented \"{0}\".", altitudeMode));
		}

		/// <summary>
		/// Writes the altitudeMode if it is not equal to the default value.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="altitudeMode"></param>
		internal static void WriteElement(XmlWriter writer, AltitudeMode altitudeMode)
		{
			if (altitudeMode != AltitudeMode.ClampToGround)
				writer.WriteElementString("altitudeMode", ToAltitudeModeString(altitudeMode));
		}

		internal static string ToUnitString(Units unit)
		{
			switch (unit)
			{
				case Units.Fraction:
					return "fraction";
				case Units.InsetPixels:
					return "insetPixels";
				case Units.Pixels:
					return "pixels";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "unit not implemented \"{0}\".", unit));
		}

		internal static void WriteElement(XmlWriter writer, IEnumerable<ICoordinate> coordinates)
		{
			if (coordinates != null)
			{
				writer.WriteStartElement("coordinates");

				int coordinateCount = 0;

				foreach (ICoordinate coordinate in coordinates)
				{
					coordinateCount++;

					if (coordinateCount > 1)
						writer.WriteValue(" ");

					string tupleElement = Coordinate.ToTuple(coordinate);
					writer.WriteValue(tupleElement);
				}

				writer.WriteEndElement();
			}
		}

		/// <summary>
		/// The dateTime is defined according to XML Schema time (see XML Schema Part 2: Datatypes 
		/// Second Edition). The value can be expressed as yyyy-mm-ddThh:mm:sszzzzzz, where T is the 
		/// separator between the date and the time, and the time zone is either Z (for UTC) or zzzzzz, 
		/// which represents ±hh:mm in relation to UTC. Additionally, the value can be expressed as a date 
		/// only. See <see cref="TimeStamp"/> for examples.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="elementName"></param>
		/// <param name="dateTime"></param>
		internal static void WriteElement(XmlWriter writer, string elementName, DateTime dateTime)
		{
			if (dateTime.Ticks != 0)
				writer.WriteElementString(elementName, string.Format(CultureInfo.InvariantCulture, "{0:u}", dateTime.ToUniversalTime()));
		}

		internal static bool ContainsSpecialXmlCharacter(string s)
		{
			return s != null && s.IndexOfAny(SpecialXmlCharacters) >= 0;
		}

		internal static void WriteAttribute(XmlWriter writer, string attributeName, string attributeValue)
		{
			if (!string.IsNullOrEmpty(attributeValue))
				writer.WriteAttributeString(attributeName, attributeValue);
		}

		internal static void WriteElement(XmlWriter writer, 
			string elementName, string elementValue, bool isRequiredElement)
		{
			if (isRequiredElement || !string.IsNullOrEmpty(elementValue))
			{
				writer.WriteStartElement(elementName);

				if (string.IsNullOrEmpty(elementValue))
				{
					writer.WriteValue("");	//always write "" to force the end tag...  
											//e.g. from <this/> to <this></this>.
				}
				else
				{
					if (ContainsSpecialXmlCharacter(elementValue))
						writer.WriteCData(elementValue);
					else
						writer.WriteValue(elementValue);
				}

				writer.WriteEndElement();
				writer.Flush();
			}
		}

		/// <summary>
		/// The settings used when WriteTo(string) and WriteTo(Stream) are called since
		/// they need to create an XmlWriter with settings.
		/// </summary>
		public static XmlWriterSettings XmlWriterSettings = new XmlWriterSettings() { Indent = true };

		// ----- instance members -----

		/// <summary>
		/// Disposes of resources used by <see cref="Kml"/>.
		/// </summary>
		public virtual void Dispose() { }

		/// <summary>
		/// The hint attribute is used as a signal to Google Earth to display the file as celestial data.
		/// </summary>
		public string Hint { get; set; }

		/// <summary>
		/// Controls the behavior of files fetched by a <see cref="NetworkLink" />.
		/// <see cref="Kml"/> can have zero or one <see cref="NetworkLinkControl"/>.
		/// </summary>
		public NetworkLinkControl NetworkLinkControl { get; set; }

		/// <summary>
		/// <see cref="Kml"/> can have zero or one <see cref="Feature"/>.
		/// </summary>
		public Feature Feature { get; set; }

		/// <summary>
		/// Type of stream. <see cref="KML"/> or <see cref="KMZ"/>.
		/// </summary>
		public enum StreamType
		{
			/// <summary>
			/// A KML stream. KML is Keyhole Markup Language.
			/// </summary>
			KML, 

			/// <summary>
			/// A <see cref="KML"/> stream zipped up to be KMZ. A KMZ file consists of a main KML 
			/// file and zero or more supporting files that are packaged using a Zip utility into one 
			/// unit, called an archive. When the KMZ file is unzipped, the main .kml file and its 
			/// supporting files are separated into their original formats and directory structure, 
			/// with their original filenames and extensions. In addition to being an archive format, 
			/// the Zip format is also compressed, so an archive can include only a single large KML 
			/// file. Depending on the content of the KML file, this process typically results in 10:1 
			/// compression. Your 10 Kbyte KML file can be served with a 1 Kbyte KMZ file.
			/// <see cref="https://developers.google.com/kml/documentation/kmzarchives"/>
			/// </summary>
			KMZ,
		}

		/// <summary>
		/// Creates a KML file with the given <paramref name="fileName"/>
		/// </summary>
		/// <param name="fileName"></param>
		public void WriteTo(string fileName)
		{
			WriteTo(fileName, StreamType.KML);
		}

		/// <summary>
		/// Creates a KML or a KMZ file with the given <paramref name="fileName"/>
		/// </summary>
		/// <param name="fileName">The name of the file to create.</param>
		/// <param name="streamType"></param>
		public void WriteTo(string fileName, StreamType streamType)
		{
			switch (streamType)
			{
				case StreamType.KML:
					using (FileStream stream = new FileStream(fileName, FileMode.Create))
					{
						WriteTo(stream, StreamType.KML);
					}
					return;
				case StreamType.KMZ:
					using (MemoryStream memoryStream = new MemoryStream())
					{
						WriteTo(memoryStream, StreamType.KML);
						memoryStream.Seek(0, SeekOrigin.Begin);
						WriteToZip(memoryStream, "doc.kml", fileName);
					}
					return;
			}

			throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, "streamType: {0}", streamType));
		}

		/// <summary>
		/// Writes this <see cref="Kml"/> as KML (pain text) to the specified <paramref name="stream"/>
		/// </summary>
		/// <param name="stream"></param>
		public void WriteTo(Stream stream)
		{
			WriteTo(stream, StreamType.KML);
		}

		/// <summary>
		/// Writes this <see cref="Kml"/> as KML (pain text) or
		/// KMZ (compressed KML) to the specified <paramref name="stream"/>
		/// depending on <paramref name="streamType"/>
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="streamType"></param>
		public void WriteTo(Stream stream, StreamType streamType)
		{
			switch (streamType)
			{
				case StreamType.KML:
					WriteTo(XmlWriter.Create(stream, XmlWriterSettings));
					return;
				case StreamType.KMZ:
					using (MemoryStream memoryStream = new MemoryStream())
					{
						WriteTo(XmlWriter.Create(memoryStream, XmlWriterSettings));
						memoryStream.Seek(0, SeekOrigin.Begin);
						WriteToZipStream(stream, memoryStream, "doc.kml");
					}
					return;
			}

			throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, "streamType: {0}", streamType));

		}

		/// <summary>
		/// Writes this <see cref="Document"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">The <see cref="XmlWriter"> to write this <see cref="Kml"/>.</see></param>
		public void WriteTo(XmlWriter writer)
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
			//NOTE THAT THE NAMESPACE ORDER IN THE GENERATED KML/XML IS NOT RELEVENT... THEY CAN BE IN ANY ORDER!
			//writer.WriteAttributeString("xmlns", "gx", null, "http://www.google.com/KML/ext/2.2");
			//writer.WriteAttributeString("xmlns", "KML", null, "http://www.opengis.net/KML/2.2");
			//writer.WriteAttributeString("xmlns", "atom", null, "http://www.w3.org/2005/Atom");

			if (!string.IsNullOrEmpty(Hint))
				writer.WriteAttributeString("hint", Hint);

			if (NetworkLinkControl != null)
				NetworkLinkControl.WriteTo(writer);

			if (Feature != null)
				Feature.WriteTo(writer);

			writer.WriteEndElement();
			writer.Flush();
		}
	}
}