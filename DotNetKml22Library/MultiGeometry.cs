using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// A container for zero or more geometry primitives associated with the same feature.
	/// </summary>
	public class MultiGeometry : Geometry
	{
		List<Geometry> _items = new List<Geometry>();

		/// <summary>
		/// Returns a collection of Geometry items.
		/// </summary>
		public ICollection<Geometry> Items
		{
			get { return _items; }
		}

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "MultiGeometry");

			foreach (Geometry item in _items)
				item.WriteTo(writer);

			writer.WriteEndElement();
		}
	}
}
