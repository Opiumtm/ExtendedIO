using System;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Relative page index.
    /// </summary>
    public readonly struct PageAddress : IEquatable<PageAddress>, IComparable<PageAddress>, IComparable
    {
        /// <summary>
        /// Identifier of page set. 0 for absolute page access.
        /// </summary>
        public readonly ulong PagesetId;

        /// <summary>
        /// Relative page index.
        /// </summary>
        public readonly uint PageIndex;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pagesetId">Identifier of page set. 0 for absolute page access.</param>
        /// <param name="pageIndex">Relative page index.</param>
        public PageAddress(ulong pagesetId, uint pageIndex)
        {
            PagesetId = pagesetId;
            PageIndex = pageIndex;
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(PageAddress other)
        {
            return PagesetId == other.PagesetId && PageIndex == other.PageIndex;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <returns>true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false. </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PageAddress && Equals((PageAddress) obj);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return (PagesetId.GetHashCode() * 397) ^ (int) PageIndex;
            }
        }

        public static bool operator ==(PageAddress left, PageAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PageAddress left, PageAddress right)
        {
            return !left.Equals(right);
        }

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object. </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order. </returns>
        /// <param name="other">An object to compare with this instance. </param>
        public int CompareTo(PageAddress other)
        {
            var pagesetIdComparison = PagesetId.CompareTo(other.PagesetId);
            if (pagesetIdComparison != 0) return pagesetIdComparison;
            return PageIndex.CompareTo(other.PageIndex);
        }

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order. </returns>
        /// <param name="obj">An object to compare with this instance. </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="obj" /> is not the same type as this instance. </exception>
        /// <filterpriority>2</filterpriority>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is PageAddress)) throw new ArgumentException($"Object must be of type {nameof(PageAddress)}");
            return CompareTo((PageAddress) obj);
        }

        public static bool operator <(PageAddress left, PageAddress right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(PageAddress left, PageAddress right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(PageAddress left, PageAddress right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(PageAddress left, PageAddress right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}