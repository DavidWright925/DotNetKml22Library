using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract base class and cannot be used directly in a KML file. It 
	/// provides the id attribute, which allows unique identification of a KML element, 
	/// and the targetId attribute, which is used to reference objects that have 
	/// already been loaded into Google Earth.
	/// </summary>
	public abstract class Object
	{
		/// <summary>
		/// Always returns White.
		/// </summary>
		internal static Color DefaultColor { get { return new Color(System.Drawing.Color.White); } }

		/// <summary>
		/// Gets or sets the id attribute, which allows unique identification 
		/// of a KML element.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the targetId attribute, which is used to reference objects 
		/// that have already been loaded into Google Earth. The id attribute must 
		/// be assigned if the <see cref="Update"/> mechanism is to be used. 
		/// </summary>
		public string TargetId { get; set; }

		/// <summary>
		/// Writes the start element and adds the id and targetId attributes.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="elementName"></param>
		protected void WriteStartElement(XmlWriter writer, string elementName)
		{
			writer.WriteStartElement(elementName);
			Kml.WriteAttribute(writer, "id", Id);
			Kml.WriteAttribute(writer, "targetId", TargetId);

			writer.Flush();
		}

		/// <summary>
		/// Write this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public abstract void WriteTo(XmlWriter writer);
	}
}
