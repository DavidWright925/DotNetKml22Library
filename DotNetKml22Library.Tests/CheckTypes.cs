using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public class CheckTypes : TestBase
	{
		[Test]
		public void AltitudeModeEnum()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "AltitudeModeEnum" };
				kml.Feature = document;

				document.Features.Add(new Placemark()
				{
					Geometry = new Point() { AltitudeMode = AltitudeMode.Absolute },
				});

				document.Features.Add(new Placemark()
				{
					Geometry = new Point() { AltitudeMode = AltitudeMode.ClampToGround },
				});

				document.Features.Add(new Placemark()
				{
					Geometry = new Point() { AltitudeMode = AltitudeMode.RelativeToGround },
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void ColorStyleEnum()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "ColorStyleEnum" };
				kml.Feature = document;

				document.StyleSelectors.Add(new Style()
				{
					Id = "Normal",
					LabelStyle = new LabelStyle()
					{
						ColorMode = ColorMode.Normal,
					}
				});

				document.StyleSelectors.Add(new Style()
				{
					Id = "Random",
					LabelStyle = new LabelStyle()
					{
						ColorMode = ColorMode.Random,
					}
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void DisplayModeEnum()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "DisplayModeEnum" };
				kml.Feature = document;

				document.StyleSelectors.Add(new Style()
				{
					Id = "Default",
					BalloonStyle = new BalloonStyle()
					{
						DisplayMode = DisplayMode.Default,
					}
				});

				document.StyleSelectors.Add(new Style()
				{
					Id = "Hide",
					BalloonStyle = new BalloonStyle()
					{
						DisplayMode = DisplayMode.Hide,
					}
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void ViewRefreshModeEnum()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "ViewRefreshModeEnum" };
				kml.Feature = document;

				document.Features.Add(new NetworkLink()
					{
						Link = new Link()
						{
							ViewRefreshMode = ViewRefreshMode.Never,
						}
					});

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						ViewRefreshMode = ViewRefreshMode.OnRegion,
					}
				});

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						ViewRefreshMode = ViewRefreshMode.OnRequest,
					}
				});

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						ViewRefreshMode = ViewRefreshMode.OnStop,
					}
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void RefreshModeEnum()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "RefreshModeEnum" };
				kml.Feature = document;

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						RefreshMode = RefreshMode.OnChange,
					}
				});

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						RefreshMode = RefreshMode.OnExpire,
					}
				});

				document.Features.Add(new NetworkLink()
				{
					Link = new Link()
					{
						RefreshMode = RefreshMode.OnInterval,
					}
				});

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}

		[Test]
		public void TimeStamp()
		{
			string fileName = GetNewFileName();

			using (Kml kml = new Kml())
			{
				Document document = new Document() { Name = "TimeStamp" };
				kml.Feature = document;

				DateTime dateTime = DateTime.Parse("2012-02-01");

				document.Features.Add(new Placemark() { TimePrimative = new TimeStamp() { When = dateTime, Format = Format.Date } });
				document.Features.Add(new Placemark() { TimePrimative = new TimeStamp() { When = dateTime, Format = Format.DateTime } });
				document.Features.Add(new Placemark() { TimePrimative = new TimeStamp() { When = dateTime, Format = Format.Year } });
				document.Features.Add(new Placemark() { TimePrimative = new TimeStamp() { When = dateTime, Format = Format.YearMonth } });

				kml.WriteTo(fileName);
			}

			CheckFile(GetExpectedResultsFileName(), fileName);
		}
	}


}
