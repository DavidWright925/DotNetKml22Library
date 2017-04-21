using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Values for ColorMode are <see cref="Normal"/> (no effect) and <see cref="Random"/>.  
	/// A value of Random applies a Random linear scale to the base <see cref="Color"/>.
	/// </summary>
	public enum ColorMode
	{
		/// <summary>
		///  Normal (no effect)
		/// </summary>
		Normal,

		/// <summary>
		/// Random applies a random linear scale to the base <see cref="Color"/>.
		/// </summary>
		Random,
	}
}
