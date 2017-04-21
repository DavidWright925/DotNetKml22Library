using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// An angle value ≥ −180 and ≤ 180.
	/// </summary>
	public struct Angle180
	{
		const double minimumValue = -180;
		const double maximumValue = 180;
		double _value;

		/// <summary>
		/// Initialize a new instance of the <see cref="Angle180"/> struct with
		/// a value of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to assign.</param>
		public Angle180(double value)
		{
			Check.Argument(value >= minimumValue && value <= maximumValue,
				string.Format(CultureInfo.InvariantCulture, "Value must be in range {0} and {1}.", minimumValue, maximumValue));
			_value = value;
		}

		/// <summary>
		/// Gets or sets <see cref="Value"/>.  If <see cref="Value"/> is outside the valid range,
		/// an <see cref="ArgumentOutOfRangeException"/> is raised.
		/// </summary>
		public double Value
		{
			get { return _value; }
			set
			{
				if (_value != value)
				{
					Check.Argument(value >= minimumValue && value <= maximumValue,
						string.Format(CultureInfo.InvariantCulture, "Value must be in range {0} and {1}.", minimumValue, maximumValue));
					_value = value;
				}
			}
		}

		/// <summary>
		/// Returns <see cref="Value"/> as a <see cref="string"/>.
		/// </summary>
		/// <returns><see cref="Value"/> as a <see cref="string"/>.</returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}", _value);
		}
	}
}
