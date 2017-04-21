using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class Balloons : TestBase
	{
		[Test]
		public void DisplayModes()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document();
				kml.Feature = document;

				Placemark placemark1 = new Placemark()
				{
					Name = "displayMode=default",
					Description = "Hello, World!",
					Geometry = new Point(-122.001, 37.000),
				};
				Style style1 = new Style()
				{
					BalloonStyle = new BalloonStyle() { DisplayMode = DisplayMode.Default },
				};
				placemark1.StyleSelectors.Add(style1);
				document.Features.Add(placemark1);

				Placemark placemark2 = new Placemark()
				{
					Name = "displayMode=hide",
					Description = "Hello, World!",
					Geometry = new Point(-122.001, 37.001),
				};
				Style style2 = new Style()
				{
					BalloonStyle = new BalloonStyle() { DisplayMode = DisplayMode.Hide },
				};
				placemark2.StyleSelectors.Add(style2);

				document.Features.Add(placemark2);

				kml.WriteTo(fileName);
			}
			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
