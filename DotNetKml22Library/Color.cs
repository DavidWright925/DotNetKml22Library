using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// Represents ABGR Color for kml documents.  Color and opacity 
	/// (alpha) values are expressed in hexadecimal notation. The range of values for 
	/// any one color is 0 to 255 (00 to ff). The order of expression is aabbggrr, 
	/// where aa=alpha (00 to ff); bb=blue (00 to ff); gg=green (00 to ff); rr=red 
	/// (00 to ff). For alpha, 00 is fully transparent and ff is fully opaque. 
	/// For example, if you want to apply a blue color with 50 percent opacity to an 
	/// overlay, you would specify the following: 7fff0000, where alpha=0x7f, blue=0xff, 
	/// green=0x00, and red=0x00. The default is opaque white (ffffffff).
	/// </summary>
	public struct Color : IEquatable<Color>
	{
		/// <summary>
		/// Black.
		/// </summary>
		public static Color Black { get { return new Color(System.Drawing.Color.Black); } }

		/// <summary>
		/// Blue.
		/// </summary>
		public static Color Blue { get { return new Color(System.Drawing.Color.Blue); } }

		/// <summary>
		/// Brown.
		/// </summary>
		public static Color Brown { get { return new Color(System.Drawing.Color.Brown); } }

		/// <summary>
		/// Gold.
		/// </summary>
		public static Color Gold { get { return new Color(System.Drawing.Color.Gold); } }

		/// <summary>
		/// Green.
		/// </summary>
		public static Color Green { get { return new Color(System.Drawing.Color.Green); } }

		/// <summary>
		/// Grey.
		/// </summary>
		public static Color Grey { get { return new Color(System.Drawing.Color.Gray); } }

		/// <summary>
		/// Light Yellow.
		/// </summary>
		public static Color LightYellow { get { return new Color(System.Drawing.Color.LightYellow); } }

		/// <summary>
		/// Magenta.
		/// </summary>
		public static Color Magenta { get { return new Color(System.Drawing.Color.Magenta); } }

		/// <summary>
		/// Maroon.
		/// </summary>
		public static Color Maroon { get { return new Color(System.Drawing.Color.Maroon); } }

		/// <summary>
		/// Navy.
		/// </summary>
		public static Color Navy { get { return new Color(System.Drawing.Color.Navy); } }

		/// <summary>
		/// Pink.
		/// </summary>
		public static Color Pink { get { return new Color(System.Drawing.Color.Pink); } }

		/// <summary>
		/// Purple.
		/// </summary>
		public static Color Purple { get { return new Color(System.Drawing.Color.Purple); } }

		/// <summary>
		/// Red.
		/// </summary>
		public static Color Red { get { return new Color(System.Drawing.Color.Red); } }

		/// <summary>
		/// Turquoise.
		/// </summary>
		public static Color Turquoise { get { return new Color(System.Drawing.Color.Turquoise); } }

		/// <summary>
		/// White.
		/// </summary>
		public static Color White { get { return new Color(System.Drawing.Color.White); } }

		/// <summary>
		/// Yellow.
		/// </summary>
		public static Color Yellow { get { return new Color(System.Drawing.Color.Yellow); } }

		/// <summary>
		/// Compares two <see cref="Color"/>s for equality.
		/// </summary>
		/// <param name="color1">First Color to compare.</param>
		/// <param name="color2">Second Color to compare.</param>
		/// <returns>True if the colors are equal, else false.</returns>
		public static bool operator ==(Color color1, Color color2)
		{
			return color1.Equals(color2);
		}

		/// <summary>
		/// Compares two <see cref="Color"/>s for inequality.
		/// </summary>
		/// <param name="color1">First Color to compare.</param>
		/// <param name="color2">Second Color to compare.</param>
		/// <returns>True if the colors are not equal else false.</returns>
		public static bool operator !=(Color color1, Color color2)
		{
			return !(color1 == color2);
		}

		readonly string _name;
		readonly byte _alpha;
		readonly byte _blue;
		readonly byte _green;
		readonly byte _red;

		/// <summary>
		/// Initialize a new instance of the <see cref="Color"/> struct
		/// with <paramref name="color"/>.
		/// </summary>
		/// <param name="color">The <see cref="System.Drawing.Color"/> to use
		/// for this <see cref="Color"/>.</param>
		public Color(System.Drawing.Color color) : this(color.A, color.B, color.G, color.R)
		{
			_name = color.Name;
		}

		/// <summary>
		/// Initialize a new instance or the <see cref="Color"/> struct
		/// with <paramref name="blue"/>, <paramref name="green"/> and
		/// <paramref name="red"/>.
		/// </summary>
		/// <param name="blue"></param>
		/// <param name="green"></param>
		/// <param name="red"></param>
		public Color(byte blue, byte green, byte red) : this(255, blue, green, red)
		{
		}

		/// <summary>
		/// Initialize a new instance or the <see cref="Color"/> struct
		/// with <paramref name="alpha"/>, <paramref name="blue"/>, <paramref name="green"/> and
		/// <paramref name="red"/>.
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="blue"></param>
		/// <param name="green"></param>
		/// <param name="red"></param>
		public Color(byte alpha, byte blue, byte green, byte red)
		{
			_name = null;

			Check.Argument(alpha >= 0 && alpha <= 255, "alpha must be between 0 and 255");
			_alpha = alpha;

			Check.Argument(blue >= 0 && blue <= 255, "blue must be between 0 and 255");
			_blue = blue;

			Check.Argument(green >= 0 && green <= 255, "green must be between 0 and 255");
			_green = green;

			Check.Argument(red >= 0 && red <= 255, "red must be between 0 and 255");
			_red = red;
		}

		/// <summary>
		/// If a <see cref="System.Drawing.Color"/> is used to create this <see cref="Color"/>,
		/// then the name is returned by this property else <see langword="null"/> is returned.
		/// </summary>
		public string Name { get { return _name; } }

		/// <summary>
		/// Compares this Color against <paramref name="other"/> for equality.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(Color other)
		{
			return ( other._alpha == _alpha &&
				other._blue == _blue &&
				other._green == _green &&
				other._red == _red);
		}

		/// <summary>
		/// Compares this Color against <paramref name="other"/> for equality.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(System.Drawing.Color other)
		{
			return (other.A == _alpha &&
				other.B == _blue &&
				other.G == _green &&
				other.R == _red);
		}

		/// <summary>
		/// Compares this Color against <paramref name="obj"/> for equality.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			return (obj is Color && Equals((Color)obj)) || 
				(obj is System.Drawing.Color && Equals((System.Drawing.Color)obj));
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A hash code.</returns>
		public override int GetHashCode()
		{
			return _alpha.GetHashCode() ^ _blue.GetHashCode() ^ _green.GetHashCode() ^ _red.GetHashCode();
		}

		/// <summary>
		/// Returns <see cref="Color"/> as a string representation.
		/// "aabbggrr", where aa=alpha (00 to ff); bb=blue (00 to ff); gg=green (00 to ff); rr=red 
		/// (00 to ff). For alpha, 00 is fully transparent and ff is fully opaque.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:X2}{1:X2}{2:X2}{3:X2}",
				_alpha, _blue, _green, _red).ToLowerInvariant();
		}
	}
}
