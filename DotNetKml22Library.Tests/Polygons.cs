using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class Polygons : TestBase
	{
		[Test]
		public void Absolute()
		{
			string fileName = GetNewFileName();

			CoordinateCollection coordinates = new CoordinateCollection();

			coordinates.Add("-112.3372510731295,36.14888505105317,1784");
			coordinates.Add("-112.3356128688403,36.14781540589019,1784");
			coordinates.Add("-112.3368169371048,36.14658677734382,1784");
			coordinates.Add("-112.3384408457543,36.14762778914076,1784");
			coordinates.Add("-112.3372510731295,36.14888505105317,1784");

			LinearRing linearRing = new LinearRing()
			{
				Coordinates = coordinates,
			};

			Polygon polygon = new Polygon()
			{
				Tessellate = true,
				AltitudeMode = AltitudeMode.Absolute,
				OuterBoundaryIs = new OuterBoundaryIs(linearRing),
			};

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "KmlFile" };

				kml.Feature = document;

				Style style = new Style() { Id = "transBluePoly" };
				style.LineStyle = new LineStyle() { Width = 1.5 };
				style.PolyStyle = new PolyStyle() { Color = new Color(0x7d, 0xff, 0x00, 0x00) };

				document.StyleSelectors.Add(style);

				Placemark placemark = new Placemark()
				{
					Name = "Absolute",
					StyleUrl = "#transBluePoly",
					Geometry = polygon,
				};
				document.Features.Add(placemark);

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
