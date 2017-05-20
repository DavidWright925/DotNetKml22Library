using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	public class InnerBoundaryIs
	{
		readonly LinearRing _linearRing;

		public InnerBoundaryIs(LinearRing linearRing)
		{
			Check.ArgumentNotNull(linearRing, "linearRing");
			_linearRing = linearRing;
		}

		public LinearRing LinearRing { get { return _linearRing; } }

		/// <summary>
		/// Writes this <see cref="LinearRing"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public virtual void WriteTo(XmlWriter writer)
		{
			writer.WriteStartElement("innerBoundaryIs");
			if (_linearRing != null)
				_linearRing.WriteTo(writer);
			writer.WriteEndElement();
		}
	}
}
