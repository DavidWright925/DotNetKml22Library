﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	[TestFixture]
	public sealed class KmlSamples : TestBase
	{
		/// <summary>
		/// Creates KML to match that provided by Google "KML_Samples.kml" provided 
		/// here (<see cref="https://developers.google.com/kml/documentation/kml_tut"/>).
		/// </summary>
		//[Test]
		public void Create()
		{
			Kml kml = new Kml();
			Document document = new Document()
			{
				Name = "KML Samples",
				Open = true,
				Description = "Unleash your creativity with the help of these examples!",
			};
			kml.Feature = document;
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "downArrowIcon",
					IconStyle = new IconStyle()
					{
						Icon = new Icon("http://maps.google.com/mapfiles/kml/pal4/icon28.png")
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "globeIcon",
					IconStyle = new IconStyle()
					{
						Icon = new Icon("http://maps.google.com/mapfiles/kml/pal3/icon19.png")
					},
					LineStyle = new LineStyle()
					{
						Width = 2
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "transPurpleLineGreenPoly",
					LineStyle = new LineStyle()
					{
						Color = new Color(0x7F, 0xFF, 0x00, 0xFF),
						Width = 4
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7F, 0x00, 0xFF, 0x00),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "yellowLineGreenPoly",
					LineStyle = new LineStyle()
					{
						Color = new Color(0x7F, 0x00, 0xFF, 0xFF),
						Width = 4
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7F, 0x00, 0xFF, 0x00),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "thickBlackLine",
					LineStyle = new LineStyle()
					{
						Color = new Color(0x87, 0x00, 0x00, 0x00),
						Width = 10
					},
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "redLineBluePoly",
					LineStyle = new LineStyle()
					{
						Color = new Color(0xFF, 0x00, 0x00, 0xFF),
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0xFF, 0xFF, 0x00, 0x00),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "blueLineRedPoly",
					LineStyle = new LineStyle()
					{
						Color = new Color(0xFF, 0xFF, 0x00, 0x00),
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0xFF, 0x00, 0x00, 0xFF),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "transRedPoly",
					LineStyle = new LineStyle()
					{
						Width = 1.5,
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7d, 0x00, 0x00, 0xFF),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "transBluePoly",
					LineStyle = new LineStyle()
					{
						Width = 1.5,
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7d, 0xFF, 0x00, 0x00),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "transGreenPoly",
					LineStyle = new LineStyle()
					{
						Width = 1.5,
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7d, 0x00, 0xFF, 0x00),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "transYellowPoly",
					LineStyle = new LineStyle()
					{
						Width = 1.5,
					},
					PolyStyle = new PolyStyle()
					{
						Color = new Color(0x7d, 0x00, 0xFF, 0xFF),
					}
				});
			document.StyleSelectors.Add(
				new Style()
				{
					Id = "noDrivingDirections",
					BalloonStyle = new BalloonStyle()
					{
						Text = "\n          <b>$[name]</b>\n          <br /><br />\n          $[description]\n        "
					}
				});

			Folder placemarksFolder = new Folder()
			{
				Name = "Placemarks",
				Description = "These are just some of the different kinds of placemarks with\n        which you can mark your favorite places",
				AbstractView = new LookAt()
				{
					Longitude = new Angle180(-122.0839597145766),
					Latitude = new Angle90(37.42222904525232),
					Altitude = 0,
					Heading = new Angle360(-148.4122922628044),
					Tilt = new AnglePos90(40.5575073395506),
					Range = 500.6566641072245,
				},
			};
			document.Features.Add(placemarksFolder);
			placemarksFolder.Features.Add(new Placemark()
				{
					Name = "Simple placemark",
					Description = "Attached to the ground. Intelligently places itself at the\n          height of the underlying terrain.",
					Geometry = new Point(-122.0822035425683, 37.42228990140251, 0),
				});
			placemarksFolder.Features.Add(new Placemark()
				{
					Name = "Floating placemark",
					Visibility = false,
					Description = "Floats a defined distance above the ground.",
					Geometry = new Point(-122.084075, 37.4220033612141, 50) { AltitudeMode = AltitudeMode.RelativeToGround },
					AbstractView = new LookAt()
								{
									Longitude = new Angle180(-122.0839597145766),
									Latitude = new Angle90(37.42222904525232),
									Altitude = 0,
									Heading = new Angle360(-148.4122922628044),
									Tilt = new AnglePos90(40.5575073395506),
									Range = 500.6566641072245,
								},					
					StyleUrl = string.Format("#{0}", "downArrowIcon"),
				});
			placemarksFolder.Features.Add(new Placemark()
			{
				Name = "Extruded placemark",
				Visibility = false,
				Description = "Tethered to the ground by a customizable\n          &quot;tail&quot;",
				Geometry = new Point(-122.0857667006183, 37.42156927867553, 50)
				{
					Extrude = true,
					AltitudeMode = AltitudeMode.RelativeToGround
				},
				AbstractView = new LookAt()
				{
					Longitude = new Angle180(-122.0845787421525),
					Latitude = new Angle90(37.42215078737763),
					Altitude = 0,
					Heading = new Angle360(-148.4126684946234),
					Tilt = new AnglePos90(40.55750733918048),
					Range = 365.2646606980322,
				},
				StyleUrl = string.Format("#{0}", "globeIcon"),
			});

			Folder stylesAndMarkupFolder = new Folder()
			{
				Name = "Styles and Markup",
				Visibility = false,
				Description = "With KML it is easy to create rich, descriptive markup to\n        annotate and enrich your placemarks",
				AbstractView = new LookAt()
				{
					Longitude = new Angle180(-122.0845787422371),
					Latitude = new Angle90(37.42215078726837),
					Altitude = 0,
					Heading = new Angle360(-148.4126777488172),
					Tilt = new AnglePos90(40.55750733930874),
					Range = 365.2646826292919,
				},
				StyleUrl = "#noDrivingDirections",
			};
			document.Features.Add(stylesAndMarkupFolder);

			string fileName = GetNewFileName();
			kml.WriteTo(fileName);
		}
	}
}
