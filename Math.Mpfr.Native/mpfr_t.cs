
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Math.Gmp.Native;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents a multiple precision floating-point number.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A floating-point number, or float for short, is an arbitrary precision significand (also called mantissa)
    /// with a limited precision exponent.
    /// The C data type for such objects is <see cref="mpfr_t"/> (internally defined as a one-element array of a
    /// structure, and <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/4609ac5e-5cf9-cd20-2fa9-8040101c165c.htm">mp_ptr</a>
    /// is the C data type representing a pointer to this structure).
    /// A floating-point number can have three special values: Not-a-Number (NaN) or plus or minus Infinity.
    /// NaN represents an uninitialized object, the result of an invalid operation (like 0 divided by 0), or
    /// a value that cannot be determined (like +Infinity minus +Infinity).
    /// Moreover, like in the IEEE 754 standard, zero is signed, i.e., there are both +0 and -0; the behavior
    /// is the same as in the IEEE 754 standard and it is generalized to the other functions supported by MPFR.
    /// Unless documented otherwise, the sign bit of a NaN is unspecified. 
    /// </para>
    /// <para>
    /// The precision is the number of bits used to represent the significand of a floating-point number;
    /// the corresponding C data type is <see cref="mpfr_prec_t"/>.
    /// The precision can be any integer between <see cref="mpfr_lib.MPFR_PREC_MIN"/> and <see cref="mpfr_lib.MPFR_PREC_MAX"/>.
    /// In the current implementation, <see cref="mpfr_lib.MPFR_PREC_MIN"/> is equal to 2. 
    /// </para>
    /// <para>
    /// Warning! MPFR needs to increase the precision internally, in order to provide accurate results
    /// (and in particular, correct rounding).
    /// Do not attempt to set the precision to any value near <see cref="mpfr_lib.MPFR_PREC_MAX"/>, otherwise MPFR will
    /// abort due to an assertion failure.
    /// Moreover, you may reach some memory limit on your platform, in which case the program may abort, crash or have
    /// undefined behavior (depending on your C implementation).
    /// </para>
    /// <para>
    /// The rounding mode specifies the way to round the result of a floating-point operation, in case the exact result
    /// can not be represented exactly in the destination significand; the corresponding C data type is <see cref="mpfr_rnd_t"/>. 
    /// </para>
    /// </remarks>
    public class mpfr_t : mp_base
    {

        /// <summary>
        /// The <see cref="mpfr_t"/> value.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _initialized = false;

        internal void Initializing()
        {
            Math.Gmp.Native.size_t length = /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12U + (size_t)IntPtr.Size;
            Pointer = gmp_lib.allocate(length).ToIntPtr();
        }

        internal void Initialized()
        {
            //gmp_lib.ZeroMemory(Pointer, (int)length);
            _initialized = true;
        }

        internal void Clear()
        {
            if (_initialized) gmp_lib.free(Pointer);
            Pointer = IntPtr.Zero;
            _initialized = false;
        }

        /// <summary>
        /// The precision of the mantissa, in limbs.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In any calculation the aim is to produce <see cref="_mpfr_prec"/> limbs of result (the most significant being non-zero). 
        /// </para>
        /// </remarks>
        public mpfr_prec_t _mpfr_prec
        {
            get
            {
                return (mpfr_prec_t)Marshal.ReadInt32(Pointer, 0);
            }
        }

        /// <summary>
        /// Gets the sign of the floating-point number.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_signbit"/>
        /// <seealso cref="mpfr_lib.mpfr_setsign"/>
        /// <seealso cref="mpfr_lib.mpfr_copysign"/>
        public mpfr_sign_t _mpfr_sign
        {
            get
            {
                return Marshal.ReadInt32(Pointer, 4);
            }
        }

        /// <summary>
        /// The _mpfr_exp field stores the exponent.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An exponent of 0 means a radix point just above the most significant limb.
        /// Non-zero values n are a multiplier 2^n relative to that point.
        /// A NaN, an infinity and a zero are indicated by special values of the exponent field. 
        /// </para>
        /// </remarks>
        public mpfr_exp_t _mpfr_exp
        {
            get
            {
                return Marshal.ReadInt32(Pointer, /*sizeof(int) + sizeof(int)*/ 8);
            }
        }

        /// <summary>
        /// The <see cref="_mp_d_intptr"/> field is a pointer to the limbs, least significant limbs stored first. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// The number of limbs in use is controlled by <see cref="_mpfr_prec"/>, namely
        /// ceil(<see cref="_mpfr_prec"/> / <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/f88c76a8-118a-5cbd-0df1-e30adcacb8ae.htm">mp_bits_per_limb</a>).
        /// Non-singular (i.e., different from NaN, Infinity or zero) values always have the most
        /// significant bit of the most significant limb set to 1.
        /// When the precision does not correspond to a whole number of limbs, the excess bits at
        /// the low end of the data are zeros.
        /// </para>
        /// </remarks>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override IntPtr _mp_d_intptr
        {
            get
            {
                return Marshal.ReadIntPtr(Pointer, /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12);
            }
            set
            {
                Marshal.WriteIntPtr(Pointer, /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12, value);
            }
        }

        /// <summary>
        /// The number of limbs currently in use.
        /// </summary>
        public override mp_size_t _mp_size
        {
            get
            {
                return (mp_size_t)((_mpfr_prec + gmp_lib.mp_bits_per_limb - 1) / gmp_lib.mp_bits_per_limb);
            }
        }

        /// <summary>
        /// Gets the unmanaged memory pointer of the multiple precision floating-point number.
        /// </summary>
        /// <returns>The unmanaged memory pointer of the multiple precision floating-point number.</returns>
        public IntPtr ToIntPtr()
        {
            return Pointer;
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to an <see cref="mpfr_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="string"/> value.</param>
        /// <returns>An <see cref="mpfr_t"/> value.</returns>
        /// <remarks>
        /// <para>
        /// Base is assumed to be 10 unless the first character of the string is <c>B</c>
        /// followed by the base <c>2</c> to <c>62</c> or <c>-62</c> to <c>-2</c> followed
        /// by a space and then the floating-point number.
        /// Negative values are used to specify that the exponent is in decimal.
        /// </para>
        /// </remarks>
        public static implicit operator mpfr_t(string value)
        {
            int @base = 0;
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init(x);
            if (value != null && value.Substring(0, 1).ToUpperInvariant() == "B")
            {
                int pos = value.IndexOf(' ', 1);
                if (pos != -1 && int.TryParse(value.Substring(1, pos - 1), out @base) == true)
                    value = value.Substring(pos + 1);
            }
            char_ptr s = new char_ptr(value);
            mpfr_lib.mpfr_set_str(x, s, @base, mpfr_lib.mpfr_get_default_rounding_mode());
            gmp_lib.free(s);
            return x;
        }

        /// <summary>
        /// Return the string representation of the float.
        /// </summary>
        /// <returns>The string representation of the float.</returns>
        public override string ToString()
        {
            if (!_initialized) return null;
            mpfr_exp_t exp = 0;
            char_ptr s_ptr = mpfr_lib.mpfr_get_str(char_ptr.Zero, ref exp, 10, 0, this, mpfr_lib.mpfr_get_default_rounding_mode());
            string s = s_ptr.ToString();
            gmp_lib.free(s_ptr);
            if (s.StartsWith("-", StringComparison.Ordinal))
                return "-0." + s.Substring(1) + "e" + exp.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            else
                return "0." + s + "e" + exp.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

    }

}