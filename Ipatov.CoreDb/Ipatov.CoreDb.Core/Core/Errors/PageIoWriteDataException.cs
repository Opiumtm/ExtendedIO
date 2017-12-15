using System;

namespace Ipatov.CoreDb.Core.Errors
{
    /// <summary>
    /// Page data write invalid data exception.
    /// </summary>
    public class PageIoWriteInvalidDataException : PageIoException
    {
        /// <summary>
        /// Page data is null.
        /// </summary>
        public static string PageDataIsNullMessage = "Page data is null.";

        /// <summary>
        /// Invalid page data size.
        /// </summary>
        public static string PageDataInvalidSize = "Invalid page data size. Valid page size is {0}.";

        /// <inheritdoc />
        public PageIoWriteInvalidDataException(PageAddress? page) : base(page)
        {
        }

        /// <inheritdoc />
        public PageIoWriteInvalidDataException(string message, PageAddress? page) : base(message, page)
        {
        }

        /// <inheritdoc />
        public PageIoWriteInvalidDataException(string message, Exception innerException, PageAddress? page) : base(message, innerException, page)
        {
        }
    }
}