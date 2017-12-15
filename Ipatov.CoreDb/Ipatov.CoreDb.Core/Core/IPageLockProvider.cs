using System;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Page lock provider.
    /// </summary>
    public interface IPageLockProvider : IDisposable
    {
        /// <summary>
        /// Lock the page or entire paging store.
        /// </summary>
        /// <param name="lockType">Lock type.</param>
        /// <param name="addresses">Address of pages to lock. if null, lock the enitre store.</param>
        /// <param name="timeout">Lock timeout.</param>
        /// <returns>Disposable to unlock locked pages.</returns>
        Task<IDisposable> Lock(PageLockType lockType, PageAddress[] addresses, TimeSpan timeout);
    }
}