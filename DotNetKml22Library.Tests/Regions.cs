using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	public class Regions : TestBase
	{
		public void PolygonFade()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Placemark placemark = new Placemark() { Name = "Polygon with fade in/out", };
				kml.Feature = placemark;

				placemark.StyleSelectors.Add(new Style() { PolyStyle = new PolyStyle() { Color = new Color(0xff, 0xff, 0x80, 0x90) } });

				//Polygon polygon = new Polygon();
				//placemark.Geometry = polygon;

				Region region = new Region();
				placemark.Region = region;
				region.LatLonAltBox.North = new Angle90(-34.85);
				region.LatLonAltBox.South = new Angle90(-34.97);
				region.LatLonAltBox.East = new Angle180(138.64);
				region.LatLonAltBox.West = new Angle180(138.56);

				Lod lod = new Lod();
				region.Lod = lod;

				lod.MinLodPixels = 128;
				lod.MaxLodPixels = 1024;
				lod.MinFadeExtent = 64;
				lod.MaxFadeExtent = 256;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
