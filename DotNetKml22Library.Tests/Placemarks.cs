using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class Placemarks : TestBase
	{
		[Test]
		public void EmptyDocument()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test, Description("Example used on wikipedia")]
		public void NewYorkCity()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document();
				kml.Feature = document;
				Placemark placemark = new Placemark();
				placemark.Name = "New York city";
				placemark.Description = "New York City";
				placemark.Geometry = new Point(-74.006393, 40.714172, 0);
				document.Features.Add(placemark);
				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void DescriptiveHtml()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Placemark feature = new Placemark()
				{
					Name = "Descriptive HTML",
					Description = "<h1>HTML IS HERE</h1><br/>ok?",
					Geometry = new Point(-122.0822035425683, 37.42228990140251, 0),
				};
				kml.Feature = feature;
				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Extruded()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{

				LookAt lookAt = new LookAt()
				{
					Longitude = new Angle180(-122.0857667006183),
					Latitude = new Angle90(37.42156927867553),
					Altitude = 50,
					Heading = new Angle360(),
					Tilt = new AnglePos90(45),
					Range = 50,
					AltitudeMode = AltitudeMode.RelativeToGround,
				};

				Style style = new Style();
				style.IconStyle = new IconStyle()
				{
					Icon = new Icon("http://maps.google.com/mapfiles/kml/pal3/icon19.png")
				};
				style.LineStyle = new LineStyle()
				{
					Width = 2,
				};

				Placemark feature = new Placemark()
				{
					Name = "Extruded placemark",
					Description = "Tethered to the ground by a customizable \"tail\"",
					Geometry = new Point(-122.0857667006183, 37.42156927867553, 50) 
						{ AltitudeMode = AltitudeMode.RelativeToGround, Extrude = true },
					AbstractView = lookAt,
				};
				feature.StyleSelectors.Add(style);

				kml.Feature = feature;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Floating()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{

				LookAt lookAt = new LookAt()
				{
					Longitude = new Angle180(-122.084075),
					Latitude = new Angle90(37.4220033612141),
					Altitude = 45,
					Heading = new Angle360(),
					Tilt = new AnglePos90(90),
					Range = 100,
					AltitudeMode = AltitudeMode.RelativeToGround,
				};

				string styleId = "downArrowIcon";
				Style style = new Style();
				style.Id = styleId;
				style.IconStyle = new IconStyle();
				style.IconStyle.Icon = new Icon("http://maps.google.com/mapfiles/kml/pal4/icon28.png");

				Placemark feature = new Placemark()
				{
					Name = "Floating placemark",
					Description = "Floats a defined distance above the ground.",
					Geometry = new Point(-122.084075, 37.4220033612141, 50) { AltitudeMode = AltitudeMode.RelativeToGround },
					AbstractView = lookAt,
					StyleUrl = string.Format("#{0}", styleId),
				};
				feature.StyleSelectors.Add(style);

				kml.Feature = feature;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Simple()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Placemark feature = new Placemark()
				{
					Name = "Simple placemark",
					Description = "Attached to the ground. Intelligently places itself at the height of the underlying terrain.",
					Geometry = new Point(-122.0822035425683, 37.42228990140251, 0),
				};
				kml.Feature = feature;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Address()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Placemark feature = new Placemark()
				{
					Name = "San Ramon",
					Address = "San Ramon, CA 94583",
				};
				kml.Feature = feature;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Snippet()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document();
				kml.Feature = document;

				document.Features.Add(new Placemark()
				{
					Name = "Snippet 1",
					Description = "This is a description.  This is a description.  This is a description.  This is a description.  ",
				});

				document.Features.Add(new Placemark()
				{
					Name = "Snippet 2",
					Description = "This is a description.  This is a description.  This is a description.  This is a description.  ",
					Snippet = "This is a snippet, This is a snippet, This is a snippet, This is a snippet",
				});

				document.Features.Add(new Placemark()
				{
					Name = "Snippet 3",
					Description = "This is a description.  This is a description.  This is a description.  This is a description.  ",
					Snippet = "This is a snippet, This is a snippet, This is a snippet, This is a snippet",
					SnippetMaxLines = 1,
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
