using System;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Interface to the underlying paged random access store.
    /// </summary>
    public interface IPagedRandomAccessStore : IDisposable
    {
        /// <summary>
        /// Page size in bytes.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Read pages.
        /// </summary>
        /// <param name="addresses">Page adresses to read.</param>
        /// <returns>Retrieved pages.</returns>
        Task<DataPage[]> ReadPages(params PageAddress[] addresses);

        /// <summary>
        /// Write pages.
        /// </summary>
        /// <param name="pages">Pages array.</param>
        /// <returns>Completion task.</returns>
        Task WritePages(params DataPage[] pages);

        /// <summary>
        /// Allocate new pages.
        /// </summary>
        /// <param name="count">Count of pages to allocate.</param>
        /// <returns>Reserved page addresses.</returns>
        Task<PageAddress[]> AllocatePages(int count);

        /// <summary>
        /// Deallocate pages.
        /// </summary>
        /// <param name="addresses">Addresses of pages to deallocate.</param>
        /// <returns>Completion task.</returns>
        Task DeallocatePages(params PageAddress[] addresses);
    }
}