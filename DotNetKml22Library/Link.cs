using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// <see cref="Link" /> specifies the location of any of the following:
	/// <para>
	/// KML files fetched by network links
	/// </para>
	/// <para>
	/// Image files used in any Overlay (the <see cref="Icon" /> element 
	/// specifies the image in an Overlay; <see cref="Icon" /> has the same 
	/// fields as <see cref="Link" />)
	/// </para>
	/// <para>
	/// Model files used in the <see cref="Model" /> element
	/// </para>
	/// <para>
	/// The file is conditionally loaded and refreshed, depending on the refresh parameters supplied here.
	/// </para>
	/// </summary>
	public class Link : Object
	{
		// ----- static members -----

		static string ToViewRefreshModeString(ViewRefreshMode viewRefreshMode)
		{
			switch (viewRefreshMode)
			{
				case ViewRefreshMode.Never:
					return "never";
				case ViewRefreshMode.OnRegion:
					return "onRegion";
				case ViewRefreshMode.OnRequest:
					return "onRequest";
				case ViewRefreshMode.OnStop:
					return "onStop";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "ViewRefreshMode not implemented \"{0}\".", viewRefreshMode));
		}

		static string ToRefreshModeString(RefreshMode refreshMode)
		{
			switch (refreshMode)
			{
				case RefreshMode.OnChange:
					return "onChange";
				case RefreshMode.OnExpire:
					return "onExpire";
				case RefreshMode.OnInterval:
					return "onInterval";
			}

			throw new NotImplementedException(
				string.Format(CultureInfo.InvariantCulture, "RefreshMode not implemented \"{0}\".", refreshMode));
		}

		// ----- instance members -----

		/// <summary>
		/// A URL (either an HTTP address or a local file specification). When the 
		/// parent of <see cref="Link"/> is a NetworkLink, <see cref="Href"/> is 
		/// a KML file. When the parent of <see cref="Link"/> is a Model, 
		/// <see cref="Href"/> is a COLLADA file. When the parent of 
		/// <see cref="Icon"/> (same fields as <see cref="Link"/>) is an Overlay, 
		/// <see cref="Href"/> is an image. Relative URLs can be used in this tag 
		/// and are evaluated relative to the enclosing KML file. See KMZ Files for 
		/// details on constructing relative references in KML and KMZ files.
		/// </summary>
		public string Href { get; set; }

		/// <summary>
		/// Specifies a time-based refresh mode.
		/// </summary>
		public RefreshMode RefreshMode { get; set; }

		/// <summary>
		/// Indicates to refresh the file every n seconds.
		/// </summary>
		public int RefreshInterval { get; set; }

		/// <summary>
		/// Specifies how the link is refreshed when the "camera" changes.
		/// </summary>
		public ViewRefreshMode ViewRefreshMode { get; set; }

		/// <summary>
		/// After camera movement stops, specifies the number of seconds to wait before refreshing the view.
		/// </summary>
		public int ViewRefreshTime { get; set; }

		/// <summary>
		/// Writes this <see cref="LinearRing"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "Link");
			Kml.WriteElement(writer, "href", Href);
			if (RefreshMode != RefreshMode.OnChange)
				writer.WriteElementString("refreshMode", ToRefreshModeString(RefreshMode));
			if (RefreshInterval > 0)
				writer.WriteElementString("refreshInterval", RefreshInterval.ToString(CultureInfo.InvariantCulture));
			if (ViewRefreshMode != ViewRefreshMode.Never)
				writer.WriteElementString("viewRefreshMode", ToViewRefreshModeString(ViewRefreshMode));
			if (ViewRefreshTime > 0)
				writer.WriteElementString("viewRefreshTime", ViewRefreshTime.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
