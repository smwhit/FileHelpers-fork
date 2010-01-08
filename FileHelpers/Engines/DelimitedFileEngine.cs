

using System;
using System.Diagnostics;
using System.Text;
using FileHelpers.Options;

namespace FileHelpers
{
	/// <summary>
	/// Is a version of the <see cref="FileHelperEngine"/> exclusive for 
	/// delimited records that allow you to change the delimiter an other options at runtime
	/// </summary>
	/// <remarks>
	/// Useful when you need to export or import the same info with 2 or more different delimiters or little different options.
	/// </remarks>
    [DebuggerDisplay("DelimitedFileEngine for type: {RecordType.Name}. ErrorMode: {ErrorManager.ErrorMode.ToString()}. Encoding: {Encoding.EncodingName}")]
    public sealed class DelimitedFileEngine
        : FileHelperEngine
    {

        /// <summary>
        /// Create a version of the <see cref="FileHelperEngine"/> exclusive for 
        /// delimited records that allow you to change the delimiter an other options at runtime
        /// </summary>
        /// <remarks>
        /// Useful when you need to export or import the same info with 2 or more different delimiters.
        /// </remarks>
        /// <param name="recordType">The record mapping class.</param>
        public DelimitedFileEngine(Type recordType)
            : base(recordType)
        {
            if (!mRecordInfo.IsDelimited)
                throw new BadUsageException("The Delimited Engine only accepts record types marked with DelimitedRecordAttribute");
        }

        public DelimitedFileEngine(Type recordType, Encoding encoding)
            : this(recordType)
        {
            Encoding = encoding;
        }
		
		/// <summary>Allow changes in the record layout like delimiters and others common settings.</summary>
		public new DelimitedRecordOptions Options
		{
			get { return (DelimitedRecordOptions) mOptions; }
			
		}
	}


	/// <summary>
	/// Is a version of the <see cref="FileHelperEngine"/> exclusive for 
	/// delimited records that allow you to change the delimiter an other options at runtime
	/// </summary>
	/// <remarks>
	/// Useful when you need to export or import the same info with 2 or more different delimiters or little different options.
	/// </remarks>
    [DebuggerDisplay("DelimitedFileEngine for type: {RecordType.Name}. ErrorMode: {ErrorManager.ErrorMode.ToString()}. Encoding: {Encoding.EncodingName}")]
    public sealed class DelimitedFileEngine<T>
        : FileHelperEngine<T>
        where T: class
	{

	#region "  Constructor  "

		/// <summary>
		/// Create a version of the <see cref="FileHelperEngine"/> exclusive for 
		/// delimited records that allow you to change the delimiter an other options at runtime
		/// </summary>
		/// <remarks>
		/// Useful when you need to export or import the same info with 2 or more different delimiters.
		/// </remarks>
		public DelimitedFileEngine()
			: base()
		{
			if (!mRecordInfo.IsDelimited)
				throw new BadUsageException("The Delimited Engine only accepts Record Types marked with DelimitedRecordAttribute");
		}

        public DelimitedFileEngine(Encoding encoding)
            : this()
        {
            Encoding = encoding;
        }

	#endregion

		
		/// <summary>Allow changes in the record layout like delimiters and others common settings.</summary>
        public new DelimitedRecordOptions Options
		{
            get { return (DelimitedRecordOptions) mOptions; }
			
		}
	}


}
