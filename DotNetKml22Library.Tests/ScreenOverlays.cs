using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class ScreenOverlays : TestBase
	{
		[Test]
		public void AbsoluteTopLeft()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				ScreenOverlay screenOverlay = new ScreenOverlay();
				kml.Feature = screenOverlay;

				screenOverlay.Name = "Absolute Positioning";
				screenOverlay.Icon = new Icon("http://kml-samples.googlecode.com/svn/trunk/resources/top_left.jpg");

				screenOverlay.OverlayXY = new Vec2()
				{
					Y = 1,
				};

				screenOverlay.ScreenXY = new Vec2()
				{
					Y = 1,
				};

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Crosshairs()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				ScreenOverlay screenOverlay = new ScreenOverlay();
				kml.Feature = screenOverlay;

				screenOverlay.Name = "Simple crosshairs";
				screenOverlay.Description = "This screen overlay uses fractional positioning to put the image in the exact center of the screen";
				screenOverlay.Icon = new Icon("http://kml-samples.googlecode.com/svn/trunk/resources/crosshairs.png");

				screenOverlay.OverlayXY = new Vec2() { X = .5, Y = .5, };

				screenOverlay.ScreenXY = new Vec2() { X = .5, Y = 1, };

				screenOverlay.RotationXY = new Vec2() { X = .5, Y = 1, };

				screenOverlay.Size = new Vec2() { XUnits = Units.Pixels, YUnits = Units.Pixels };

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void DynamicRight()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				ScreenOverlay screenOverlay = new ScreenOverlay();
				kml.Feature = screenOverlay;

				screenOverlay.Name = "Dynamic Positioning: Right of screen";
				screenOverlay.Icon = new Icon("http://kml-samples.googlecode.com/svn/trunk/resources/dynamic_right.jpg");

				screenOverlay.OverlayXY = new Vec2() { X = 1, Y = 1, };

				screenOverlay.ScreenXY = new Vec2() { X = 1, Y = 1, };

				screenOverlay.RotationXY = new Vec2() { X = 0, Y = 0, };

				screenOverlay.Size = new Vec2() { X = 0, Y = 1, };

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
