using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in a KML file. This 
	/// element is extended by the <see cref="TimeSpan"/> and <see cref="TimeStamp"/> elements.
	/// </summary>
	public abstract class TimePrimative : Object
	{
	}
}
