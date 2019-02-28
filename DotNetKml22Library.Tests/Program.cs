using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
            //Creates a simple placemark.kml file
			using (Kml kml = new Kml())
			{
				Placemark feature = new Placemark()
				{
					Name = "Simple placemark",
					Description = "Attached to the ground. Intelligently places itself at the height of the underlying terrain.",
					Geometry = new Point(-122.0822035425683, 37.42228990140251, 0),
				};
				kml.Feature = feature;
				kml.WriteTo("simple.kml");
			}
		}
	}
}
