using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Units used by <see cref="Vec2"/>.
	/// </summary>
	public enum Units
	{
		/// <summary>
		/// Indicates the value is a fraction of the image.
		/// </summary>
		Fraction, 
		
		/// <summary>
		///  Indicates the value in pixels.
		/// </summary>
		Pixels, 
		
		/// <summary>
		/// Indicates the indent for the image.
		/// </summary>
		InsetPixels
	}
}
