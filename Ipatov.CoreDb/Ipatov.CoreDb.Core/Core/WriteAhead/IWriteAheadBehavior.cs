namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead log.
    /// </summary>
    public interface IWriteAheadBehavior : IPagedRandomAccessStore
    {
        /// <summary>
        /// Write-ahead log.
        /// </summary>
        /// <remarks>Shared object, don't disposed automatically.</remarks>
        IWriteAheadLog Log { get; }
    }
}