
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    public enum mpfr_rnd_t
    {
        MPFR_RNDN = 0,      /* round to nearest, with ties to even */
        MPFR_RNDZ = 1,      /* round toward zero */
        MPFR_RNDU = 2,      /* round toward +Inf */
        MPFR_RNDD = 3,      /* round toward -Inf */
        MPFR_RNDA = 4,      /* round away from zero */
        MPFR_RNDF = 5,      /* faithful rounding (not implemented yet) */
        MPFR_RNDNA = -1     /* round to nearest, with ties away from zero (mpfr_round) */
    }

}
