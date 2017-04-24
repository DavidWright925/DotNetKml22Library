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
		readonly List<Feature> _features;

		/// <summary>
		/// Initializes a new instance of the <see cref="Container"/> class.
		/// </summary>
		public Container()
		{
			_features = new List<Feature>();
		}

		/// <summary>
		/// <see cref="Feature"/>s in this container.
		/// </summary>
		public ICollection<Feature> Features
		{
			get { return _features; }
		}

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
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
