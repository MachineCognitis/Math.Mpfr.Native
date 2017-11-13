﻿
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Math.Mpfr.Native
{

    public class mpfr_t : mp_base
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal bool _initialized = false;

        /// <summary>
        /// Creates a new multiple precision floating-point number.
        /// </summary>
        public mpfr_t()
        {
            size_t length = /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12U + (size_t)IntPtr.Size;
            _pointer = mpfr_lib.allocate(length).ToIntPtr();
            mpfr_lib.ZeroMemory(_pointer, (int)length);
        }

        /// <summary>
        /// The number of limbs currently in use, or the negative of that when representing a negative value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Zero is represented by <see cref="_mp_size"/> and <see cref="_mp_exp"/> both set to zero,
        /// and in that case the <see cref="mp_base._mp_d"/> data is unused.
        /// (In the future <see cref="_mp_exp"/> might be undefined when representing zero.) 
        /// </para>
        /// </remarks>
        public override mp_size_t _mp_size
        {
            get
            {
                return Marshal.ReadInt32(_pointer,  /*sizeof(int)*/ 4);
            }
        }

        /// <summary>
        /// The precision of the mantissa, in limbs.
        /// </summary>
        /// <remarks>
        /// <para>
        ///  In any calculation the aim is to produce <see cref="_mp_prec"/> limbs of result (the most significant being non-zero). 
        /// </para>
        /// </remarks>
        public int _mp_prec
        {
            get
            {
                return Marshal.ReadInt32(_pointer, 0);
            }
        }

        /// <summary>
        /// The exponent, in limbs, determining the location of the implied radix point.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Zero means the radix point is just above the most significant limb.
        /// Positive values mean a radix point offset towards the lower limbs and hence a value &#8805; 1, as for example in the diagram above.
        /// Negative exponents mean a radix point further above the highest limb. 
        /// </para>
        /// <para>
        /// Naturally the exponent can be any value, it doesn’t have to fall within the limbs as the diagram shows,
        /// it can be a long way above or a long way below.
        /// Limbs other than those included in the {<see cref="mp_base._mp_d"/>, <see cref="_mp_size"/>} data are treated as zero.
        /// </para>
        /// </remarks>
        public int _mp_exp
        {
            get
            {
                return Marshal.ReadInt32(_pointer, /*sizeof(int) + sizeof(int)*/ 8);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal override IntPtr _mp_d_intptr
        {
            get
            {
                return Marshal.ReadIntPtr(_pointer, /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12);
            }
            set
            {
                Marshal.WriteIntPtr(_pointer, /*sizeof(int) + sizeof(int) + sizeof(int)*/ 12, value);
            }
        }

        /// <summary>
        /// Gets the unmanaged memory pointer of the multiple precision floating-point number.
        /// </summary>
        /// <returns>The unmanaged memory pointer of the multiple precision floating-point number.</returns>
        public IntPtr ToIntPtr()
        {
            return _pointer;
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to an <see cref="mpf_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="string"/> value.</param>
        /// <returns>An <see cref="mpf_t"/> value.</returns>
        /// <remarks>
        /// <para>
        /// Base is assumed to be 10 unless the first character of the string is <c>B</c>
        /// followed by the base <c>2</c> to <c>62</c> or <c>-62</c> to <c>-2</c> followed
        /// by a space and then the floating-point number.
        /// Negative values are used to specify that the exponent is in decimal.
        /// </para>
        /// </remarks>
        public static implicit operator mpf_t(string value)
        {
            int @base = 10;
            mpf_t x = new mpf_t();
            mpfr_lib.mpf_init(x);
            if (value != null && value.Substring(0, 1).ToUpperInvariant() == "B")
            {
                int pos = value.IndexOf(' ', 1);
                if (pos != -1 && int.TryParse(value.Substring(1, pos - 1), out @base) == true)
                    value = value.Substring(pos + 1);
            }
            char_ptr s = new char_ptr(value);
            mpfr_lib.mpf_set_str(x, s, @base);
            mpfr_lib.free(s);
            return x;
        }

        /// <summary>
        /// Return the string representation of the float.
        /// </summary>
        /// <returns>The string representation of the float.</returns>
        public override string ToString()
        {
            if (!_initialized) return null;
            ptr<mp_exp_t> exp = new ptr<mp_exp_t>(0);
            char_ptr s_ptr = mpfr_lib.mpf_get_str(char_ptr.Zero, exp, 10, 0, this);
            string s = s_ptr.ToString();
            mpfr_lib.free(s_ptr);
            if (s.StartsWith("-", StringComparison.Ordinal))
                return "-0." + s.Substring(1) + "e" + exp.Value._value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            else
                return "0." + s + "e" + exp.Value._value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

    }

}