using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Support of page locking.
    /// </summary>
    public class PageLockingBehavior : PagingRangeBehavior
    {
        /// <summary>
        /// Locking provider.
        /// </summary>
        protected readonly IPageLockProvider LockProvider;

        /// <summary>
        /// Timeout of operations.
        /// </summary>
        protected readonly TimeSpan Timeout;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="underlyingStore">Underlying store.</param>
        /// <param name="lockProvider">Lock provider.</param>
        /// <param name="timeout">Timeout of locks.</param>
        public PageLockingBehavior(IPagedRandomAccessStore underlyingStore, IPageLockProvider lockProvider, TimeSpan timeout) : base(underlyingStore)
        {
            LockProvider = lockProvider ?? throw new ArgumentNullException(nameof(lockProvider));
            Timeout = timeout;
        }

        /// <summary>
        /// Disposables to dispose.
        /// </summary>
        protected override IDisposable[] Disposables => new IDisposable[] { UnderlyingStore, LockProvider };

        /// <summary>
        /// Total allocated pages.
        /// </summary>
        public override async ValueTask<uint> GetTotalPages()
        {
            using (await LockProvider.Lock(PageLockType.Read, null, Timeout))
            {
                return await base.GetTotalPages();
            }
        }

        /// <summary>
        /// Read pages.
        /// </summary>
        /// <param name="addresses">Page adresses to read.</param>
        /// <returns>Retrieved pages.</returns>
        public override async Task<DataPage[]> ReadPages(params PageAddress[] addresses)
        {
            if (addresses == null) throw new ArgumentNullException(nameof(addresses));
            using (await LockProvider.Lock(PageLockType.Read, addresses, Timeout))
            {
                return await base.ReadPages(addresses);
            }
        }

        /// <summary>
        /// Write pages.
        /// </summary>
        /// <param name="pages">Pages array.</param>
        /// <returns>Completion task.</returns>
        public override async Task WritePages(params DataPage[] pages)
        {
            if (pages == null) throw new ArgumentNullException(nameof(pages));
            using (await LockProvider.Lock(PageLockType.Write, pages.Select(p => p.Address).Distinct().ToArray(), Timeout))
            {
                await base.WritePages(pages);
            }
        }

        /// <summary>
        /// Allocate new pages.
        /// </summary>
        /// <param name="count">Count of pages to allocate.</param>
        /// <returns>New page addresses.</returns>
        public override async Task<PageAddress[]> AllocatePages(uint count)
        {
            using (await LockProvider.Lock(PageLockType.Write, null, Timeout))
            {
                return await base.AllocatePages(count);
            }
        }

        /// <summary>
        /// Trim size. Do noting if size is already too small.
        /// </summary>
        /// <param name="newSize">New size.</param>
        /// <returns>Completion task.</returns>
        public override async Task TrimSize(uint newSize)
        {
            using (await LockProvider.Lock(PageLockType.Write, null, Timeout))
            {
                await base.AllocatePages(newSize);
            }
        }
    }
}