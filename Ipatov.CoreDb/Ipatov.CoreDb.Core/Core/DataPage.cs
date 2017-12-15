using System;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Page data.
    /// </summary>
    public readonly struct DataPage
    {
        /// <summary>
        /// Page address.
        /// </summary>
        public readonly PageAddress Address;

        /// <summary>
        /// Page data. Deallocate page if null.
        /// </summary>
        public readonly byte[] PageData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="address">Page address.</param>
        /// <param name="pageData">Page data.</param>
        public DataPage(PageAddress address, byte[] pageData)
        {
            Address = address;
            PageData = pageData ?? throw new ArgumentNullException(nameof(pageData));
        }
    }
}