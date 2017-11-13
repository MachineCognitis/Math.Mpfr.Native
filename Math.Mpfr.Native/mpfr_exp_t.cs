﻿
using System;
using System.Runtime.InteropServices;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the exponent of a floating-point number.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The floating point functions accept and return exponents in the C type <see cref="mpfr_exp_t"/>.
    /// Currently this is usually a long, but on some systems it’s an int for efficiency.
    /// </para>
    /// <para>
    /// In .Net, this is a 32-bit integer. 
    /// </para>
    /// </remarks>
    public struct mpfr_exp_t
    {

        internal int _value;

        /// <summary>
        /// Creates a new <see cref="mpfr_exp_t"/>, and sets its <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value of the new <see cref="mpfr_exp_t"/>.</param>
        public mpfr_exp_t(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts a <see cref="Byte"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="Byte"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static implicit operator mpfr_exp_t(byte value)
        {
            return new mpfr_exp_t(value);
        }

        /// <summary>
        /// Converts a <see cref="Byte"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="Byte"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static implicit operator mpfr_exp_t(sbyte value)
        {
            return new mpfr_exp_t(value);
        }

        /// <summary>
        /// Converts a <see cref="UInt16"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="UInt16"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static implicit operator mpfr_exp_t(ushort value)
        {
            return new mpfr_exp_t(value);
        }

        /// <summary>
        /// Converts an <see cref="Int16"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">An <see cref="Int16"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static implicit operator mpfr_exp_t(short value)
        {
            return new mpfr_exp_t(value);
        }

        /// <summary>
        /// Converts a <see cref="UInt32"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="UInt32"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static explicit operator mpfr_exp_t(uint value)
        {
            if (value > int.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the mpfr_exp_t data type.", value));
            return new mpfr_exp_t((int)value);
        }

        /// <summary>
        /// Converts an <see cref="Int32"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">An <see cref="Int32"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static implicit operator mpfr_exp_t(int value)
        {
            return new mpfr_exp_t(value);
        }

        /// <summary>
        /// Converts a <see cref="UInt64"/> value to an <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">A <see cref="UInt64"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static explicit operator mpfr_exp_t(ulong value)
        {
            if (value > int.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the mpfr_exp_t data type.", value));
            return new mpfr_exp_t((int)value);
        }

        /// <summary>
        /// Converts an <see cref="Int64"/> value to a <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="value">An <see cref="Int64"/> value.</param>
        /// <returns>An <see cref="mpfr_exp_t"/> value.</returns>
        public static explicit operator mpfr_exp_t(long value)
        {
            if (value < uint.MinValue || value > uint.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the mpfr_exp_t data type.", value));
            return new mpfr_exp_t((int)value);
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to a <see cref="Byte"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>A <see cref="Byte"/> value.</returns>
        public static explicit operator byte(mpfr_exp_t value)
        {
            if (value._value > byte.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the Byte data type.", value));
            return (byte)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to an <see cref="SByte"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>An <see cref="SByte"/> value.</returns>
        public static explicit operator sbyte(mpfr_exp_t value)
        {
            if (value._value < sbyte.MinValue || value._value > sbyte.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the SByte data type.", value));
            return (sbyte)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to a <see cref="UInt16"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>A <see cref="UInt16"/> value.</returns>
        public static explicit operator ushort(mpfr_exp_t value)
        {
            if (value._value > ushort.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the UInt16 data type.", value));
            return (ushort)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to an <see cref="Int16"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>An <see cref="Int16"/> value.</returns>
        public static explicit operator short(mpfr_exp_t value)
        {
            if (value._value < short.MinValue || value._value > short.MaxValue) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the Int16 data type.", value));
            return (short)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to a <see cref="UInt32"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>A <see cref="UInt32"/> value.</returns>
        public static explicit operator uint(mpfr_exp_t value)
        {
            if (value._value < 0) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the UInt32 data type.", value));
            return (uint)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to an <see cref="Int32"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>An <see cref="Int32"/> value.</returns>
        public static implicit operator int(mpfr_exp_t value)
        {
            return value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to a <see cref="UInt64"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>A <see cref="UInt64"/> value.</returns>
        public static explicit operator ulong(mpfr_exp_t value)
        {
            if (value._value < 0) throw new System.OverflowException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "'{0}' is out of range of the UInt64 data type.", value));
            return (ulong)value._value;
        }

        /// <summary>
        /// Converts an <see cref="mpfr_exp_t"/> value to an <see cref="Int64"/> value.
        /// </summary>
        /// <param name="value">An <see cref="mpfr_exp_t"/> value.</param>
        /// <returns>An <see cref="Int64"/> value.</returns>
        public static implicit operator long(mpfr_exp_t value)
        {
            return value._value;
        }

        /// <summary>
        /// Gets the string representation of the <see cref="mpfr_exp_t"/>.
        /// </summary>
        /// <returns>The string representation of the <see cref="mpfr_exp_t"/>.</returns>
        public override string ToString()
        {
            return _value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns><c>True</c> if <paramref name="obj"/> is an instance of <see cref="mpfr_exp_t"/> and equals the value of this instance; otherwise, <c>False</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mpfr_exp_t))
                return false;

            return Equals((mpfr_exp_t)obj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="mpfr_exp_t"/> value.
        /// </summary>
        /// <param name="other">A <see cref="mpfr_exp_t"/> value to compare to this instance.</param>
        /// <returns><c>True</c> if <paramref name="other"/> has the same value as this instance; otherwise, <c>False</c>.</returns>
        public bool Equals(mpfr_exp_t other)
        {
            return _value == other._value;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// Gets a value that indicates whether the two argument values are equal.
        /// </summary>
        /// <param name="value1">A <see cref="mpfr_exp_t"/> value.</param>
        /// <param name="value2">A <see cref="mpfr_exp_t"/> value.</param>
        /// <returns><c>True</c> if the two values are equal, and <c>False</c> otherwise.</returns>
        public static bool operator ==(mpfr_exp_t value1, mpfr_exp_t value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        /// Gets a value that indicates whether the two argument values are different.
        /// </summary>
        /// <param name="value1">A <see cref="mpfr_exp_t"/> value.</param>
        /// <param name="value2">A <see cref="mpfr_exp_t"/> value.</param>
        /// <returns><c>True</c> if the two values are different, and <c>False</c> otherwise.</returns>
        public static bool operator !=(mpfr_exp_t value1, mpfr_exp_t value2)
        {
            return !value1.Equals(value2);
        }

    }

}