
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Math.Gmp.Native;

namespace Math.Mpfr.Native
{

    public class mpfr_t : mp_base
    {

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
        ///  In any calculation the aim is to produce <see cref="_mp_prec"/> limbs of result (the most significant being non-zero). 
        /// </para>
        /// </remarks>
        public mpfr_prec_t _mpfr_prec
        {
            get
            {
                return (mpfr_prec_t)Marshal.ReadInt32(Pointer, 0);
            }
        }

        public mpfr_sign_t _mpfr_sign
        {
            get
            {
                return Marshal.ReadInt32(Pointer, 4);
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
        public mpfr_exp_t _mpfr_exp
        {
            get
            {
                return Marshal.ReadInt32(Pointer, /*sizeof(int) + sizeof(int)*/ 8);
            }
        }

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