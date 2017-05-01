using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	//http://code.google.com/apis/kml/documentation/kmlreference.html#networklinkcontrol

	//ToDo: Implement rest of NetworkLinkControl...

	/// <summary>
	/// Controls the behavior of files fetched by a <see cref="NetworkLink" />.
	/// </summary>
	public class NetworkLinkControl
	{
		public NetworkLinkControl()
		{
			MinRefreshPeriod = double.NaN;
		}

		/// <summary>
		/// You can deliver a pop-up message, such as usage guidelines for your 
		/// network link. The message appears when the network link is first loaded 
		/// into Google Earth, or when it is changed in the network link control.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Specified in seconds, <see cref="MinRefreshPeriod"/> is the minimum 
		/// allowed time between fetches of the file. This parameter allows servers 
		/// to throttle fetches of a particular file and to tailor refresh rates to 
		/// the expected rate of change to the data. For example, a user might set 
		/// a link refresh to 5 seconds, but you could set your minimum refresh 
		/// period to 3600 to limit refresh updates to once every hour.
		/// </summary>
		public double MinRefreshPeriod { get; set; }

		/// <summary>
		/// LookAt or Camera
		/// </summary>
		public AbstractView AbstractView { get; set; }

		/// <summary>
		/// Writes this object to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">A <see cref="XmlWriter"/> to write this object.</param>
		public virtual void WriteTo(XmlWriter writer)
		{
			writer.WriteStartElement("NetworkLinkControl");
			if (!double.IsNaN(MinRefreshPeriod))
				writer.WriteElementString("minRefreshPeriod", 
					string.Format(CultureInfo.InvariantCulture, "{0}", MinRefreshPeriod));
			Kml.WriteElement(writer, "message", Message);
			if (AbstractView != null)
				AbstractView.WriteTo(writer);
			writer.WriteEndElement();
			writer.Flush();
		}
	}
}
