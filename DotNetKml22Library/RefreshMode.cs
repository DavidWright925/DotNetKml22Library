using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies a time-based refresh mode.
	/// </summary>
	public enum RefreshMode
	{
		/// <summary>
		/// Refresh when the file is loaded and whenever the Link parameters change (the default).
		/// </summary>
		OnChange,

		/// <summary>
		/// Refresh every n seconds (specified in <see cref="RefreshInterval" />).
		/// </summary>
		OnInterval,

		/// <summary>
		///  Refresh the file when the expiration time is reached. If a fetched file 
		///  has a NetworkLinkControl, the (expires) time takes precedence over expiration 
		///  times specified in HTTP headers. If no (expires) time is specified, 
		///  the HTTP max-age header is used (if present). If max-age is not 
		///  present, the Expires HTTP header is used (if present).
		/// </summary>
		OnExpire,
	}
}
