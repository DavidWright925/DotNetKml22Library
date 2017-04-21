using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetKml22Library
{
	/// <summary>
	/// Specifies how the link is refreshed when the <see cref="Camera"/> changes.
	/// </summary>
	public enum ViewRefreshMode
	{
		/// <summary>
		/// (default) - Ignore changes in the view. Also ignore <see cref="ViewFormat" /> 
		/// parameters, if any
		/// </summary>
		Never,

		/// <summary>
		/// Refresh the file n seconds after movement stops, where n is specified 
		/// in <see cref="ViewRefreshTime" />.
		/// </summary>
		OnStop,

		/// <summary>
		///  Refresh the file only when the user explicitly requests it. 
		///  (For example, in Google Earth, the user right-clicks and selects 
		///  Refresh in the Context menu.)
		/// </summary>
		OnRequest,

		/// <summary>
		/// Refresh the file when the Region becomes active.
		/// </summary>
		OnRegion,
	}
}
