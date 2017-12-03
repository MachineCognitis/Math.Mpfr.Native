
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the different rounding modes.
    /// </summary>
    public enum mpfr_rnd_t
    {
        /// <summary>
        /// Round to nearest, with ties to even.
        /// </summary>
        MPFR_RNDN = 0,

        /// <summary>
        /// Round toward zero.
        /// </summary>
        MPFR_RNDZ = 1,

        /// <summary>
        /// Round toward +Infinity.
        /// </summary>
        MPFR_RNDU = 2,

        /// <summary>
        /// Round toward -Infinity.
        /// </summary>
        MPFR_RNDD = 3,

        /// <summary>
        /// Round away from zero.
        /// </summary>
        MPFR_RNDA = 4,

        /// <summary>
        /// Faithful rounding (not implemented yet).
        /// </summary>
        MPFR_RNDF = 5,

        /// <summary>
        /// Round to nearest, with ties away from zero (<see cref="mpfr_lib.mpfr_round"/>).
        /// </summary>
        MPFR_RNDNA = -1
    }

}
