using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetKml22Library
{
	/// <summary>
	/// This is an abstract element and cannot be used directly in a 
	/// KML file. It is the base type for the Style and StyleMap elements. 
	/// The StyleMap element selects a style based on the current mode 
	/// of the Placemark. An element derived from StyleSelector is uniquely 
	/// identified by its id and its url.
	/// </summary>
	public abstract class StyleSelector : Object
	{
	}
}
