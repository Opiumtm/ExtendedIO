using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Stream-based page store.
    /// </summary>
    public sealed class StreamPageStore : IPagedRandomAccessStore
    {
        private readonly Stream _stream;

        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pageSize">Page size.</param>
        /// <param name="stream">Underlying stream. Would be disposed automatically.</param>
        public StreamPageStore(int pageSize, Stream stream)
        {
            PageSize = pageSize;
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _stream.Dispose();
            _lock.Dispose();
        }

        /// <summary>
        /// Page size in bytes.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Read pages.
        /// </summary>
        /// <param name="addresses">Page adresses to read.</param>
        /// <returns>Retrieved pages.</returns>
        public Task<DataPage[]> ReadPages(params PageAddress[] addresses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write pages.
        /// </summary>
        /// <param name="pages">Pages array.</param>
        /// <returns>Completion task.</returns>
        public Task WritePages(params DataPage[] pages)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allocate new pages.
        /// </summary>
        /// <param name="count">Count of pages to allocate.</param>
        /// <returns>Reserved page addresses.</returns>
        public Task<PageAddress[]> AllocatePages(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deallocate pages.
        /// </summary>
        /// <param name="addresses">Addresses of pages to deallocate.</param>
        /// <returns>Completion task.</returns>
        public Task DeallocatePages(params PageAddress[] addresses)
        {
            throw new NotImplementedException();
        }
    }
}