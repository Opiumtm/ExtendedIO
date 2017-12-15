using System;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead log.
    /// </summary>
    public interface IWriteAheadLog : IWriteAheadLogShutdownRecovery, IDisposable
    {
        /// <summary>
        /// Write-ahead pages.
        /// </summary>
        /// <param name="pages">Pages to log.</param>
        /// <returns>Log entries.</returns>
        Task<WriteAheadLogEntry[]> WriteAhead(DataPage[] pages);

        /// <summary>
        /// Read log entries.
        /// </summary>
        /// <param name="logEntries">Log entries.</param>
        /// <returns></returns>
        Task<WriteAheadLogData[]> ReadPages(PageAddress[] logEntries);

        /// <summary>
        /// Complete page commit.
        /// </summary>
        /// <param name="logEntries">Log entries.</param>
        /// <returns>Completion task.</returns>
        Task CompleteCommit(PageAddress[] logEntries);

        /// <summary>
        /// Pages logged.
        /// </summary>
        event WriteAheadLogged Logged;
    }
}