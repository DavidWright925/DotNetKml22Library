using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	//https://developers.google.com/kml/documentation/kmlreference#icon
	/// <summary>
	/// Defines an image associated with an Icon style or overlay. The required 
	/// &lt;href&gt; child element defines the location of the image to be used as the overlay 
	/// or as the icon for the placemark. This location can either be on a local file system or a 
	/// remote web server. The &lt;gx:x>, &lt;gx:y&gt;, &lt;gx:w&gt;, and &lt;gx:h&gt; elements are used to select one 
	/// icon from an image that contains multiple icons (often referred to as an icon palette.
	/// </summary>
	public class Icon : Object
	{
		readonly string _href;

		/// <summary>
		/// Initializes a new instance of the <see cref="Icon"/> class with <paramref name="href"/>.
		/// </summary>
		/// <param name="href"></param>
		public Icon(string href)
		{
			if (string.IsNullOrWhiteSpace(href))
				throw new ArgumentException("href is null or white space", "href");
			_href = href;
		}

		/// <summary>
		/// Gets the icon href.
		/// </summary>
		public string Href
		{
			get { return _href; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Icon");
			writer.WriteElementString("href", _href);
			writer.WriteEndElement();
			writer.Flush();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _href;
		}
	}
}
