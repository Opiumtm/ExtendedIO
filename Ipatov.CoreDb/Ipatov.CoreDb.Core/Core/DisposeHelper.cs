using System;
using System.Collections.Generic;

namespace Ipatov.CoreDb.Core
{
    /// <summary>
    /// Disposable helpers.
    /// </summary>
    public static class DisposableHelper
    {
        /// <summary>
        /// Dispose all disposables.
        /// </summary>
        /// <param name="disposables">Disposables.</param>
        public static void DisposeAll(params IDisposable[] disposables)
        {
            if (disposables == null) throw new ArgumentNullException(nameof(disposables));
            var errors = new List<Exception>();
            for (var i = 0; i < disposables.Length; i++)
            {
                try
                {
                    disposables[i]?.Dispose();
                }
                catch (Exception e)
                {
                    errors.Add(e);
                }
            }
            if (errors.Count > 0)
            {
                throw new AggregateException(errors);
            }
        }

        /// <summary>
        /// Dispose all disposables.
        /// </summary>
        /// <param name="disposables">Disposables.</param>
        public static void DisposeAll(IEnumerable<IDisposable> disposables)
        {
            if (disposables == null) throw new ArgumentNullException(nameof(disposables));
            var errors = new List<Exception>();
            foreach (var disposable in disposables)
            {
                try
                {
                    disposable?.Dispose();
                }
                catch (Exception e)
                {
                    errors.Add(e);
                }
            }
            if (errors.Count > 0)
            {
                throw new AggregateException(errors);
            }
        }
    }
}