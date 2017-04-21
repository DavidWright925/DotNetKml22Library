using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This element draws an image overlay fixed to the screen. Sample 
	/// uses for ScreenOverlays are compasses, logos, and heads-up displays. 
	/// ScreenOverlay sizing is determined by the <see cref="Size"/> element. 
	/// Positioning of the overlay is handled by mapping a point in the 
	/// image specified by <see cref="OverlayXY"/> to a point on the screen 
	/// specified by <see cref="ScreenXY"/>. Then the image is rotated 
	/// by <see cref="Rotation"/> degrees about a point relative to the 
	/// screen specified by <see cref="RotationXY"/>.  The href child of Icon 
	/// specifies the image to be used as the overlay. This file can be 
	/// either on a local file system or on a web server. If this element 
	/// is omitted or contains no <href>, a rectangle is drawn using the 
	/// color and size defined by the screen overlay.
	/// </summary>
	public class ScreenOverlay : Overlay
	{
		/// <summary>
		/// Specifies a point on (or outside of) the overlay image that is mapped to the screen coordinate.
		/// </summary>
		public Vec2 OverlayXY { get; set; }

		/// <summary>
		/// Specifies a point relative to the screen origin that the overlay image is mapped to.
		/// </summary>
		public Vec2 ScreenXY { get; set; }

		/// <summary>
		/// Point relative to the screen about which the screen overlay is rotated.
		/// </summary>
		public Vec2 RotationXY { get; set; }

		/// <summary>
		/// Specifies the size of the image for the screen overlay.
		/// </summary>
		public Vec2 Size { get; set; }

		/// <summary>
		/// Indicates the angle of rotation of the parent object. A value of 
		/// 0 means no rotation. The value is an angle in degrees counterclockwise 
		/// starting from north. Use ±180 to indicate the rotation of the parent 
		/// object from 0. The center of the <see cref="Rotation"/>, if not (.5,.5), 
		/// is specified in <see cref="RotationXY"/>.
		/// </summary>
		public Angle180 Rotation { get; set; }

		/// <summary>
		/// Writes this <see cref="ScreenOverlay"/> to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">The <see cref="XmlWriter"/> to write this object.</param>
		public override void WriteTo(XmlWriter writer)
		{
			WriteStartElement(writer, "ScreenOverlay");

			base.WriteTo(writer);

			writer.WriteStartElement("overlayXY");
			OverlayXY.WriteTo(writer);
			writer.WriteEndElement();

			writer.WriteStartElement("screenXY");
			ScreenXY.WriteTo(writer);
			writer.WriteEndElement();

			writer.WriteStartElement("rotationXY");
			RotationXY.WriteTo(writer);
			writer.WriteEndElement();

			writer.WriteStartElement("size");
			Size.WriteTo(writer);
			writer.WriteEndElement();

			if (Rotation.Value != 0)
				writer.WriteElementString("rotation", Rotation.ToString());

			writer.WriteEndElement();	//ScreenOverlay
			writer.Flush();
		}
	}
}
