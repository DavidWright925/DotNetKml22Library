using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class MiscTests : TestBase
	{
		[Test]
		public void Abolute()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "KmlFile" };
				kml.Feature = document;

				Placemark placemark = new Placemark()
				{
					Id = "1",
					Name = "12-691-H07",
					Description = "Transparent purple line",
					Geometry = new Point(41.077043, -121.518489),
				};

				document.Features.Add(placemark);

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}
}
