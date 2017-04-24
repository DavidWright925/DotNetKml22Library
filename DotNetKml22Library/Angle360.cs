using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DotNetKml22Library
{
	/// <summary>
	/// An angle value ≥ −360 and ≤ 360.
	/// </summary>
	public struct Angle360
	{
		const double minimumValue = -360;
		const double maximumValue = 360;
		double _value;

		/// <summary>
		/// Initialize a new instance of the <see cref="Angle360"/> struct with
		/// a value of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to assign.</param>
		public Angle360(double value)
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
