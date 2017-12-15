using System;

namespace Ipatov.CoreDb.Core.Errors
{
    /// <summary>
    /// Requested page to read is out of range.
    /// </summary>
    public class PageIoReadOutOfRangeException : PageIoReadException
    {
        private const string ErrorMessage = "Requested page index to read is out of range. Allocate new pages to extend page range.";

        /// <inheritdoc />
        public PageIoReadOutOfRangeException(PageAddress? page) : base(ErrorMessage, page)
        {
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public PageIoReadOutOfRangeException(Exception innerException, PageAddress? page) : base(ErrorMessage, innerException, page)
        {
        }
    }
}