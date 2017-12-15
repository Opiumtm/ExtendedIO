using System;

namespace Ipatov.CoreDb.Core.Errors
{
    /// <summary>
    /// Requested page to write is out of range.
    /// </summary>
    public class PageIoWriteOutOfRangeException : PageIoReadException
    {
        private const string ErrorMessage = "Requested page index to write is out of range. Allocate new pages to extend page range.";

        /// <inheritdoc />
        public PageIoWriteOutOfRangeException(PageAddress? page) : base(ErrorMessage, page)
        {
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public PageIoWriteOutOfRangeException(Exception innerException, PageAddress? page) : base(ErrorMessage, innerException, page)
        {
        }
    }
}