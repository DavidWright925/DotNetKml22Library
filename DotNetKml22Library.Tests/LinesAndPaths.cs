using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class LinesAndPaths : TestBase
	{
		[Test]
		public void Abolute()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "KmlFile" };
				kml.Feature = document;

				Style style = new Style() { Id = "transPurpleLineGreenPoly" };
				style.LineStyle = new LineStyle()
				{
					Color = new Color(0x7f, 0xff, 0x00, 0xff),
					Width = 4,
				};
				style.PolyStyle = new PolyStyle()
				{
					Color = new Color(0x7f, 0x00, 0xff, 0x00),
				};
				kml.Feature.StyleSelectors.Add(style);

				Placemark placemark = new Placemark()
				{
					Name = "Absolute",
					Description = "Transparent purple line",
					StyleUrl = "#transPurpleLineGreenPoly",
				};

				CoordinateCollection coordinates = new CoordinateCollection();
				coordinates.Add(36.09447672602546, -112.265654928602, 2357);
				coordinates.Add(36.09342608838671, -112.2660384528238, 2357);
				coordinates.Add(36.09251058776881, -112.2668139013453, 2357);
				coordinates.Add(36.09189827357996, -112.2677826834445, 2357);
				coordinates.Add(36.0913137941187, -112.2688557510952, 2357);
				coordinates.Add(36.0903677207521, -112.2694810717219, 2357);
				coordinates.Add(36.08932171487285, -112.2695268555611, 2357);
				coordinates.Add(36.08850916060472, -112.2690144567276, 2357);
				coordinates.Add(36.08753813597956, -112.2681528815339, 2357);
				coordinates.Add(36.08682685262568, -112.2670588176031, 2357);
				coordinates.Add(36.08646312301303, -112.2657374587321, 2357);

				LineString lineString = new LineString()
				{
					Tessellate = true,
					AltitudeMode = AltitudeMode.Absolute,
					Coordinates = coordinates
				};
				placemark.Geometry = lineString;

				document.Features.Add(placemark);

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Absolute_Extruded()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "KmlFile" };

				kml.Feature = document;

				Style style = new Style() { Id = "yellowLineGreenPoly" };
				style.LineStyle = new LineStyle() { Width = 4, Color = new Color(0x7f, 0x00, 0xff, 0xff) };
				style.PolyStyle = new PolyStyle() { Color = new Color(0x7f, 0x00, 0xff, 0x00) };

				document.StyleSelectors.Add(style);

				Placemark placemark = new Placemark()
				{
					Name = "Absolute Extruded",
					Description = "Transparent green wall with yellow outlines",
					StyleUrl = "#yellowLineGreenPoly",
				};
				document.Features.Add(placemark);

				LineString lineString = new LineString()
				{
					Extrude = true,
					Tessellate = true,
					AltitudeMode = AltitudeMode.Absolute,
				};

				CoordinateCollection coordinates = new CoordinateCollection();

				coordinates.Add("-112.2550785337791,36.07954952145647,2357");
				coordinates.Add("-112.2549277039738,36.08117083492122,2357");
				coordinates.Add("-112.2552505069063,36.08260761307279,2357");
				coordinates.Add("-112.2564540158376,36.08395660588506,2357");
				coordinates.Add("-112.2580238976449,36.08511401044813,2357");
				coordinates.Add("-112.2595218489022,36.08584355239394,2357");
				coordinates.Add("-112.2608216347552,36.08612634548589,2357");
				coordinates.Add("-112.262073428656,36.08626019085147,2357");
				coordinates.Add("-112.2633204928495,36.08621519860091,2357");
				coordinates.Add("-112.2644963846444,36.08627897945274,2357");
				coordinates.Add("-112.2656969554589,36.08649599090644,2357");

				lineString.Coordinates = coordinates;

				placemark.Geometry = lineString;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Linear_Ring()
		{
			string fileName = GetNewFileName();

			CoordinateCollection coordinates = new CoordinateCollection();

			coordinates.Add("-112.0814237830345,36.10677870477137,0");
			coordinates.Add("-112.0870267752693,36.0905099328766,0");
			coordinates.Add("-112.0820267752693,36.0905099328766,0");
			coordinates.Add("-112.0814237830345,36.10677870477137,0");

			LinearRing linearRing = new LinearRing()
			{
				Tessellate = true,
				Coordinates = coordinates,
			};

			using (Kml kml = new Kml())
			{
				Placemark placemark = new Placemark()
				{
					Name = "Tessellated",
					Description = "If the <tessellate> tag has a value of 1, the line will contour to the underlying terrain",
					Geometry = linearRing,
				};

				kml.Feature = placemark;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
