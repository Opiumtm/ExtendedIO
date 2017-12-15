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
        uint PageSize { get; }

        /// <summary>
        /// Implementation flags.
        /// </summary>
        PagingStoreImplementationFlags ImplementationFlags { get; }

        /// <summary>
        /// Total allocated pages.
        /// </summary>
        ValueTask<uint> GetTotalPages();

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
        /// <returns>New page addresses.</returns>
        Task<PageAddress[]> AllocatePages(uint count);

        /// <summary>
        /// Trim size. Do noting if size is already too small.
        /// </summary>
        /// <param name="newSize">New size.</param>
        /// <returns>Completion task.</returns>
        Task TrimSize(uint newSize);
    }
}