using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in 
	/// a KML file. The following diagram shows how some of a Feature's 
	/// elements appear in Google Earth.
	/// </summary>
	public abstract class Feature : Object
	{
		ICollection<StyleSelector> _styleSelector;

        /// <summary>
        /// Initialize a new instance of the <see cref="Feature"/> class.
        /// </summary>
		public Feature()
		{
			Visibility = true;
			SnippetMaxLines = 2;
		}

		/// <summary>
		/// User-defined text displayed in the 3D viewer as the label 
		/// for the object (for example, for a Placemark, Folder, or NetworkLink).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Boolean value. Specifies whether the feature is drawn in the 3D 
		/// viewer when it is initially loaded. In order for a feature to be 
		/// visible, the (visibility) tag of all its ancestors must also be 
		/// set to 1. In the Google Earth List View, each Feature has a checkbox 
		/// that allows the user to control visibility of the Feature.
		/// </summary>
		public bool Visibility { get; set; }

		/// <summary>
		/// Boolean value. Specifies whether a Document or Folder appears 
		/// closed or open when first loaded into the Places panel. 
		/// 0=collapsed (the default), 1=expanded. See also (ListStyle). 
		/// This element applies only to Document, Folder, and NetworkLink.
		/// </summary>
		public bool Open { get; set; }

		/// <summary>
		/// A string value representing an unstructured address written as a standard street, 
		/// city, state address, and/or as a postal code. You can use the <see cref="Address"/> 
		/// tag to specify the location of a point instead of using latitude and longitude 
		/// coordinates. (However, if a <see cref="Point"/> is provided, it takes precedence 
		/// over the  <see cref="Address"/>.) To find out which locales are supported for this 
		/// tag in Google Earth, go to the Google Maps Help.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// A short description of the feature. In Google Earth, this 
		/// description is displayed in the Places panel under the name 
		/// of the feature. If a Snippet is not supplied, the first two 
		/// lines of the <see cref="Description" /> are used. In Google Earth, if a 
		/// Placemark contains both a description and a Snippet, the <see cref="Snippet"/> 
		/// appears beneath the Placemark in the Places panel, and the <see cref="Description"/> 
		/// appears in the Placemark's description balloon. This tag does not support 
		/// HTML markup. <see cref="Snippet"/> has a maxLines attribute, an integer 
		/// that specifies the maximum number of lines to display.
		/// </summary>
		public string Snippet { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Snippet"/> max lines.  Default is 2.
		/// </summary>
		public int SnippetMaxLines { get; set; }

		/// <summary>
		/// User-supplied content that appears in the description balloon.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// A <see cref="Camera"/> or a <see cref="LookAt"/>.
		/// </summary>
		public AbstractView AbstractView { get; set; }

		/// <summary>
		/// Associates this Feature with a period of time (<see cref="TimeSpan"/>) or a 
		/// point in time (<see cref="TimeStamp"/>).
		/// </summary>
		public TimePrimative TimePrimative { get; set; }

		/// <summary>
		/// URL of a <Style> or <StyleMap> defined in a Document. If the style
		/// is in the same file, use a # reference. If the style is defined in 
		/// an external file, use a full URL along with # referencing.
		/// </summary>
		public string StyleUrl { get; set; }

		public ICollection<StyleSelector> StyleSelectors
		{
			get { return _styleSelector ?? (_styleSelector = new List<StyleSelector>()); }
		}

		/// <summary>
		/// Features and geometry associated with a Region are drawn only when the Region is active.
		/// </summary>
		public Region Region { get; set; }

		/// <summary>
		/// Writes this <see cref="LinearRing"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{

			Kml.WriteElement(writer, "name", Name);
			if (Open)
				writer.WriteElementString("open", "1");			//only write if it is not the default.
			if (!Visibility)
				writer.WriteElementString("visibility", "1");
			if (!string.IsNullOrEmpty(Address))
				writer.WriteElementString("address", Address);
			if (!string.IsNullOrEmpty(Snippet))
			{
				writer.WriteStartElement("Snippet");
				writer.WriteAttributeString("maxLines", SnippetMaxLines.ToString(CultureInfo.InvariantCulture));
				writer.WriteString(Snippet);
				writer.WriteEndElement();
			}
			Kml.WriteElement(writer, "description", Description);
			if (AbstractView != null)
				AbstractView.WriteTo(writer);
			if (TimePrimative != null)
				TimePrimative.WriteTo(writer);
			Kml.WriteElement(writer, "styleUrl", StyleUrl);
			if (_styleSelector != null)
			{
				foreach (StyleSelector selector in _styleSelector)
					selector.WriteTo(writer);
			}

			if (Region != null)
				Region.WriteTo(writer);
			writer.Flush();
		}
	}
}
