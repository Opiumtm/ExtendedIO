namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Page locking behavior.
    /// </summary>
    public interface IPageLockingBehavior : IPagedRandomAccessStore
    {
        /// <summary>
        /// Locking provider.
        /// </summary>
        IPageLockProvider LockProvider { get; }
    }
}