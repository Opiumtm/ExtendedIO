using System;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Page I/O exception.
    /// </summary>
    public class PageIoException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="page">Page address.</param>
        public PageIoException(PageAddress? page)
        {
            Page = page;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="page">Page address.</param>
        public PageIoException(string message, PageAddress? page) : base(message)
        {
            Page = page;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="page">Page address.</param>
        public PageIoException(string message, Exception innerException, PageAddress? page) : base(message, innerException)
        {
            Page = page;
        }

        /// <summary>
        /// Relative page address.
        /// </summary>
        public PageAddress? Page { get; }
    }
}