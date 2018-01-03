
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the different rounding modes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The ‘roundtonearest’ mode works as in the IEEE 754 standard: in case the number to be rounded lies exactly in
    /// the middle of two representable numbers, it is rounded to the one with the least significant bit set to zero.
    /// For example, the number 2.5, which is represented by (10.1) in binary, is rounded to (10.0)=2 with a precision
    /// of two bits, and not to (11.0)=3.
    /// This rule avoids the drift phenomenon mentioned by Knuth in volume 2 of The Art of Computer Programming
    /// (Section 4.2.2).
    /// </para>
    /// <para>
    /// The MPFR_RNDF mode works as follows: the computed value is either that corresponding to MPFR_RNDD or that
    /// corresponding to MPFR_RNDU.
    /// In particular when those values are identical, i.e., when the result of the corresponding operation is exactly
    /// representable, that exact result is returned.
    /// Thus, the computed result can take at most two possible values, and in absence of underflow/overflow, the
    /// corresponding error is strictly less than one ulp (unit in the last place) of that result and of the exact result.
    /// For MPFR_RNDF, the ternary value (defined below) and the inexact flag (defined later, as with the other flags)
    /// are unspecified, the divide-by-zero flag is as with other roundings, and the underflow and overflow flags match
    /// what would be obtained in the case the computed value is the same as with MPFR_RNDD or MPFR_RNDU.
    /// The results may not be reproducible.
    /// </para>
    /// <para>
    /// Most MPFR functions take as first argument the destination variable, as second and following arguments the input
    /// variables, as last argument a rounding mode, and have a return value of type int, called the ternary value.
    /// The value stored in the destination variable is correctly rounded, i.e., MPFR behaves as if it computed the
    /// result with an infinite precision, then rounded it to the precision of this variable.
    /// The input variables are regarded as exact (in particular, their precision does not affect the result).
    /// </para>
    /// <para>
    /// As a consequence, in case of a non-zero real rounded result, the error on the result is less or equal to 1/2 ulp
    /// (unit in the last place) of that result in the rounding to nearest mode, and less than 1 ulp of that result in
    /// the directed rounding modes (a ulp is the weight of the least significant represented bit of the result after
    /// rounding).
    /// </para>
    /// <para>
    /// Unless documented otherwise, functions returning an int return a ternary value.
    /// If the ternary value is zero, it means that the value stored in the destination variable is the exact result of
    /// the corresponding mathematical function.
    /// If the ternary value is positive (resp. negative), it means the value stored in the destination variable is greater
    /// (resp. lower) than the exact result.
    /// For example with the MPFR_RNDU rounding mode, the ternary value is usually positive, except when the result is exact,
    /// in which case it is zero.
    /// In the case of an infinite result, it is considered as inexact when it was obtained by overflow, and exact otherwise.
    /// A NaN result (Not-a-Number) always corresponds to an exact return value.
    /// The opposite of a returned ternary value is guaranteed to be representable in an int.
    /// </para>
    /// <para>
    /// Unless documented otherwise, functions returning as result the value 1 (or any other value specified in this manual)
    /// for special cases (like acos(0)) yield an overflow or an underflow if that value is not representable in the current
    /// exponent range.
    /// </para>
    /// </remarks>
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
        /// Faithful rounding.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This feature is currently experimental.
        /// Specific support for this rounding mode has been added to some functions, such as the basic operations
        /// (addition, subtraction, multiplication, square, division, square root) or when explicitly documented.
        /// It might also work with other functions, as it is possible that they do not need modification in their code;
        /// even though a correct behavior is not guaranteed yet (corrections were done when failures occurred in the
        /// test suite, but almost nothing has been checked manually), failures should be regarded as bugs and reported,
        /// so that they can be fixed.
        /// </para>
        /// </remarks>
        MPFR_RNDF = 5,

        /// <summary>
        /// Round to nearest, with ties away from zero (<see cref="mpfr_lib.mpfr_round">mpfr_lib.mpfr_round</see>).
        /// </summary>
        MPFR_RNDNA = -1
    }

}
