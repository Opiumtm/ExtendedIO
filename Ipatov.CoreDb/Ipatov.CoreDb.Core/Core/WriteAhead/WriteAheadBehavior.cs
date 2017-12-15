using System.Collections.Generic;

namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead logging behavior.
    /// </summary>
    public class WriteAheadBehavior : PagingRangeBehavior, IWriteAheadBehavior
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="underlyingStore">Underlying source.</param>
        /// <param name="log">Write-ahead log. Shared object, don't disposed automatically.</param>
        public WriteAheadBehavior(IPagedRandomAccessStore underlyingStore, IWriteAheadLog log) : base(underlyingStore)
        {
            Log = log;
        }

        /// <summary>
        /// Write-ahead log.
        /// </summary>
        /// <remarks>Shared object, don't disposed automatically.</remarks>
        public IWriteAheadLog Log { get; }

        /// <summary>
        /// Latest log pages.
        /// </summary>
        protected readonly Dictionary<PageAddress, WriteAheadLogData> LatestLogPages = new Dictionary<PageAddress, WriteAheadLogData>();
    }
}