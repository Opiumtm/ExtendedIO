using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Paging store range modifier of behavior.
    /// </summary>
    public abstract class PagingRangeBehavior : IPagedRandomAccessStore
    {
        /// <summary>
        /// Underlying store.
        /// </summary>
        protected readonly IPagedRandomAccessStore UnderlyingStore;

        /// <inheritdoc />
        protected PagingRangeBehavior(IPagedRandomAccessStore underlyingStore)
        {
            UnderlyingStore = underlyingStore ?? throw new ArgumentNullException(nameof(underlyingStore));
        }

        /// <summary>
        /// Disposables to dispose.
        /// </summary>
        protected virtual IDisposable[] Disposables => new IDisposable[] { UnderlyingStore };

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            DisposableHelper.DisposeAll(Disposables);
        }

        /// <summary>
        /// Page size in bytes.
        /// </summary>
        public uint PageSize => UnderlyingStore.PageSize;

        /// <summary>
        /// Implementation flags.
        /// </summary>
        public virtual PagingStoreImplementationFlags ImplementationFlags => UnderlyingStore.ImplementationFlags;

        /// <summary>
        /// Total allocated pages.
        /// </summary>
        public virtual ValueTask<uint> GetTotalPages()
        {
            return UnderlyingStore.GetTotalPages();
        }

        /// <summary>
        /// Read pages.
        /// </summary>
        /// <param name="addresses">Page adresses to read.</param>
        /// <returns>Retrieved pages.</returns>
        public virtual Task<DataPage[]> ReadPages(params PageAddress[] addresses)
        {
            return UnderlyingStore.ReadPages(addresses);
        }

        /// <summary>
        /// Write pages.
        /// </summary>
        /// <param name="pages">Pages array.</param>
        /// <returns>Completion task.</returns>
        public virtual Task WritePages(params DataPage[] pages)
        {
            return UnderlyingStore.WritePages(pages);
        }
    }
}