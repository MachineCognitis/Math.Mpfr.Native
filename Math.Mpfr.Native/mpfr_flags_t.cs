
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents one or more exception flags.
    /// </summary>
    /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exceptions">GNU MPFR - Exceptions</a></seealso>
    [Flags]
    public enum mpfr_flags_t
    {
        /// <summary>
        /// Represents the underflow flag.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An underflow occurs when the exact result of a function is a non-zero real number and the result obtained after the rounding,
        /// assuming an unbounded exponent range (for the rounding), has an exponent smaller than the minimum value of the current exponent range.
        /// (In the round-to-nearest mode, the halfway case is rounded toward zero.)
        /// </para>
        /// <para>
        /// Note: This is not the single possible definition of the underflow.
        /// MPFR chooses to consider the underflow after rounding.
        /// The underflow before rounding can also be defined.
        /// For instance, consider a function that has the exact result 7 × 2^(e−4), where e is the smallest exponent
        /// (for a significand between 1/2 and 1), with a 2-bit target precision and rounding toward plus infinity.
        /// The exact result has the exponent e−1.
        /// With the underflow before rounding, such a function call would yield an underflow, as e−1 is outside
        /// the current exponent range.
        /// However, MPFR first considers the rounded result assuming an unbounded exponent range.
        /// The exact result cannot be represented exactly in precision 2, and here, it is rounded to 0.5 × 2^e,
        /// which is representable in the current exponent range.
        /// As a consequence, this will not yield an underflow in MPFR.
        /// </para>
        /// </remarks>
        MPFR_FLAGS_UNDERFLOW = 1,

        /// <summary>
        /// Represents the overflow flag.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An overflow occurs when the exact result of a function is a non-zero real number and the result obtained
        /// after the rounding, assuming an unbounded exponent range (for the rounding), has an exponent larger than
        /// the maximum value of the current exponent range.
        /// In the round-to-nearest mode, the result is infinite.
        /// Note: unlike the underflow case, there is only one possible definition of overflow here.
        /// </para>
        /// </remarks>
        MPFR_FLAGS_OVERFLOW = 2,

        /// <summary>
        /// Represents the NaN flag.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A NaN exception occurs when the result of a function is NaN.
        /// </para>
        /// </remarks>
        MPFR_FLAGS_NAN = 4,

        /// <summary>
        /// Represent the inexact flag.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An inexact exception occurs when the result of a function cannot be represented exactly and must be rounded.
        /// </para>
        /// </remarks>
        MPFR_FLAGS_INEXACT = 8,

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// A range exception occurs when a function that does not return a MPFR number (such as comparisons and
        /// conversions to an integer) has an invalid result (e.g., an argument is NaN in mpfr_cmp, or a
        /// conversion to an integer cannot be represented in the target type).
        /// </para>
        /// </remarks>
        MPFR_FLAGS_ERANGE = 16,

        /// <summary>
        /// Represent the divide-by-zero flag.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An exact infinite result is obtained from finite inputs.
        /// </para>
        /// </remarks>
        MPFR_FLAGS_DIVBY0 = 32,

        /// <summary>
        /// Represents all flags.
        /// </summary>
        MPFR_FLAGS_ALL = MPFR_FLAGS_UNDERFLOW | MPFR_FLAGS_OVERFLOW | MPFR_FLAGS_NAN | MPFR_FLAGS_INEXACT | MPFR_FLAGS_ERANGE | MPFR_FLAGS_DIVBY0
    }

}