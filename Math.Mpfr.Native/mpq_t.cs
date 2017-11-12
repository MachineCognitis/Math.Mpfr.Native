﻿
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents a multiple precision rational number.
    /// </summary>
    /// <remarks></remarks>
    /// <seealso cref="mpf_t"/>
    /// <seealso cref="mpz_t"/>
    public class mpq_t
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IntPtr _pointer;

        /// <summary>
        /// Creates a new multiple precision rational.
        /// </summary>
        public mpq_t()
        {
            size_t length = /*2 * (sizeof(int) + sizeof(int))*/ 16 + 2 * (size_t)IntPtr.Size;
            _pointer = mpfr_lib.allocate(length).ToIntPtr();
            mpfr_lib.ZeroMemory(_pointer, (int)length);
        }

        /// <summary>
        /// Get the numerator integer of the rational.
        /// </summary>
        /// <returns>The numerator integer of the rational.</returns>
        public mpz_t _mp_num
        {
            get
            {
                return new mpz_t(_pointer);
            }
        }

        /// <summary>
        /// Get the denominator integer of the rational.
        /// </summary>
        /// <returns>The denominator integer of the rational.</returns>
        public mpz_t _mp_den
        {
            get
            {
                return new mpz_t((IntPtr)(_pointer.ToInt64() /*+ sizeof(int) + sizeof(int)*/ + 8 + IntPtr.Size));
            }
        }

        /// <summary>
        /// Gets the unmanaged memory pointer of the multiple precision rational.
        /// </summary>
        /// <returns>The unmanaged memory pointer of the multiple precision rational.</returns>
        public IntPtr ToIntPtr()
        {
            return _pointer;
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to an <see cref="mpq_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="string"/> value.</param>
        /// <returns>An <see cref="mpq_t"/> value.</returns>
        /// <remarks>
        /// <para>
        /// The leading characters are used: <c>0x</c> and <c>0X</c> for hexadecimal,
        /// <c>0b</c> and <c>0B</c> for binary, <c>0</c> for octal, or decimal otherwise.
        /// Note that this is done separately for the numerator and denominator, so for
        /// instance <c>0xEF/100</c> is <c>239/100</c>, whereas <c>0xEF/0x100</c> is
        /// <c>239/256</c>.
        /// </para>
        /// </remarks>
        public static implicit operator mpq_t(string value)
        {
            mpq_t x = new mpq_t();
            mpfr_lib.mpq_init(x);
            char_ptr s = new char_ptr(value);
            mpfr_lib.mpq_set_str(x, s, 0);
            mpfr_lib.free(s);
            return x;
        }

        /// <summary>
        /// Return the string representation of the rational.
        /// </summary>
        /// <returns>The string representation of the rational.</returns>
        public override string ToString()
        {
            char_ptr s_ptr = mpfr_lib.mpq_get_str(char_ptr.Zero, 10, this);
            string s = s_ptr.ToString();
            mpfr_lib.free(s_ptr);
            return s;
        }

    }

}