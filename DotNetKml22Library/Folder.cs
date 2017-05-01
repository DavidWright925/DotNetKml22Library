using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// A Folder is used to arrange other Features hierarchically 
	/// (Folders, <see cref="Placemark"/>s, NetworkLinks, or Overlays). A Feature 
	/// is visible only if it and all its ancestors are visible.
	/// </summary>
	public class Folder : Feature
	{
		List<Feature> _features = new List<Feature>();

		public ICollection<Feature> Features
		{
			get { return _features; }
		}

		/// <summary>
		/// Writes this <see cref="LinearRing"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Folder");
			base.WriteTo(writer);
			if (_features != null)
				foreach (Feature feature in _features)
					feature.WriteTo(writer);
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
