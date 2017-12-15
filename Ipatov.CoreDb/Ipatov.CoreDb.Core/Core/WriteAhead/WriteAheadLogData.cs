namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead log data.
    /// </summary>
    public readonly struct WriteAheadLogData
    {
        /// <summary>
        /// Log entry.
        /// </summary>
        public readonly WriteAheadLogEntry LogEntry;

        /// <summary>
        /// Page data.
        /// </summary>
        public readonly byte[] PageData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logEntry">Log entry.</param>
        /// <param name="pageData">Page data.</param>
        public WriteAheadLogData(WriteAheadLogEntry logEntry, byte[] pageData)
        {
            LogEntry = logEntry;
            PageData = pageData;
        }
    }
}