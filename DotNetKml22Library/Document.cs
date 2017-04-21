using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// A <see cref="Document"/> is a container for <see cref="Feature"/>s and 
	/// <see cref="Style"/>s.  This element is required if your KML file uses 
	/// shared styles.
	/// </summary>
	public class Document : Container
	{
        /// <summary>
        /// Initialize a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document()
        {
        }

        /// <summary>
        /// Writes this <see cref="Document"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"> to write this <see cref="Document"/>.</see></param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Document");

			base.WriteTo(writer);

			writer.WriteEndElement();

			writer.Flush();
		}
	}
}
