using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class NetworkLinks : TestBase
	{
		[Test]
		public void FlyToView()
		{
			string expectedResult = GetExpectedResultsFileName();
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document()
				{
					Name = "LookAt - NNW",
					Description = "Above the Google campus looking just west of north",
				};

				NetworkLink networkLink = new NetworkLink()
				{
					FlyToView = true,
					Link = new Link()
					{
						Href = "http://kml-samples.googlecode.com/svn/trunk/morekml/Network_Links/Targets/Network_Links.Targets.With_LookAt.kml",
					},
				};

				document.Features.Add(networkLink);

				kml.Feature = document;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void MultipleInstances()
		{
			string expectedResult = GetExpectedResultsFileName();
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document()
				{
					Description = "Two NetworkLinks to the same KML parses one unique instance per NetworkLink.",
				};

				document.Features.Add(new NetworkLink()
				{
					Name = "Once",
					Link = new Link()
					{
						Href = "http://kml-samples.googlecode.com/svn/trunk/morekml/Network_Links/Targets/Network_Links.Targets.Simple.kml",
					},
				});

				document.Features.Add(new NetworkLink()
				{
					Name = "again",
					Link = new Link()
					{
						Href = "http://kml-samples.googlecode.com/svn/trunk/morekml/Network_Links/Targets/Network_Links.Targets.Simple.kml",
					},
				});

				kml.Feature = document;

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void Simple()
		{
			string expectedResult = GetExpectedResultsFileName();
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				kml.Feature = new NetworkLink()
				{
					Link = new Link()
					{
						Href = "http://kml-samples.googlecode.com/svn/trunk/morekml/Network_Links/Targets/Network_Links.Targets.Simple.kml",
					},
				};

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void TargetsSimple()
		{
			string expectedResult = GetExpectedResultsFileName();
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				kml.Feature = new Placemark()
				{
					Id = "networkLinkPlacemark",
					Name = "Target KML File",
					Geometry = new Point(),
				};

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void TargetsWithLookAt()
		{
			string expectedResult = GetExpectedResultsFileName();
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				kml.NetworkLinkControl = new NetworkLinkControl()
				{
					AbstractView = new LookAt()
					{
						Longitude = new Angle180(-122.0811407993471),
						Latitude = new Angle90(37.41932335967982),
						Altitude = 0,
						Heading = new Angle360(126.1506691541814),
						Tilt = new AnglePos90(65.38634344128558),
						Range = 100.1988425024791,
					},
				};

				kml.Feature = new Placemark()
				{
					Name = "45 tilt, look south",
					Description = "The NetworkLinkControl has a LookAt",
					AbstractView = new LookAt()
					{
						Longitude = new Angle180(-122.0811388429017),
						Latitude = new Angle90(37.4193231646791),
						Heading = new Angle360(180),
						Tilt = new AnglePos90(45),
						Range = 195.4636752213504,
					},
				};

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
