using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using NUnit.Framework;

namespace DotNetKml22Library.Tests
{
	public class TestBase
	{
		static XmlSchemaSet _xmlSchemaSet;
		public static bool ValidateAgainstSchema { get; set; }
		bool _isKmlValid;

		static TestBase()
		{
			ValidateAgainstSchema = true;
		}

		static XmlSchemaSet GetSchemas()
		{
			if (_xmlSchemaSet == null)
			{
				_xmlSchemaSet = new XmlSchemaSet();
				_xmlSchemaSet.Add("http://www.opengis.net/kml/2.2", "../../ogckml22.xsd");
				_xmlSchemaSet.Add("http://www.w3.org/2005/Atom", "../../atom.xsd");
			}
			return _xmlSchemaSet;
		}

		/// <summary>
		/// Checks a file is correct by comparing the expected vs actual file.
		/// </summary>
		/// <param name="expected"></param>
		/// <param name="actual"></param>
		internal void CheckFile(string expected, string actual)
		{
			CheckFile(expected, actual, ValidateAgainstSchema);
		}

		internal void CheckFile(string expected, string actual, bool validateAgainstSchema)
		{
			if (validateAgainstSchema)
				Assert.IsTrue(IsValidKmlFile(actual));

			if (File.Exists(expected))
			{
				FileAssert.AreEqual(expected, actual);
			}
			else
			{
				Assert.Inconclusive("Expected result file missing.");
			}
		}

		/// <summary>
		/// Validates file against the Kml 2.2 Schema.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		bool IsValidKmlFile(string fileName)
		{
			XmlDocument document = new XmlDocument();
			document.Load(fileName);

			ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

			document.Schemas.Add(GetSchemas());

			_isKmlValid = true;
			document.Validate(eventHandler);
			return _isKmlValid;
		}

		void ValidationEventHandler(object sender, ValidationEventArgs e)
		{
			switch (e.Severity)
			{
				case XmlSeverityType.Error:
					_isKmlValid = false;
					Trace.WriteLine("Error: {0}", e.Message);
					return;
				case XmlSeverityType.Warning:
					_isKmlValid = false;
					Trace.WriteLine("Warning {0}", e.Message);
					return;
			}
			throw new InvalidOperationException("Unexpected severity found");
		}

		string GetActualResultsFolder()
		{
			string folderName = "ActualResults";
			Directory.CreateDirectory(folderName);
			return folderName;
		}

		/// <summary>
		/// Returns the name of the expected results based on the name of the calling method.
		/// The file can be used for a file comparison.
		/// </summary>
		/// <returns>A file name of expected results.</returns>
		internal string GetExpectedResultsFileName()
		{
			return Path.Combine("../../ExpectedResults", GetFileNameFromStackTrace());
		}

		internal string GetNewFileName()
		{
			return Path.Combine(GetActualResultsFolder(), GetFileNameFromStackTrace());
		}

		string GetFileNameFromStackTrace()
		{
			return GetFileNameFromStackTrace(3);
		}

		string GetFileNameFromStackTrace(int index)
		{
			StackTrace stackTrace = new StackTrace();
			string methodName = stackTrace.GetFrame(index).GetMethod().Name;
			return string.Format("{0}_{1}.kml", GetType().Name, methodName);
		}
	}
}
