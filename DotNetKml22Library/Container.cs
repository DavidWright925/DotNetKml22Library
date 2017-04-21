using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in a KML file. 
	/// A Container element holds one or more Features and allows the creation 
	/// of nested hierarchies.
	/// </summary>
	public abstract class Container : Feature
	{
		List<Feature> _features = new List<Feature>();

		public ICollection<Feature> Features
		{
			get { return _features; }
		}

		public override void WriteTo(XmlWriter writer)
		{
			base.WriteTo(writer);

			if (_features != null)
				foreach (Feature feature in _features)
					feature.WriteTo(writer);

			writer.Flush();
		}
	}
}
