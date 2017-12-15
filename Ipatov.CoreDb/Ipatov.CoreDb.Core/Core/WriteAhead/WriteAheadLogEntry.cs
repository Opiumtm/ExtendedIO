namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Entry of write-ahead log.
    /// </summary>
    public readonly struct WriteAheadLogEntry
    {
        /// <summary>
        /// Original page address.
        /// </summary>
        public readonly PageAddress OriginalPageAddress;

        /// <summary>
        /// Log page address.
        /// </summary>
        public readonly PageAddress LogPageAddress;

        /// <summary>
        /// Log entry countery.
        /// </summary>
        public readonly ulong Counter;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalPageAddress">Original page address.</param>
        /// <param name="logPageAddress">Log page address.</param>
        /// <param name="counter">Log entry counter.</param>
        public WriteAheadLogEntry(PageAddress originalPageAddress, PageAddress logPageAddress, ulong counter)
        {
            OriginalPageAddress = originalPageAddress;
            LogPageAddress = logPageAddress;
            Counter = counter;
        }
    }
}