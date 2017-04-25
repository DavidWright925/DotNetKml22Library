using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace DotNetKml22Library.Tests
{
	[TestFixture, Description("Some basic tests to make sure kml can be generated without errors.")]
	public class Generation
	{
		[Test, Description("Create a basic Kml file using WriteTo(fileName).")]
		public void CreateKmlFile()
		{
			string fileName = "_CreateKmlFile.kml";
			using (Kml kml = new Kml())
			{
				kml.Feature = new Placemark() { Name = fileName, Geometry = new Point() };
				kml.WriteTo(fileName);
			}
		}

		[Test, Description("Create a basic Kmz file.")]
		public void CreateKmzFile()
		{
			string fileName = "_CreateKmzFile.kmz";
			using (Kml kml = new Kml())
			{
				kml.Feature = new Placemark() { Name = fileName, Geometry = new Point() };
				kml.WriteTo(fileName, Kml.StreamType.KMZ);
			}
		}

		[Test, Description("Create a basic Kml writing to a stream file using WriteTo(stream).")]
		public void WriteKmlToAKmlStream()
		{
			string fileName = "_WriteKmlToAKmlStream.kml";
			using (Kml kml = new Kml())
			{
				kml.Feature = new Placemark() { Name = fileName, Geometry = new Point() };
				using (Stream stream = new FileStream(fileName, FileMode.Create))
				{
					kml.WriteTo(stream);
				}
			}
		}

		[Test, Description("Create a basic Kmz writing to a stream file using WriteTo(stream).")]
		public void WriteKmlToAKmzStream()
		{
			string fileName = "_WriteKmlToAKmzStream.kmz";
			using (Kml kml = new Kml())
			{
				kml.Feature = new Placemark() { Name = fileName, Geometry = new Point() };
				using (Stream stream = new FileStream(fileName, FileMode.Create))
				{
					kml.WriteTo(stream, Kml.StreamType.KMZ);
				}
			}
		}
	}
}
