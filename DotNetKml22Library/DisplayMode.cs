using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// See <see cref="BalloonStyle.DisplayMode"/>.
	/// </summary>
	public enum DisplayMode
	{
		/// <summary>
		/// If displayMode is Default, Google Earth uses the information supplied in text to create a balloon .
		/// </summary>
		Default,

		/// <summary>
		/// If displayMode is Hide, Google Earth does not display the balloon.
		/// </summary>
		Hide,
	}
}
