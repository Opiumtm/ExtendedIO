using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Ipatov.CoreDb.Core.Errors;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Stream-based page store.
    /// </summary>
    public sealed class StreamPageStore : IPagedRandomAccessStore
    {
        private readonly Stream _stream;

        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        private readonly List<bool> _allocatedBlocks = new List<bool>();


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pageSize">Page size.</param>
        /// <param name="stream">Underlying stream. Would be disposed automatically.</param>
        public StreamPageStore(uint pageSize, Stream stream)
        {
            if (pageSize < 1 || pageSize > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            PageSize = pageSize;
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            DisposableHelper.DisposeAll(_stream, _lock);
        }

        /// <summary>
        /// Page size in bytes.
        /// </summary>
        public uint PageSize { get; }

        /// <summary>
        /// Implementation flags.
        /// </summary>
        public PagingStoreImplementationFlags ImplementationFlags => 0;

        /// <summary>
        /// Total allocated pages.
        /// </summary>
        public ValueTask<uint> GetTotalPages()
        {
            return new ValueTask<uint>(TotalPages);
        }

        /// <summary>
        /// Total allocated pages.
        /// </summary>
        private uint TotalPages => (uint) (_stream.Length / PageSize);

        /// <summary>
        /// Read pages.
        /// </summary>
        /// <param name="addresses">Page adresses to read.</param>
        /// <returns>Retrieved pages.</returns>
        public async Task<DataPage[]> ReadPages(params PageAddress[] addresses)
        {
            await _lock.WaitAsync(TimeSpan.FromSeconds(30));
            try
            {
                if (addresses == null) throw new ArgumentNullException(nameof(addresses));
                var result = new DataPage[addresses.Length];
                for (var i = 0; i < addresses.Length; i++)
                {
                    var page = addresses[i];
                    long ofs = (long)page.PageIndex * PageSize;
                    long ofs2 = ofs + PageSize - 1;
                    if (_stream.Length >= ofs2)
                    {
                        try
                        {
                            var buf = new byte[PageSize];
                            _stream.Seek(ofs, SeekOrigin.Begin);
                            await _stream.ReadAsync(buf, 0, (int)PageSize);
                            result[i] = new DataPage(page, buf);
                        }
                        catch (Exception e)
                        {
                            throw new PageIoReadException(e.Message, e, page);
                        }
                    }
                    else
                    {
                        throw new PageIoReadOutOfRangeException(page);
                    }
                }
                return result;
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Write pages.
        /// </summary>
        /// <param name="pages">Pages array.</param>
        /// <returns>Completion task.</returns>
        public async Task WritePages(params DataPage[] pages)
        {
            await _lock.WaitAsync();
            try
            {

            }
            finally
            {
                
            }
            if (pages == null) throw new ArgumentNullException(nameof(pages));
            foreach (var page in pages)
            {
                long ofs = (long)page.Address.PageIndex * PageSize;
                if ((ofs + PageSize - 1) >= _stream.Length)
                {
                    throw new PageIoWriteOutOfRangeException(page.Address);
                }
                if (page.PageData == null)
                {
                    try
                    {

                    }
                    catch (Exception e)
                    {
                        throw new PageIoWriteException(e.Message, e, page.Address);
                    }
                }
                if (page.PageData.Length != PageSize)
                {
                    throw new PageIoWriteInvalidDataException(string.Format(PageIoWriteInvalidDataException.PageDataInvalidSize, PageSize), page.Address);
                }
                try
                {
                    await _stream.WriteAsync(page.PageData, 0, (int)PageSize);
                }
                catch (Exception e)
                {
                    throw new PageIoWriteException(e.Message, e, page.Address);
                }
            }
        }
    }
}