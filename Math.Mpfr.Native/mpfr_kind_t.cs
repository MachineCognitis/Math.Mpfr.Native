
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    public enum mpfr_kind_t
    {
        MPFR_NAN_KIND = 0,
        MPFR_INF_KIND = 1,
        MPFR_ZERO_KIND = 2,
        MPFR_REGULAR_KIND = 3
    }

}