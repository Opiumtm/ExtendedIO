using System.Collections.Generic;

namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead log shutdown recovery interface.
    /// </summary>
    public interface IWriteAheadLogShutdownRecovery
    {
        /// <summary>
        /// Enumerate pages to commit synchronously.
        /// </summary>
        /// <returns>Data pages to commit.</returns>
        IEnumerable<WriteAheadLogData[]> EnumPagesToCommitSync();

        /// <summary>
        /// Complete full synchronous commit.
        /// </summary>
        void CompleteSyncCommit();
    }
}