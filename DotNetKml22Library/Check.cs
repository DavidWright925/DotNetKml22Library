using System;
using System.Diagnostics;
using System.IO;

	///<summary>
	/// Each method in this class generates an exception if an assertion is <see langword="false"/>.
	/// They are used to save typing.
	///</summary>
	///<remarks>
	/// This table is a guide to determine which function to use:
	///<list type="table">
	///<listheader>
	///		<term>Function Name</term>
	///		<description>Purpose</description>
	///	</listheader>
	///<item>
	///		<term>ArgumentNotNull</term>
	///		<description>
	///		To ensure an argument is not <see langword="null"/>. If <see langword="null"/>, NullArgumentException is thrown.
	///		</description>
	///	</item>
	///<item>
	///		<term>Argument</term>
	///		<description>
	///		To ensure an argument satisfies a condition. If the assertion is <see langword="false"/>,
	///		ArgumentOutOfRangeException is thrown.
	///		</description>
	///	</item>
	///<item>
	///		<term>Operation</term>
	///		<description>
	///		To check preconditions (except argument preconditions), postconditions, and invariants.
	///		Basically, use this for any assertion except assertions about arguments. If the assertion is 
	///		<see langword="false"/>, InvalidOperationException is thrown.
	///		</description>
	///	</item>
	///</list>
	/// If you wish to perform the assertion only in debug builds then call a method ending in Debug.
	/// <para>This sample shows how to call the Operation method.</para>
	/// <code>
	///public void Test(int x)
	///{
	///    try
	///    {
	///        Check.Operation(x > 1, "x must be > 1");
	///    }
	///    catch (System.Exception ex)
	///    {
	///        Console.WriteLine(ex.ToString());
	///    }
	///}
	/// </code>
	/// </remarks>
	/// 
	sealed class Check
	{
		// No creation
		private Check() { }

		/// <summary>
		/// Throw ArgumentNullException if an argument is <see langword="null"/>.
		/// </summary>
		/// <param name="argument">object that should not be <see langword="null"/></param>
		/// <param name="argumentName">name of the argument</param>
		[DebuggerHidden]
		public static void ArgumentNotNull(object argument, string argumentName)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName);
		}

		/// <summary>
		/// Throw ArgumentNullException if an argument is <see langword="null"/>, in debug builds only.
		/// </summary>
		/// <param name="argument">object that should not be <see langword="null"/></param>
		/// <param name="argumentName">name of the argument</param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void ArgumentNotNullDebug(object argument, string argumentName)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName);
		}

		/// <summary>
		/// Throw ArgumentNullException if an argument is <see langword="null"/>.
		/// </summary>
		/// <param name="argument">object that should not be <see langword="null"/></param>
		/// <param name="argumentName">name of the argument</param>
		/// <param name="message">message included in the ArgumentNullException</param>
		[DebuggerHidden]
		public static void ArgumentNotNull(object argument, string argumentName, string message)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName, message);
		}

		/// <summary>
		/// Throw ArgumentNullException if an argument is <see langword="null"/>, in debug builds only.
		/// </summary>
		/// <param name="argument">object that should not be <see langword="null"/></param>
		/// <param name="argumentName">name of the argument</param>
		/// <param name="message">message included in the ArgumentNullException</param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void ArgumentNotNullDebug(object argument, string argumentName, string message)
		{
			if (argument == null)
				throw new ArgumentNullException(argumentName, message);
		}

		/// <summary>
		/// Throw ArgumentOutOfRangeException if assertion is <see langword="false"/>.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="argumentName">name of the argument</param>
		[DebuggerHidden]
		public static void Argument(bool assertion, string argumentName)
		{
			if (!assertion)
				throw new ArgumentOutOfRangeException(argumentName);
		}

		/// <summary>
		/// Throw ArgumentOutOfRangeException if assertion is <see langword="false"/>, in debug builds only.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="argumentName">name of the argument</param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void ArgumentDebug(bool assertion, string argumentName)
		{
			if (!assertion)
				throw new ArgumentOutOfRangeException(argumentName);
		}

		/// <summary>
		/// Throw ArgumentOutOfRangeException if assertion is <see langword="false"/>.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="argumentName">name of the argument</param>
		/// <param name="message">message included in the ArgumentOutOfRangeException</param>
		[DebuggerHidden]
		public static void Argument(bool assertion, string argumentName, string message)
		{
			if (!assertion)
				throw new ArgumentOutOfRangeException(argumentName, message);
		}

		/// <summary>
		/// Throw ArgumentOutOfRangeException if assertion is <see langword="false"/>, in debug builds only.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="argumentName">name of the argument</param>
		/// <param name="message">message included in the ArgumentOutOfRangeException</param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void ArgumentDebug(bool assertion, string argumentName, string message)
		{
			if (!assertion)
				throw new ArgumentOutOfRangeException(argumentName, message);
		}

		/// <summary>
		/// Throw InvalidOperationException if assertion is <see langword="false"/>.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		[DebuggerHidden]
		public static void Operation(bool assertion)
		{
			if (!assertion)
				throw new InvalidOperationException();
		}

		/// <summary>
		/// Throw InvalidOperationException if assertion is <see langword="false"/>, in debug builds only.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void OperationDebug(bool assertion)
		{
			if (!assertion)
				throw new InvalidOperationException();
		}

		/// <summary>
		/// Throw InvalidOperationException if assertion is <see langword="false"/>.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="message">message included in the InvalidOperationException</param>
		[DebuggerHidden]
		public static void Operation(bool assertion, string message)
		{
			if (!assertion)
				throw new InvalidOperationException(message);
		}

		/// <summary>
		/// Throw InvalidOperationException if assertion is <see langword="false"/>, in debug builds only.
		/// </summary>
		/// <param name="assertion">boolean value that should be <see langword="true"/></param>
		/// <param name="message">message included in the InvalidOperationException</param>
		[Conditional("DEBUG")]
		[DebuggerHidden]
		public static void OperationDebug(bool assertion, string message)
		{
			if (!assertion)
				throw new InvalidOperationException(message);
		}
	}
