#undef GENERICS
//#define GENERICS
//#if NET_2_0

#region "  � Copyright 2005-06 to Marcos Meli - http://www.marcosmeli.com.ar" 

// Errors, suggestions, contributions, send a mail to: marcosdotnet[at]yahoo.com.ar.

#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

using FileHelpers.RunTime;

#if ! MINI
using System.Data;
#endif


namespace FileHelpers
{


	/// <summary>A class to read generic CSV files delimited for any char.</summary>
	public sealed class CsvEngine : FileHelperEngine
	{

		/// <summary>Reads a Csv File and return their contents as DataTable (The file must have the field names in the first row)</summary>
		/// <param name="classname">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="filename">The file to read.</param>
		/// <returns>The contents of the file as a DataTable</returns>
		public static DataTable CsvToDataTable(string filename, string classname, char delimiter)
		{
			return CsvToDataTable(filename, classname, delimiter, true);
		}


		/// <summary>Reads a Csv File and return their contents as DataTable</summary>
		/// <param name="classname">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="filename">The file to read.</param>
		/// <param name="hasHeader">Indicates if the file contains a header with the field names.</param>
		/// <returns>The contents of the file as a DataTable</returns>
		public static DataTable CsvToDataTable(string filename, string classname, char delimiter, bool hasHeader)
		{
			CsvOptions options = new CsvOptions(classname, delimiter, filename);
			if (hasHeader == false) options.HeaderLines = 0;
			return CsvToDataTable(filename, options);
		}

		/// <summary>Reads a Csv File and return their contents as DataTable</summary>
		/// <param name="filename">The file to read.</param>
		/// <param name="options">The options used to create the record mapping class.</param>
		/// <returns>The contents of the file as a DataTable</returns>
		public static DataTable CsvToDataTable(string filename, CsvOptions options)
		{
			CsvEngine engine = new CsvEngine(options);
			return engine.ReadFileAsDT(filename);
		}

		//private string mFileName;

		#region "  Constructor  "

		/// <summary>Create a CsvEngine using the specified sample file with their headers.</summary>
		/// <param name="className">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="sampleFile">A sample file with a header that contains the names of the fields.</param>
		public CsvEngine(string className, char delimiter, string sampleFile): this(new CsvOptions(className, delimiter, sampleFile))
		{}

		/// <summary>Create a CsvEngine using the specified number of fields.</summary>
		/// <param name="className">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="numberOfFields">The number of fields of each record</param>
		public CsvEngine(string className, char delimiter, int numberOfFields): this(new CsvOptions(className, delimiter, numberOfFields))
		{}

		/// <summary>Create a CsvEngine using the specified sample file with their headers.</summary>
		/// <param name="options">The options used to create the record mapping class.</param>
		public CsvEngine(CsvOptions options): base(GetMappingClass(options))
		{
		}

		#endregion

		private static Type GetMappingClass(CsvOptions options)
		{
			CsvClassBuilder cb = new CsvClassBuilder(options);
			return cb.CreateRecordClass();
		}
	}

	/// <summary>Class used to pass information to the <see cref="FileHelpers.RunTime.CsvClassBuilder"/> and the <see cref="CsvEngine"/></summary>
	public sealed class CsvOptions
	{

		/// <summary>Create a Csv Wrapper using the specified number of fields.</summary>
		/// <param name="className">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="numberOfFields">The number of fields of each record</param>
		public CsvOptions(string className, char delimiter, int numberOfFields)
		{
			mRecordClassName = className;
			mDelimiter = delimiter;
			mNumberOfFields = numberOfFields;
		}

		/// <summary>Create a Csv Wrapper using the specified sample file with their headers.</summary>
		/// <param name="className">The name of the record class</param>
		/// <param name="delimiter">The delimiter for each field</param>
		/// <param name="sampleFile">A sample file with a header that contains the names of the fields.</param>
		public CsvOptions(string className, char delimiter, string sampleFile)
		{
			mRecordClassName = className;
			mDelimiter = delimiter;
            mSampleFileName = sampleFile;
		}

		private string mSampleFileName = string.Empty;
		private char mDelimiter = ',';
		private char mHeaderDelimiter = char.MinValue;
		private int mHeaderLines = 1;
		private string mRecordClassName = string.Empty;
		private int mNumberOfFields = -1;
		private string mFieldsPrefix = "Field_";

		/// <summary>A sample file from where to read the field names and number.</summary>
		public string SampleFileName
		{
			get { return mSampleFileName; }
			set { mSampleFileName = value; }
		}

		/// <summary>The delimiter for each field.</summary>
		public char Delimiter
		{
			get { return mDelimiter; }
			set { mDelimiter = value; }
		}

		/// <summary>The delimiter for each fiel name in the header.</summary>
		public char HeaderDelimiter
		{
			get { return mHeaderDelimiter; }
			set { mHeaderDelimiter = value; }
		}

		/// <summary>The name used for the record class (a valid .NET class).</summary>
		public string RecordClassName
		{
			get { return mRecordClassName; }
			set { mRecordClassName = value; }
		}

		/// <summary>The prefix used when you only specified the number of fields</summary>
		public string FieldsPrefix
		{
			get { return mFieldsPrefix; }
			set { mFieldsPrefix = value; }
		}

		/// <summary>The number of fields that the file contains.</summary>
		public int NumberOfFields
		{
			get { return mNumberOfFields; }
			set { mNumberOfFields = value; }
		}

		/// <summary>The number of header lines</summary>
		public int HeaderLines
		{
			get { return mHeaderLines; }
			set { mHeaderLines = value; }
		}
	}
}

//#endif