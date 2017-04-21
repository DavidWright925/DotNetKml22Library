﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	public class OuterBoundaryIs
	{
		readonly LinearRing _linearRing;

		public OuterBoundaryIs(LinearRing linearRing)
		{
			Check.ArgumentNotNull(linearRing, "linearRing");
			_linearRing = linearRing;
		}

		public LinearRing LinearRing { get { return _linearRing; } }

		public virtual void WriteTo(XmlWriter writer)
		{
			writer.WriteStartElement("outerBoundaryIs");

			if (_linearRing != null)
				_linearRing.WriteTo(writer);

			writer.WriteEndElement();
		}
	}
}
