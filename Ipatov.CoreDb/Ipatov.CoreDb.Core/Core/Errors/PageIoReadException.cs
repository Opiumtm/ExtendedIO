using System;

namespace Ipatov.CoreDb.Core.Errors
{
    /// <summary>
    /// Page I/O read exception.
    /// </summary>
    public class PageIoReadException : PageIoException
    {
        /// <inheritdoc />
        public PageIoReadException(PageAddress? page) : base(page)
        {
        }

        /// <inheritdoc />
        public PageIoReadException(string message, PageAddress? page) : base(message, page)
        {
        }

        /// <inheritdoc />
        public PageIoReadException(string message, Exception innerException, PageAddress? page) : base(message, innerException, page)
        {
        }
    }
}