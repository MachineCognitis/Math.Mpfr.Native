
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the kind of floating-point number in the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a>.
    /// </summary>
    public enum mpfr_kind_t
    {
        /// <summary>
        /// Represents an invalid number.
        /// </summary>
        MPFR_NAN_KIND = 0,
        
        /// <summary>
        /// Represents infinity.
        /// </summary>
        MPFR_INF_KIND = 1,

        /// <summary>
        /// Represents zero.
        /// </summary>
        MPFR_ZERO_KIND = 2,

        /// <summary>
        /// Represent a regular number.
        /// </summary>
        MPFR_REGULAR_KIND = 3
    }

}