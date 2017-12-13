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
        public PageAddress Address;

        /// <summary>
        /// Page data.
        /// </summary>
        public byte[] PageData;

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