
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the free cache policies.
    /// </summary>
    [Flags]
    public enum mpfr_free_cache_t
    {
        /// <summary>
        /// To free the local cache.
        /// </summary>
        MPFR_FREE_LOCAL_CACHE = 1,

        /// <summary>
        /// To free the global cache.
        /// </summary>
        MPFR_FREE_GLOBAL_CACHE = 2
    }

}