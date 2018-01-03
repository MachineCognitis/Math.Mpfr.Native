
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using Math.Gmp.Native;
using Math.Mpfr.Native;
using System.Linq;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {

        #region "Utility functions."

        private delegate TResult _Func<out TResult>();

        private string Test(_Func<object> func)
        {
            object result = null;
            try
            {
                result = func();
            }
            catch (System.Exception ex)
            {
                return ex.GetType().Name;
            }
            return result.ToString();
        }

        #endregion

        #region "Types."

        [TestMethod]
        public void mpfr_prec_t_test()
        {
            // uint
            mpfr_prec_t v;

            byte zero = 0;
            sbyte minusOne = -1;

            // Check implicit and explict conversions to mpfr_prec_t.
            v = (byte)zero;
            v = (mpfr_prec_t)(sbyte)zero;
            v = (ushort)zero;
            v = (mpfr_prec_t)(short)zero;
            v = (uint)zero;
            v = (mpfr_prec_t)(int)zero;
            v = (mpfr_prec_t)(ulong)zero;
            v = (mpfr_prec_t)(long)zero;

            // Check implicit and explict conversions from mpfr_prec_t.
            byte b = (byte)v;
            sbyte sb = (sbyte)v;
            ushort us = (ushort)v;
            short s = (short)v;
            uint ui = v;
            int i = (int)v;
            ulong ul = v;
            long l = v;

            // Check OverflowException conversions to mpfr_prec_t.
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(byte)byte.MaxValue) == byte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(sbyte)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(sbyte)sbyte.MaxValue) == sbyte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(ushort)ushort.MaxValue) == ushort.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(short)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(short)short.MaxValue) == short.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(uint)uint.MaxValue) == uint.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(int)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(int)int.MaxValue) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(ulong)ulong.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(long)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_prec_t)(long)long.MaxValue) == typeof(OverflowException).Name);

            // Check OverflowException conversions from mpfr_prec_t.
            Assert.IsTrue(Test(() => b = (byte)(new mpfr_prec_t(uint.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new mpfr_prec_t(uint.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new mpfr_prec_t(uint.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new mpfr_prec_t(uint.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new mpfr_prec_t(uint.MaxValue))) == uint.MaxValue.ToString());
            Assert.IsTrue(Test(() => i = (int)(new mpfr_prec_t(uint.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new mpfr_prec_t(uint.MaxValue))) == uint.MaxValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new mpfr_prec_t(uint.MaxValue))) == uint.MaxValue.ToString());

            // Check equality and inequality.
            Object obj = new mpfr_prec_t(8);
            Assert.IsTrue((new mpfr_prec_t(8)).Equals(obj));
            Assert.IsTrue(!(new mpfr_prec_t(8)).Equals(new int()));
            Assert.IsTrue((new mpfr_prec_t(8)).Equals(new mpfr_prec_t(8)));
            Assert.IsTrue(!(new mpfr_prec_t(8)).Equals(new mpfr_prec_t(9)));
            Assert.IsTrue((new mpfr_prec_t(8)) == (new mpfr_prec_t(8)));
            Assert.IsTrue((new mpfr_prec_t(8)) != (new mpfr_prec_t(9)));
        }

        [TestMethod]
        public void mpfr_sign_t_test()
        {
            // int
            mpfr_sign_t v;

            byte zero = 0;

            // Check implicit and explict conversions to mpfr_sign_t.
            v = (byte)zero;
            v = (sbyte)zero;
            v = (ushort)zero;
            v = (short)zero;
            v = (mpfr_sign_t)(uint)zero;
            v = (int)zero;
            v = (mpfr_sign_t)(ulong)zero;
            v = (mpfr_sign_t)(long)zero;

            // Check implicit and explict conversions from mpfr_sign_t.
            byte b = (byte)v;
            sbyte sb = (sbyte)v;
            ushort us = (ushort)v;
            short s = (short)v;
            uint ui = (uint)v;
            int i = v;
            ulong ul = (ulong)v;
            long l = v;

            // Check OverflowException conversions to mpfr_sign_t.
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(byte)byte.MaxValue) == byte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(sbyte)sbyte.MinValue) == sbyte.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(sbyte)sbyte.MaxValue) == sbyte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(ushort)ushort.MaxValue) == ushort.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(short)short.MinValue) == short.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(short)short.MaxValue) == short.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(uint)uint.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(int)int.MinValue) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(int)int.MaxValue) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(ulong)ulong.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(long)long.MinValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_sign_t)(long)long.MaxValue) == typeof(OverflowException).Name);

            // Check OverflowException conversions from mpfr_sign_t.
            Assert.IsTrue(Test(() => b = (byte)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => b = (byte)(new mpfr_sign_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new mpfr_sign_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new mpfr_sign_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new mpfr_sign_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new mpfr_sign_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => i = (int)(new mpfr_sign_t(int.MinValue))) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => i = (int)(new mpfr_sign_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => ul = (ulong)(new mpfr_sign_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new mpfr_sign_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new mpfr_sign_t(int.MinValue))) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new mpfr_sign_t(int.MaxValue))) == int.MaxValue.ToString());

            // Check equality and inequality.
            Object obj = new mpfr_sign_t(8);
            Assert.IsTrue((new mpfr_sign_t(8)).Equals(obj));
            Assert.IsTrue(!(new mpfr_sign_t(8)).Equals(new byte()));
            Assert.IsTrue((new mpfr_sign_t(8)).Equals(new mpfr_sign_t(8)));
            Assert.IsTrue(!(new mpfr_sign_t(8)).Equals(new mpfr_sign_t(9)));
            Assert.IsTrue((new mpfr_sign_t(8)) == (new mpfr_sign_t(8)));
            Assert.IsTrue((new mpfr_sign_t(8)) != (new mpfr_sign_t(9)));
        }

        [TestMethod]
        public void uintmax_t_test()
        {
            // ulong
            uintmax_t v;

            byte zero = 0;
            sbyte minusOne = -1;

            // Check implicit and explict conversions to uintmax_t.
            v = (byte)zero;
            v = (uintmax_t)(sbyte)zero;
            v = (ushort)zero;
            v = (uintmax_t)(short)zero;
            v = (uint)zero;
            v = (uintmax_t)(int)zero;
            v = (ulong)zero;
            v = (uintmax_t)(long)zero;

            // Check implicit and explict conversions from uintmax_t.
            byte b = (byte)v;
            sbyte sb = (sbyte)v;
            ushort us = (ushort)v;
            short s = (short)v;
            uint ui = (uint)v;
            int i = (int)v;
            ulong ul = v;
            long l = (long)v;

            // Check OverflowException conversions to uintmax_t.
            Assert.IsTrue(Test(() => v = (uintmax_t)(byte)byte.MaxValue) == byte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(sbyte)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (uintmax_t)(sbyte)sbyte.MaxValue) == sbyte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(ushort)ushort.MaxValue) == ushort.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(short)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (uintmax_t)(short)short.MaxValue) == short.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(uint)uint.MaxValue) == uint.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(int)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (uintmax_t)(int)int.MaxValue) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(ulong)ulong.MaxValue) == ulong.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (uintmax_t)(long)minusOne) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (uintmax_t)(long)long.MaxValue) == long.MaxValue.ToString());

            // Check OverflowException conversions from uintmax_t.
            Assert.IsTrue(Test(() => b = (byte)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => i = (int)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new uintmax_t(ulong.MaxValue))) == ulong.MaxValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new uintmax_t(ulong.MaxValue))) == typeof(OverflowException).Name);

            // Check equality and inequality.
            Object obj = new uintmax_t(8);
            Assert.IsTrue((new uintmax_t(8)).Equals(obj));
            Assert.IsTrue(!(new uintmax_t(8)).Equals(new int()));
            Assert.IsTrue((new uintmax_t(8)).Equals(new uintmax_t(8)));
            Assert.IsTrue(!(new uintmax_t(8)).Equals(new uintmax_t(9)));
            Assert.IsTrue((new uintmax_t(8)) == (new uintmax_t(8)));
            Assert.IsTrue((new uintmax_t(8)) != (new uintmax_t(9)));
        }

        [TestMethod]
        public void intmax_t_test()
        {
            // long
            intmax_t v;

            byte zero = 0;

            // Check implicit and explict conversions to intmax_t.
            v = (byte)zero;
            v = (sbyte)zero;
            v = (ushort)zero;
            v = (short)zero;
            v = (uint)zero;
            v = (int)zero;
            v = (intmax_t)(ulong)zero;
            v = (long)zero;

            // Check implicit and explict conversions from intmax_t.
            byte b = (byte)v;
            sbyte sb = (sbyte)v;
            ushort us = (ushort)v;
            short s = (short)v;
            uint ui = (uint)v;
            int i = (int)v;
            ulong ul = (ulong)v;
            long l = v;

            // Check OverflowException conversions to intmax_t.
            Assert.IsTrue(Test(() => v = (intmax_t)(byte)byte.MaxValue) == byte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(sbyte)sbyte.MinValue) == sbyte.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(sbyte)sbyte.MaxValue) == sbyte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(ushort)ushort.MaxValue) == ushort.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(short)short.MinValue) == short.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(short)short.MaxValue) == short.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(uint)uint.MaxValue) == uint.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(int)int.MinValue) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(int)int.MaxValue) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(ulong)ulong.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (intmax_t)(long)long.MinValue) == long.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (intmax_t)(long)long.MaxValue) == long.MaxValue.ToString());

            // Check OverflowException conversions from intmax_t.
            Assert.IsTrue(Test(() => b = (byte)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => b = (byte)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => i = (int)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => i = (int)(new intmax_t(long.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new intmax_t(long.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new intmax_t(long.MaxValue))) == long.MaxValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new intmax_t(long.MinValue))) == long.MinValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new intmax_t(long.MaxValue))) == long.MaxValue.ToString());

            // Check equality and inequality.
            Object obj = new intmax_t(8);
            Assert.IsTrue((new intmax_t(8)).Equals(obj));
            Assert.IsTrue(!(new intmax_t(8)).Equals(new byte()));
            Assert.IsTrue((new intmax_t(8)).Equals(new intmax_t(8)));
            Assert.IsTrue(!(new intmax_t(8)).Equals(new intmax_t(9)));
            Assert.IsTrue((new intmax_t(8)) == (new intmax_t(8)));
            Assert.IsTrue((new intmax_t(8)) != (new intmax_t(9)));
        }

        [TestMethod]
        public void mpfr_exp_t_test()
        {
            // int
            mpfr_exp_t v;

            byte zero = 0;

            // Check implicit and explict conversions to mpfr_exp_t.
            v = (byte)zero;
            v = (sbyte)zero;
            v = (ushort)zero;
            v = (short)zero;
            v = (mpfr_exp_t)(uint)zero;
            v = (int)zero;
            v = (mpfr_exp_t)(ulong)zero;
            v = (mpfr_exp_t)(long)zero;

            // Check implicit and explict conversions from mpfr_exp_t.
            byte b = (byte)v;
            sbyte sb = (sbyte)v;
            ushort us = (ushort)v;
            short s = (short)v;
            uint ui = (uint)v;
            int i = v;
            ulong ul = (ulong)v;
            long l = v;

            // Check OverflowException conversions to mpfr_exp_t.
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(byte)byte.MaxValue) == byte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(sbyte)sbyte.MinValue) == sbyte.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(sbyte)sbyte.MaxValue) == sbyte.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(ushort)ushort.MaxValue) == ushort.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(short)short.MinValue) == short.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(short)short.MaxValue) == short.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(uint)uint.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(int)int.MinValue) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(int)int.MaxValue) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(ulong)ulong.MaxValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(long)long.MinValue) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => v = (mpfr_exp_t)(long)long.MaxValue) == typeof(OverflowException).Name);

            // Check OverflowException conversions from mpfr_exp_t.
            Assert.IsTrue(Test(() => b = (byte)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => b = (byte)(new mpfr_exp_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => sb = (sbyte)(new mpfr_exp_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => us = (ushort)(new mpfr_exp_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => s = (short)(new mpfr_exp_t(int.MaxValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ui = (uint)(new mpfr_exp_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => i = (int)(new mpfr_exp_t(int.MinValue))) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => i = (int)(new mpfr_exp_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => ul = (ulong)(new mpfr_exp_t(int.MinValue))) == typeof(OverflowException).Name);
            Assert.IsTrue(Test(() => ul = (ulong)(new mpfr_exp_t(int.MaxValue))) == int.MaxValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new mpfr_exp_t(int.MinValue))) == int.MinValue.ToString());
            Assert.IsTrue(Test(() => l = (long)(new mpfr_exp_t(int.MaxValue))) == int.MaxValue.ToString());

            // Check equality and inequality.
            Object obj = new mpfr_exp_t(8);
            Assert.IsTrue((new mpfr_exp_t(8)).Equals(obj));
            Assert.IsTrue(!(new mpfr_exp_t(8)).Equals(new byte()));
            Assert.IsTrue((new mpfr_exp_t(8)).Equals(new mpfr_exp_t(8)));
            Assert.IsTrue(!(new mpfr_exp_t(8)).Equals(new mpfr_exp_t(9)));
            Assert.IsTrue((new mpfr_exp_t(8)) == (new mpfr_exp_t(8)));
            Assert.IsTrue((new mpfr_exp_t(8)) != (new mpfr_exp_t(9)));
        }

        [TestMethod]
        [TestCategory("mpfr_t")]
        public void mpfr_t_test()
        {
            // Set default precision to 32 bits.
            mpfr_lib.mpfr_set_default_prec(32U);

            // Create new multiple-precision floating-point numbers.
            mpfr_t x = "B16 7048 860D DF79@0";
            mpfr_t y = "123 456 789 012 345e0";
            mpfr_t z = new mpfr_t();
            mpfr_t result = "0.28867000000e5";
            mpfr_lib.mpfr_init(z);

            // Add floating-point numbers, and assert result.
            mpfr_lib.mpfr_add(z, x, y, mpfr_rnd_t.MPFR_RNDN);
            Assert.IsTrue(mpfr_lib.mpfr_cmp(z, result) == 0);

            // Release allocated memory for floating-point numbers.
            mpfr_lib.mpfr_clears(x, y, z, result, null);
        }

        //[TestMethod]
        //public void va_list()
        //{
        //    object[] args;
        //    va_list va_args;

        //    args = new object[] { new ptr<Char>('A') };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Char>)args[0]).Value == 'A');

        //    args = new object[] { new ptr<Byte>(Byte.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Byte>)args[0]).Value == Byte.MinValue);

        //    args = new object[] { new ptr<SByte>(SByte.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<SByte>)args[0]).Value == SByte.MaxValue);

        //    args = new object[] { new ptr<Int16>(Int16.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Int16>)args[0]).Value == Int16.MinValue);

        //    args = new object[] { new ptr<UInt16>(UInt16.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<UInt16>)args[0]).Value == UInt16.MaxValue);

        //    args = new object[] { new ptr<Int32>(Int32.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Int32>)args[0]).Value == Int32.MinValue);

        //    args = new object[] { new ptr<UInt32>(UInt32.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<UInt32>)args[0]).Value == UInt32.MaxValue);

        //    args = new object[] { new ptr<Int64>(Int64.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Int64>)args[0]).Value == Int64.MinValue);

        //    args = new object[] { new ptr<UInt64>(UInt64.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<UInt64>)args[0]).Value == UInt64.MaxValue);

        //    args = new object[] { new ptr<mp_bitcnt_t>(UInt32.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<mp_bitcnt_t>)args[0]).Value == UInt32.MaxValue);

        //    args = new object[] { new ptr<mp_size_t>(Int32.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<mp_size_t>)args[0]).Value == Int32.MinValue);

        //    args = new object[] { new ptr<Single>(Single.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Single>)args[0]).Value == Single.MinValue);

        //    args = new object[] { new ptr<Double>(Double.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<Double>)args[0]).Value == Double.MaxValue);

        //    args = new object[] { new ptr<mp_limb_t>(IntPtr.Size == 4 ? UInt32.MaxValue : UInt64.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<mp_limb_t>)args[0]).Value == (IntPtr.Size == 4 ? UInt32.MaxValue : UInt64.MaxValue));

        //    args = new object[] { new ptr<size_t>(IntPtr.Size == 4 ? UInt32.MaxValue : UInt64.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<size_t>)args[0]).Value == (IntPtr.Size == 4 ? UInt32.MaxValue : UInt64.MaxValue));

        //    args = new object[] { new ptr<uintmax_t>(UInt64.MaxValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<uintmax_t>)args[0]).Value == UInt64.MaxValue);

        //    args = new object[] { new ptr<intmax_t>(Int64.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<intmax_t>)args[0]).Value == Int64.MinValue);

        //    args = new object[] { new ptr<mp_exp_t>(Int32.MinValue) };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((ptr<mp_exp_t>)args[0]).Value == Int32.MinValue);

        //    args = new object[] { new StringBuilder("ABCDEFGHIJ") };
        //    va_args = new va_list(args);
        //    va_args.RetrieveArgumentValues();
        //    Assert.IsTrue(((StringBuilder)args[0]).ToString() == "ABCDEFGHIJ");
        //}

        #endregion

        #region "Float routines."

        [TestMethod]
        public void mpfr_abs()
        {
            // Create, initialize, and set a new floating-point number op to -10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, -10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = |op|.
            Assert.IsTrue(mpfr_lib.mpfr_abs(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 10) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_acos()
        {
            // Create, initialize, and set a new floating-point number op to 0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 2 * acos(op).
            Assert.IsTrue(mpfr_lib.mpfr_acos(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_mul_si(rop, rop, 2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is PI.
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_cmp(rop, op) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_acosh()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = acosh(op).
            Assert.IsTrue(mpfr_lib.mpfr_acosh(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 0.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 0) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_add()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + op2.
            Assert.IsTrue(mpfr_lib.mpfr_add(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -200.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -200.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_add_d()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + 210.
            Assert.IsTrue(mpfr_lib.mpfr_add_d(rop, op1, 210.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_add_q()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new rational number op2 to 1/5.
            mpq_t op2 = new mpq_t();
            gmp_lib.mpq_init(op2);
            gmp_lib.mpq_set_si(op2, 1, 5);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + op2.
            Assert.IsTrue(mpfr_lib.mpfr_add_q(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -209.8);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpq_clear(op2);
        }

        [TestMethod]
        public void mpfr_add_si()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + 210.
            Assert.IsTrue(mpfr_lib.mpfr_add_si(rop, op1, 210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_add_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + 210.
            Assert.IsTrue(mpfr_lib.mpfr_add_ui(rop, op1, 210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_add_z()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to 5.
            mpz_t op2 = new mpz_t();
            gmp_lib.mpz_init_set_si(op2, 5);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 + op2.
            Assert.IsTrue(mpfr_lib.mpfr_add_z(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -200.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -205.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        public void mpfr_agm()
        {
            // Create, initialize, and set a new floating-point number op1 to 24.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 24, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 6.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(op2, 6, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = agm(op1, op2).
            Assert.IsTrue(mpfr_lib.mpfr_agm(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 13.458171481725615420766813156);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_ai()
        {
            // Create, initialize, and set a new floating-point number x to 1.0.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(x, 1.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Airy(x).
            Assert.IsTrue(mpfr_lib.mpfr_ai(rop, x, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.135292416312881415524e0");

            // Release unmanaged memory allocated for x and rop.
            mpfr_lib.mpfr_clears(x, rop, null);
        }

        [TestMethod]
        public void mpfr_asin()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 2 * asin(op).
            Assert.IsTrue(mpfr_lib.mpfr_asin(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_mul_si(rop, rop, 2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is PI.
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_cmp(rop, op) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_asinh()
        {
            // Create, initialize, and set a new floating-point number op to 0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = asinh(op).
            Assert.IsTrue(mpfr_lib.mpfr_asinh(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 0.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 0) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_asprintf()
        {
            // Create pointer to unmanaged character string pointer.
            ptr<char_ptr> str = new ptr<char_ptr>();

            mpz_t z = "123456";
            mpq_t q = "123/456";
            mpf_t f = "12345e6";
            mpfr_t r = "12345e6";
            mp_limb_t m = 123456;

            // Print to newly allocated unmanaged memory string.
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Zd - %QX - %Fa - %Mo", z, q, f, m) == 42);
            Assert.IsTrue(str.Value.ToString() == "123456 - 7B/1C8 - 0x2.dfd1c04p+32 - 361100");

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Zd", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Zi", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%ZX", z) == 5);
            Assert.IsTrue(str.Value.ToString() == "1E240");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Zo", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "361100");
            gmp_lib.free(str.Value);
            gmp_lib.mpz_clear(z);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Qd", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "123/456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Qi", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "123/456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%QX", q) == 6);
            Assert.IsTrue(str.Value.ToString() == "7B/1C8");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Qo", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "173/710");
            gmp_lib.free(str.Value);
            gmp_lib.mpq_clear(q);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Fe", f) == 12);
            Assert.IsTrue(str.Value.ToString() == "1.234500e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Ff", f) == 18);
            Assert.IsTrue(str.Value.ToString() == "12345000000.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Fg", f) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Fa", f) == 15);
            Assert.IsTrue(str.Value.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str.Value);
            gmp_lib.mpf_clear(f);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Re", r) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Rf", r) == 18);
            Assert.IsTrue(str.Value.ToString() == "12345000000.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Rg", r) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Ra", r) == 15);
            Assert.IsTrue(str.Value.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str.Value);
            mpfr_lib.mpfr_clear(r);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Md", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Mi", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%MX", m) == 5);
            Assert.IsTrue(str.Value.ToString() == "1E240");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Mo", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "361100");
            gmp_lib.free(str.Value);

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.Value.ToString() == "11111111111");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.Value.ToString() == "11111111111");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.Value.ToString() == "2964619C7");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.Value.ToString() == "122621414707");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%hd", (short)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            //Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.Value.ToString() == "A");
            //gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%d", (mpfr_exp_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%d", (mpfr_sign_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Pd", (mpfr_prec_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.Value.ToString() == "1.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.Value.ToString() == "1.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000e+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000e+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000E+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000E+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            //Assert.IsTrue(gmp_lib.gmp_asprintf(str, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.Value.ToString() == "0x1.000000p+0");
            //gmp_lib.free(str.Value);
            //Assert.IsTrue(gmp_lib.gmp_asprintf(str, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.Value.ToString() == "0x1.000004p+0");
            //gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.Value.ToString() == "Hello World!");
            gmp_lib.free(str.Value);

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "123456%n", p) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%p", p) == 2 * IntPtr.Size);
            gmp_lib.free(str.Value);
        }

        [TestMethod]
        public void mpfr_atan()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 4 * atan(op).
            Assert.IsTrue(mpfr_lib.mpfr_atan(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_mul_si(rop, rop, 4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is PI.
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_cmp(rop, op) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_atan2()
        {
            // Create, initialize, and set a new floating-point number x to -1.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, -1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 0.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = atan2(y, x).
            Assert.IsTrue(mpfr_lib.mpfr_atan2(rop, y, x, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert that the value of rop is PI.
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(x, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_cmp(rop, x) == 0);

            // Release unmanaged memory allocated for x, y, and rop.
            mpfr_lib.mpfr_clears(x, y, rop, null);
        }

        [TestMethod]
        public void mpfr_atanh()
        {
            // Create, initialize, and set a new floating-point number op to 0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = atanh(op).
            Assert.IsTrue(mpfr_lib.mpfr_atanh(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 0.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 0) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_buildopt_float128_p()
        {
            // Assert that ‘__float128’ support is not available.
            Assert.IsTrue(mpfr_lib.mpfr_buildopt_float128_p() != 0);
        }

        [TestMethod]
        public void mpfr_buildopt_decimal_p()
        {
            // Assert that Decimal float is not available.
            Assert.IsTrue(mpfr_lib.mpfr_buildopt_decimal_p() != 0);
        }

        [TestMethod]
        public void mpfr_buildopt_gmpinternals_p()
        {
            // Assert that --with-gmp-build compile option was used.
            Assert.IsTrue(mpfr_lib.mpfr_buildopt_gmpinternals_p() == 0);
        }

        [TestMethod]
        public void mpfr_buildopt_sharedcache_p()
        {
            // Assert that --enable-shared-cache compile option was used.
            Assert.IsTrue(mpfr_lib.mpfr_buildopt_sharedcache_p() == 0);
        }

        [TestMethod]
        public void mpfr_buildopt_tls_p()
        {
            // Assert that --enable-thread-safe compile option was used.
            Assert.IsTrue(mpfr_lib.mpfr_buildopt_tls_p() != 0);
        }

        [TestMethod]
        public void mpfr_buildopt_tune_case()
        {
            if (gmp_lib.mp_bytes_per_limb == 4)
                Assert.IsTrue(mpfr_lib.mpfr_buildopt_tune_case().ToString() == "src/x86/mparam.h");
            else
                Assert.IsTrue(mpfr_lib.mpfr_buildopt_tune_case().ToString() == "default");
        }

        [TestMethod]
        public void mpfr_can_round()
        {
            // Create, initialize, and set a new floating-point number x to 0.100146.
            mpfr_t b = new mpfr_t();
            mpfr_lib.mpfr_init2(b, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(b, 0.100146, mpfr_rnd_t.MPFR_RNDN) == 0);

            mpfr_exp_t err = 63;
            mpfr_rnd_t rnd1 = mpfr_rnd_t.MPFR_RNDN;
            mpfr_rnd_t rnd2 = mpfr_rnd_t.MPFR_RNDN;
            mpfr_prec_t prec = 53;

            // Assert that we can round to 53 bits.
            Assert.IsTrue(mpfr_lib.mpfr_can_round(b, err, rnd1, rnd2, prec) != 0);

            // Release unmanaged memory allocated for b.
            mpfr_lib.mpfr_clear(b);
        }

        [TestMethod]
        public void mpfr_cbrt()
        {
            // Create, initialize, and set a new floating-point number op to 8.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = cbrt(op).
            Assert.IsTrue(mpfr_lib.mpfr_cbrt(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 2) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rootn_ui()
        {
            // Create, initialize, and set a new floating-point number op to 8.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to the cubic root of op.
            Assert.IsTrue(mpfr_lib.mpfr_rootn_ui(rop, op, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 2) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_ceil()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = ceil(op).
            Assert.IsTrue(mpfr_lib.mpfr_ceil(rop, op) == 2);

            // Assert that the value of rop is 11.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 11.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_check_range()
        {
            // Create, initialize, and set a new floating-point number x to 0.100146.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(x, 0.100146, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that return value is -1.
            Assert.IsTrue(mpfr_lib.mpfr_check_range(x, -1, mpfr_rnd_t.MPFR_RNDZ) == -1);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_clear()
        {
            // Create and initialize a new floating-point number x.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);

            // Assert that the value of x is NaN.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_clear_divby0()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_divby0();
            Assert.IsTrue(mpfr_lib.mpfr_divby0_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_erangeflag()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_erangeflag();
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_flags()
        {
            // Clear all flags and assert that flags are clear.
            mpfr_lib.mpfr_clear_flags();
            Assert.IsTrue(mpfr_lib.mpfr_underflow_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_overflow_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_divby0_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_nanflag_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_inexflag()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_inexflag();
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_nanflag()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_nanflag();
            Assert.IsTrue(mpfr_lib.mpfr_nanflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_overflow()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_overflow();
            Assert.IsTrue(mpfr_lib.mpfr_overflow_p() == 0);
        }

        [TestMethod]
        public void mpfr_clear_underflow()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_underflow();
            Assert.IsTrue(mpfr_lib.mpfr_underflow_p() == 0);
        }

        [TestMethod]
        public void mpfr_clears()
        {
            // Create new floating-point numbers x1, x2 and x3.
            mpfr_t x1 = new mpfr_t();
            mpfr_t x2 = new mpfr_t();
            mpfr_t x3 = new mpfr_t();

            // Initialize the floating-point numbers.
            mpfr_lib.mpfr_inits(x1, x2, x3, null);

            // Assert that their value is NaN.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x1) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x2) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x3) != 0);

            // Release unmanaged memory allocated for the floating-point numbers.
            mpfr_lib.mpfr_clears(x1, x2, x3, null);
        }

        [TestMethod]
        public void mpfr_cmp()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number op2.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 128, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 > op2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp(op1, op2) > 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_cmp_d()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 > 128.0.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_d(op1, 128.0) > 0);

            // Release unmanaged memory allocated for op1.
            mpfr_lib.mpfr_clear(op1);
        }

        [TestMethod]
        public void mpfr_cmp_f()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number op2.
            mpf_t op2 = new mpf_t();
            gmp_lib.mpf_init_set_si(op2, 128);

            // Assert that op1 > op2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_f(op1, op2) > 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clear(op1);
            gmp_lib.mpf_clear(op2);
        }

        [TestMethod]
        public void mpfr_cmp_q()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new rational number op2.
            mpq_t op2 = new mpq_t();
            gmp_lib.mpq_init(op2);
            gmp_lib.mpq_set_si(op2, 128, 1);

            // Assert that op1 > op2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_q(op1, op2) > 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clear(op1);
            gmp_lib.mpq_clear(op2);
        }

        [TestMethod]
        public void mpfr_cmp_si()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 > 128.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(op1, 128) > 0);

            // Release unmanaged memory allocated for op1.
            mpfr_lib.mpfr_clear(op1);
        }

        [TestMethod]
        public void mpfr_cmp_si_2exp()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 = 128 * 2^2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si_2exp(op1, 128, 2) == 0);

            // Release unmanaged memory allocated for op1.
            mpfr_lib.mpfr_clear(op1);
        }

        [TestMethod]
        public void mpfr_cmp_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 > 128.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_ui(op1, 128) > 0);

            // Release unmanaged memory allocated for op1.
            mpfr_lib.mpfr_clear(op1);
        }

        [TestMethod]
        public void mpfr_cmp_ui_2exp()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 = 128 * 2^2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_ui_2exp(op1, 128, 2) == 0);

            // Release unmanaged memory allocated for op1.
            mpfr_lib.mpfr_clear(op1);
        }

        [TestMethod]
        public void mpfr_cmp_z()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to 128.
            mpz_t op2 = new mpz_t();
            gmp_lib.mpz_init_set_si(op2, 128);

            // Assert that op1 > op2.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_z(op1, op2) > 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clear(op1);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        public void mpfr_cmpabs()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number op2.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 128, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that |op1| > |op2|.
            Assert.IsTrue(mpfr_lib.mpfr_cmpabs(op1, op2) > 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_const_catalan()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Assert that rop is the Catalan's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_catalan(rop, mpfr_rnd_t.MPFR_RNDN) == -1);
            Assert.IsTrue(rop.ToString() == "0.915965594177219015048e0");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_const_euler()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Assert that rop is the Euler's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_euler(rop, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(rop.ToString() == "0.577215664901532860616e0");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_const_log2()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Assert that rop is log(2).
            Assert.IsTrue(mpfr_lib.mpfr_const_log2(rop, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(rop.ToString() == "0.693147180559945309429e0");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_const_pi()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Assert that z is the Catalan's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(rop, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(rop.ToString() == "0.314159265358979323851e1");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_copysign()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to -5.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Assert that rop = -512.
            Assert.IsTrue(mpfr_lib.mpfr_copysign(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, -512) == 0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_cos()
        {
            // Create, initialize, and set a new floating-point number op to 0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = cos(op).
            Assert.IsTrue(mpfr_lib.mpfr_cos(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 1) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_cosh()
        {
            // Create, initialize, and set a new floating-point number op to 0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = cosh(op).
            Assert.IsTrue(mpfr_lib.mpfr_cosh(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 1) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_cot()
        {
            // Create, initialize, and set a new floating-point number op to pi / 4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_mul_d(op, op, 0.25, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = cot(op).
            Assert.IsTrue(mpfr_lib.mpfr_cot(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert that the value of rop is 1.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 1) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_coth()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = coth(op).
            Assert.IsTrue(mpfr_lib.mpfr_coth(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.131303528549933130366e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_csc()
        {
            // Create, initialize, and set a new floating-point number op to pi / 2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(mpfr_lib.mpfr_mul_d(op, op, 0.5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = csc(op).
            Assert.IsTrue(mpfr_lib.mpfr_csc(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert that the value of rop is 1.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, 1) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_csch()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = csch(op).
            Assert.IsTrue(mpfr_lib.mpfr_csch(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.850918128239321545122e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_custom_get_exp()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = x + 1.
            Assert.IsTrue(mpfr_lib.mpfr_add_si(x, x, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the exponent of x is 1.
            Assert.IsTrue(mpfr_lib.mpfr_custom_get_exp(x) == 1);

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
        }

        [TestMethod]
        public void mpfr_custom_get_kind()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = x + 1.
            Assert.IsTrue(mpfr_lib.mpfr_add_si(x, x, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert x is a regular floating-point number.
            Assert.IsTrue(mpfr_lib.mpfr_custom_get_kind(x) == mpfr_kind_t.MPFR_REGULAR_KIND);

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
        }

        [TestMethod]
        public void mpfr_custom_get_significand()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = x + 1.
            Assert.IsTrue(mpfr_lib.mpfr_add_si(x, x, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert significand of x.
            Byte[] result = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0x80 };
            byte[] sp = new byte[8];
            Marshal.Copy(significand.ToIntPtr(), sp, 0, 8);
            Assert.IsTrue(sp.SequenceEqual(result));

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
        }

        [TestMethod]
        public void mpfr_custom_get_size()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = 16.
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 16, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert exponent of x.
            Assert.IsTrue(mpfr_lib.mpfr_custom_get_exp(x) == 5);

            // Assert significand of x.
            Byte[] result = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0x80 };
            byte[] sp = new byte[8];
            Marshal.Copy(significand.ToIntPtr(), sp, 0, 8);
            Assert.IsTrue(sp.SequenceEqual(result));

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
        }

        [TestMethod]
        public void mpfr_custom_init_set()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = 16.
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 16, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert exponent of x.
            Assert.IsTrue(mpfr_lib.mpfr_custom_get_exp(x) == 5);

            // Assert significand of x.
            Byte[] result = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0x80 };
            byte[] sp = new byte[8];
            Marshal.Copy(significand.ToIntPtr(), sp, 0, 8);
            Assert.IsTrue(sp.SequenceEqual(result));

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
        }

        [TestMethod]
        public void mpfr_custom_move()
        {
            // Initialize a custom, 64-bit significand floating-point number, and set it to 0.
            size_t size = mpfr_lib.mpfr_custom_get_size(64U);
            void_ptr significand = gmp_lib.allocate(size);
            gmp_lib.ZeroMemory(significand.ToIntPtr(), (int)size);
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_custom_init_set(x, mpfr_kind_t.MPFR_ZERO_KIND, 0, 64U, significand);

            // Set x = 16.
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 16, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of x.
            Assert.IsTrue(x.ToString() == "0.160000000000000000000e2");

            // Allocate new significand.
            void_ptr significand2 = gmp_lib.allocate(8);
            Marshal.Copy(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xc0 }, 0, significand2.ToIntPtr(), 8);

            // Assign new significanf to x.
            mpfr_lib.mpfr_custom_move(x, significand2);

            // Assert the value of x.
            Assert.IsTrue(x.ToString() == "0.240000000000000000000e2");

            // Release unmanaged memory allocated for x and significand.
            mpfr_lib.mpfr_custom_clear(x);
            gmp_lib.free(significand);
            gmp_lib.free(significand2);
        }

        [TestMethod]
        public void mpfr_d_div()
        {
            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = -210.0 / op2.
            Assert.IsTrue(mpfr_lib.mpfr_d_div(rop, -210.0, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_d_sub()
        {
            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10.0 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_d_sub(rop, 10.0, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_digamma()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = digamma(op).
            Assert.IsTrue(mpfr_lib.mpfr_digamma(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "-0.577215664901532860616e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_dim()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to positive difference of op1 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_dim(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 0.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_div()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / op2.
            Assert.IsTrue(mpfr_lib.mpfr_div(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_div_2exp()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_div_2exp(rop, op1, 8U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 2.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 2.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_2si()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_div_2si(rop, op1, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 2.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 2.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_2ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 512.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 512, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_div_2ui(rop, op1, 8U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 2.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 2.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_d()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 10.0.
            Assert.IsTrue(mpfr_lib.mpfr_div_d(rop, op1, 10.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_q()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new rational op2 to 10.
            mpq_t op2 = new mpq_t();
            gmp_lib.mpq_init(op2);
            gmp_lib.mpq_set_si(op2, 10, 1);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / op2.
            Assert.IsTrue(mpfr_lib.mpfr_div_q(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpq_clear(op2);
        }

        [TestMethod]
        public void mpfr_div_si()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 10.
            Assert.IsTrue(mpfr_lib.mpfr_div_si(rop, op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / 10.
            Assert.IsTrue(mpfr_lib.mpfr_div_ui(rop, op1, 10U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_div_z()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to 10.
            mpz_t op2 = new mpz_t();
            gmp_lib.mpz_init(op2);
            gmp_lib.mpz_set_si(op2, 10);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 / op2.
            Assert.IsTrue(mpfr_lib.mpfr_div_z(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -21.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        public void mpfr_divby0_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_divby0();
            Assert.IsTrue(mpfr_lib.mpfr_divby0_p() == 0);
        }

        [TestMethod]
        public void mpfr_eint()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to exponential integral of op.
            Assert.IsTrue(mpfr_lib.mpfr_eint(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.189511781635593675550e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_eq()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 = op2 to 10 bits.
            Assert.IsTrue(mpfr_lib.mpfr_eq(op1, op2, 10U) != 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_equal_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 = op2.
            Assert.IsTrue(mpfr_lib.mpfr_equal_p(op1, op2) != 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_erangeflag_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_erangeflag();
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_flags_clear()
        {
            // Clear erange and inexact flags, and assert that they are clear.
            mpfr_lib.mpfr_flags_clear(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_INEXACT);
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() == 0);
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() == 0);
        }

        [TestMethod]
        [TestCategory("mpfr_flags_set")]
        public void mpfr_flags_set()
        {
            // Set erange and inexact flags, and assert that they are set.
            mpfr_lib.mpfr_flags_set(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_INEXACT);
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() != 0);
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() != 0);
        }

        [TestMethod]
        [TestCategory("mpfr_flags_test")]
        public void mpfr_flags_test()
        {
            // Set erange and divby0 flags.
            mpfr_lib.mpfr_flags_set(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_DIVBY0);

            // Get the erange and inexact flags, and assert that their values.
            mpfr_flags_t flags = mpfr_lib.mpfr_flags_test(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_INEXACT);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_ERANGE) != 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_INEXACT) == 0);
        }

        [TestMethod]
        [TestCategory("mpfr_flags_save")]
        public void mpfr_flags_save()
        {
            // Set erange and divby0 flags.
            mpfr_lib.mpfr_flags_set(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_DIVBY0);

            // Get all flags, and assert their values.
            mpfr_flags_t flags = mpfr_lib.mpfr_flags_save();
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_DIVBY0) != 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_ERANGE) != 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_INEXACT) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_NAN) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_OVERFLOW) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_UNDERFLOW) == 0);
        }

        [TestMethod]
        public void mpfr_flags_restore()
        {
            // Set erange and divby0 flags.
            mpfr_lib.mpfr_flags_restore(mpfr_flags_t.MPFR_FLAGS_ERANGE | mpfr_flags_t.MPFR_FLAGS_DIVBY0, mpfr_flags_t.MPFR_FLAGS_ALL);

            // Get all flags, and assert their values.
            mpfr_flags_t flags = mpfr_lib.mpfr_flags_save();
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_DIVBY0) != 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_ERANGE) != 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_INEXACT) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_NAN) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_OVERFLOW) == 0);
            Assert.IsTrue((flags & mpfr_flags_t.MPFR_FLAGS_UNDERFLOW) == 0);
        }

        [TestMethod]
        public void mpfr_erf()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to error function of op.
            Assert.IsTrue(mpfr_lib.mpfr_erf(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.842700792949714869368e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_erfc()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to complementary error function of op.
            Assert.IsTrue(mpfr_lib.mpfr_erfc(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.157299207050285130659e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_exp()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = e^op.
            Assert.IsTrue(mpfr_lib.mpfr_exp(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.271828182845904523543e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_exp10()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10^op.
            Assert.IsTrue(mpfr_lib.mpfr_exp10(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.100000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_exp2()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 2^op.
            Assert.IsTrue(mpfr_lib.mpfr_exp2(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.200000000000000000000e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_expm1()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = e^op - 1.
            Assert.IsTrue(mpfr_lib.mpfr_expm1(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.171828182845904523532e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_fac_ui()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 5!.
            Assert.IsTrue(mpfr_lib.mpfr_fac_ui(rop, 5U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.120000000000000000000e3");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_fits_sint_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in int.
            Assert.IsTrue(mpfr_lib.mpfr_fits_sint_p(op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_slong_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in long.
            Assert.IsTrue(mpfr_lib.mpfr_fits_slong_p(op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_intmax_p()
        {
            // Create, initialize, and set the value of op Int64.MaxValue.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_uj(op, Int64.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op fits in intmax_t.
            Assert.IsTrue(mpfr_lib.mpfr_fits_intmax_p(op, mpfr_rnd_t.MPFR_RNDN) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_sshort_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in short.
            Assert.IsTrue(mpfr_lib.mpfr_fits_sshort_p(op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_uint_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in uint.
            Assert.IsTrue(mpfr_lib.mpfr_fits_uint_p(op, mpfr_rnd_t.MPFR_RNDN) > 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_ulong_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in int.
            Assert.IsTrue(mpfr_lib.mpfr_fits_sint_p(op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_uintmax_p()
        {
            // Create, initialize, and set the value of op UInt64.MaxValue.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_uj(op, UInt64.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op fits in uintmax_t.
            Assert.IsTrue(mpfr_lib.mpfr_fits_uintmax_p(op, mpfr_rnd_t.MPFR_RNDN) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fits_ushort_p()
        {
            // Create, initialize, and set the value of op 4294967295.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, uint.MaxValue, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op does not fit in ushort.
            Assert.IsTrue(mpfr_lib.mpfr_fits_ushort_p(op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_floor()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = floor(op).
            Assert.IsTrue(mpfr_lib.mpfr_floor(rop, op) == -2);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_fma()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op3 to 10.
            mpfr_t op3 = new mpfr_t();
            mpfr_lib.mpfr_init2(op3, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op3, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = (op1 * op2) + op3.
            Assert.IsTrue(mpfr_lib.mpfr_fma(rop, op1, op2, op3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2090.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2090.0);

            // Release unmanaged memory allocated for rop, op1, op2, op3, and op4.
            mpfr_lib.mpfr_clears(rop, op1, op2, op3, null);
        }

        [TestMethod]
        public void mpfr_fmma()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op3 to 10.
            mpfr_t op3 = new mpfr_t();
            mpfr_lib.mpfr_init2(op3, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op3, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op4 to 10.
            mpfr_t op4 = new mpfr_t();
            mpfr_lib.mpfr_init2(op4, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op4, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = (op1 * op2) + (op3 * op4).
            Assert.IsTrue(mpfr_lib.mpfr_fmma(rop, op1, op2, op3, op4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2090.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2000.0);

            // Release unmanaged memory allocated for rop, op1, op2, and op3.
            mpfr_lib.mpfr_clears(rop, op1, op2, op3, op4, null);
        }

        [TestMethod]
        public void mpfr_fmod()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 3.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            Assert.IsTrue(mpfr_lib.mpfr_fmod(r, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z.
            Assert.IsTrue(r.ToString() == "0.100000000000000000000e1");

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_fmodquo()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 3.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            int q = 0;
            Assert.IsTrue(mpfr_lib.mpfr_fmodquo(r, ref q, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z and q.
            Assert.IsTrue(r.ToString() == "0.100000000000000000000e1" && q == 33);

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_fmodquo_2()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 3.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            ptr<int> q = new ptr<int>(0);
            Assert.IsTrue(mpfr_lib.mpfr_fmodquo(r, q, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z and q.
            Assert.IsTrue(r.ToString() == "0.100000000000000000000e1" && q.Value == 33);

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_fms()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op3 to 10.
            mpfr_t op3 = new mpfr_t();
            mpfr_lib.mpfr_init2(op3, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op3, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = (op1 * op2) - op3.
            Assert.IsTrue(mpfr_lib.mpfr_fms(rop, op1, op2, op3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2110.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2110.0);

            // Release unmanaged memory allocated for rop, op1, op2, and op3.
            mpfr_lib.mpfr_clears(rop, op1, op2, op3, null);
        }

        [TestMethod]
        public void mpfr_fmms()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op3 to 10.
            mpfr_t op3 = new mpfr_t();
            mpfr_lib.mpfr_init2(op3, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op3, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op4 to 10.
            mpfr_t op4 = new mpfr_t();
            mpfr_lib.mpfr_init2(op4, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op4, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = (op1 * op2) - (op3 * op4).
            Assert.IsTrue(mpfr_lib.mpfr_fmms(rop, op1, op2, op3, op4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2200.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2200.0);

            // Release unmanaged memory allocated for rop, op1, op2, op3, and op4.
            mpfr_lib.mpfr_clears(rop, op1, op2, op3, op4, null);
        }

        [TestMethod]
        public void mpfr_frac()
        {
            // Create, initialize, and set a new floating-point number op to 10.0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = fraction(op).
            Assert.IsTrue(mpfr_lib.mpfr_frac(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 0.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_free_cache()
        {
            // Create and initialize a new floating-point number z.
            mpfr_t z = new mpfr_t();
            mpfr_lib.mpfr_init2(z, 64U);

            // Assert that z is the Catalan's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_log2(z, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(z.ToString() == "0.693147180559945309429e0");

            // Release unmanaged memory allocated for x and z.
            mpfr_lib.mpfr_clear(z);

            // Free constants cache.
            mpfr_lib.mpfr_free_cache();
        }

        [TestMethod]
        public void mpfr_free_cache2()
        {
            // Create and initialize a new floating-point number z.
            mpfr_t z = new mpfr_t();
            mpfr_lib.mpfr_init2(z, 64U);

            // Assert that z is the Catalan's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_log2(z, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(z.ToString() == "0.693147180559945309429e0");

            // Release unmanaged memory allocated for x and z.
            mpfr_lib.mpfr_clear(z);

            // Free constants cache.
            mpfr_lib.mpfr_free_cache2(mpfr_free_cache_t.MPFR_FREE_GLOBAL_CACHE | mpfr_free_cache_t.MPFR_FREE_LOCAL_CACHE);
        }

        [TestMethod]
        public void mpfr_free_pool()
        {
            // Create and initialize a new floating-point number z.
            mpfr_t z = new mpfr_t();
            mpfr_lib.mpfr_init2(z, 64U);

            // Assert that z is the Catalan's constant.
            Assert.IsTrue(mpfr_lib.mpfr_const_log2(z, mpfr_rnd_t.MPFR_RNDN) == 1);
            Assert.IsTrue(z.ToString() == "0.693147180559945309429e0");

            // Release unmanaged memory allocated for x and z.
            mpfr_lib.mpfr_clear(z);

            // Free internal pools.
            mpfr_lib.mpfr_free_pool();
        }

        [TestMethod]
        public void mpfr_mp_memory_cleanup()
        {
            Assert.IsTrue(mpfr_lib.mpfr_mp_memory_cleanup() == 0);
        }

        [TestMethod]
        public void mpfr_free_str()
        {
            // Create pointer to unmanaged character string pointer.
            ptr<char_ptr> str = new ptr<char_ptr>();
            mpfr_t r = "12345e6";

            Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%Re", r) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            mpfr_lib.mpfr_free_str(str.Value);

            // Release unmanaged memory allocated for r.
            mpfr_lib.mpfr_clear(r);
        }

        [TestMethod]
        public void mpfr_frexp()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);

            // Initialize exponent.
            mpfr_exp_t exp = 0;

            // Find y and exp such that x = y * 2^exp where y in [0.5, 1).
            Assert.IsTrue(mpfr_lib.mpfr_frexp(ref exp, y, x, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of exp and y.
            Assert.IsTrue(y.ToString() == "0.781250000000000000000e0" && exp == 7);

            // Release unmanaged memory allocated for x, and y.
            mpfr_lib.mpfr_clears(x, y, null);
        }

        [TestMethod]
        public void mpfr_frexp_2()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);

            // Initialize exponent.
            ptr<mpfr_exp_t> exp = new ptr<mpfr_exp_t>(0);

            // Find y and exp such that x = y * 2^exp where y in [0.5, 1).
            Assert.IsTrue(mpfr_lib.mpfr_frexp(exp, y, x, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of exp and y.
            Assert.IsTrue(y.ToString() == "0.781250000000000000000e0" && exp.Value == 7);

            // Release unmanaged memory allocated for x, and y.
            mpfr_lib.mpfr_clears(x, y, null);
        }

        [TestMethod]
        public void mpfr_gamma()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Gamma(op).
            Assert.IsTrue(mpfr_lib.mpfr_gamma(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.100000000000000000000e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_gamma_inc()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 0.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = IncompleteGamma(op).
            Assert.IsTrue(mpfr_lib.mpfr_gamma_inc(rop, op, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.100000000000000000000e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, op2, null);
        }

        [TestMethod]
        public void mpfr_beta()
        {
            // Create, initialize, and set a new floating-point number op1 to 2.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 2.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Beta(op1, op2).
            Assert.IsTrue(mpfr_lib.mpfr_beta(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.166666666666666666671e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_get_d()
        {
            // Create, initialize, and set a new floating-point number to -123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(op, mpfr_rnd_t.MPFR_RNDN) == -123.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_d_2exp()
        {
            // Create, initialize, and set a new floating-point number to -8.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the absolute value of op is 0.5 * 2^4.
            int exp = 0;
            Assert.IsTrue(mpfr_lib.mpfr_get_d_2exp(ref exp, op, mpfr_rnd_t.MPFR_RNDN) == -0.5);
            Assert.IsTrue(exp == 4);

            // Release unmanaged memory allocated for x and exp.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_d_2exp_2()
        {
            // Create, initialize, and set a new floating-point number to -8.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the absolute value of op is 0.5 * 2^4.
            ptr<int> exp = new ptr<int>(0);
            Assert.IsTrue(mpfr_lib.mpfr_get_d_2exp(exp, op, mpfr_rnd_t.MPFR_RNDN) == -0.5);
            Assert.IsTrue(exp.Value == 4);

            // Release unmanaged memory allocated for x and exp.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_default_prec()
        {
            // Assert that default precision is 53 bits.
            Assert.IsTrue(mpfr_lib.mpfr_get_default_prec() == 53U);
        }

        [TestMethod]
        public void mpfr_get_default_rounding_mode()
        {
            // Set default rounding mode.
            mpfr_lib.mpfr_set_default_rounding_mode(mpfr_rnd_t.MPFR_RNDN);

            // Assert default rounding mode.
            Assert.IsTrue(mpfr_lib.mpfr_get_default_rounding_mode() == mpfr_rnd_t.MPFR_RNDN);
        }

        [TestMethod]
        public void mpfr_get_emax()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_emax_max()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_emax_min()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_emin()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_emin_max()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_emin_min()
        {
            // Assert maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1073741823);
            // Assert minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == -1073741823);

            // Assert mpfr_set_emax minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_min() == -1073741823);
            // Assert mpfr_set_emax maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emax_max() == 1073741823);

            // Assert mpfr_set_emin minimum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_min() == -1073741823);
            // Assert mpfr_set_emin maximum exponent.
            Assert.IsTrue(mpfr_lib.mpfr_get_emin_max() == 1073741823);
        }

        [TestMethod]
        public void mpfr_get_exp()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert exp of x.
            Assert.IsTrue(mpfr_lib.mpfr_get_exp(x) == 7);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_get_f()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpf_t rop = new mpf_t();
            gmp_lib.mpf_init(rop);

            // Set rop = op.
            Assert.IsTrue(mpfr_lib.mpfr_get_f(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.4.
            Assert.IsTrue(gmp_lib.mpf_get_d(rop) == 10.4);

            // Release unmanaged memory allocated for rop and op.
            gmp_lib.mpf_clear(rop);
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_flt()
        {
            // Create, initialize, and set a new floating-point number to -123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_flt(op, mpfr_rnd_t.MPFR_RNDN) == -123.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_patches()
        {
            // Assert no patch applied.
            Assert.IsTrue(mpfr_lib.mpfr_get_patches().ToString() == "");
        }

        [TestMethod]
        public void mpfr_get_prec()
        {
            // Create and initialize a new floating-point number x with 64-bit precision.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);

            // Assert that the value of x is 0.0, and that its precision is 64 bits.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_get_prec(x) == 64U);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_get_si()
        {
            // Create, initialize, and set a new floating-point number to -123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(op, mpfr_rnd_t.MPFR_RNDN) == -123);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_sj()
        {
            // Create, initialize, and set a new floating-point number to -123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_sj(op, mpfr_rnd_t.MPFR_RNDN) == -123);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_str()
        {
            // Create, initialize, and set a new floating-point number to -8.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -8.
            mpfr_exp_t exp = 0;
            char_ptr value = mpfr_lib.mpfr_get_str(char_ptr.Zero, ref exp, 10, 0, op, mpfr_rnd_t.MPFR_RNDN);
            Assert.IsTrue(value.ToString() == "-800000000000000000000");
            Assert.IsTrue(exp == 1);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
            gmp_lib.free(value);
        }

        [TestMethod]
        public void mpfr_get_str_2()
        {
            // Create, initialize, and set a new floating-point number to -8.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, -8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -8.
            ptr<mpfr_exp_t> exp = new ptr<mpfr_exp_t>(0);
            char_ptr value = mpfr_lib.mpfr_get_str(char_ptr.Zero, exp, 10, 0, op, mpfr_rnd_t.MPFR_RNDN);
            Assert.IsTrue(value.ToString() == "-800000000000000000000");
            Assert.IsTrue(exp.Value == 1);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
            gmp_lib.free(value);
        }

        [TestMethod]
        public void mpfr_get_ui()
        {
            // Create, initialize, and set a new floating-point number to 123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_ui(op, mpfr_rnd_t.MPFR_RNDN) == 123);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_uj()
        {
            // Create, initialize, and set a new floating-point number to 123.0
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of op is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_uj(op, mpfr_rnd_t.MPFR_RNDN) == 123);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_version()
        {
            // Assert MPFR version.
            Assert.IsTrue(mpfr_lib.mpfr_get_version().ToString() == "4.0.0");
        }

        [TestMethod]
        public void mpfr_get_z()
        {
            // Create, initialize, and set a new floating-point number op to 10.6.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.6, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new integer rop.
            mpz_t rop = new mpz_t();
            gmp_lib.mpz_init(rop);

            // Set rop = op.
            Assert.IsTrue(mpfr_lib.mpfr_get_z(rop, op, mpfr_rnd_t.MPFR_RNDN) == 2);

            // Assert that the value of rop is 11.
            Assert.IsTrue(gmp_lib.mpz_get_ui(rop) == 11);

            // Release unmanaged memory allocated for rop and op.
            gmp_lib.mpz_clear(rop);
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_q()
        {
            // Create, initialize, and set a new floating-point number op to 10.6.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.6, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new rational rop.
            mpq_t rop = new mpq_t();
            gmp_lib.mpq_init(rop);

            // Set rop = op.
            mpfr_lib.mpfr_get_q(rop, op);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "5967269506265907/562949953421312");

            // Release unmanaged memory allocated for rop and op.
            gmp_lib.mpq_clear(rop);
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_get_z_2exp()
        {
            // Create, initialize, and set a new floating-point number op to 8.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new integer rop.
            mpz_t rop = new mpz_t();
            gmp_lib.mpz_init(rop);

            // Set rop such that op = rop * 2^exp.
            mpfr_exp_t exp = mpfr_lib.mpfr_get_z_2exp(rop, op);

            // Assert rop and exp.
            Assert.IsTrue(rop.ToString() == "9223372036854775808" && exp == -60);

            // Release unmanaged memory allocated for rop and op.
            gmp_lib.mpz_clear(rop);
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_grandom()
        {
            // Create, initialize, and seed a new random number generator.
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_mt(state);
            gmp_lib.gmp_randseed_ui(state, 100000U);

            // Create and initialize a new floating-point number rop1.
            mpfr_t rop1 = new mpfr_t();
            mpfr_lib.mpfr_init2(rop1, 64U);

            // Create and initialize a new floating-point number rop2.
            mpfr_t rop2 = new mpfr_t();
            mpfr_lib.mpfr_init2(rop2, 64U);

            // Generate two Gaussin random floating-point numbers.
            Assert.IsTrue(mpfr_lib.mpfr_grandom(rop1, rop2, state, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Generate one Gaussin random floating-point number.
            Assert.IsTrue(mpfr_lib.mpfr_grandom(rop1, null, state, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Free all memory occupied by state and rop.
            gmp_lib.gmp_randclear(state);
            mpfr_lib.mpfr_clears(rop1, rop2, null);
        }

        [TestMethod]
        public void mpfr_nrandom()
        {
            // Create, initialize, and seed a new random number generator.
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_mt(state);
            gmp_lib.gmp_randseed_ui(state, 100000U);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Generate one Gaussian random floating-point numbers.
            Assert.IsTrue(mpfr_lib.mpfr_nrandom(rop, state, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Free all memory occupied by state and rop.
            gmp_lib.gmp_randclear(state);
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_erandom()
        {
            // Create, initialize, and seed a new random number generator.
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_mt(state);
            gmp_lib.gmp_randseed_ui(state, 100000U);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Generate one exponential random floating-point numbers.
            Assert.IsTrue(mpfr_lib.mpfr_erandom(rop, state, mpfr_rnd_t.MPFR_RNDN) < 0);

            // Free all memory occupied by state and rop.
            gmp_lib.gmp_randclear(state);
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_greater_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 > op2 is false.
            Assert.IsTrue(mpfr_lib.mpfr_greater_p(op1, op2) == 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_greaterequal_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 >= op2.
            Assert.IsTrue(mpfr_lib.mpfr_greaterequal_p(op1, op2) != 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_hypot()
        {
            // Create, initialize, and set a new floating-point number x to -3.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, -3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 4.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number z.
            mpfr_t z = new mpfr_t();
            mpfr_lib.mpfr_init2(z, 64U);

            // Set z = sqrt(x^2 + y^2).
            Assert.IsTrue(mpfr_lib.mpfr_hypot(z, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of z is 5.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(z, 5) == 0);

            // Release unmanaged memory allocated for x, y, and z.
            mpfr_lib.mpfr_clears(x, y, z, null);
        }

        [TestMethod]
        public void mpfr_inexflag_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_inexflag();
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_inf_p()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is not infinity.
            Assert.IsTrue(mpfr_lib.mpfr_inf_p(op) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_init()
        {
            // Create and initialize a new floating-point number x.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);

            // Assert that the value of x is NaN.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_init_set()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is not infinity.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_init_set_d()
        {
            // Create, initialize, and set a new floating-point number rop to 10.0.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(rop, 10.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_init_set_f()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpf_t op = new mpf_t();
            gmp_lib.mpf_init_set_si(op, 1);

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_f(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 1.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpf_clear(op);
        }

        [TestMethod]
        public void mpfr_init_set_q()
        {
            // Create, initialize, and set a new rational op to 1.
            mpq_t op = "1/1";

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_q(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 1.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpq_clear(op);
        }

        [TestMethod]
        public void mpfr_init_set_si()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(rop, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_init_set_str()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t x = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_str(x, "10.4", 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is not infinity.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(x, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_init_set_ui()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_ui(rop, 10U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is not infinity.
            Assert.IsTrue(mpfr_lib.mpfr_get_ui(rop, mpfr_rnd_t.MPFR_RNDN) == 10U);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_init_set_z()
        {
            // Create, initialize, and set a new integer op to 1.
            mpz_t op = "1";

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            Assert.IsTrue(mpfr_lib.mpfr_init_set_z(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is not infinity.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpz_clear(op);
        }

        [TestMethod]
        public void mpfr_init2()
        {
            // Create and initialize a new floating-point number x with 64-bit precision.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);

            // Assert that the value of x is NaN, and that its precision is 64 bits.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);
            uint p = mpfr_lib.mpfr_get_prec(x);
            Assert.IsTrue(mpfr_lib.mpfr_get_prec(x) == 64U);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_inp_str()
        {
            // Create and initialize op.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);

            // Write op to a temporary file.
            string pathname = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(pathname, "123456");

            // Read op from the temporary file, and assert that the number of bytes read is 6.
            ptr<FILE> stream = new ptr<FILE>();
            _wfopen_s(out stream.Value.Value, pathname, "r");
            Assert.IsTrue(mpfr_lib.mpfr_inp_str(op, stream, 10, mpfr_rnd_t.MPFR_RNDN) == 6);
            fclose(stream.Value.Value);

            // Assert that op is 123456.
            Assert.IsTrue(mpfr_lib.mpfr_get_ui(op, mpfr_rnd_t.MPFR_RNDN) == 123456U);

            // Delete temporary file.
            System.IO.File.Delete(pathname);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_inits()
        {
            // Create new floating-point numbers x1, x2 and x3.
            mpfr_t x1 = new mpfr_t();
            mpfr_t x2 = new mpfr_t();
            mpfr_t x3 = new mpfr_t();

            // Initialize the floating-point numbers.
            mpfr_lib.mpfr_inits(x1, x2, x3, null);

            // Assert that their value is 0.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x1) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x2) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x3) != 0);

            // Release unmanaged memory allocated for the floating-point numbers.
            mpfr_lib.mpfr_clears(x1, x2, x3, null);
        }

        [TestMethod]
        public void mpfr_inits2()
        {
            // Create new floating-point numbers x1, x2 and x3.
            mpfr_t x1 = new mpfr_t();
            mpfr_t x2 = new mpfr_t();
            mpfr_t x3 = new mpfr_t();

            // Initialize the floating-point numbers.
            mpfr_lib.mpfr_inits2(64U, x1, x2, x3, null);

            // Assert that their value is 0 and precision is 64 bits.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x1) != 0 && mpfr_lib.mpfr_get_prec(x1) == 64U);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x2) != 0 && mpfr_lib.mpfr_get_prec(x2) == 64U);
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x3) != 0 && mpfr_lib.mpfr_get_prec(x3) == 64U);

            // Release unmanaged memory allocated for the floating-point numbers.
            mpfr_lib.mpfr_clears(x1, x2, x3, null);
        }

        [TestMethod]
        public void mpfr_integer_p()
        {
            // Create, initialize, and set a new floating-point number op to 10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is an integer.
            Assert.IsTrue(mpfr_lib.mpfr_integer_p(op) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_j0()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = J0(op).
            Assert.IsTrue(mpfr_lib.mpfr_j0(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "-0.243371750714207143215e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_j1()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = J0(op).
            Assert.IsTrue(mpfr_lib.mpfr_j1(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "-0.554727618489979474337e-1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_jn()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = J0(op).
            Assert.IsTrue(mpfr_lib.mpfr_jn(rop, 3, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.144974266424802618878e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_less_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 < op2 is false.
            Assert.IsTrue(mpfr_lib.mpfr_less_p(op1, op2) == 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_lessequal_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 <= op2.
            Assert.IsTrue(mpfr_lib.mpfr_lessequal_p(op1, op2) != 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_lessgreater_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op1 < op2 is false.
            Assert.IsTrue(mpfr_lib.mpfr_lessgreater_p(op1, op2) == 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_lgamma()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(|Gamma(op)|).
            int sign = 0;
            Assert.IsTrue(mpfr_lib.mpfr_lgamma(rop, ref sign, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.137108263716202786516e2" && sign == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_lgamma_2()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(|Gamma(op)|).
            ptr<int> sign = new ptr<int>(0);
            Assert.IsTrue(mpfr_lib.mpfr_lgamma(rop, sign, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.137108263716202786516e2" && sign.Value == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_li2()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to Re(Dilog(op)).
            Assert.IsTrue(mpfr_lib.mpfr_li2(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.449271207859561792596e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_lngamma()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(Gamma(op)).
            Assert.IsTrue(mpfr_lib.mpfr_lngamma(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.137108263716202786516e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_log()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(op).
            Assert.IsTrue(mpfr_lib.mpfr_log(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.234180580614732701452e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_log_ui()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(10).
            Assert.IsTrue(mpfr_lib.mpfr_log_ui(rop, 10U, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.230258509299404568404e1");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_log10()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log10(op).
            Assert.IsTrue(mpfr_lib.mpfr_log10(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.101703333929878036968e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_log1p()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log(1 + op).
            Assert.IsTrue(mpfr_lib.mpfr_log1p(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.243361335540044980788e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_log2()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop to log10(op).
            Assert.IsTrue(mpfr_lib.mpfr_log2(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop and sign.
            Assert.IsTrue(rop.ToString() == "0.337851162325372986173e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_max()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = max(op1, op2).
            Assert.IsTrue(mpfr_lib.mpfr_max(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_min()
        {
            // Create, initialize, and set a new floating-point number op1 to -210.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = max(op1, op2).
            Assert.IsTrue(mpfr_lib.mpfr_min(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -210.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -210.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_min_prec()
        {
            // Create and initialize a new floating-point number x.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(x, 10.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the minimum precision in bits to store the value of x.
            Assert.IsTrue(mpfr_lib.mpfr_min_prec(x) == 3);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_modf()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number iop.
            mpfr_t iop = new mpfr_t();
            mpfr_lib.mpfr_init2(iop, 64U);

            // Create and initialize a new floating-point number fop.
            mpfr_t fop = new mpfr_t();
            mpfr_lib.mpfr_init2(fop, 64U);

            // Set rop to log10(op).
            Assert.IsTrue(mpfr_lib.mpfr_modf(iop, fop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of iop and fop.
            Assert.IsTrue(iop.ToString() == "0.100000000000000000000e2");
            Assert.IsTrue(fop.ToString() == "0.400000000000000355271e0");

            // Release unmanaged memory allocated for iop, fop, and op.
            mpfr_lib.mpfr_clears(iop, fop, op, null);
        }

        [TestMethod]
        public void mpfr_mul()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 * op2.
            Assert.IsTrue(mpfr_lib.mpfr_mul(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2100.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2100.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_mul_2exp()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_2exp(rop, op1, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 25600.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 25600.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_2si()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_2si(rop, op1, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 25600.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 25600.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_2ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 2^8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_2ui(rop, op1, 8U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 25600.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 25600.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_d()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_d(rop, op1, 8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 800.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 800.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_q()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new rational op2 to -210.
            mpq_t op2 = "-210/1";

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 * op2.
            Assert.IsTrue(mpfr_lib.mpfr_mul_q(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2100.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2100.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpq_clear(op2);
        }

        [TestMethod]
        public void mpfr_mul_si()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_si(rop, op1, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 800.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 800.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 * 8.
            Assert.IsTrue(mpfr_lib.mpfr_mul_ui(rop, op1, 8U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 800.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 800.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_mul_z()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to -210.
            mpz_t op2 = "-210";

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 * op2.
            Assert.IsTrue(mpfr_lib.mpfr_mul_z(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -2100.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -2100.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        public void mpfr_nan_p()
        {
            // Create and initialize a new floating-point number op.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);

            // Assert that op is NaN.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(op) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_nanflag_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_nanflag();
            Assert.IsTrue(mpfr_lib.mpfr_nanflag_p() == 0);
        }

        [TestMethod]
        public void mpfr_neg()
        {
            // Create, initialize, and set a new floating-point number  to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = -op1.
            Assert.IsTrue(mpfr_lib.mpfr_neg(rop, op1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of z is -10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -10.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_nextabove()
        {
            // Create, initialize, and set a new floating-point number x to 10.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Move x to next above and then next below.
            mpfr_lib.mpfr_nextabove(x);
            mpfr_lib.mpfr_nextbelow(x);

            // Assert that the value of x is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_nextbelow()
        {
            // Create, initialize, and set a new floating-point number x to 10.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Move x to next above and then next below.
            mpfr_lib.mpfr_nextabove(x);
            mpfr_lib.mpfr_nextbelow(x);

            // Assert that the value of x is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_nexttoward()
        {
            // Create, initialize, and set a new floating-point number x to 10.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            mpfr_t y1 = "11.0";
            mpfr_t y2 = "12.0";

            // Move x toward y1 then y2.
            mpfr_lib.mpfr_nexttoward(x, y1);
            mpfr_lib.mpfr_nexttoward(x, y2);

            // Assert that the value of x is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for x, y1, and y2.
            mpfr_lib.mpfr_clears(x, y1, y2, null);
        }

        [TestMethod]
        public void mpfr_number_p()
        {
            // Create, initialize, and set a new floating-point number op to 10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is an integer.
            Assert.IsTrue(mpfr_lib.mpfr_number_p(op) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 _wfopen_s(out IntPtr pFile, String filename, String mode);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern Int32 fclose(IntPtr stream);

        [TestMethod]
        public void mpfr_out_str()
        {
            // Create, initialize, and set the value of op to 123456.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            mpfr_lib.mpfr_set_ui(op, 123456U, mpfr_rnd_t.MPFR_RNDN);

            // Get a temporary file.
            string pathname = System.IO.Path.GetTempFileName();

            // Open temporary file for writing.
            ptr<FILE> stream = new ptr<FILE>();
            _wfopen_s(out stream.Value.Value, pathname, "w");

            // Write op to temporary file, and assert that the number of bytes written is 24.
            Assert.IsTrue(mpfr_lib.mpfr_out_str(stream, 10, 0, op, mpfr_rnd_t.MPFR_RNDN) == 24);

            // Close temporary file.
            fclose(stream.Value.Value);

            // Assert that the content of the temporary file is "123456".
            string result = System.IO.File.ReadAllText(pathname);
            Assert.IsTrue(result == "1.23456000000000000000e5");

            // Delete temporary file.
            System.IO.File.Delete(pathname);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_fpif_import_export()
        {
            // Create, initialize, and set the value of op to 123456.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            mpfr_lib.mpfr_set_ui(op, 123456U, mpfr_rnd_t.MPFR_RNDN);

            // Get a temporary file.
            string pathname = System.IO.Path.GetTempFileName();

            // Open temporary file for writing.
            ptr<FILE> stream = new ptr<FILE>();
            _wfopen_s(out stream.Value.Value, pathname, "w");

            // Export op to temporary file.
            Assert.IsTrue(mpfr_lib.mpfr_fpif_export(stream, op) == 0);
            fclose(stream.Value.Value);

            // Read op from the temporary file.
            mpfr_lib.mpfr_set_ui(op, 0, mpfr_rnd_t.MPFR_RNDN);
            stream = new ptr<FILE>();
            _wfopen_s(out stream.Value.Value, pathname, "r");
            Assert.IsTrue(mpfr_lib.mpfr_fpif_import(op, stream) == 0);
            fclose(stream.Value.Value);

            // Assert that op is 123456.
            Assert.IsTrue(mpfr_lib.mpfr_get_ui(op, mpfr_rnd_t.MPFR_RNDN) == 123456U);

            // Delete temporary file.
            System.IO.File.Delete(pathname);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_overflow_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_overflow();
            Assert.IsTrue(mpfr_lib.mpfr_overflow_p() == 0);
        }

        [TestMethod]
        public void mpfr_pow()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 3.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1^op2.
            Assert.IsTrue(mpfr_lib.mpfr_pow(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1000.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1000.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_pow_si()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1^3.
            Assert.IsTrue(mpfr_lib.mpfr_pow_si(rop, op1, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1000.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1000.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_pow_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1^3.
            Assert.IsTrue(mpfr_lib.mpfr_pow_ui(rop, op1, 3U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1000.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1000.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_pow_z()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to -210.
            mpz_t op2 = "3";

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1^op2.
            Assert.IsTrue(mpfr_lib.mpfr_pow_z(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1000.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1000.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        public void mpfr_prec_round()
        {
            // Create and initialize a new floating-point number x with 64-bit precision.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);

            // Round x to precision 128 bits.
            Assert.IsTrue(mpfr_lib.mpfr_prec_round(x, 128U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that precision has changed to 128 bits.
            Assert.IsTrue(mpfr_lib.mpfr_get_prec(x) == 128U);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_print_rnd_mode()
        {
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDA).ToString() == "MPFR_RNDA");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDD).ToString() == "MPFR_RNDD");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDF).ToString() == "MPFR_RNDF");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDN).ToString() == "MPFR_RNDN");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDU).ToString() == "MPFR_RNDU");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDZ).ToString() == "MPFR_RNDZ");
            Assert.IsTrue(mpfr_lib.mpfr_print_rnd_mode(mpfr_rnd_t.MPFR_RNDNA) == char_ptr.Zero);
        }

        [TestMethod]
        public void mpfr_rec_sqrt()
        {
            // Create, initialize, and set a new floating-point number op to 25.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 25, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 1 / sqrt(op).
            Assert.IsTrue(mpfr_lib.mpfr_rec_sqrt(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.200000000000000000003e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_regular_p()
        {
            // Create, initialize, and set a new floating-point number op to 10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is an integer.
            Assert.IsTrue(mpfr_lib.mpfr_regular_p(op) != 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_reldiff()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = |op1 - op2| / op1.
            mpfr_lib.mpfr_reldiff(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN);

            // Assert that the value of z is 22.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 22.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_remainder()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 3.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            Assert.IsTrue(mpfr_lib.mpfr_remainder(r, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z.
            Assert.IsTrue(r.ToString() == "0.100000000000000000000e1");

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_remquo()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 7.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 7, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            int q = 0;
            Assert.IsTrue(mpfr_lib.mpfr_remquo(r, ref q, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z and q.
            Assert.IsTrue(r.ToString() == "0.200000000000000000000e1" && q == 14);

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_remquo_2()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to 7.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, 7, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number r.
            mpfr_t r = new mpfr_t();
            mpfr_lib.mpfr_init2(r, 64U);

            // Set r = x - n * y where n = trunc(x / y).
            ptr<int> q = new ptr<int>(0);
            Assert.IsTrue(mpfr_lib.mpfr_remquo(r, q, x, y, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of z and q.
            Assert.IsTrue(r.ToString() == "0.200000000000000000000e1" && q.Value == 14);

            // Release unmanaged memory allocated for r, x, and y.
            mpfr_lib.mpfr_clears(r, x, y, null);
        }

        [TestMethod]
        public void mpfr_rint()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint(rop, op, mpfr_rnd_t.MPFR_RNDN) == -2);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.250000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rint_ceil()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint_ceil(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.260000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rint_floor()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint_floor(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.250000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rint_round()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint_round(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.250000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rint_roundeven()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint_roundeven(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.250000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_rint_trunc()
        {
            // Create, initialize, and set a new floating-point number op to 25.2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 25.2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_rint_trunc(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.250000000000000000000e2");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_root()
        {
            // Create, initialize, and set a new floating-point number op to 32.0.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 32.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op^(1/5).
            Assert.IsTrue(mpfr_lib.mpfr_root(rop, op, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.200000000000000000000e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_round()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_round(rop, op) == -2);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_roundeven()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = round(op).
            Assert.IsTrue(mpfr_lib.mpfr_roundeven(rop, op) == -2);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sec()
        {
            // Create, initialize, and set a new floating-point number op to pi.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_const_pi(op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = csc(op).
            Assert.IsTrue(mpfr_lib.mpfr_sec(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert that the value of rop is -1.
            Assert.IsTrue(mpfr_lib.mpfr_cmp_si(rop, -1) == 0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sech()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = sech(op).
            Assert.IsTrue(mpfr_lib.mpfr_sech(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.648054273663885399581e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_set()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 128U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(rop, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op to -210.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 128U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assign the value of op to rop.
            Assert.IsTrue(mpfr_lib.mpfr_set(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of x is -210.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -210.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_set_d()
        {
            // Create and initialize a new floating-point number.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 128U);

            // Set rop to -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_set_d(rop, -123.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of x is -123.0.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -123.0);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        [TestCategory("mpfr_set_default_prec")]
        public void mpfr_set_default_prec()
        {
            // Set default precision to 128 bits.
            mpfr_lib.mpfr_set_default_prec(128U);

            // Assert that the value of x is 128 bits.
            Assert.IsTrue(mpfr_lib.mpfr_get_default_prec() == 128U);
        }

        [TestMethod]
        public void mpfr_set_default_rounding_mode()
        {
            // Set default rounding mode.
            mpfr_lib.mpfr_set_default_rounding_mode(mpfr_rnd_t.MPFR_RNDN);

            // Assert default rounding mode.
            Assert.IsTrue(mpfr_lib.mpfr_get_default_rounding_mode() == mpfr_rnd_t.MPFR_RNDN);
        }

        [TestMethod]
        public void mpfr_set_divby0()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_divby0();
            Assert.IsTrue(mpfr_lib.mpfr_divby0_p() != 0);
        }


        [TestMethod]
        [TestCategory("mpfr_set_emax_emin")]
        public void mpfr_set_emax()
        {
            // Set max exponent.
            mpfr_lib.mpfr_set_emax(1000);
            Assert.IsTrue(mpfr_lib.mpfr_get_emax() == 1000);
        }

        [TestMethod]
        [TestCategory("mpfr_set_emax_emin")]
        public void mpfr_set_emin()
        {
            // Set max exponent.
            mpfr_lib.mpfr_set_emin(1000);
            Assert.IsTrue(mpfr_lib.mpfr_get_emin() == 1000);
        }

        [TestMethod]
        public void mpfr_set_erangeflag()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_erangeflag();
            Assert.IsTrue(mpfr_lib.mpfr_erangeflag_p() != 0);
        }

        [TestMethod]
        public void mpfr_set_exp()
        {
            // Create, initialize, and set a new floating-point number x to 100.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert exp of x.
            Assert.IsTrue(mpfr_lib.mpfr_get_exp(x) == 7);

            // Set exponent of x.
            Assert.IsTrue(mpfr_lib.mpfr_set_exp(x, 5) == 0);

            // Assert x and its exp.
            Assert.IsTrue(mpfr_lib.mpfr_get_exp(x) == 5);
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 25.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_f()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpf_t op = new mpf_t();
            gmp_lib.mpf_init_set_si(op, 1);

            // Create and initialize new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op.
            Assert.IsTrue(mpfr_lib.mpfr_set_f(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that rop is 1.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpf_clear(op);
        }

        [TestMethod]
        public void mpfr_set_flt()
        {
            // Create, initialize, and set a new floating-point number rop to 10.0.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_flt(rop, (float)10.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_inexflag()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_inexflag();
            Assert.IsTrue(mpfr_lib.mpfr_inexflag_p() != 0);
        }

        [TestMethod]
        public void mpfr_set_inf()
        {
            // Create, initialize, and set a new floating-point number x to -infinity.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            mpfr_lib.mpfr_set_inf(x, -1);

            // Assert x is infinity.
            Assert.IsTrue(mpfr_lib.mpfr_inf_p(x) != 0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_nan()
        {
            // Create, initialize, and set a new floating-point number x to NaN.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            mpfr_lib.mpfr_set_nan(x);

            // Assert x is NaN.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_nanflag()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_nanflag();
            Assert.IsTrue(mpfr_lib.mpfr_nanflag_p() != 0);
        }

        [TestMethod]
        public void mpfr_set_overflow()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_overflow();
            Assert.IsTrue(mpfr_lib.mpfr_overflow_p() != 0);
        }

        [TestMethod]
        public void mpfr_set_prec()
        {
            // Create and initialize a new floating-point number x.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init(x);

            // Set its precision to 64 bits.
            mpfr_lib.mpfr_set_prec(x, 64U);

            // Assert that the value of x is 0.0, and that its precision is 64 bits.
            Assert.IsTrue(mpfr_lib.mpfr_nan_p(x) != 0);
            Assert.IsTrue(mpfr_lib.mpfr_get_prec(x) == 64U);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_prec_raw()
        {
            // Create, initialize, and set a new rational y to 200 / 3.
            mpq_t y = new mpq_t();
            gmp_lib.mpq_init(y);
            gmp_lib.mpq_set_ui(y, 200, 3U);

            // Create, initialize, and set a new floating-point number x to y.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 128U);
            Assert.IsTrue(mpfr_lib.mpfr_set_q(x, y, mpfr_rnd_t.MPFR_RNDN) == -1);

            Assert.IsTrue(x.ToString() == "0.6666666666666666666666666666666666666654e2");

            // Change precision of x, and set its value to 10000 / 3.
            mpfr_lib.mpfr_set_prec_raw(x, 8U);
            gmp_lib.mpq_set_ui(y, 10000, 3U);
            Assert.IsTrue(mpfr_lib.mpfr_set_q(x, y, mpfr_rnd_t.MPFR_RNDN) == -1);

            Assert.IsTrue(x.ToString() == "0.3328e4");

            // Restore precision of x.
            mpfr_lib.mpfr_set_prec_raw(x, 128U);

            // Release unmanaged memory allocated for x and y.
            mpfr_lib.mpfr_clear(x);
            gmp_lib.mpq_clear(y);
        }

        [TestMethod]
        public void mpfr_set_q()
        {
            // Create, initialize, and set a new rational op to 1.
            mpq_t op = "1/1";

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_q(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 1.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpq_clear(op);
        }

        [TestMethod]
        public void mpfr_set_si()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(rop, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_sj()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_sj(rop, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_sj(rop, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_si_2exp()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10 * 2^5.
            Assert.IsTrue(mpfr_lib.mpfr_set_si_2exp(rop, 10, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 320.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 320);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_sj_2exp()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10 * 2^5.
            Assert.IsTrue(mpfr_lib.mpfr_set_sj_2exp(rop, 10, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 320.
            Assert.IsTrue(mpfr_lib.mpfr_get_sj(rop, mpfr_rnd_t.MPFR_RNDN) == 320);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_str()
        {
            // Create, initialize, and set a new floating-point number x to 0.0234.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            char_ptr value = new char_ptr("0.234e-4");
            Assert.IsTrue(mpfr_lib.mpfr_set_str(x, value, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that x is 0.0234.
            Assert.IsTrue(x.ToString() == "0.233999999999999999999e-4");

            // Release unmanaged memory allocated for x and value.
            mpfr_lib.mpfr_clear(x);
            gmp_lib.free(value);
        }

        [TestMethod]
        public void mpfr_set_ui()
        {
            // Create and initialize a new floating-point number.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 128U);

            // Set x to 100.
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(x, 100U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of x is 100.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 100.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_uj()
        {
            // Create and initialize a new floating-point number.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 128U);

            // Set x to 100.
            Assert.IsTrue(mpfr_lib.mpfr_set_uj(x, 100U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of x is 100.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == 100.0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_set_ui_2exp()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10 * 2^5.
            Assert.IsTrue(mpfr_lib.mpfr_set_ui_2exp(rop, 10U, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 320.
            Assert.IsTrue(mpfr_lib.mpfr_get_si(rop, mpfr_rnd_t.MPFR_RNDN) == 320);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_uj_2exp()
        {
            // Create, initialize, and set a new floating-point number rop to 10.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10 * 2^5.
            Assert.IsTrue(mpfr_lib.mpfr_set_uj_2exp(rop, 10U, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is 320.
            Assert.IsTrue(mpfr_lib.mpfr_get_uj(rop, mpfr_rnd_t.MPFR_RNDN) == 320);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_set_underflow()
        {
            // Set flag and assert that flag is set.
            mpfr_lib.mpfr_set_underflow();
            Assert.IsTrue(mpfr_lib.mpfr_underflow_p() != 0);
        }

        [TestMethod]
        public void mpfr_set_z()
        {
            // Create, initialize, and set a new integer op to 200.
            mpz_t op = new mpz_t();
            gmp_lib.mpz_init(op);
            gmp_lib.mpz_set_ui(op, 200U);

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_z(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that rop is 200.
            Assert.IsTrue(rop.ToString() == "0.200000000000000000000e3");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpz_clear(op);
        }

        [TestMethod]
        public void mpfr_set_z_2exp()
        {
            // Create, initialize, and set a new integer op to 200.
            mpz_t op = new mpz_t();
            gmp_lib.mpz_init(op);
            gmp_lib.mpz_set_ui(op, 200U);

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op * 2^5.
            Assert.IsTrue(mpfr_lib.mpfr_set_z_2exp(rop, op, 5, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that rop is 200.
            Assert.IsTrue(rop.ToString() == "0.640000000000000000000e4");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.mpz_clear(op);
        }

        [TestMethod]
        public void mpfr_set_zero()
        {
            // Create, initialize, and set a new floating-point number x to +0.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 64U);
            mpfr_lib.mpfr_set_zero(x, 1);

            // Assert x is 0.
            Assert.IsTrue(mpfr_lib.mpfr_zero_p(x) != 0);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_setsign()
        {
            // Create, initialize, and set a new integer op to 200.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, 200U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number rop to op.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init(rop);

            // Set rop = -op.
            Assert.IsTrue(mpfr_lib.mpfr_setsign(rop, op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that rop is -200.
            Assert.IsTrue(rop.ToString() == "-0.20000000000000000e3");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sgn()
        {
            // Create, initialize, and set a new integer op to 200.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_ui(op, 200U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert sign of op..
            Assert.IsTrue(mpfr_lib.mpfr_sgn(op) > 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_si_div()
        {
            // Create, initialize, and set a new floating-point number op2 to 4.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = 100 / op2.
            Assert.IsTrue(mpfr_lib.mpfr_si_div(rop, 100, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 25.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 25.0);

            // Release unmanaged memory allocated for rop and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_si_sub()
        {
            // Create, initialize, and set a new floating-point number op2 to 4.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = 100 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_si_sub(rop, 100, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 96.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 96.0);

            // Release unmanaged memory allocated for rop and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_signbit()
        {
            // Create, initialize, and set a new integer op to 200.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_ui(op, 200U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert sign of op..
            Assert.IsTrue(mpfr_lib.mpfr_signbit(op) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_sin()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = sin(op).
            Assert.IsTrue(mpfr_lib.mpfr_sin(rop, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.841470984807896506665e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sin_cos()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number sop.
            mpfr_t sop = new mpfr_t();
            mpfr_lib.mpfr_init2(sop, 64U);

            // Create and initialize a new floating-point number cop.
            mpfr_t cop = new mpfr_t();
            mpfr_lib.mpfr_init2(cop, 64U);

            // Set sop = sin(op), cop = cos(op).
            Assert.IsTrue(mpfr_lib.mpfr_sin_cos(sop, cop, op, mpfr_rnd_t.MPFR_RNDN) == 5);

            // Assert the value of sop and cop.
            Assert.IsTrue(sop.ToString() == "0.841470984807896506665e0");
            Assert.IsTrue(cop.ToString() == "0.540302305868139717414e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(sop, cop, op, null);
        }

        [TestMethod]
        public void mpfr_sinh()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = sinh(op).
            Assert.IsTrue(mpfr_lib.mpfr_sinh(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.117520119364380145688e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sinh_cosh()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number sop.
            mpfr_t sop = new mpfr_t();
            mpfr_lib.mpfr_init2(sop, 64U);

            // Create and initialize a new floating-point number cop.
            mpfr_t cop = new mpfr_t();
            mpfr_lib.mpfr_init2(cop, 64U);

            // Set sop = sinh(op), cop = cosh(op).
            Assert.IsTrue(mpfr_lib.mpfr_sinh_cosh(sop, cop, op, mpfr_rnd_t.MPFR_RNDN) == 10);

            // Assert the value of sop and cop.
            Assert.IsTrue(sop.ToString() == "0.117520119364380145688e1");
            Assert.IsTrue(cop.ToString() == "0.154308063481524377844e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(sop, cop, op, null);
        }

        [TestMethod]
        public void mpfr_snprintf()
        {
            // Allocate unmanaged string with 50 characters.
            char_ptr str = new char_ptr(".................................................");

            mpz_t z = "123456";
            mpq_t q = "123/456";
            mpf_t f = "12345e6";
            mpfr_t r = "12345e6";
            mp_limb_t m = 123456;

            // Print to string.
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 50, "%Zd - %QX - %Fa - %Mo", z, q, f, m) == 42);
            Assert.IsTrue(str.ToString() == "123456 - 7B/1C8 - 0x2.dfd1c04p+32 - 361100");

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Zd", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Zi", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%ZX", z) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Zo", z) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.mpz_clear(z);

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Qd", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Qi", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%QX", q) == 6);
            Assert.IsTrue(str.ToString() == "7B/1C8");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Qo", q) == 7);
            Assert.IsTrue(str.ToString() == "173/710");
            gmp_lib.mpq_clear(q);

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Fe", f) == 12);
            Assert.IsTrue(str.ToString() == "1.234500e+10");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Ff", f) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Fg", f) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Fa", f) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.mpf_clear(f);

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Re", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Rf", r) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Rg", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Ra", r) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            mpfr_lib.mpfr_clear(r);

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Md", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Mi", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%MX", m) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Mo", m) == 6);
            Assert.IsTrue(str.ToString() == "361100");

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.ToString() == "2964619C7");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.ToString() == "122621414707");

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%hd", (short)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            //Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.ToString() == "A");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            //Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");
            //Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");

            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.ToString() == "Hello World!");

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "123456%n", p) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            Assert.IsTrue(mpfr_lib.mpfr_snprintf(str, 41, "%p", p) == 2 * IntPtr.Size);

            gmp_lib.free(str);
        }

        [TestMethod]
        public void mpfr_sprintf()
        {
            // Allocate unmanaged string with 50 characters.
            char_ptr str = new char_ptr(".................................................");

            mpz_t z = "123456";
            mpq_t q = "123/456";
            mpf_t f = "12345e6";
            mpfr_t r = "12345e6";
            mp_limb_t m = 123456;

            // Print to string.
            Assert.IsTrue(gmp_lib.gmp_sprintf(str, "%Zd - %QX - %Fa - %Mo", z, q, f, m) == 42);
            Assert.IsTrue(str.ToString() == "123456 - 7B/1C8 - 0x2.dfd1c04p+32 - 361100");

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Zd", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Zi", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%ZX", z) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Zo", z) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.mpz_clear(z);

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Qd", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Qi", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%QX", q) == 6);
            Assert.IsTrue(str.ToString() == "7B/1C8");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Qo", q) == 7);
            Assert.IsTrue(str.ToString() == "173/710");
            gmp_lib.mpq_clear(q);

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Fe", f) == 12);
            Assert.IsTrue(str.ToString() == "1.234500e+10");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Ff", f) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Fg", f) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Fa", f) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.mpf_clear(f);

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Re", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Rf", r) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Rg", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Ra", r) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            mpfr_lib.mpfr_clear(r);

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Md", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Mi", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%MX", m) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Mo", m) == 6);
            Assert.IsTrue(str.ToString() == "361100");

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.ToString() == "2964619C7");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.ToString() == "122621414707");

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%hd", (short)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            //Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.ToString() == "A");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            //Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");
            //Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");

            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.ToString() == "Hello World!");

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "123456%n", p) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            Assert.IsTrue(mpfr_lib.mpfr_sprintf(str, "%p", p) == 2 * IntPtr.Size);

            gmp_lib.free(str);
        }

        [TestMethod]
        public void mpfr_sqr()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op^2.
            Assert.IsTrue(mpfr_lib.mpfr_sqr(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.100000000000000000000e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sqrt()
        {
            // Create, initialize, and set a new floating-point number op to 100.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_si(op, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = sqrt(op).
            Assert.IsTrue(mpfr_lib.mpfr_sqrt(rop, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of z is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_sqrt_ui()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = sqrt(100).
            Assert.IsTrue(mpfr_lib.mpfr_sqrt_ui(rop, 100U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_strtofr()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Parse first float in string.
            char_ptr nptr = new char_ptr("10.0  20.0");
            ptr<char_ptr> endptr = new ptr<char_ptr>();
            Assert.IsTrue(mpfr_lib.mpfr_strtofr(rop, nptr, endptr, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);
            Assert.IsTrue(endptr.Value.ToString() == "  20.0");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.free(nptr);
        }

        [TestMethod]
        public void mpfr_strtofr_2()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Parse first float in string.
            char_ptr nptr = new char_ptr("10.0  20.0");
            char_ptr endptr = new char_ptr();
            Assert.IsTrue(mpfr_lib.mpfr_strtofr(rop, nptr, ref endptr, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);
            Assert.IsTrue(endptr.ToString() == "  20.0");

            // Release unmanaged memory allocated for rop.
            mpfr_lib.mpfr_clear(rop);
            gmp_lib.free(nptr);
        }

        [TestMethod]
        public void mpfr_sub()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_sub(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, null);
        }

        [TestMethod]
        public void mpfr_sub_d()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 - 8.
            Assert.IsTrue(mpfr_lib.mpfr_sub_d(rop, op1, 8.0, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 92.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 92.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_sub_q()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new rational op2 to -210.
            mpq_t op2 = "-210/1";

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_sub_q(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpq_clear(op2);
        }

        [TestMethod]
        public void mpfr_sub_si()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 - 8.
            Assert.IsTrue(mpfr_lib.mpfr_sub_si(rop, op1, 8, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 92.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 92.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_sub_ui()
        {
            // Create, initialize, and set a new floating-point number op1 to 100.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 100, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set z = op1 - 8.
            Assert.IsTrue(mpfr_lib.mpfr_sub_ui(rop, op1, 8U, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 92.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 92.0);

            // Release unmanaged memory allocated for rop and op1.
            mpfr_lib.mpfr_clears(rop, op1, null);
        }

        [TestMethod]
        public void mpfr_sub_z()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new integer op2 to -210.
            mpz_t op2 = "-210";

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_sub_z(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, null);
            gmp_lib.mpz_clear(op2);
        }

        [TestMethod]
        [TestCategory("mpfr_subnormalize")]
        public void mpfr_subnormalize()
        {
            // Emulate IEEE 754 double precision.
            mpfr_lib.mpfr_set_default_prec(53U);
            mpfr_lib.mpfr_set_emin(-1073);
            mpfr_lib.mpfr_set_emax(1023);

            // Create and initialize near-subnormal floating-point number x.
            mpfr_t x = "0x1.1235P-1021";

            // Create subnormal by dividing by 34.3, and round it emulating subnormal.
            int i = mpfr_lib.mpfr_div_d(x, x, 34.3, mpfr_rnd_t.MPFR_RNDN);
            i = mpfr_lib.mpfr_subnormalize(x, i, mpfr_rnd_t.MPFR_RNDN);

            // Release unmanaged memory allocated for x.
            mpfr_lib.mpfr_clear(x);
        }

        [TestMethod]
        public void mpfr_sum()
        {
            // Create, initialize, and set a new floating-point number op1 to 10.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op1, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op2 to 20.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 20, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number op3 to 30.
            mpfr_t op3 = new mpfr_t();
            mpfr_lib.mpfr_init2(op3, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op3, 30, mpfr_rnd_t.MPFR_RNDN) == 0);
            
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Sum({op1, op2, op3}).
            Assert.IsTrue(mpfr_lib.mpfr_sum(rop, new mpfr_t[] { op1, op2, op3 }, 3, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 60.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 60.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op1, op2, op3, null);
        }

        [TestMethod]
        public void mpfr_swap()
        {
            // Create, initialize, and set a new floating-point number x to 10.
            mpfr_t x = new mpfr_t();
            mpfr_lib.mpfr_init2(x, 128U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(x, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create, initialize, and set a new floating-point number y to -210.
            mpfr_t y = new mpfr_t();
            mpfr_lib.mpfr_init2(y, 128U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(y, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Swap the values of x and y.
            mpfr_lib.mpfr_swap(x, y);

            // Assert that the value of x is -210.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(x, mpfr_rnd_t.MPFR_RNDN) == -210.0);

            // Assert that the value of y is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(y, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for x and y.
            mpfr_lib.mpfr_clears(x, y, null);
        }

        [TestMethod]
        public void mpfr_tan()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = tan(op).
            Assert.IsTrue(mpfr_lib.mpfr_tan(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.155740772465490223046e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_tanh()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = tanh(op).
            Assert.IsTrue(mpfr_lib.mpfr_tanh(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.761594155955764888109e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_trunc()
        {
            // Create, initialize, and set a new floating-point number op to 10.4.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_init_set_d(op, 10.4, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = trunc(op).
            Assert.IsTrue(mpfr_lib.mpfr_trunc(rop, op) == -2);

            // Assert that the value of rop is 10.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 10.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_ui_div()
        {
            // Create, initialize, and set a new floating-point number op to 10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 210 / op.
            Assert.IsTrue(mpfr_lib.mpfr_ui_div(rop, 210U, op, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 21.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 21.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_ui_pow()
        {
            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 2^op2.
            Assert.IsTrue(mpfr_lib.mpfr_ui_pow(rop, 2, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1024.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1024.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_ui_pow_ui()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 2^10.
            Assert.IsTrue(mpfr_lib.mpfr_ui_pow_ui(rop, 2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is 1024.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 1024.0);

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_ui_sub()
        {
            // Create, initialize, and set a new floating-point number op2 to -210.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, -210, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = 10 - y.
            Assert.IsTrue(mpfr_lib.mpfr_ui_sub(rop, 10U, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of z is 220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == 220.0);

            // Release unmanaged memory allocated for rop, and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
        }

        [TestMethod]
        public void mpfr_underflow_p()
        {
            // Clear flag and assert that flag is clear.
            mpfr_lib.mpfr_clear_underflow();
            Assert.IsTrue(mpfr_lib.mpfr_underflow_p() == 0);
        }

        [TestMethod]
        public void mpfr_unordered_p()
        {
            // Create, initialize, and set a new floating-point number op1 to 1.
            mpfr_t op1 = new mpfr_t();
            mpfr_lib.mpfr_init2(op1, 64U);
            mpfr_lib.mpfr_set_si(op1, 1, mpfr_rnd_t.MPFR_RNDN);

            // Create, initialize, and set a new floating-point number op2 to 1.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            mpfr_lib.mpfr_set_si(op2, 1, mpfr_rnd_t.MPFR_RNDN);

            // Assert that op1 and op2 are ordered.
            Assert.IsTrue(mpfr_lib.mpfr_unordered_p(op1, op2) == 0);

            // Release unmanaged memory allocated for op1 and op2.
            mpfr_lib.mpfr_clears(op1, op2, null);
        }

        [TestMethod]
        public void mpfr_urandom()
        {
            // Create, initialize, and seed a new random number generator.
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_mt(state);
            gmp_lib.gmp_randseed_ui(state, 100000U);

            // Create, initialize, and set the value of rop to NaN.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Generate a random integer in the range [0, 1].
            Assert.IsTrue(mpfr_lib.mpfr_urandom(rop, state, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Free all memory occupied by state and rop.
            gmp_lib.gmp_randclear(state);
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_urandomb()
        {
            // Create, initialize, and seed a new random number generator.
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_mt(state);
            gmp_lib.gmp_randseed_ui(state, 100000U);

            // Create, initialize, and set the value of rop to NaN.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Generate a random integer in the range [0, 1).
            Assert.IsTrue(mpfr_lib.mpfr_urandomb(rop, state) == 0);

            // Free all memory occupied by state and rop.
            gmp_lib.gmp_randclear(state);
            mpfr_lib.mpfr_clear(rop);
        }

        [TestMethod]
        public void mpfr_vasprintf()
        {
            ptr<char_ptr> str = new ptr<char_ptr>();

            mpz_t z = "123456";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Zd", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Zi", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%ZX", z) == 5);
            Assert.IsTrue(str.Value.ToString() == "1E240");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Zo", z) == 6);
            Assert.IsTrue(str.Value.ToString() == "361100");
            gmp_lib.free(str.Value);
            gmp_lib.mpz_clear(z);

            mpq_t q = "123/456";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Qd", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "123/456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Qi", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "123/456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%QX", q) == 6);
            Assert.IsTrue(str.Value.ToString() == "7B/1C8");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Qo", q) == 7);
            Assert.IsTrue(str.Value.ToString() == "173/710");
            gmp_lib.free(str.Value);
            gmp_lib.mpq_clear(q);

            mpf_t f = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Fe", f) == 12);
            Assert.IsTrue(str.Value.ToString() == "1.234500e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Ff", f) == 18);
            Assert.IsTrue(str.Value.ToString() == "12345000000.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Fg", f) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Fa", f) == 15);
            Assert.IsTrue(str.Value.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str.Value);
            gmp_lib.mpf_clear(f);

            mpfr_t r = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Re", r) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Rf", r) == 18);
            Assert.IsTrue(str.Value.ToString() == "12345000000.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Rg", r) == 10);
            Assert.IsTrue(str.Value.ToString() == "1.2345e+10");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Ra", r) == 15);
            Assert.IsTrue(str.Value.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str.Value);
            mpfr_lib.mpfr_clear(r);

            mp_limb_t m = 123456;
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Md", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Mi", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%MX", m) == 5);
            Assert.IsTrue(str.Value.ToString() == "1E240");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Mo", m) == 6);
            Assert.IsTrue(str.Value.ToString() == "361100");
            gmp_lib.free(str.Value);

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.Value.ToString() == "11111111111");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.Value.ToString() == "11111111111");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.Value.ToString() == "2964619C7");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.Value.ToString() == "122621414707");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%hd", (short)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            //Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.Value.ToString() == "A");
            //gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.Value.ToString() == "1.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.Value.ToString() == "1.000000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000e+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000e+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000E+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.Value.ToString() == "1.000000E+000");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.Value.ToString() == "1");
            gmp_lib.free(str.Value);

            //Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.Value.ToString() == "0x1.000000p+0");
            //gmp_lib.free(str.Value);
            //Assert.IsTrue(mpfr_lib.mpfr_asprintf(str, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.Value.ToString() == "0x1.000004p+0");
            //gmp_lib.free(str.Value);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.Value.ToString() == "Hello World!");
            gmp_lib.free(str.Value);

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "123456%n", p) == 6);
            Assert.IsTrue(str.Value.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            gmp_lib.free(str.Value);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(str, "%p", p) == 2 * IntPtr.Size);
            gmp_lib.free(str.Value);
        }

        [TestMethod]
        public void mpfr_vasprintf_2()
        {
            char_ptr str = new char_ptr();

            mpz_t z = "123456";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Zd", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Zi", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%ZX", z) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Zo", z) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.free(str);
            gmp_lib.mpz_clear(z);

            mpq_t q = "123/456";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Qd", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Qi", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%QX", q) == 6);
            Assert.IsTrue(str.ToString() == "7B/1C8");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Qo", q) == 7);
            Assert.IsTrue(str.ToString() == "173/710");
            gmp_lib.free(str);
            gmp_lib.mpq_clear(q);

            mpf_t f = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Fe", f) == 12);
            Assert.IsTrue(str.ToString() == "1.234500e+10");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Ff", f) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Fg", f) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Fa", f) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str);
            gmp_lib.mpf_clear(f);

            mpfr_t r = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Re", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Rf", r) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Rg", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Ra", r) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.free(str);
            mpfr_lib.mpfr_clear(r);

            mp_limb_t m = 123456;
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Md", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Mi", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%MX", m) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Mo", m) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.free(str);

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.ToString() == "2964619C7");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.ToString() == "122621414707");
            gmp_lib.free(str);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%hd", (short)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            //Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.ToString() == "A");
            //gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            gmp_lib.free(str);

            //Assert.IsTrue(mpfr_lib.mpfr_asprintf(ref str, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");
            //gmp_lib.free(str);
            //Assert.IsTrue(mpfr_lib.mpfr_asprintf(ref str, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000004p+0");
            //gmp_lib.free(str);

            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.ToString() == "Hello World!");
            gmp_lib.free(str);

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "123456%n", p) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            gmp_lib.free(str);
            Assert.IsTrue(mpfr_lib.mpfr_vasprintf(ref str, "%p", p) == 2 * IntPtr.Size);
            gmp_lib.free(str);
        }

        [TestMethod]
        public void mpfr_vsnprintf()
        {
            char_ptr str = new char_ptr(".........................................");

            mpz_t z = "123456";
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Zd", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Zi", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%ZX", z) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Zo", z) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.mpz_clear(z);

            mpq_t q = "123/456";
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Qd", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Qi", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%QX", q) == 6);
            Assert.IsTrue(str.ToString() == "7B/1C8");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Qo", q) == 7);
            Assert.IsTrue(str.ToString() == "173/710");
            gmp_lib.mpq_clear(q);

            mpf_t f = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Fe", f) == 12);
            Assert.IsTrue(str.ToString() == "1.234500e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Ff", f) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Fg", f) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Fa", f) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.mpf_clear(f);

            mpfr_t r = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Re", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Rf", r) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Rg", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Ra", r) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            mpfr_lib.mpfr_clear(r);

            mp_limb_t m = 123456;
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Md", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Mi", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%MX", m) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Mo", m) == 6);
            Assert.IsTrue(str.ToString() == "361100");

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.ToString() == "2964619C7");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.ToString() == "122621414707");

            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%hd", (short)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            //Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.ToString() == "A");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            //Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");
            //Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");

            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.ToString() == "Hello World!");

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "123456%n", p) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(p.Value == 6);
            Assert.IsTrue(mpfr_lib.mpfr_vsnprintf(str, 41, "%p", p) == 2 * IntPtr.Size);

            gmp_lib.free(str);
        }

        [TestMethod]
        public void mpfr_vsprintf()
        {
            // Create string.
            char_ptr str = new char_ptr(".........................................");

            mpz_t z = "123456";
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Zd", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Zi", z) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%ZX", z) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Zo", z) == 6);
            Assert.IsTrue(str.ToString() == "361100");
            gmp_lib.mpz_clear(z);

            mpq_t q = "123/456";
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Qd", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Qi", q) == 7);
            Assert.IsTrue(str.ToString() == "123/456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%QX", q) == 6);
            Assert.IsTrue(str.ToString() == "7B/1C8");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Qo", q) == 7);
            Assert.IsTrue(str.ToString() == "173/710");
            gmp_lib.mpq_clear(q);

            mpf_t f = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Fe", f) == 12);
            Assert.IsTrue(str.ToString() == "1.234500e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Ff", f) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Fg", f) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Fa", f) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            gmp_lib.mpf_clear(f);

            mpfr_t r = "12345e6";
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Re", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Rf", r) == 18);
            Assert.IsTrue(str.ToString() == "12345000000.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Rg", r) == 10);
            Assert.IsTrue(str.ToString() == "1.2345e+10");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Ra", r) == 15);
            Assert.IsTrue(str.ToString() == "0x2.dfd1c04p+32");
            mpfr_lib.mpfr_clear(r);

            mp_limb_t m = 123456;
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Md", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Mi", m) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%MX", m) == 5);
            Assert.IsTrue(str.ToString() == "1E240");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Mo", m) == 6);
            Assert.IsTrue(str.ToString() == "361100");

            mp_ptr n = new mp_ptr(new uint[] { 0x964619c7, 0x00000002 });
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Nd", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Ni", n, n.Size) == 11);
            Assert.IsTrue(str.ToString() == "11111111111");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%NX", n, n.Size) == 9);
            Assert.IsTrue(str.ToString() == "2964619C7");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%No", n, n.Size) == 12);
            Assert.IsTrue(str.ToString() == "122621414707");

            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%hd", (short)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%hhd", (byte)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            //Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%hhc", 'A') == 1);
            //Assert.IsTrue(str.ToString() == "A");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%ld", (Int32)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%lld", (Int64)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            // Instead of %z, use %M.
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%Md", (size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%d", (mp_bitcnt_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%d", (mp_size_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%d", (mp_exp_t)1) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%f", (Double)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%f", (Single)1.0) == 8);
            Assert.IsTrue(str.ToString() == "1.000000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%e", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%e", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000e+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%g", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%g", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%E", (Double)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%E", (Single)1.0) == 13);
            Assert.IsTrue(str.ToString() == "1.000000E+000");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%G", (Double)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%G", (Single)1.0) == 1);
            Assert.IsTrue(str.ToString() == "1");

            //Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%a", (Double)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000000p+0");
            //Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%a", (Single)1.0) == 13);
            //Assert.IsTrue(str.ToString() == "0x1.000004p+0");

            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%s", "Hello World!") == 12);
            Assert.IsTrue(str.ToString() == "Hello World!");

            ptr<int> p = new ptr<int>(12);
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "123456%n", p) == 6);
            Assert.IsTrue(str.ToString() == "123456");
            Assert.IsTrue(mpfr_lib.mpfr_vsprintf(str, "%p", p) == 2 * IntPtr.Size);
            //Assert.IsTrue(str.ToString() == p.ToIntPtr().ToString("X0" + (2 * IntPtr.Size).ToString()));

            // Free allocated unmanaged memory.
            gmp_lib.free(str);
        }

        [TestMethod]
        public void mpfr_y0()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Y0(op).
            Assert.IsTrue(mpfr_lib.mpfr_y0(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.882569642156769579796e-1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_y1()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Y1(op).
            Assert.IsTrue(mpfr_lib.mpfr_y1(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "-0.781212821300288716550e0");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_yn()
        {
            // Create, initialize, and set a new floating-point number op to 1.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 1, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Yn(3, op).
            Assert.IsTrue(mpfr_lib.mpfr_yn(rop, 3, op, mpfr_rnd_t.MPFR_RNDN) == 1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "-0.582151760596472884774e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_z_sub()
        {
            // Create, initialize, and set a new integer op1 to -210.
            mpz_t op1 = "-210";

            // Create, initialize, and set a new floating-point number op2 to 10.
            mpfr_t op2 = new mpfr_t();
            mpfr_lib.mpfr_init2(op2, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op2, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = op1 - op2.
            Assert.IsTrue(mpfr_lib.mpfr_z_sub(rop, op1, op2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that the value of rop is -220.
            Assert.IsTrue(mpfr_lib.mpfr_get_d(rop, mpfr_rnd_t.MPFR_RNDN) == -220.0);

            // Release unmanaged memory allocated for rop, op1, and op2.
            mpfr_lib.mpfr_clears(rop, op2, null);
            gmp_lib.mpz_clear(op1);
        }

        [TestMethod]
        public void mpfr_zero_p()
        {
            // Create, initialize, and set a new floating-point number op to 10.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_d(op, 10, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Assert that op is nopt zero.
            Assert.IsTrue(mpfr_lib.mpfr_zero_p(op) == 0);

            // Release unmanaged memory allocated for op.
            mpfr_lib.mpfr_clear(op);
        }

        [TestMethod]
        public void mpfr_zeta()
        {
            // Create, initialize, and set a new floating-point number op to 2.
            mpfr_t op = new mpfr_t();
            mpfr_lib.mpfr_init2(op, 64U);
            Assert.IsTrue(mpfr_lib.mpfr_set_si(op, 2, mpfr_rnd_t.MPFR_RNDN) == 0);

            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Zeta(op).
            Assert.IsTrue(mpfr_lib.mpfr_zeta(rop, op, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.164493406684822643642e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clears(rop, op, null);
        }

        [TestMethod]
        public void mpfr_zeta_ui()
        {
            // Create and initialize a new floating-point number rop.
            mpfr_t rop = new mpfr_t();
            mpfr_lib.mpfr_init2(rop, 64U);

            // Set rop = Zeta(op).
            Assert.IsTrue(mpfr_lib.mpfr_zeta_ui(rop, 2U, mpfr_rnd_t.MPFR_RNDN) == -1);

            // Assert the value of rop.
            Assert.IsTrue(rop.ToString() == "0.164493406684822643642e1");

            // Release unmanaged memory allocated for rop and op.
            mpfr_lib.mpfr_clear(rop);
        }

        #endregion

    }
}
