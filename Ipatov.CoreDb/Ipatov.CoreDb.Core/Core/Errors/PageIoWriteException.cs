using System;

namespace Ipatov.CoreDb.Core.Errors
{
    /// <summary>
    /// Page I/O write exception.
    /// </summary>
    public class PageIoWriteException : PageIoException
    {
        /// <inheritdoc />
        public PageIoWriteException(PageAddress? page) : base(page)
        {
        }

        /// <inheritdoc />
        public PageIoWriteException(string message, PageAddress? page) : base(message, page)
        {
        }

        /// <inheritdoc />
        public PageIoWriteException(string message, Exception innerException, PageAddress? page) : base(message, innerException, page)
        {
        }
    }
}