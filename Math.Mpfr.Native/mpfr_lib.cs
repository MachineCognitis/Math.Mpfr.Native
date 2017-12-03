
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Math.Gmp.Native;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents all of the functions of the GNU MPFR library.
    /// </summary>
    public static class mpfr_lib
    {

        // Safe handle to the loaded MPFR library.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private static SafeHandle _mpfr_lib = new SafeHandle(_load_mpfr_lib());

        private static IntPtr _load_mpfr_lib()
        {
            // Load MPFR library based on current computer x86 or x64 architecture.
            string folderName = IntPtr.Size == 4 ? "x86" : "x64";
            // Get pathname of executing assembly.
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().EscapedCodeBase;
            // Get directory pathname of MPFR library.
            string libpath = System.IO.Path.GetDirectoryName(System.Uri.UnescapeDataString((new System.UriBuilder(codeBase)).Path)) + System.IO.Path.DirectorySeparatorChar + folderName;
            // Add MPFR library directory to DLL search paths.
            SafeNativeMethods.SetDllDirectory(libpath);
            // Load MPFR library and create safe handle to it.
            IntPtr handle = SafeNativeMethods.LoadLibrary(@"libmpfr-4.dll");
            // Retrieve and cache MPFR dynamic memory allocation functions.
            return handle;
        }

        /// <summary>
        /// The minimum number of bits that can be used to represent the significand of a floating-point number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In the current implementation, <see cref="MPFR_PREC_MIN"/> is 2.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.MPFR_PREC_MAX"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html">GNU MPFR</a></seealso>
        public static readonly mpfr_prec_t MPFR_PREC_MIN = 2;

        /// <summary>
        /// The maximum number of bits that can be used to represent the significand of a floating-point number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In the current implementation, <see cref="MPFR_PREC_MIN"/> is 2,147,483,647.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.MPFR_PREC_MIN"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html">GNU MPFR</a></seealso>
        public static readonly mpfr_prec_t MPFR_PREC_MAX = 2147483647;

        /// <summary>
        /// <see cref="MPFR_VERSION"/> is the version of MPFR.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static readonly int MPFR_VERSION = MPFR_VERSION_NUM(MPFR_VERSION_MAJOR, MPFR_VERSION_MINOR, MPFR_VERSION_PATCHLEVEL);

        /// <summary>
        /// <see cref="MPFR_VERSION_MAJOR"/> is the major MPFR version.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static readonly int MPFR_VERSION_MAJOR = 3;

        /// <summary>
        /// <see cref="MPFR_VERSION_MINOR"/> is the minor MPFR version.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static readonly int MPFR_VERSION_MINOR = 1;

        /// <summary>
        /// <see cref="MPFR_VERSION_PATCHLEVEL"/> is the patch level of MPFR version.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static readonly int MPFR_VERSION_PATCHLEVEL = 6;

        /// <summary>
        /// <see cref="MPFR_VERSION_STRING"/> is the version (with an optional suffix, used in development and pre-release versions) as a string constant.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static readonly string MPFR_VERSION_STRING = "3.1.6";

        /// <summary>
        /// Create an integer in the same format as used by <see cref="MPFR_VERSION"/> from the given <paramref name="major"/>, <paramref name="minor"/> and <paramref name="patchlevel"/>. 
        /// </summary>
        /// <param name="major">The major version.</param>
        /// <param name="minor">The minor version.</param>
        /// <param name="patchlevel">The patch level.</param>
        /// <returns>An integer in the same format as used by <see cref="MPFR_VERSION"/> from the given <paramref name="major"/>, <paramref name="minor"/> and <paramref name="patchlevel"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_version"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        public static int MPFR_VERSION_NUM(int major, int minor, int patchlevel)
        {
            return (((major) << 16) | ((minor) << 8) | (patchlevel));
        }

        /// <summary>
        /// Output <paramref name="op"/> on stream <paramref name="stream"/>, as a string of digits in base <paramref name="base"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        /// <param name="base">The base.</param>
        /// <param name="n">Number of significant digits.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return the number of characters written, or if an error occurred, return 0.</returns>
        /// <remarks>
        /// <para>
        /// The base may vary from 2 to 62. 
        /// Print <paramref name="n"/> significant digits exactly, or if <paramref name="n"/> is 0,
        /// enough digits so that <paramref name="op"/> can be read back exactly (see <see cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>). 
        /// </para>
        /// <para>
        /// In addition to the significant digits, a decimal point (defined by the current locale) at the right of
        /// the first digit and a trailing exponent in base 10, in the form ‘eNNN’, are printed.
        /// If <paramref name="base"/> is greater than 10, ‘@’ will be used instead of ‘e’ as exponent delimiter. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_inp_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Input-and-Output-Functions">GNU MPFR - Input and Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static size_t mpfr_out_str(ptr<FILE> stream, int @base, size_t n, mpfr_t op, mpfr_rnd_t rnd)
        {
            if (IntPtr.Size == 4)
                return SafeNativeMethods.__gmpfr_out_str_x86(stream.Value.Value, @base, (uint)n, op.ToIntPtr(), (int)rnd);
            else
                return SafeNativeMethods.__gmpfr_out_str_x64(stream.Value.Value, @base, (ulong)n, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Input a string in base <paramref name="base"/> from stream <paramref name="stream"/>, rounded in the direction <paramref name="rnd"/>, and put the read float in <paramref name="rop"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="stream">The input stream.</param>
        /// <param name="base">The base.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return the number of bytes read, or if an error occurred, return 0.</returns>
        /// <remarks>
        /// <para>
        /// This function reads a word (defined as a sequence of characters between whitespace) and parses it using <see cref="mpfr_set_str"/>.
        /// See the documentation of <see cref="O:Math.Mpfr.Native.mpfr_strtofr"/> for a detailed description of the valid string formats. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_out_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Input-and-Output-Functions">GNU MPFR - Input and Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static size_t mpfr_inp_str(mpfr_t rop, ptr<FILE> stream, int @base, mpfr_rnd_t rnd)
        {
            if (IntPtr.Size == 4)
                return SafeNativeMethods.__gmpfr_inp_str_x86(rop.ToIntPtr(), stream.Value.Value, @base, (int)rnd);
            else
                return SafeNativeMethods.__gmpfr_inp_str_x64(rop.ToIntPtr(), stream.Value.Value, @base, (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to an <see cref="intmax_t"/> after rounding it with respect to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, 0 is returned and the erange flag is set.
        /// If <paramref name="op"/> is too big for the return type, the function returns the maximum
        /// or the minimum of the corresponding C type, depending on the direction of the overflow;
        /// the erange flag is set too.
        /// See also <see cref="mpfr_fits_intmax_p"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static intmax_t mpfr_get_sj(mpfr_t op, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_mpfr_get_sj(op.ToIntPtr(),(int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to an <see cref="uintmax_t"/> after rounding it with respect to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, 0 is returned and the erange flag is set.
        /// If <paramref name="op"/> is too big for the return type, the function returns the maximum
        /// or the minimum of the corresponding C type, depending on the direction of the overflow;
        /// the erange flag is set too.
        /// See also <see cref="mpfr_fits_uintmax_p"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static uintmax_t mpfr_get_uj(mpfr_t op, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_mpfr_get_uj(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_sj(mpfr_t rop, intmax_t op, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_set_sj(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_uj(mpfr_t rop, uintmax_t op, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_set_uj(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> multiplied by two to the power <paramref name="e"/>, rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_sj_2exp(mpfr_t rop, intmax_t op, intmax_t e, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_set_sj_2exp(rop.ToIntPtr(), op, e, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> multiplied by two to the power <paramref name="e"/>, rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_uj_2exp(mpfr_t rop, uintmax_t op, uintmax_t e, mpfr_rnd_t rnd)
        {
            return SafeNativeMethods.__gmpfr_set_uj_2exp(rop.ToIntPtr(), op, e, (int)rnd);
        }

        /// <summary>
        /// Return the MPFR version, as a null-terminated string. 
        /// </summary>
        /// <returns>Return the MPFR version, as a null-terminated string.</returns>
        /// <seealso cref="mpfr_lib.MPFR_VERSION"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MAJOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_MINOR"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_PATCHLEVEL"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_STRING"/>
        /// <seealso cref="mpfr_lib.MPFR_VERSION_NUM"/>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static /*const*/ char_ptr /*char **/ mpfr_get_version(/*void*/)
        {
            return new char_ptr(SafeNativeMethods.mpfr_get_version());
        }

        /// <summary>
        /// Return a null-terminated string containing the ids of the patches applied to the MPFR library (contents of the PATCHES file), separated by spaces.
        /// </summary>
        /// <returns>Return a null-terminated string containing the ids of the patches applied to the MPFR library (contents of the PATCHES file), separated by spaces.</returns>
        /// <remarks>
        /// <para>
        /// Note: If the program has been compiled with an older MPFR version and is dynamically linked with a new MPFR library version,
        /// the identifiers of the patches applied to the old (compile-time) MPFR version are not available (however this information
        /// should not have much interest in general). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tls_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_decimal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_gmpinternals_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tune_case"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static /*const*/ char_ptr /*char **/ mpfr_get_patches(/*void*/)
        {
            return new char_ptr(SafeNativeMethods.mpfr_get_patches());
        }

        /// <summary>
        /// Return a non-zero value if MPFR was compiled as thread safe using compiler-level Thread Local Storage, return zero otherwise.
        /// </summary>
        /// <returns>Return a non-zero value if MPFR was compiled as thread safe using compiler-level Thread Local Storage, return zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return a non-zero value if MPFR was compiled with decimal float support
        /// (that is, MPFR was built with the --enable-decimal-float configure option),
        /// return zero otherwise. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_patches"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_decimal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_gmpinternals_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tune_case"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_buildopt_tls_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_buildopt_tls_p();
        }

        /// <summary>
        /// Return a non-zero value if MPFR was compiled with decimal float support, return zero otherwise. 
        /// </summary>
        /// <returns>Return a non-zero value if MPFR was compiled with decimal float support, return zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return a non-zero value if MPFR was compiled with decimal float support
        /// (that is, MPFR was built with the --enable-decimal-float configure option), return zero otherwise. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_patches"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tls_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_gmpinternals_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tune_case"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_buildopt_decimal_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_buildopt_decimal_p();
        }

        /// <summary>
        /// Return a non-zero value if MPFR was compiled with GMP internals, return zero otherwise. 
        /// </summary>
        /// <returns>Return a non-zero value if MPFR was compiled with GMP internals, return zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return a non-zero value if MPFR was compiled with GMP internals
        /// (that is, MPFR was built with either --with-gmp-build or --enable-gmp-internals configure option), return zero otherwise. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_patches"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tls_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_decimal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tune_case"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_buildopt_gmpinternals_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_buildopt_gmpinternals_p();
        }

        /// <summary>
        /// Return a string saying which thresholds file has been used at compile time.
        /// </summary>
        /// <returns>Return a string saying which thresholds file has been used at compile time.</returns>
        /// <remarks>
        /// <para>
        /// This file is normally selected from the processor type. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_patches"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_tls_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_decimal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_buildopt_gmpinternals_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static /*const*/ char_ptr /*char **/ mpfr_buildopt_tune_case(/*void*/)
        {
            return new char_ptr(SafeNativeMethods.mpfr_buildopt_tune_case());
        }

        /// <summary>
        /// Return the (current) smallest exponent allowed for a floating-point variable.
        /// </summary>
        /// <returns>Return the (current) smallest exponent allowed for a floating-point variable.</returns>
        /// <remarks>
        /// <para>
        /// The smallest positive value of a floating-point variable is one half times 2 raised to the smallest exponent
        /// and the largest value has the form (1 - epsilon) times 2 raised to the largest exponent,
        /// where epsilon depends on the precision of the considered variable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emin(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emin();
        }

        /// <summary>
        /// Set the smallest exponent allowed for a floating-point variable.
        /// </summary>
        /// <param name="exp">The exponent.</param>
        /// <returns>Return a non-zero value when <paramref name="exp"/> is not in the range accepted by the implementation (in that case the smallest exponent is not changed), and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// If the user changes the exponent range, it is her/his responsibility to check that all current floating-point variables 
        /// are in the new allowed range (for example using <see cref="mpfr_check_range"/>), otherwise the subsequent behavior will
        /// be undefined, in the sense of the ISO C standard. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_emin(mpfr_exp_t exp)
        {
            return SafeNativeMethods.mpfr_set_emin(exp);
        }

        /// <summary>
        /// Return the minimum exponent allowed for <see cref="mpfr_set_emin"/>. 
        /// </summary>
        /// <returns>Return the minimum exponent allowed for <see cref="mpfr_set_emin"/>.</returns>
        /// <remarks>
        /// <para>
        /// This value is implementation dependent, thus a program using <see cref="mpfr_set_emax"/>(<see cref="mpfr_get_emax_max"/>())
        /// or <see cref="mpfr_set_emin"/>(<see cref="mpfr_get_emin_min"/>()) may not be portable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emin_min(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emin_min();
        }

        /// <summary>
        /// Return the maximum exponent allowed for <see cref="mpfr_set_emin"/>. 
        /// </summary>
        /// <returns>Return the maximum of the exponent allowed for <see cref="mpfr_set_emin"/>.</returns>
        /// <remarks>
        /// <para>
        /// This value is implementation dependent, thus a program using <see cref="mpfr_set_emax"/>(<see cref="mpfr_get_emax_max"/>())
        /// or <see cref="mpfr_set_emin"/>(<see cref="mpfr_get_emin_min"/>()) may not be portable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emin_max(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emin_max();
        }

        /// <summary>
        /// Return the (current) largest exponent allowed for a floating-point variable.
        /// </summary>
        /// <returns>Return the (current) largest exponent allowed for a floating-point variable.</returns>
        /// <remarks>
        /// <para>
        /// The smallest positive value of a floating-point variable is one half times 2 raised to the smallest exponent
        /// and the largest value has the form (1 - epsilon) times 2 raised to the largest exponent,
        /// where epsilon depends on the precision of the considered variable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emax(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emax();
        }

        /// <summary>
        /// Set the largest exponent allowed for a floating-point variable.
        /// </summary>
        /// <param name="exp">The exponent.</param>
        /// <returns>Return a non-zero value when <paramref name="exp"/> is not in the range accepted by the implementation (in that case the largest exponent is not changed), and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// If the user changes the exponent range, it is her/his responsibility to check that all current floating-point variables 
        /// are in the new allowed range (for example using <see cref="mpfr_check_range"/>), otherwise the subsequent behavior will
        /// be undefined, in the sense of the ISO C standard. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_emax(mpfr_exp_t exp)
        {
            return SafeNativeMethods.mpfr_set_emax(exp);
        }

        /// <summary>
        /// Return the minimum exponent allowed for <see cref="mpfr_set_emax"/>. 
        /// </summary>
        /// <returns>Return the minimum exponent allowed for <see cref="mpfr_set_emax"/>.</returns>
        /// <remarks>
        /// <para>
        /// This value is implementation dependent, thus a program using <see cref="mpfr_set_emax"/>(<see cref="mpfr_get_emax_max"/>())
        /// or <see cref="mpfr_set_emin"/>(<see cref="mpfr_get_emin_min"/>()) may not be portable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emax_min(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emax_min();
        }

        /// <summary>
        /// Return the maximum exponent allowed for <see cref="mpfr_set_emax"/>. 
        /// </summary>
        /// <returns>Return the maximum exponent allowed for <see cref="mpfr_set_emax"/>.</returns>
        /// <remarks>
        /// <para>
        /// This value is implementation dependent, thus a program using <see cref="mpfr_set_emax"/>(<see cref="mpfr_get_emax_max"/>())
        /// or <see cref="mpfr_set_emin"/>(<see cref="mpfr_get_emin_min"/>()) may not be portable. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_emax_max(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_emax_max();
        }

        /// <summary>
        /// Set the default rounding mode to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rnd">The rounding direction.</param>
        /// <remarks>
        /// <para>
        /// The default rounding mode is to nearest initially. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_default_rounding_mode "/>
        /// <seealso cref="mpfr_lib.mpfr_prec_round"/>
        /// <seealso cref="mpfr_lib.mpfr_can_round"/>
        /// <seealso cref="mpfr_lib.mpfr_min_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_print_rnd_mode"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_default_rounding_mode(mpfr_rnd_t rnd)
        {
            SafeNativeMethods.mpfr_set_default_rounding_mode((int)rnd);
        }

        /// <summary>
        /// Get the default rounding mode. 
        /// </summary>
        /// <returns>The default rounding mode.</returns>
        /// <seealso cref="mpfr_lib.mpfr_set_default_rounding_mode"/>
        /// <seealso cref="mpfr_lib.mpfr_prec_round"/>
        /// <seealso cref="mpfr_lib.mpfr_can_round"/>
        /// <seealso cref="mpfr_lib.mpfr_min_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_print_rnd_mode"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_rnd_t mpfr_get_default_rounding_mode(/*void*/)
        {
            return (mpfr_rnd_t)SafeNativeMethods.mpfr_get_default_rounding_mode();
        }

        /// <summary>
        /// Return a string ("MPFR_RNDD", "MPFR_RNDU", "MPFR_RNDN", "MPFR_RNDZ", "MPFR_RNDA") corresponding to the rounding mode <paramref name="rnd"/>, or a null pointer if <paramref name="rnd"/> is an invalid rounding mode. 
        /// </summary>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return a string ("MPFR_RNDD", "MPFR_RNDU", "MPFR_RNDN", "MPFR_RNDZ", "MPFR_RNDA") corresponding to the rounding mode <paramref name="rnd"/>, or a null pointer if <paramref name="rnd"/> is an invalid rounding mode. </returns>
        /// <seealso cref="mpfr_lib.mpfr_set_default_rounding_mode"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_rounding_mode "/>
        /// <seealso cref="mpfr_lib.mpfr_prec_round"/>
        /// <seealso cref="mpfr_lib.mpfr_can_round"/>
        /// <seealso cref="mpfr_lib.mpfr_min_prec"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static /*const*/ char_ptr /*char **/ mpfr_print_rnd_mode(mpfr_rnd_t rnd)
        {
            return new char_ptr(SafeNativeMethods.mpfr_print_rnd_mode((int)rnd));
        }

        /// <summary>
        /// Clear all global flags (underflow, overflow, divide-by-zero, invalid, inexact, erange). 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_flags(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_flags();
        }

        /// <summary>
        /// Clear the underflow flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_underflow(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_underflow();
        }

        /// <summary>
        /// Clear the overflow flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_overflow(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_overflow();
        }

        /// <summary>
        /// Clear the divide-by-zero flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_divby0(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_divby0();
        }

        /// <summary>
        /// Clear the invalid flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_nanflag(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_nanflag();
        }

        /// <summary>
        /// Clear the inexact flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_inexflag(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_inexflag();
        }

        /// <summary>
        /// Clear the erange flag. 
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear_erangeflag(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_erangeflag();
        }

        /// <summary>
        /// Set the underflow flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_underflow(/*void*/)
        {
            SafeNativeMethods.mpfr_set_underflow();
        }

        /// <summary>
        /// Set the overflow flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_overflow(/*void*/)
        {
            SafeNativeMethods.mpfr_set_overflow();
        }

        /// <summary>
        /// Set the divide-by-zero flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_divby0(/*void*/)
        {
            SafeNativeMethods.mpfr_set_divby0();
        }

        /// <summary>
        /// Set the invalid flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_nanflag(/*void*/)
        {
            SafeNativeMethods.mpfr_set_nanflag();
        }

        /// <summary>
        /// Set the inexact flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_inexflag(/*void*/)
        {
            SafeNativeMethods.mpfr_set_inexflag();
        }

        /// <summary>
        /// Set the erange flag.
        /// </summary>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_erangeflag(/*void*/)
        {
            SafeNativeMethods.mpfr_set_erangeflag();
        }

        /// <summary>
        /// Return the underflow flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the underflow flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_underflow_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_underflow_p();
        }

        /// <summary>
        /// Return the overflow flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the overflow flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_overflow_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_overflow_p();
        }

        /// <summary>
        /// Return the divide-by-zero flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the divide-by-zero flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_divby0_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_divby0_p();
        }

        /// <summary>
        /// Return the invalid flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the invalid flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_nanflag_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_nanflag_p();
        }

        /// <summary>
        /// Return the inexact flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the inexact flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_erangeflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_inexflag_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_inexflag_p();
        }

        /// <summary>
        /// Return the erange flag, which is non-zero iff the flag is set. 
        /// </summary>
        /// <returns>Return the erange flag, which is non-zero iff the flag is set.</returns>
        /// <seealso cref="mpfr_lib.mpfr_clear_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_underflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_overflow"/>
        /// <seealso cref="mpfr_lib.mpfr_set_divby0"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nanflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inexflag"/>
        /// <seealso cref="mpfr_lib.mpfr_set_erangeflag"/>
        /// <seealso cref="mpfr_lib.mpfr_clear_flags"/>
        /// <seealso cref="mpfr_lib.mpfr_underflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_overflow_p"/>
        /// <seealso cref="mpfr_lib.mpfr_divby0_p"/>
        /// <seealso cref="mpfr_lib.mpfr_nanflag_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inexflag_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_erangeflag_p(/*void*/)
        {
            return SafeNativeMethods.mpfr_erangeflag_p();
        }

        /// <summary>
        /// Check that <paramref name="x"/> is within the current range of acceptable values.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="t">The input <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a>.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>This function returns zero if the new value of <paramref name="x"/> equals the exact one y, a positive value if that new value is larger than y, and a negative value if it is smaller than y.</returns>
        /// <remarks>
        /// <para>
        /// This function assumes that <paramref name="x"/> is the correctly-rounded value of some real value y in the
        /// direction <paramref name="rnd"/> and some extended exponent range, and that t is the 
        /// corresponding <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a>.
        /// For example, one performed t = <see cref="mpfr_log"/>(<paramref name="x"/>, u, <paramref name="rnd"/>),
        /// and y is the exact logarithm of u.
        /// Thus <paramref name="t"/> is negative if <paramref name="x"/> is smaller than y, positive if <paramref name="x"/>
        /// is larger than y, and zero if <paramref name="x"/> equals y.
        /// This function modifies <paramref name="x"/> if needed to be in the current range of acceptable values:
        /// It generates an underflow or an overflow if the exponent of <paramref name="x"/> is outside the current allowed range;
        /// the value of <paramref name="t"/> may be used to avoid a double rounding.
        /// This function returns zero if the new value of <paramref name="x"/> equals the exact one y, a positive value if that
        /// new value is larger than y, and a negative value if it is smaller than y.
        /// Note that unlike most functions, the new result <paramref name="x"/> is compared to the (unknown) exact one y,
        /// not the input value <paramref name="x"/>, i.e., the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> is propagated. 
        /// </para>
        /// <para>
        /// Note: If <paramref name="x"/> is an infinity and <paramref name="t"/> is different from zero (i.e., if the rounded result is an inexact infinity),
        /// then the overflow flag is set.
        /// This is useful because <see cref="mpfr_check_range"/> is typically called (at least in MPFR functions) after restoring the flags that could
        /// have been set due to internal computations. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_subnormalize"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_check_range(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_check_range(x.ToIntPtr(), t, (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="x"/>, set its precision to be exactly <paramref name="prec"/> bits and its value to NaN.
        /// </summary>
        /// <param name="x">The floating-point number to initialize.</param>
        /// <param name="prec">The precision of the significand in bits.</param>
        /// <remarks>
        /// <para>
        /// (Warning: the corresponding MPF function initializes to zero instead.)
        /// </para>
        /// <para>
        /// Normally, a variable should be initialized once only or at least be cleared, using <see cref="mpfr_clear"/>, between initializations.
        /// To change the precision of a variable which has already been initialized, use <see cref="mpfr_set_prec"/>.
        /// The precision <paramref name="prec"/> must be an integer between <see cref="MPFR_PREC_MIN"/>
        /// and <see cref="MPFR_PREC_MAX"/> (otherwise the behavior is undefined). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_init2(mpfr_t x, mpfr_prec_t prec)
        {
            if (x == null) throw new ArgumentNullException("x");
            x.Initializing();
            SafeNativeMethods.mpfr_init2(x.ToIntPtr(), prec);
            x.Initialized();
        }

        /// <summary>
        /// Initialize <paramref name="x"/>, set its precision to the default precision, and set its value to NaN.
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <remarks>
        /// <para>
        /// The default precision can be changed by a call to <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// <para>
        /// Warning!
        /// In a given program, some other libraries might change the default precision and not restore it.
        /// Thus it is safer to use <see cref="mpfr_init2"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_init(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            x.Initializing();
            SafeNativeMethods.mpfr_init(x.ToIntPtr());
            x.Initialized();
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_ui(mpfr_t rop, /*const*/ uint op, mpfr_rnd_t rnd)
        {
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_ui(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_si(mpfr_t rop, /*const*/ int op, mpfr_rnd_t rnd)
        {
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_si(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_d(mpfr_t rop, /*const*/ double op, mpfr_rnd_t rnd)
        {
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_d(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_z(mpfr_t rop, /*const*/ mpz_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_z(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_q(mpfr_t rop, /*const*/ mpq_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_q(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="rop"/> and set its value from <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The precision of <paramref name="rop"/> will be taken from the active default precision, as set by <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_f(mpfr_t rop, /*const*/ mpf_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            mpfr_init(rop);
            return SafeNativeMethods.mpfr_set_f(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Free the space occupied by the significand of <paramref name="x"/>. 
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <remarks>
        /// <para>
        /// Make sure to call this function for all <see cref="mpfr_t"/> variables when you are done with them.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clear(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_clear(x.ToIntPtr());
            x.Clear();
        }

        /// <summary>
        /// Initialize all the <see cref="mpfr_t"/> variables of the given variable argument <paramref name="x"/>, set their precision to be exactly <paramref name="prec"/> bits and their value to NaN.
        /// </summary>
        /// <param name="prec">The precision of the significand in bits.</param>
        /// <param name="x">List of floating-point numbers to initialize.</param>
        /// <remarks>
        /// <para>
        /// See <see cref="mpfr_init2"/> for more details.
        /// The list of floating-pointer numbers ends when it encounters a null pointer (whose type must also be <see cref="mpfr_t"/>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_inits2(mpfr_prec_t prec, params mpfr_t[] x /*...*/)
        {
            if (x == null) throw new ArgumentNullException("x");
            foreach (mpfr_t a in x)
            {
                if (a != null)
                {
                    a.Initializing();
                    SafeNativeMethods.mpfr_init2(a.ToIntPtr(), prec);
                    a.Initialized();
                }
            }
        }

        /// <summary>
        /// Initialize all the <see cref="mpfr_t"/> variables of the given list <paramref name="x"/>, set their precision to the default precision and their value to NaN.
        /// </summary>
        /// <param name="x">The list of floating-point numbers.</param>
        /// <remarks>
        /// <para>
        /// See <see cref="mpfr_init"/> for more details.
        /// The list of floating-point numbers ends when it encounters a null pointer (whose type must also be <see cref="mpfr_t"/>). 
        /// </para>
        /// <para>
        /// Warning!
        /// In a given program, some other libraries might change the default precision and not restore it.
        /// Thus it is safer to use <see cref="mpfr_inits2"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_inits(params mpfr_t[] x /*...*/)
        {
            if (x == null) throw new ArgumentNullException("x");
            foreach (mpfr_t a in x)
            {
                if (a != null)
                {
                    a.Initializing();
                    SafeNativeMethods.mpfr_init(a.ToIntPtr());
                    a.Initialized();
                }
            }
        }

        /// <summary>
        /// Free the space occupied by all the <see cref="mpfr_t"/> variables of the given list <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The list of floating-point numbers.</param>
        /// <remarks>
        /// <para>
        /// See <see cref="mpfr_clear"/> for more details.
        /// The list of floating-point numbers ends when it encounters a null pointer (whose type must also be <see cref="mpfr_t"/>). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_clears(params mpfr_t[] x /*...*/)
        {
            if (x == null) throw new ArgumentNullException("x");
            foreach (mpfr_t a in x) { if (a != null) mpfr_clear(a); }
        }

        /// <summary>
        /// Round <paramref name="x"/> according to <paramref name="rnd"/> with precision <paramref name="prec"/>, which must be an integer between <see cref="MPFR_PREC_MIN"/> and <see cref="MPFR_PREC_MAX"/> (otherwise the behavior is undefined).
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="prec">The precision in bits.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="x"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="prec"/> is greater or equal to the precision of <paramref name="x"/>, then new space is allocated for the
        /// significand, and it is filled with zeros.
        /// Otherwise, the significand is rounded to precision <paramref name="prec"/> with the given direction.
        /// In both cases, the precision of <paramref name="x"/> is changed to <paramref name="prec"/>. 
        /// </para>
        /// <para>
        /// Here is an example of how to use <see cref="mpfr_prec_round"/> to implement Newton’s algorithm to compute
        /// the inverse of a, assuming x is already an approximation to n bits: 
        /// </para>
        /// <code language="C#">
        /// mpfr_set_prec (t, 2 * n);
        /// mpfr_set(t, a, mpfr_rnd_t.MPFR_RNDN);            /* round a to 2n bits */
        /// mpfr_mul(t, t, x, mpfr_rnd_t.MPFR_RNDN);         /* t is correct to 2n bits */
        /// mpfr_ui_sub(t, 1, t, mpfr_rnd_t.MPFR_RNDN);      /* high n bits cancel with 1 */
        /// mpfr_prec_round(t, n, mpfr_rnd_t.MPFR_RNDN);     /* t is correct to n bits */
        /// mpfr_mul(t, t, x, mpfr_rnd_t.MPFR_RNDN);         /* t is correct to n bits */
        /// mpfr_prec_round(x, 2 * n, mpfr_rnd_t.MPFR_RNDN); /* exact */
        /// mpfr_add(x, x, t, mpfr_rnd_t.MPFR_RNDN);         /* x is correct to 2n bits */
        /// </code> 
        /// <para>
        /// Warning! You must not use this function if x was initialized with <see cref="mpfr_custom_init_set"/>
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a>). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_default_rounding_mode"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_rounding_mode "/>
        /// <seealso cref="mpfr_lib.mpfr_can_round"/>
        /// <seealso cref="mpfr_lib.mpfr_min_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_print_rnd_mode"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_prec_round(mpfr_t x, mpfr_prec_t prec, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_prec_round(x.ToIntPtr(), prec, (int)rnd);
        }

        /// <summary>
        /// Return non-zero value if one is able to round correctly x to precision <paramref name="prec"/> with the direction <paramref name="rnd2"/>, and 0 otherwise.
        /// </summary>
        /// <param name="b">Floating-point number that approximates x.</param>
        /// <param name="err">The approximation error.</param>
        /// <param name="rnd1">The rounding direction of the approximation.</param>
        /// <param name="rnd2">The rounding direction of x.</param>
        /// <param name="prec">The precision of x.</param>
        /// <returns>Return non-zero value if one is able to round correctly x to precision <paramref name="prec"/> with the direction <paramref name="rnd2"/>, and 0 otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Assuming <paramref name="b"/> is an approximation of an unknown number x in the direction <paramref name="rnd1"/>
        /// with error at most two to the power E(<paramref name="b"/>) - <paramref name="err"/> where E(<paramref name="b"/>)
        /// is the exponent of <paramref name="b"/>, return a non-zero value if one is able to round correctly x to precision
        /// <paramref name="prec"/> with the direction <paramref name="rnd2"/>, and 0 otherwise (including for NaN and Inf).
        /// This function <b>does not modify</b> its arguments. 
        /// </para>
        /// <para>
        /// If <paramref name="rnd1"/> is <see cref="mpfr_rnd_t.MPFR_RNDN"/>, then the sign of the error is unknown,
        /// but its absolute value is the same, so that the possible range is twice as large as with a directed
        /// rounding for <paramref name="rnd1"/>. 
        /// </para>
        /// <para>
        /// Note: if one wants to also determine the correct <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> when rounding <paramref name="b"/> to precision <paramref name="prec"/>
        /// with rounding mode rnd, a useful trick is the following:
        /// </para>
        /// <code language="C#">
        /// if (mpfr_can_round(b, err, MPFR_RNDN, MPFR_RNDZ, prec + (rnd == mpfr_rnd_t.MPFR_RNDN)))
        ///  ...
        /// </code> 
        /// <para>
        /// Indeed, if rnd is <see cref="mpfr_rnd_t.MPFR_RNDN"/>, this will check if one can round to prec + 1 bits with a directed rounding:
        /// if so, one can surely round to nearest to prec bits, and in addition one can determine the correct <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a>,
        /// which would not be the case when b is near from a value exactly representable on prec bits. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_default_rounding_mode"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_rounding_mode "/>
        /// <seealso cref="mpfr_lib.mpfr_prec_round"/>
        /// <seealso cref="mpfr_lib.mpfr_min_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_print_rnd_mode"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_can_round(/*const*/ mpfr_t b, mpfr_exp_t err, mpfr_rnd_t rnd1, mpfr_rnd_t rnd2, mpfr_prec_t prec)
        {
            if (b == null) throw new ArgumentNullException("b");
            return SafeNativeMethods.mpfr_can_round(b.ToIntPtr(), err, (int)rnd1, (int)rnd2, prec);
        }

        /// <summary>
        /// Return the minimal number of bits required to store the significand of <paramref name="x"/>, and 0 for special values, including 0.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <returns>Return the minimal number of bits required to store the significand of <paramref name="x"/>, and 0 for special values, including 0.</returns>
        /// <remarks>
        /// <para>
        /// Warning: the returned value can be less than <see cref="MPFR_PREC_MIN"/>.
        /// </para>
        /// <para>
        /// The function name is subject to change. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_default_rounding_mode"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_rounding_mode "/>
        /// <seealso cref="mpfr_lib.mpfr_prec_round"/>
        /// <seealso cref="mpfr_lib.mpfr_can_round"/>
        /// <seealso cref="mpfr_lib.mpfr_print_rnd_mode"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Related-Functions">GNU MPFR - Rounding Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_prec_t mpfr_min_prec(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_min_prec(x.ToIntPtr());
        }

        /// <summary>
        /// Return the exponent of <paramref name="x"/>, assuming that <paramref name="x"/> is a non-zero ordinary number and the significand is considered in [1/2,1).
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <returns>Return the exponent of <paramref name="x"/>, assuming that <paramref name="x"/> is a non-zero ordinary number and the significand is considered in [1/2,1).</returns>
        /// <remarks>
        /// <para>
        /// The behavior for NaN, infinity or zero is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_exp(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_get_exp(x.ToIntPtr());
        }

        /// <summary>
        /// Set the exponent of <paramref name="x"/> if <paramref name="e"/> is in the current exponent range.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="e">The exponent value.</param>
        /// <returns>Return 0 (even if <paramref name="x"/> is not a non-zero ordinary number); otherwise, return a non-zero value.</returns>
        /// <remarks>
        /// <para>
        /// Set the exponent of <paramref name="x"/> if <paramref name="e"/> is in the current exponent range, and return 0
        /// (even if <paramref name="x"/> is not a non-zero ordinary number); otherwise, return a non-zero value.
        /// The significand is assumed to be in [1/2,1). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_exp(mpfr_t x, mpfr_exp_t e)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_set_exp(x.ToIntPtr(), e);
        }

        /// <summary>
        /// Return the precision of <paramref name="x"/>, i.e., the number of bits used to store its significand. 
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <returns>The precision of <paramref name="x"/>, i.e., the number of bits used to store its significand.</returns>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_prec_t mpfr_get_prec(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_get_prec(x.ToIntPtr());
        }

        /// <summary>
        /// Reset the precision of <paramref name="x"/> to be exactly <paramref name="prec"/> bits, and set its value to NaN.
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <param name="prec">The precision of the significand in bits.</param>
        /// <remarks>
        /// <para>
        /// The previous value stored in <paramref name="x"/> is lost.
        /// It is equivalent to a call to <see cref="mpfr_clear"/>(x) followed by a call to <see cref="mpfr_init2"/>(x, prec),
        /// but more efficient as no allocation is done in case the current allocated space for the significand of
        /// <paramref name="x"/> is enough.
        /// The precision <paramref name="prec"/> can be any integer between <see cref="MPFR_PREC_MIN"/> and <see cref="MPFR_PREC_MAX"/>.
        /// In case you want to keep the previous value stored in <paramref name="x"/>, use <see cref="mpfr_prec_round"/> instead. 
        /// </para>
        /// <para>
        /// Warning!
        /// You must not use this function if <paramref name="x"/> was initialized with <see cref="mpfr_custom_init_set"/>
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Custom Interface</a>).
        /// </para>
        /// <para>
        /// The function is useful for changing the precision during a calculation.
        /// A typical use would be for adjusting the precision gradually in iterative algorithms like Newton-Raphson, making the
        /// computation precision closely match the actual accurate part of the numbers. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_prec(mpfr_t x, mpfr_prec_t prec)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_set_prec(x.ToIntPtr(), prec);
        }

        /// <summary>
        /// Reset the precision of <paramref name="x"/> to be exactly <paramref name="prec"/> bits.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="prec">The precision in bits.</param>
        /// <remarks>
        /// <para>
        /// The only difference with <see cref="mpfr_set_prec"/> is that <paramref name="prec"/> is assumed to be small enough
        /// so that the significand fits into the current allocated memory space for <paramref name="x"/>.
        /// Otherwise the behavior is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_eq"/>
        /// <seealso cref="mpfr_lib.mpfr_reldiff"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_div_2exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Compatibility-with-MPF">GNU MPFR - Compatibility With MPF</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_prec_raw(mpfr_t x, mpfr_prec_t prec)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_set_prec_raw(x.ToIntPtr(), prec);
        }

        /// <summary>
        /// Set the default precision to be exactly <paramref name="prec"/> bits, where <paramref name="prec"/> can be any integer between <see cref="MPFR_PREC_MIN"/>and <see cref="MPFR_PREC_MAX"/>.
        /// </summary>
        /// <param name="prec">The new default precision in bits.</param>
        /// <remarks>
        /// <para>
        /// The precision of a variable means the number of bits used to store its significand.
        /// All subsequent calls to <see cref="mpfr_init"/> or <see cref="mpfr_inits"/> will use this precision,
        /// but previously initialized variables are unaffected.
        /// The default precision is set to 53 bits initially. 
        /// </para>
        /// <para>
        /// Note: when MPFR is built with the --enable-thread-safe configure option (<see cref="mpfr_buildopt_tls_p"/>), the default precision is local to each thread.
        /// See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>, for more information. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_get_default_prec"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_default_prec(mpfr_prec_t prec)
        {
            SafeNativeMethods.mpfr_set_default_prec(prec);
        }

        /// <summary>
        /// Return the current default MPFR precision in bits.
        /// </summary>
        /// <returns>The current default MPFR precision in bits.</returns>
        /// <remarks>
        /// <para>
        /// See the documentation of <see cref="mpfr_set_default_prec"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init2(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits2(mpfr_prec_t, mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_clear(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_clears(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_init(mpfr_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_inits(mpfr_t[])"/>
        /// <seealso cref="mpfr_lib.mpfr_set_default_prec(mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_prec_t mpfr_get_default_prec(/*void*/)
        {
            return SafeNativeMethods.mpfr_get_default_prec();
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If the system does not support the IEEE 754 standard, <see cref="mpfr_set_d"/> might not preserve the signed zeros.
        /// </para>
        /// <para>
        /// Note: If you want to store a floating-point constant to a <see cref="mpfr_t"/>, you should use <see cref="mpfr_set_str"/>
        /// (or one of the MPFR constant functions, such as <see cref="mpfr_const_pi"/> for Pi) instead of <see cref="mpfr_set_d"/>.
        /// Otherwise the floating-point constant will be first converted into a reduced-precision (e.g., 53-bit) binary number before MPFR can work with it. 
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_d(mpfr_t rop, double op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_d(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If the system does not support the IEEE 754 standard, <see cref="mpfr_set_flt"/> might not preserve the signed zeros.
        /// </para>
        /// <para>
        /// Note: If you want to store a floating-point constant to a <see cref="mpfr_t"/>, you should use <see cref="mpfr_set_str"/>
        /// (or one of the MPFR constant functions, such as <see cref="mpfr_const_pi"/> for Pi) instead of <see cref="mpfr_set_flt"/>.
        /// Otherwise the floating-point constant will be first converted into a reduced-precision (e.g., 53-bit) binary number before MPFR can work with it. 
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_flt(mpfr_t rop, float op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_flt(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_z(mpfr_t rop, /*const*/ mpz_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_set_z(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> multiplied by two to the power <paramref name="e"/>, rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_z_2exp(mpfr_t rop, /*const*/ mpz_t op, mpfr_exp_t e, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_set_z_2exp(rop.ToIntPtr(), op.ToIntPtr(), e, (int)rnd);
        }

        /// <summary>
        /// Set the variable <paramref name="x"/> to NaN (Not-a-Number).
        /// </summary>
        /// <param name="x">The result floating-point number.</param>
        /// <remarks>
        /// <para>
        /// In <see cref="mpfr_set_nan"/>, the sign bit of the result is unspecified. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_nan(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_set_nan(x.ToIntPtr());
        }

        /// <summary>
        /// Set the variable <paramref name="x"/> to infinity.
        /// </summary>
        /// <param name="x">The result floating-point number.</param>
        /// <param name="sign">The sign of the result.</param>
        /// <remarks>
        /// <para>
        /// In <see cref="mpfr_set_inf"/>, <paramref name="x"/> is set to plus infinity iff <paramref name="sign"/> is nonnegative.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_inf(mpfr_t x, int sign)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_set_inf(x.ToIntPtr(), sign);
        }

        /// <summary>
        /// Set the variable <paramref name="x"/> to zero.
        /// </summary>
        /// <param name="x">The result floating-point number.</param>
        /// <param name="sign">The sign of the result.</param>
        /// <remarks>
        /// <para>
        /// In<see cref="mpfr_set_zero"/>, <paramref name="x"/> is set to plus zero iff <paramref name="sign"/> is nonnegative.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_set_zero(mpfr_t x, int sign)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_set_zero(x.ToIntPtr(), sign);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_f(mpfr_t rop, /*const*/ mpf_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_set_f(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/37c88d6c-8d02-2330-ad77-f20fb73d1677.htm">mpf_t</a>, after rounding it with respect to <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The erange flag is set if <paramref name="op"/> is NaN or an infinity, which do not exist in MPF.
        /// If <paramref name="op"/> is NaN, then <paramref name="rop"/> is undefined.
        /// If <paramref name="op"/> is +Inf (resp. -Inf), then <paramref name="rop"/> is set to the maximum (resp. minimum) value in the precision of the MPF number;
        /// if a future MPF version supports infinities, this behavior will be considered incorrect and will change (portable programs should assume that <paramref name="rop"/>
        /// is set either to this finite number or to an infinite number).
        /// Note that since MPFR currently has the same exponent type as MPF (but not with the same radix), the range of values is much larger in MPF than in MPFR, so that an
        /// overflow or underflow is not possible. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_get_f(mpf_t /*mpf_ptr*/ rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_f(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_si(mpfr_t rop, int /*long*/ op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_si(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_ui(mpfr_t rop, uint /*unsigned long*/ op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_ui(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> multiplied by two to the power <paramref name="e"/>, rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_si_2exp(mpfr_t rop, int /*long*/ op, mpfr_exp_t e, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_si_2exp(rop.ToIntPtr(), op, e, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> multiplied by two to the power <paramref name="e"/>, rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_ui_2exp(mpfr_t rop, uint /*unsigned long*/ op, mpfr_exp_t e, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_ui_2exp(rop.ToIntPtr(), op, e, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that the input 0 is converted to +0 regardless of the rounding mode.
        /// <see cref="mpfr_set_q"/> might fail if the numerator (or the denominator) can not be represented as a <see cref="mpfr_t"/>. 
        /// </para>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_q(mpfr_t rop, mpq_t /*mpq_srcptr*/ op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_q(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the string <paramref name="s"/> in base <paramref name="base"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="s"></param>
        /// <param name="base"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Retturn 0 if the entire string up to the final null character is a valid number in base <paramref name="base"/>; otherwise it is -1.</returns>
        /// <remarks>
        /// <para>
        /// See the documentation of <see cref="O:Math.Mpfr.Native.mpfr_strtofr"/> for a detailed description of the valid string formats.
        /// Contrary to <see cref="O:Math.Mpfr.Native.mpfr_strtofr"/>,<see cref="mpfr_set_str"/> requires the whole string to represent a valid floating-point number. 
        /// </para>
        /// <para>
        /// The meaning of the return value differs from other MPFR functions:
        /// it is 0 if the entire string up to the final null character is a valid number in base <paramref name="base"/>; otherwise it is -1,
        /// and <paramref name="rop"/> may have changed (users interested in the 
        /// <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> should use <see cref="O:Math.Mpfr.Native.mpfr_strtofr"/> instead). 
        /// </para>
        /// <para>
        /// Note: it is preferable to use <see cref="O:Math.Mpfr.Native.mpfr_strtofr"/> if one wants to distinguish between an infinite <paramref name="rop"/> value
        /// coming from an infinite <paramref name="s"/> or from an overflow. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set_str(mpfr_t rop, /*const*/ char_ptr /*char **/ s, int @base, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_set_str(rop.ToIntPtr(), s.ToIntPtr(), @base, (int)rnd);
        }

        /// <summary>
        /// Initialize <paramref name="x"/> and set its value from the string <paramref name="s"/> in base <paramref name="base"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="x">The result floating-point number.</param>
        /// <param name="s">String containing a floating-point number.</param>
        /// <param name="base">The base.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="x"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// See <see cref="mpfr_set_str"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_init_set_f"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Combined-Initialization-and-Assignment-Functions">GNU MPFR - Combined Initialization and Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_init_set_str(mpfr_t x, /*const*/ string /*char **/ s, int @base, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            x.Initializing();
            char_ptr str = new char_ptr(s);
            int result = SafeNativeMethods.mpfr_init_set_str(x.ToIntPtr(), str.ToIntPtr(), @base, (int)rnd);
            x.Initialized();
            gmp_lib.free(str);
            return result;
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the absolute value of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just changes or adjusts the sign if <paramref name="rop"/> and <paramref name="op"/> are the same variable,
        /// otherwise a rounding might occur if the precision of <paramref name="rop"/> is less than that of <paramref name="op"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_abs(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_abs(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/> rounded toward the given direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function assigns new values to already initialized floats
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_set(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_set(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to -<paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just changes or adjusts the sign if <paramref name="rop"/> and <paramref name="op"/> are the same variable,
        /// otherwise a rounding might occur if the precision of <paramref name="rop"/> is less than that of <paramref name="op"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_neg(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_neg(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return a non-zero value iff <paramref name="op"/> has its sign bit set (i.e., if it is negative, -0, or a NaN whose representation has its sign bit set). 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return a non-zero value iff <paramref name="op"/> has its sign bit set (i.e., if it is negative, -0, or a NaN whose representation has its sign bit set).</returns>
        /// <seealso cref="mpfr_lib.mpfr_setsign"/>
        /// <seealso cref="mpfr_lib.mpfr_copysign"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_signbit(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_signbit(op.ToIntPtr());
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op"/>, rounded toward the given direction <paramref name="rnd"/>, then set (resp. clear) its sign bit if <paramref name="s"/> is non-zero (resp. zero), even when <paramref name="op"/> is a NaN. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="s">The sign bit.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_signbit"/>
        /// <seealso cref="mpfr_lib.mpfr_copysign"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_setsign(mpfr_t rop, /*const*/ mpfr_t op, int s, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_setsign(rop.ToIntPtr(), op.ToIntPtr(), s, (int)rnd);
        }

        /// <summary>
        /// Set the value of <paramref name="rop"/> from <paramref name="op1"/>, rounded toward the given direction <paramref name="rnd"/>, then set its sign bit to that of <paramref name="op2"/> (even when <paramref name="op1"/> or <paramref name="op2"/> is a NaN). 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function is equivalent to <see cref="mpfr_setsign"/>(<paramref name="rop"/>, <paramref name="op1"/>, <see cref="mpfr_signbit"/>(<paramref name="op2"/>), <paramref name="rnd"/>).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_signbit"/>
        /// <seealso cref="mpfr_lib.mpfr_setsign"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_copysign(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_copysign(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Put the scaled significand of <paramref name="op"/> (regarded as an integer, with the precision of <paramref name="op"/>) into <paramref name="rop"/>, and return the exponent exp (which may be outside the current exponent range) such that <paramref name="op"/> = <paramref name="rop"/> * 2^exp.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return the exponent exp (which may be outside the current exponent range) such that <paramref name="op"/> = <paramref name="rop"/> * 2^exp.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is zero, the minimal exponent emin is returned.
        /// If <paramref name="op"/> is NaN or an infinity, the erange flag is set, <paramref name="rop"/> is set to 0, and the the minimal exponent emin is returned.
        /// The returned exponent may be less than the minimal exponent emin of MPFR numbers in the current exponent range;
        /// in case the exponent is not representable in the <see cref="mpfr_exp_t"/> type, the erange flag is set and the minimal value of the <see cref="mpfr_exp_t"/> type is returned. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_get_z_2exp(mpz_t /*mpz_ptr*/ rop, /*const*/ mpfr_t op)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_z_2exp(rop.ToIntPtr(), op.ToIntPtr());
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a float, using the rounding mode <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, some fixed NaN (either quiet or signaling) or the result of 0.0/0.0 is returned.
        /// If <paramref name="op"/> is ±Inf, an infinity of the same sign or the result of ±1.0/0.0 is returned.
        /// If <paramref name="op"/> is zero, the function returns a zero, trying to preserve its sign, if possible.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static float mpfr_get_flt(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_flt(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a double, using the rounding mode <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, some fixed NaN (either quiet or signaling) or the result of 0.0/0.0 is returned.
        /// If <paramref name="op"/> is ±Inf, an infinity of the same sign or the result of ±1.0/0.0 is returned.
        /// If <paramref name="op"/> is zero, the function returns a zero, trying to preserve its sign, if possible.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static double mpfr_get_d(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_d(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return d and set <paramref name="exp"/> such that 0.5 &#8804; abs(d) &lt;1 and d * 2^<paramref name="exp"/> = <paramref name="op"/> rounded to double precision, using the given rounding mode. 
        /// </summary>
        /// <param name="exp">Pointer to returned exponent.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is zero, then a zero of the same sign (or an unsigned zero, if the implementation does
        /// not have signed zeros) is returned, and <paramref name="exp"/> is set to 0.
        /// If <paramref name="op"/> is NaN or an infinity, then the corresponding double precision value is returned,
        /// and <paramref name="exp"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d_2exp(ptr{int}, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static double mpfr_get_d_2exp(ref int /*long **/ exp, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_d_2exp(ref exp, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return d and set <paramref name="exp"/> such that 0.5 &#8804; abs(d) &lt;1 and d * 2^<paramref name="exp"/> = <paramref name="op"/> rounded to double precision, using the given rounding mode. 
        /// </summary>
        /// <param name="exp">Pointer to returned exponent.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is zero, then a zero of the same sign (or an unsigned zero, if the implementation does
        /// not have signed zeros) is returned, and <paramref name="exp"/> is set to 0.
        /// If <paramref name="op"/> is NaN or an infinity, then the corresponding double precision value is returned,
        /// and <paramref name="exp"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d_2exp(ref int, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static double mpfr_get_d_2exp(ptr<int> /*long **/ exp, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (exp == null) throw new ArgumentNullException("exp");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_d_2exp(ref exp.Value, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="exp"/> and <paramref name="y"/> such that 0.5 &#8804; abs(<paramref name="y"/>) &lt; 1 and <paramref name="y"/> * 2^<paramref name="exp"/> = <paramref name="x"/> rounded to the precision of <paramref name="y"/>, using the given rounding mode.
        /// </summary>
        /// <param name="exp">The returned exponent.</param>
        /// <param name="y">The returned significand.</param>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="y"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="x"/> is zero, then <paramref name="y"/> is set to a zero of the same sign and <paramref name="exp"/> is set to 0.
        /// If <paramref name="x"/> is NaN or an infinity, then <paramref name="y"/> is set to the same value and <paramref name="exp"/> is undefined.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_frexp(ptr{mpfr_exp_t}, mpfr_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_frexp(ref mpfr_exp_t /*mpfr_exp_t **/ exp, mpfr_t y, /*const*/ mpfr_t x, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_frexp(ref exp.Value, y.ToIntPtr(), x.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="exp"/> and <paramref name="y"/> such that 0.5 &#8804; abs(<paramref name="y"/>) &lt; 1 and <paramref name="y"/> * 2^<paramref name="exp"/> = <paramref name="x"/> rounded to the precision of <paramref name="y"/>, using the given rounding mode.
        /// </summary>
        /// <param name="exp">The returned exponent.</param>
        /// <param name="y">The returned significand.</param>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="y"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="x"/> is zero, then <paramref name="y"/> is set to a zero of the same sign and <paramref name="exp"/> is set to 0.
        /// If <paramref name="x"/> is NaN or an infinity, then <paramref name="y"/> is set to the same value and <paramref name="exp"/> is undefined.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_frexp(ref mpfr_exp_t, mpfr_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_frexp(ptr<mpfr_exp_t> /*mpfr_exp_t **/ exp, mpfr_t y, /*const*/ mpfr_t x, mpfr_rnd_t rnd)
        {
            if (exp == null) throw new ArgumentNullException("exp");
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_frexp(ref exp.Value.Value, y.ToIntPtr(), x.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a long after rounding it with respect to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, 0 is returned and the erange flag is set.
        /// If <paramref name="op"/> is too big for the return type, the function returns the maximum
        /// or the minimum of the corresponding C type, depending on the direction of the overflow;
        /// the erange flag is set too.
        /// See also <see cref="mpfr_fits_slong_p"/>, and <see cref="mpfr_fits_sint_p"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int /*long*/ mpfr_get_si(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_si(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to an unsigned long after rounding it with respect to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The converted floating-point number.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN, 0 is returned and the erange flag is set.
        /// If <paramref name="op"/> is too big for the return type, the function returns the maximum
        /// or the minimum of the corresponding C type, depending on the direction of the overflow;
        /// the erange flag is set too.
        /// See also <see cref="mpfr_fits_ulong_p"/> or <see cref="mpfr_fits_uint_p"/> .
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static uint /*unsigned long*/ mpfr_get_ui(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_ui(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a string of digits in base <paramref name="b"/>, with rounding in the direction <paramref name="rnd"/>, where <paramref name="n"/> is either zero (see below) or the number of significant digits output in the string; in the latter case, <paramref name="n"/> must be greater or equal to 2. 
        /// </summary>
        /// <param name="str">The result string.</param>
        /// <param name="expptr">The returned exponent.</param>
        /// <param name="b">The base.</param>
        /// <param name="n">The number of digits in the result string.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return the converted string of digits.</returns>
        /// <remarks>
        /// <para>
        /// The base may vary from 2 to 62; otherwise the function does nothing and immediately returns a null pointer.
        /// If the input number is an ordinary number, the exponent is written through the pointer <paramref name="expptr"/>
        /// (for input 0, the current minimal exponent is written); the type <see cref="mpfr_exp_t"/> is large enough to hold the exponent in all cases.
        /// </para>
        /// <para>
        /// The generated string is a fraction, with an implicit radix point immediately to the left of the first digit.
        /// For example, the number -3.1416 would be returned as "-31416" in the string and 1 written at <paramref name="expptr"/>.
        /// If <paramref name="rnd"/> is to nearest, and <paramref name="op"/> is exactly in the middle of two consecutive possible outputs,
        /// the one with an even significand is chosen, where both significands are considered with the exponent of <paramref name="op"/>.
        /// Note that for an odd base, this may not correspond to an even last digit: for example with 2 digits in base 7, (14) and a half is rounded to (15) which is 12 in decimal,
        /// (16) and a half is rounded to (20) which is 14 in decimal, and (26) and a half is rounded to (26) which is 20 in decimal. 
        /// </para>
        /// <para>
        /// If <paramref name="n"/> is zero, the number of digits of the significand is chosen large enough so that re-reading the printed value with the same precision,
        /// assuming both output and input use rounding to nearest, will recover the original value of <paramref name="op"/>.
        /// More precisely, in most cases, the chosen precision of <paramref name="str"/> is the minimal precision m depending only on p = PREC(<paramref name="op"/>)
        /// and <paramref name="b"/> that satisfies the above property, i.e., m = 1 + ceil(p * log(2) / log(<paramref name="b"/>)), with p replaced by p - 1 if <paramref name="b"/>
        /// is a power of 2, but in some very rare cases, it might be m + 1 (the smallest case for bases up to 62 is when p equals 186564318007 for bases 7 and 49).
        /// </para>
        /// <para>
        /// If <paramref name="str"/> is a null pointer, space for the significand is allocated using the allocation function
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>)
        /// and a pointer to the string is returned (unless the base is invalid).
        /// To free the returned string, you must use <see cref="mpfr_free_str"/>. 
        /// </para>
        /// <para>
        /// If <paramref name="str"/> is not a null pointer, it should point to a block of storage large enough for the significand,
        /// i.e., at least max(<paramref name="n"/> + 2, 7).
        /// The extra two bytes are for a possible minus sign, and for the terminating null character, and the value 7 accounts
        /// for -@Inf@ plus the terminating null character.
        /// The pointer to the string <paramref name="str"/> is returned (unless the base is invalid). 
        /// </para>
        /// <para>
        /// Note: The NaN and inexact flags are currently not set when need be; this will be fixed in future versions.
        /// Programmers should currently assume that whether the flags are set by this function is unspecified. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="mpfr_lib.mpfr_get_str(char_ptr, ptr{mpfr_exp_t}, int, size_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static char_ptr /*char **/ mpfr_get_str(char_ptr /*char **/ str, ref mpfr_exp_t /*mpfr_exp_t **/ expptr, int b, size_t n, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (IntPtr.Size == 4)
                return new char_ptr(SafeNativeMethods.mpfr_get_str_x86(str.ToIntPtr(), ref expptr.Value, b, (uint)n, op.ToIntPtr(), (int)rnd));
            else
                return new char_ptr(SafeNativeMethods.mpfr_get_str_x64(str.ToIntPtr(), ref expptr.Value, b, n, op.ToIntPtr(), (int)rnd));
        }
        /// <summary>
        /// Convert <paramref name="op"/> to a string of digits in base <paramref name="b"/>, with rounding in the direction <paramref name="rnd"/>, where <paramref name="n"/> is either zero (see below) or the number of significant digits output in the string; in the latter case, <paramref name="n"/> must be greater or equal to 2. 
        /// </summary>
        /// <param name="str">The result string.</param>
        /// <param name="expptr">The returned exponent.</param>
        /// <param name="b">The base.</param>
        /// <param name="n">The number of digits in the result string.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return the converted string of digits.</returns>
        /// <remarks>
        /// <para>
        /// The base may vary from 2 to 62; otherwise the function does nothing and immediately returns a null pointer.
        /// If the input number is an ordinary number, the exponent is written through the pointer <paramref name="expptr"/>
        /// (for input 0, the current minimal exponent is written); the type <see cref="mpfr_exp_t"/> is large enough to hold the exponent in all cases.
        /// </para>
        /// <para>
        /// The generated string is a fraction, with an implicit radix point immediately to the left of the first digit.
        /// For example, the number -3.1416 would be returned as "-31416" in the string and 1 written at <paramref name="expptr"/>.
        /// If <paramref name="rnd"/> is to nearest, and <paramref name="op"/> is exactly in the middle of two consecutive possible outputs,
        /// the one with an even significand is chosen, where both significands are considered with the exponent of <paramref name="op"/>.
        /// Note that for an odd base, this may not correspond to an even last digit: for example with 2 digits in base 7, (14) and a half is rounded to (15) which is 12 in decimal,
        /// (16) and a half is rounded to (20) which is 14 in decimal, and (26) and a half is rounded to (26) which is 20 in decimal. 
        /// </para>
        /// <para>
        /// If <paramref name="n"/> is zero, the number of digits of the significand is chosen large enough so that re-reading the printed value with the same precision,
        /// assuming both output and input use rounding to nearest, will recover the original value of <paramref name="op"/>.
        /// More precisely, in most cases, the chosen precision of <paramref name="str"/> is the minimal precision m depending only on p = PREC(<paramref name="op"/>)
        /// and <paramref name="b"/> that satisfies the above property, i.e., m = 1 + ceil(p * log(2) / log(<paramref name="b"/>)), with p replaced by p - 1 if <paramref name="b"/>
        /// is a power of 2, but in some very rare cases, it might be m + 1 (the smallest case for bases up to 62 is when p equals 186564318007 for bases 7 and 49).
        /// </para>
        /// <para>
        /// If <paramref name="str"/> is a null pointer, space for the significand is allocated using the allocation function
        /// (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>)
        /// and a pointer to the string is returned (unless the base is invalid).
        /// To free the returned string, you must use <see cref="mpfr_free_str"/>. 
        /// </para>
        /// <para>
        /// If <paramref name="str"/> is not a null pointer, it should point to a block of storage large enough for the significand,
        /// i.e., at least max(<paramref name="n"/> + 2, 7).
        /// The extra two bytes are for a possible minus sign, and for the terminating null character, and the value 7 accounts
        /// for -@Inf@ plus the terminating null character.
        /// The pointer to the string <paramref name="str"/> is returned (unless the base is invalid). 
        /// </para>
        /// <para>
        /// Note: The NaN and inexact flags are currently not set when need be; this will be fixed in future versions.
        /// Programmers should currently assume that whether the flags are set by this function is unspecified. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="mpfr_lib.mpfr_get_str(char_ptr, ref mpfr_exp_t, int, size_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static char_ptr /*char **/ mpfr_get_str(char_ptr /*char **/ str, ptr<mpfr_exp_t> /*mpfr_exp_t **/ expptr, int b, size_t n, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (expptr == null) throw new ArgumentNullException("expptr");
            if (op == null) throw new ArgumentNullException("op");
            if (IntPtr.Size == 4)
                return new char_ptr(SafeNativeMethods.mpfr_get_str_x86(str.ToIntPtr(), ref expptr.Value.Value, b, (uint)n, op.ToIntPtr(), (int)rnd));
            else
                return new char_ptr(SafeNativeMethods.mpfr_get_str_x64(str.ToIntPtr(), ref expptr.Value.Value, b, n, op.ToIntPtr(), (int)rnd));
        }

        /// <summary>
        /// Convert <paramref name="op"/> to a <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/8beda7fb-bbc4-b56f-fd1f-1459377ecb3b.htm">mpz_t</a>, after rounding it with respect to <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op"/> is NaN or an infinity, the erange flag is set, <paramref name="rop"/> is set to 0, and 0 is returned.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib.mpfr_free_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_get_z(mpz_t /*mpz_ptr*/ rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_get_z(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Free a string allocated by <see cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/> using the unallocation function (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>).
        /// </summary>
        /// <param name="str">Pointer to string.</param>
        /// <remarks>
        /// <para>
        /// The block is assumed to be strlen(<paramref name="str"/>) + 1 bytes.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_get_d"/>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_d_2exp"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_frexp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_get_z"/>
        /// <seealso cref="mpfr_lib.mpfr_get_f"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_get_str"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_free_str(char_ptr /*char **/ str)
        {
            if (str == null) throw new ArgumentNullException("str");
            SafeNativeMethods.mpfr_free_str(str.ToIntPtr());
        }

        /// <summary>
        /// Generate a uniformly distributed random float.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="state">The state of the random number generator.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The floating-point number <paramref name="rop"/> can be seen as if a random real number is generated according to the continuous
        /// uniform distribution on the interval [0, 1] and then rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// The second argument is a <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/f7e5846d-548d-3bf3-74ac-219fde42a041.htm">gmp_randstate_t</a>
        /// structure which should be created using the GMP gmp_randinit function (see the GMP manual). 
        /// </para>
        /// <para>
        /// Note: the note for <see cref="mpfr_urandomb"/> holds too.
        /// In addition, the exponent range and the rounding mode might have a side effect on the next random state. 
        /// </para>
        /// <para>
        /// The rule for the underflow flag is here “underflow before rounding” instead of the usual “underflow after rounding”.
        /// The reason is that the exponent is drawn first, and if it is smaller than the minimum exponent, the significand is not drawn.
        /// To fix the behavior on the underflow flag, one would have to draw the significand in some cases, meaning that the behavior
        /// of the random generator would change, thus it would break the ABI for the MPFR 3.1 branch.
        /// However, the observed behavior always corresponds to an existing number. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_urandomb"/>
        /// <seealso cref="mpfr_lib.mpfr_grandom"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_urandom(mpfr_t rop, gmp_randstate_t state, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (state == null) throw new ArgumentNullException("state");
            return SafeNativeMethods.mpfr_urandom(rop.ToIntPtr(), state.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Generate two random floats according to a standard normal gaussian distribution.
        /// </summary>
        /// <param name="rop1">The first result operand floating-point number.</param>
        /// <param name="rop2">The second result operand floating-point number.</param>
        /// <param name="state">The state of the random number generator.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The combination of the ternary values is returned like with <see cref="mpfr_sin_cos"/>. If <paramref name="rop2"/> is a null pointer, the second ternary value is assumed to be 0 (note that the encoding of the only ternary value is not the same as the usual encoding for functions that return only one result). Otherwise the ternary value of a random number is always non-zero.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="rop2"/> is a null pointer, then only one value is generated and stored in <paramref name="rop1"/>. 
        /// </para>
        /// <para>
        /// The floating-point number <paramref name="rop1"/> (and <paramref name="rop2"/>) can be seen as if a random real number were
        /// generated according to the standard normal gaussian distribution and then rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// The third argument is a <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/f7e5846d-548d-3bf3-74ac-219fde42a041.htm">gmp_randstate_t</a>
        /// structure, which should be created using the GMP gmp_randinit function (see the GMP manual). 
        /// </para>
        /// <para>
        /// Note: the note for <see cref="mpfr_urandomb"/> holds too.
        /// In addition, the exponent range and the rounding mode might have a side effect on the next random state. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_urandomb"/>
        /// <seealso cref="mpfr_lib.mpfr_urandom"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_grandom(mpfr_t rop1, mpfr_t rop2, gmp_randstate_t state, mpfr_rnd_t rnd)
        {
            if (rop1 == null) throw new ArgumentNullException("rop1");
            if (state == null) throw new ArgumentNullException("state");
            return SafeNativeMethods.mpfr_grandom(rop1.ToIntPtr(), rop2 == null ? IntPtr.Zero : rop2.ToIntPtr(), state.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Generate a uniformly distributed random float in the interval 0 &#8804; <paramref name="rop"/> &lt; 1.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="state">The state of the random number generator.</param>
        /// <returns>Return 0, unless the exponent is not in the current exponent range, in which case <paramref name="rop"/> is set to NaN and a non-zero value is returned (this should never happen in practice, except in very specific cases).</returns>
        /// <remarks>
        /// <para>
        /// More precisely, the number can be seen as a float with a random non-normalized significand and exponent 0,
        /// which is then normalized (thus if e denotes the exponent after normalization, then the least -e significant bits of the significand are always 0).
        /// </para>
        /// <para>
        /// The second argument is a <a href="https://machinecognitis.github.io/Math.Gmp.Native/html/f7e5846d-548d-3bf3-74ac-219fde42a041.htm">gmp_randstate_t</a> structure
        /// which should be created using the GMP gmp_randinit function (see the GMP manual).
        /// </para>
        /// <para>
        /// Note: for a given version of MPFR, the returned value of rop and the new value of state (which controls further random values) do not depend on the machine word size.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_urandom"/>
        /// <seealso cref="mpfr_lib.mpfr_grandom"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_urandomb(mpfr_t rop, gmp_randstate_t state)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (state == null) throw new ArgumentNullException("state");
            return SafeNativeMethods.mpfr_urandomb(rop.ToIntPtr(), state.ToIntPtr());
        }

        /// <summary>
        /// Equivalent to <see cref="mpfr_nexttoward"/> where y is plus infinity. 
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <seealso cref="mpfr_lib.mpfr_nexttoward"/>
        /// <seealso cref="mpfr_lib.mpfr_nextbelow"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_nextabove(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_nextabove(x.ToIntPtr());
        }

        /// <summary>
        /// Equivalent to <see cref="mpfr_nexttoward"/> where y is minus infinity. 
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <seealso cref="mpfr_lib.mpfr_nexttoward"/>
        /// <seealso cref="mpfr_lib.mpfr_nextabove"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_nextbelow(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_nextbelow(x.ToIntPtr());
        }

        /// <summary>
        /// Replace <paramref name="x"/> by the next floating-point number in the direction of <paramref name="y"/>. 
        /// </summary>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <remarks>
        /// <para>
        /// If <paramref name="x"/> or <paramref name="y"/> is NaN, set <paramref name="x"/> to NaN.
        /// If <paramref name="x"/> and <paramref name="y"/> are equal, <paramref name="x"/> is unchanged.
        /// Otherwise, if <paramref name="x"/> is different from <paramref name="y"/>, replace <paramref name="x"/>
        /// by the next floating-point number (with the precision of <paramref name="x"/> and the current exponent range)
        /// in the direction of <paramref name="y"/> (the infinite values are seen as the smallest and largest
        /// floating-point numbers).
        /// If the result is zero, it keeps the same sign.
        /// No underflow or overflow is generated. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_nextabove"/>
        /// <seealso cref="mpfr_lib.mpfr_nextbelow"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_nexttoward(mpfr_t x, /*const*/ mpfr_t y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            SafeNativeMethods.mpfr_nexttoward(x.ToIntPtr(), y.ToIntPtr());
        }

        /// <summary>
        /// Print to stdout the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>.
        /// </summary>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written or a negative value if an error occurred.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_printf(/*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            return mpfr_vprintf(template, arguments);
        }

        /// <summary>
        /// Print to stdout the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>.
        /// </summary>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written or a negative value if an error occurred.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vprintf(/*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vprintf(format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Print to the stream <paramref name="stream"/> the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written or a negative value if an error occurred.</returns>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fprintf(ptr<FILE> /*FILE **/ stream, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            return mpfr_vfprintf(stream, template, arguments);
        }

        /// <summary>
        /// Print to the stream <paramref name="stream"/> the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written or a negative value if an error occurred.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vfprintf(ptr<FILE> /*FILE **/ stream, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vfprintf(stream.Value.Value, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Write output as a null terminated string in a block of memory allocated using the allocation function (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>).
        /// </summary>
        /// <param name="str">The output string.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>The return value is the number of characters written in the string, excluding the null-terminator, or a negative value if an error occurred, in which case the contents of <paramref name="str"/> are undefined.</returns>
        /// <remarks>
        /// <para>
        /// A pointer to the block is stored in <paramref name="str"/>. The block of memory must be freed using <see cref="mpfr_free_str"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_asprintf(ptr<char_ptr> /*char ***/ str, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            return mpfr_vasprintf(str, template, arguments);
        }

        /// <summary>
        /// Write output as a null terminated string in a block of memory allocated using the allocation function (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>).
        /// </summary>
        /// <param name="str">The output string.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>The return value is the number of characters written in the string, excluding the null-terminator, or a negative value if an error occurred, in which case the contents of <paramref name="str"/> are undefined.</returns>
        /// <remarks>
        /// <para>
        /// A pointer to the block is stored in <paramref name="str"/>. The block of memory must be freed using <see cref="mpfr_free_str"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vasprintf(ptr{char_ptr}, string, object[])"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vasprintf(ref char_ptr /*char ***/ str, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vasprintf(ref str.Pointer, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Write output as a null terminated string in a block of memory allocated using the allocation function (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Memory-Handling">GNU MPFR - Memory Handling</a>).
        /// </summary>
        /// <param name="str">The output string.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>The return value is the number of characters written in the string, excluding the null-terminator, or a negative value if an error occurred, in which case the contents of <paramref name="str"/> are undefined.</returns>
        /// <remarks>
        /// <para>
        /// A pointer to the block is stored in <paramref name="str"/>. The block of memory must be freed using <see cref="mpfr_free_str"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vasprintf(ref char_ptr, string, object[])"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vasprintf(ptr<char_ptr> /*char ***/ str, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            if (str == null) throw new ArgumentNullException("str");
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vasprintf(ref str.Value.Pointer, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Form a null-terminated string corresponding to the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>, and print it in <paramref name="buf"/>.
        /// </summary>
        /// <param name="buf">The output buffer.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written in the array buf not counting the terminating null character or a negative value if an error occurred.</returns>
        /// <remarks>
        /// <para>
        /// No overlap is permitted between buf and the other arguments.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sprintf(char_ptr /*char **/ buf, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            return mpfr_vsprintf(buf, template, arguments);
        }

        /// <summary>
        /// Form a null-terminated string corresponding to the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>, and print it in <paramref name="buf"/>.
        /// </summary>
        /// <param name="buf">The output buffer.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters written in the array buf not counting the terminating null character or a negative value if an error occurred.</returns>
        /// <remarks>
        /// <para>
        /// No overlap is permitted between buf and the other arguments.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vsprintf(char_ptr /*char **/ buf, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vsprintf(buf.ToIntPtr(), format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Form a null-terminated string corresponding to the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>, and print it in <paramref name="buf"/>.
        /// </summary>
        /// <param name="buf">The output buffer.</param>
        /// <param name="n">The number of characters written to the output buffer.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters that would have been written had n been sufficiently large, not counting the terminating null character, or a negative value if an error occurred.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="n"/> is zero, nothing is written and <paramref name="buf"/> may be a null pointer,
        /// otherwise, the <paramref name="n"/> - 1 first characters are written in <paramref name="buf"/> and
        /// the <paramref name="n"/>-th is a null character.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsnprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_snprintf(char_ptr /*char **/ buf, size_t n, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            return mpfr_vsnprintf(buf, n, template, arguments);
        }

        /// <summary>
        /// Form a null-terminated string corresponding to the optional <paramref name="arguments"/> under the control of the template string <paramref name="template"/>, and print it in <paramref name="buf"/>.
        /// </summary>
        /// <param name="buf">The output buffer.</param>
        /// <param name="n">The number of characters written to the output buffer.</param>
        /// <param name="template">Format string. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">Formatted Output Functions</a>.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Return the number of characters that would have been written had n been sufficiently large, not counting the terminating null character, or a negative value if an error occurred.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="n"/> is zero, nothing is written and <paramref name="buf"/> may be a null pointer,
        /// otherwise, the <paramref name="n"/> - 1 first characters are written in <paramref name="buf"/> and
        /// the <paramref name="n"/>-th is a null character.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vfprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_printf"/>
        /// <seealso cref="mpfr_lib.mpfr_vprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_sprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_vsprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_snprintf"/>
        /// <seealso cref="mpfr_lib.mpfr_asprintf"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_vasprintf"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Formatted-Output-Functions">GNU MPFR - Formatted Output Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vsnprintf(char_ptr /*char **/ buf, size_t n, /*const*/ string /*char **/ template, params object[] arguments /*...*/)
        {
            int result;
            va_list va_args = new va_list(arguments);
            char_ptr format = new char_ptr(template);
            if (IntPtr.Size == 4)
                result = SafeNativeMethods.mpfr_vsnprintf_x86(buf.ToIntPtr(), (uint)n, format.ToIntPtr(), va_args.ToIntPtr());
            else
                result = SafeNativeMethods.mpfr_vsnprintf_x64(buf.ToIntPtr(), n, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_pow(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_pow(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_pow_si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_pow_si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_pow_ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_pow_ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ui_pow_ui(mpfr_t rop, uint /*unsigned long int*/ op1, uint /*unsigned long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_ui_pow_ui(rop.ToIntPtr(), op1, op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ui_pow(mpfr_t rop, uint /*unsigned long int*/ op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_ui_pow(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> raised to <paramref name="op2"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the pow function: 
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus infinity for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus infinity for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus or minus zero for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(±0, y) returns plus zero for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-1, ±Inf) returns 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+1, y) returns 1 for any y, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, ±0) returns 1 for any x, even a NaN. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, y) returns NaN for finite negative x and finite non-integer y. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, -Inf) returns plus infinity for 0 &lt; abs(x) &lt; 1, and plus zero for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(x, +Inf) returns plus zero for 0 &lt; abs(x) &lt; 1, and plus infinity for abs(x) &gt; 1. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus zero for y a negative odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus zero for y negative and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns minus infinity for y a positive odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(-Inf, y) returns plus infinity for y positive and not an odd integer. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// pow(+Inf, y) returns plus zero for y negative, and plus infinity for y positive. 
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_si"/>
        /// <seealso cref="mpfr_lib.mpfr_pow_z"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_pow_z(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpz_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_pow_z(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the square root of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to -0 if <paramref name="op"/> is -0, to be consistent with the IEEE 754 standard.
        /// Set <paramref name="rop"/> to NaN if <paramref name="op"/> is negative. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_rec_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sqrt(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sqrt(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the square root of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to -0 if <paramref name="op"/> is -0, to be consistent with the IEEE 754 standard.
        /// Set <paramref name="rop"/> to NaN if <paramref name="op"/> is negative. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_rec_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sqrt_ui(mpfr_t rop, uint /*unsigned long*/ op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_sqrt_ui(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the reciprocal square root of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to +Inf if <paramref name="op"/> is ±0, +0 if <paramref name="op"/> is +Inf,
        /// and NaN if <paramref name="op"/> is negative.
        /// Warning!
        /// Therefore the result on -0 is different from the one of the rSqrt function recommended by the IEEE 754-2008 standard (Section 9.2.1), which is -Inf instead of +Inf. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_rec_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rec_sqrt(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_rec_sqrt(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_add(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_sub(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_mul(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_div(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add_ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_add_ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub_ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_sub_ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ui_sub(mpfr_t rop, uint /*unsigned long*/ op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_ui_sub(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ui_div(mpfr_t rop, uint /*unsigned long*/ op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_ui_div(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add_si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_add_si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub_si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_sub_si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_si_sub(mpfr_t rop, int /*long int*/ op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_si_sub(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long int*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_si_div(mpfr_t rop, int /*long int*/ op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_si_div(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// The <see cref="mpfr_add_d"/> function assumes that the radix of the double type is a power of 2,
        /// with a precision at most that declared by the C implementation
        /// (macro IEEE_DBL_MANT_DIG, and if not defined 53 bits). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add_d(mpfr_t rop, /*const*/ mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_add_d(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// The same restrictions than for <see cref="mpfr_add_d"/> apply to <see cref="mpfr_sub_d"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub_d(mpfr_t rop, /*const*/ mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_sub_d(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// The same restrictions than for <see cref="mpfr_add_d"/> apply to <see cref="mpfr_d_sub"/> and <see cref="mpfr_sub_d"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_d_sub(mpfr_t rop, double op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_d_sub(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// The same restrictions than for <see cref="mpfr_add_d"/> apply to <see cref="mpfr_mul_d"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_d(mpfr_t rop, /*const*/ mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_d(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// The same restrictions than for <see cref="mpfr_add_d"/> apply to <see cref="mpfr_d_div"/> and <see cref="mpfr_div_d"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_d(mpfr_t rop, /*const*/ mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_d(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// The same restrictions than for <see cref="mpfr_add_d"/> apply to <see cref="mpfr_d_div"/> and <see cref="mpfr_div_d"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_d_div(mpfr_t rop, double op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_d_div(rop.ToIntPtr(), op1, op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the square of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sqr(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_sqr(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of Pi rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function caches the computed values to avoid other calculations if a lower or equal precision is requested.
        /// To free the cache, use <see cref="mpfr_free_cache"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_const_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_const_euler"/>
        /// <seealso cref="mpfr_lib.mpfr_const_catalan"/>
        /// <seealso cref="mpfr_lib.mpfr_free_cache"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_const_pi(mpfr_t rop, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_const_pi(rop.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the logarithm of 2 rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function caches the computed values to avoid other calculations if a lower or equal precision is requested.
        /// To free the cache, use <see cref="mpfr_free_cache"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_const_pi"/>
        /// <seealso cref="mpfr_lib.mpfr_const_euler"/>
        /// <seealso cref="mpfr_lib.mpfr_const_catalan"/>
        /// <seealso cref="mpfr_lib.mpfr_free_cache"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_const_log2(mpfr_t rop, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_const_log2(rop.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of Euler’s constant 0.577… rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function caches the computed values to avoid other calculations if a lower or equal precision is requested.
        /// To free the cache, use <see cref="mpfr_free_cache"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_const_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_const_pi"/>
        /// <seealso cref="mpfr_lib.mpfr_const_catalan"/>
        /// <seealso cref="mpfr_lib.mpfr_free_cache"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_const_euler(mpfr_t rop, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_const_euler(rop.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of Catalan’s constant 0.915… rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function caches the computed values to avoid other calculations if a lower or equal precision is requested.
        /// To free the cache, use <see cref="mpfr_free_cache"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_const_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_const_pi"/>
        /// <seealso cref="mpfr_lib.mpfr_const_euler"/>
        /// <seealso cref="mpfr_lib.mpfr_free_cache"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_const_catalan(mpfr_t rop, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_const_catalan(rop.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the arithmetic-geometric mean of <paramref name="op1"/> and <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The arithmetic-geometric mean is the common limit of the sequences u(n) and v(n), where u(0) = <paramref name="op1"/>, v(0) = <paramref name="op2"/>,
        /// u(n + 1) is the arithmetic mean of u(n) and v(n), and v(n + 1) is the geometric mean of u(n) and v(n).
        /// If any operand is negative, set <paramref name="rop"/> to NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_agm(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_agm(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the natural logarithm of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to +0 if <paramref name="op"/> is 1 (in all rounding modes), for consistency with the ISO C99 and IEEE 754-2008 standards.
        /// Set <paramref name="rop"/> to -Inf if <paramref name="op"/> is ±0 (i.e., the sign of the zero has no influence on the result). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_log(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_log(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to log2(<paramref name="op"/>) rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to +0 if <paramref name="op"/> is 1 (in all rounding modes), for consistency with the ISO C99 and IEEE 754-2008 standards.
        /// Set <paramref name="rop"/> to -Inf if <paramref name="op"/> is ±0 (i.e., the sign of the zero has no influence on the result). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_log2(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_log2(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to log10(<paramref name="op"/>) rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Set <paramref name="rop"/> to +0 if <paramref name="op"/> is 1 (in all rounding modes), for consistency with the ISO C99 and IEEE 754-2008 standards.
        /// Set <paramref name="rop"/> to -Inf if <paramref name="op"/> is ±0 (i.e., the sign of the zero has no influence on the result). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_log10(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_log10(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the logarithm of one plus <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_log1p(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_log1p(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the exponential of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_exp(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_exp(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to 2^<paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_exp2(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_exp2(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to 10^<paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_expm1"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_exp10(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_exp10(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the exponential of <paramref name="op"/> followed by a subtraction by one, rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_log"/>
        /// <seealso cref="mpfr_lib.mpfr_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_log10"/>
        /// <seealso cref="mpfr_lib.mpfr_log1p"/>
        /// <seealso cref="mpfr_lib.mpfr_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_exp2"/>
        /// <seealso cref="mpfr_lib.mpfr_exp10"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_expm1(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_expm1(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the exponential integral of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_eint(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_eint(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to real part of the dilogarithm of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// MPFR defines the dilogarithm function as the integral of -log(1 - t) / t from 0 to <paramref name="op"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_li2(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_li2(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_cmp(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_d(/*const*/ mpfr_t op1, double op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_cmp_d(op1.ToIntPtr(), op2);
        }

        /// <summary>
        /// Compare |<paramref name="op1"/>| and |<paramref name="op2"/>|.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if |<paramref name="op1"/>| &gt; |<paramref name="op2"/>|, zero if |<paramref name="op1"/>| = |<paramref name="op2"/>|, and a negative value if |<paramref name="op1"/>| &lt; |<paramref name="op2"/>|.</returns>
        /// <remarks>
        /// <para>
        /// If one of the operands is NaN, set the erange flag and return zero.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmpabs(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_cmpabs(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_ui(/*const*/ mpfr_t op1, uint /*unsigned long*/ op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_cmp_ui(op1.ToIntPtr(), op2);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_si(/*const*/ mpfr_t op1, int /*long*/ op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_cmp_si(op1.ToIntPtr(), op2);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/> * 2^<paramref name="e"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="e">The exponent.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/> * 2^<paramref name="e"/>, zero if <paramref name="op1"/> = <paramref name="op2"/> * 2^<paramref name="e"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/> * 2^<paramref name="e"/>.</returns>
        /// <remarks>
        /// <para>
        /// Similar as <see cref="mpfr_cmp"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_ui_2exp(/*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_exp_t e)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_cmp_ui_2exp(op1.ToIntPtr(), op2, e);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/> * 2^<paramref name="e"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="e">The exponent.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/> * 2^<paramref name="e"/>, zero if <paramref name="op1"/> = <paramref name="op2"/> * 2^<paramref name="e"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/> * 2^<paramref name="e"/>.</returns>
        /// <remarks>
        /// <para>
        /// Similar as <see cref="mpfr_cmp"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_si_2exp(/*const*/ mpfr_t op1, int /*long*/ op2, mpfr_exp_t e)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_cmp_si_2exp(op1.ToIntPtr(), op2, e);
        }

        /// <summary>
        /// Compute the relative difference between <paramref name="op1"/> and <paramref name="op2"/> and store the result in <paramref name="rop"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <remarks>
        /// <para>
        /// This function does not guarantee the correct rounding on the relative difference;
        /// it just computes |<paramref name="op1"/> - <paramref name="op2"/>| / <paramref name="op1"/>,
        /// using the precision of <paramref name="rop"/> and the rounding mode <paramref name="rnd"/> for all operations. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_prec_raw"/>
        /// <seealso cref="mpfr_lib.mpfr_eq"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_div_2exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Compatibility-with-MPF">GNU MPFR - Compatibility With MPF</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_reldiff(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            SafeNativeMethods.mpfr_reldiff(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> and <paramref name="op2"/> are both non-zero ordinary numbers with the same exponent and the same first <paramref name="op3"/> bits.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3">The third operand integer.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> and <paramref name="op2"/> are both non-zero ordinary numbers with the same exponent and the same first <paramref name="op3"/> bits, both zero, or both infinities of the same sign. Return zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// This function is defined for compatibility with MPF, we do not recommend to use it otherwise.
        /// Do not use it either if you want to know whether two numbers are close to each other;
        /// for instance, 1.011111 and 1.100000 are regarded as different for any value of <paramref name="op3"/> larger than 1. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_prec_raw"/>
        /// <seealso cref="mpfr_lib.mpfr_reldiff"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_div_2exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Compatibility-with-MPF">GNU MPFR - Compatibility With MPF</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_eq(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2, uint /*unsigned long*/ op3)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_eq(op1.ToIntPtr(), op2.ToIntPtr(), op3);
        }

        /// <summary>
        /// Return a positive value if <paramref name="op"/> &gt; 0, zero if <paramref name="op"/> = 0, and a negative value if <paramref name="op"/> &lt; 0.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op"/> &gt; 0, zero if <paramref name="op"/> = 0, and a negative value if <paramref name="op"/> &lt; 0.</returns>
        /// <remarks>
        /// <para>
        /// If the operand is NaN, set the erange flag and return zero.
        /// This is equivalent to <see cref="mpfr_cmp_ui"/>(<paramref name="op"/>, 0), but more efficient. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sgn(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sgn(op.ToIntPtr());
        }

        /// <summary>
        /// This function is identical to <see cref="mpfr_mul_2ui"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function is only kept for compatibility with MPF, one should prefer <see cref="mpfr_mul_2ui"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_prec_raw"/>
        /// <seealso cref="mpfr_lib.mpfr_eq"/>
        /// <seealso cref="mpfr_lib.mpfr_reldiff"/>
        /// <seealso cref="mpfr_lib.mpfr_div_2exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Compatibility-with-MPF">GNU MPFR - Compatibility With MPF</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_2exp(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_2exp(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// This function is identical to <see cref="mpfr_div_2ui"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// This function is only kept for compatibility with MPF, one should prefer <see cref="mpfr_div_2ui"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set_prec_raw"/>
        /// <seealso cref="mpfr_lib.mpfr_eq"/>
        /// <seealso cref="mpfr_lib.mpfr_reldiff"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2exp"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Compatibility-with-MPF">GNU MPFR - Compatibility With MPF</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_2exp(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_2exp(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * 2^<paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just increases the exponent by <paramref name="op2"/> when <paramref name="rop"/> and <paramref name="op1"/> are identical. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_2ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_2ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> divided by 2^<paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just decreases the exponent by <paramref name="op2"/> when <paramref name="rop"/> and <paramref name="op1"/> are identical. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_2ui(mpfr_t rop, /*const*/ mpfr_t op1, uint /*unsigned long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_2ui(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * 2^<paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just increases the exponent by <paramref name="op2"/> when <paramref name="rop"/> and <paramref name="op1"/> are identical. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_2si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_mul_2si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> divided by 2^<paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Just decreases the exponent by <paramref name="op2"/> when <paramref name="rop"/> and <paramref name="op1"/> are identical. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_2si(mpfr_t rop, /*const*/ mpfr_t op1, int /*long*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            return SafeNativeMethods.mpfr_div_2si(rop.ToIntPtr(), op1.ToIntPtr(), op2, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the nearest representable integer in the given direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned value is zero when the result is exact, positive when it is greater than the original value of <paramref name="op"/>, and negative when it is smaller. More precisely, the returned value is 0 when <paramref name="op"/> is an integer representable in <paramref name="rop"/>, 1 or -1 when <paramref name="op"/> is an integer that is not representable in <paramref name="rop"/>, 2 or -2 when <paramref name="op"/> is not an integer.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, the NaN flag is set as usual.
        /// In the other cases, the inexact flag is set when <paramref name="rop"/> differs from <paramref name="op"/>, following the ISO C99 rule for the rint function.
        /// If you want the behavior to be more like IEEE 754 / ISO TS 18661-1, i.e., the usual behavior where the round-to-integer function is regarded as any other
        /// mathematical function, you should use one the mpfr_rint_* functions instead (however it is not possible to round to nearest with the even rounding rule yet). 
        /// </para>
        /// <para>
        /// Note that <see cref="mpfr_round"/> is different from <see cref="mpfr_rint"/> called with the rounding to nearest mode (where halfway cases are rounded to an
        /// even integer or significand).
        /// Note also that no double rounding is performed; for instance, 10.5 (1010.1 in binary) is rounded by <see cref="mpfr_rint"/> with rounding to nearest
        /// to 12 (1100 in binary) in 2-bit precision, because the two enclosing numbers representable on two bits are 8 and 12, and the closest is 12.
        /// (If one first rounded to an integer, one would round 10.5 to 10 with even rounding, and then 10 would be rounded to 8 again with even rounding.) 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rint(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_rint(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the nearest representable integer, rounding halfway cases away from zero (as in the roundTiesToAway mode of IEEE 754-2008). 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>The returned value is zero when the result is exact, positive when it is greater than the original value of <paramref name="op"/>, and negative when it is smaller. More precisely, the returned value is 0 when <paramref name="op"/> is an integer representable in <paramref name="rop"/>, 1 or -1 when <paramref name="op"/> is an integer that is not representable in <paramref name="rop"/>, 2 or -2 when <paramref name="op"/> is not an integer.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, the NaN flag is set as usual.
        /// In the other cases, the inexact flag is set when <paramref name="rop"/> differs from <paramref name="op"/>, following the ISO C99 rule for the rint function.
        /// If you want the behavior to be more like IEEE 754 / ISO TS 18661-1, i.e., the usual behavior where the round-to-integer function is regarded as any other
        /// mathematical function, you should use one the mpfr_rint_* functions instead (however it is not possible to round to nearest with the even rounding rule yet). 
        /// </para>
        /// <para>
        /// Note that <see cref="mpfr_round"/> is different from <see cref="mpfr_rint"/> called with the rounding to nearest mode (where halfway cases are rounded to an
        /// even integer or significand).
        /// Note also that no double rounding is performed; for instance, 10.5 (1010.1 in binary) is rounded by <see cref="mpfr_rint"/> with rounding to nearest
        /// to 12 (1100 in binary) in 2-bit precision, because the two enclosing numbers representable on two bits are 8 and 12, and the closest is 12.
        /// (If one first rounded to an integer, one would round 10.5 to 10 with even rounding, and then 10 would be rounded to 8 again with even rounding.) 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_round(mpfr_t rop, /*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_round(rop.ToIntPtr(), op.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next representable integer toward zero. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>The returned value is zero when the result is exact, positive when it is greater than the original value of <paramref name="op"/>, and negative when it is smaller. More precisely, the returned value is 0 when <paramref name="op"/> is an integer representable in <paramref name="rop"/>, 1 or -1 when <paramref name="op"/> is an integer that is not representable in <paramref name="rop"/>, 2 or -2 when <paramref name="op"/> is not an integer.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, the NaN flag is set as usual.
        /// In the other cases, the inexact flag is set when <paramref name="rop"/> differs from <paramref name="op"/>, following the ISO C99 rule for the rint function.
        /// If you want the behavior to be more like IEEE 754 / ISO TS 18661-1, i.e., the usual behavior where the round-to-integer function is regarded as any other
        /// mathematical function, you should use one the mpfr_rint_* functions instead (however it is not possible to round to nearest with the even rounding rule yet). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_trunc(mpfr_t rop, /*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_trunc(rop.ToIntPtr(), op.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next higher or equal representable integer. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>The returned value is zero when the result is exact, positive when it is greater than the original value of <paramref name="op"/>, and negative when it is smaller. More precisely, the returned value is 0 when <paramref name="op"/> is an integer representable in <paramref name="rop"/>, 1 or -1 when <paramref name="op"/> is an integer that is not representable in <paramref name="rop"/>, 2 or -2 when <paramref name="op"/> is not an integer.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, the NaN flag is set as usual.
        /// In the other cases, the inexact flag is set when <paramref name="rop"/> differs from <paramref name="op"/>, following the ISO C99 rule for the rint function.
        /// If you want the behavior to be more like IEEE 754 / ISO TS 18661-1, i.e., the usual behavior where the round-to-integer function is regarded as any other
        /// mathematical function, you should use one the mpfr_rint_* functions instead (however it is not possible to round to nearest with the even rounding rule yet). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ceil(mpfr_t rop, /*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_ceil(rop.ToIntPtr(), op.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next lower or equal representable integer. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>The returned value is zero when the result is exact, positive when it is greater than the original value of <paramref name="op"/>, and negative when it is smaller. More precisely, the returned value is 0 when <paramref name="op"/> is an integer representable in <paramref name="rop"/>, 1 or -1 when <paramref name="op"/> is an integer that is not representable in <paramref name="rop"/>, 2 or -2 when <paramref name="op"/> is not an integer.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, the NaN flag is set as usual.
        /// In the other cases, the inexact flag is set when <paramref name="rop"/> differs from <paramref name="op"/>, following the ISO C99 rule for the rint function.
        /// If you want the behavior to be more like IEEE 754 / ISO TS 18661-1, i.e., the usual behavior where the round-to-integer function is regarded as any other
        /// mathematical function, you should use one the mpfr_rint_* functions instead (however it is not possible to round to nearest with the even rounding rule yet). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_floor(mpfr_t rop, /*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_floor(rop.ToIntPtr(), op.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the nearest integer, rounding halfway cases away from zero.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> associated with the considered round-to-integer function (regarded in the same way as any other mathematical function).</returns>
        /// <remarks>
        /// <para>
        /// If the result is not representable, it is rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// Contrary to <see cref="mpfr_rint"/>, this function does perform a double rounding: first <paramref name="op"/> is rounded to the nearest integer
        /// in the direction given by the function name, then this nearest integer (if not representable) is rounded in the given direction <paramref name="rnd"/>.
        /// Thus these round-to-integer functions behave more like the other mathematical functions, i.e., the returned result is the correct rounding of the
        /// exact result of the function in the real numbers. 
        /// </para>
        /// <para>
        /// For example, <see cref="mpfr_rint_round"/> with rounding to nearest and a precision of two bits rounds 6.5 to 7 (halfway cases away from zero),
        /// then 7 is rounded to 8 by the round-even rule, despite the fact that 6 is also representable on two bits, and is closer to 6.5 than 8.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rint_round(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_rint_round(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next integer toward zero.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> associated with the considered round-to-integer function (regarded in the same way as any other mathematical function).</returns>
        /// <remarks>
        /// <para>
        /// If the result is not representable, it is rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// Contrary to <see cref="mpfr_rint"/>, this function does perform a double rounding: first <paramref name="op"/> is rounded to the nearest integer
        /// in the direction given by the function name, then this nearest integer (if not representable) is rounded in the given direction <paramref name="rnd"/>.
        /// Thus these round-to-integer functions behave more like the other mathematical functions, i.e., the returned result is the correct rounding of the
        /// exact result of the function in the real numbers. 
        /// </para>
        /// <para>
        /// For example, <see cref="mpfr_rint_round"/> with rounding to nearest and a precision of two bits rounds 6.5 to 7 (halfway cases away from zero),
        /// then 7 is rounded to 8 by the round-even rule, despite the fact that 6 is also representable on two bits, and is closer to 6.5 than 8.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rint_trunc(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_rint_trunc(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next higher or equal integer.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> associated with the considered round-to-integer function (regarded in the same way as any other mathematical function).</returns>
        /// <remarks>
        /// <para>
        /// If the result is not representable, it is rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// Contrary to <see cref="mpfr_rint"/>, this function does perform a double rounding: first <paramref name="op"/> is rounded to the nearest integer
        /// in the direction given by the function name, then this nearest integer (if not representable) is rounded in the given direction <paramref name="rnd"/>.
        /// Thus these round-to-integer functions behave more like the other mathematical functions, i.e., the returned result is the correct rounding of the
        /// exact result of the function in the real numbers. 
        /// </para>
        /// <para>
        /// For example, <see cref="mpfr_rint_round"/> with rounding to nearest and a precision of two bits rounds 6.5 to 7 (halfway cases away from zero),
        /// then 7 is rounded to 8 by the round-even rule, despite the fact that 6 is also representable on two bits, and is closer to 6.5 than 8.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rint_ceil(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_rint_ceil(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op"/> rounded to the next lower or equal integer.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> associated with the considered round-to-integer function (regarded in the same way as any other mathematical function).</returns>
        /// <remarks>
        /// <para>
        /// If the result is not representable, it is rounded in the direction <paramref name="rnd"/>. 
        /// </para>
        /// <para>
        /// Contrary to <see cref="mpfr_rint"/>, this function does perform a double rounding: first <paramref name="op"/> is rounded to the nearest integer
        /// in the direction given by the function name, then this nearest integer (if not representable) is rounded in the given direction <paramref name="rnd"/>.
        /// Thus these round-to-integer functions behave more like the other mathematical functions, i.e., the returned result is the correct rounding of the
        /// exact result of the function in the real numbers. 
        /// </para>
        /// <para>
        /// For example, <see cref="mpfr_rint_round"/> with rounding to nearest and a precision of two bits rounds 6.5 to 7 (halfway cases away from zero),
        /// then 7 is rounded to 8 by the round-even rule, despite the fact that 6 is also representable on two bits, and is closer to 6.5 than 8.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_rint_floor(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_rint_floor(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the fractional part of <paramref name="op"/>, having the same sign as <paramref name="op"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Unlike in <see cref="mpfr_rint"/>, <paramref name="rnd"/> affects only how the exact fractional part is rounded, not how the fractional part is generated. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_frac(mpfr_t rop,/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_frac(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set simultaneously <paramref name="iop"/> to the integral part of <paramref name="op"/> and <paramref name="fop"/> to the fractional part of <paramref name="op"/>, rounded in the direction <paramref name="rnd"/> with the corresponding precision of <paramref name="iop"/> and <paramref name="fop"/>. 
        /// </summary>
        /// <param name="iop">The result integral part.</param>
        /// <param name="fop">The result frational part.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return 0 iff both results are exact (see <see cref="mpfr_sin_cos"/> for a more detailed description of the return value.</returns>
        /// <remarks>
        /// <para>
        /// Equivalent to <see cref="mpfr_trunc"/>(<paramref name="iop"/>, <paramref name="op"/>, <paramref name="rnd"/>)
        /// and <see cref="mpfr_frac"/>(<paramref name="fop"/>, <paramref name="op"/>, <paramref name="rnd"/>). 
        /// </para>
        /// <para>
        /// The variables <paramref name="iop"/> and <paramref name="fop"/> must be different.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_modf(mpfr_t iop, mpfr_t fop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (iop == null) throw new ArgumentNullException("iop");
            if (fop == null) throw new ArgumentNullException("fop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_modf(iop.ToIntPtr(), fop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="r"/> to the value of <paramref name="x"/> - n * <paramref name="y"/>, rounded according to the direction <paramref name="rnd"/>, where n is the integer quotient of <paramref name="x"/> divided by <paramref name="y"/>, rounded to the nearest integer (ties rounded to even). 
        /// </summary>
        /// <param name="r">The result remainder floating-point number.</param>
        /// <param name="q">Low significant bits of quotient.</param>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The return value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> corresponding to <paramref name="r"/>. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in Section F.9.7.1 of the ISO C99 standard:
        /// If <paramref name="x"/> is infinite or <paramref name="y"/> is zero, <paramref name="r"/> is NaN.
        /// If <paramref name="y"/> is infinite and <paramref name="x"/> is finite, <paramref name="r"/> is <paramref name="x"/> rounded to the precision of <paramref name="r"/>.
        /// If <paramref name="r"/> is zero, it has the sign of <paramref name="x"/>.
        /// </para>
        /// <para>
        /// Additionally, <see cref="O:Math.Mpfr.Native.mpfr_remquo"/> stores the low significant bits from the quotient n in <paramref name="q"/>
        /// (more precisely the number of bits in a long minus one), with the sign of <paramref name="x"/> divided by <paramref name="y"/>
        /// (except if those low bits are all zero, in which case zero is returned).
        /// Note that <paramref name="x"/> may be so large in magnitude relative to <paramref name="y"/> that an exact representation of the quotient
        /// is not practical.
        /// The <see cref="mpfr_remainder"/> and <see cref="O:Math.Mpfr.Native.mpfr_remquo"/> functions are useful for additive argument reduction. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="mpfr_lib.mpfr_remquo(mpfr_t, ptr{int}, mpfr_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_remquo(mpfr_t r, ref int /*long **/ q, /*const*/ mpfr_t x, /*const*/ mpfr_t y, mpfr_rnd_t rnd)
        {
            if (r == null) throw new ArgumentNullException("r");
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_remquo(r.ToIntPtr(), ref q, x.ToIntPtr(), y.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="r"/> to the value of <paramref name="x"/> - n * <paramref name="y"/>, rounded according to the direction <paramref name="rnd"/>, where n is the integer quotient of <paramref name="x"/> divided by <paramref name="y"/>, rounded to the nearest integer (ties rounded to even). 
        /// </summary>
        /// <param name="r">The result remainder floating-point number.</param>
        /// <param name="q">Low significant bits of quotient.</param>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The return value is the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> corresponding to <paramref name="r"/>. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in Section F.9.7.1 of the ISO C99 standard:
        /// If <paramref name="x"/> is infinite or <paramref name="y"/> is zero, <paramref name="r"/> is NaN.
        /// If <paramref name="y"/> is infinite and <paramref name="x"/> is finite, <paramref name="r"/> is <paramref name="x"/> rounded to the precision of <paramref name="r"/>.
        /// If <paramref name="r"/> is zero, it has the sign of <paramref name="x"/>.
        /// </para>
        /// <para>
        /// Additionally, <see cref="O:Math.Mpfr.Native.mpfr_remquo"/> stores the low significant bits from the quotient n in <paramref name="q"/>
        /// (more precisely the number of bits in a long minus one), with the sign of <paramref name="x"/> divided by <paramref name="y"/>
        /// (except if those low bits are all zero, in which case zero is returned).
        /// Note that <paramref name="x"/> may be so large in magnitude relative to <paramref name="y"/> that an exact representation of the quotient
        /// is not practical.
        /// The <see cref="mpfr_remainder"/> and <see cref="O:Math.Mpfr.Native.mpfr_remquo"/> functions are useful for additive argument reduction. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="mpfr_lib.mpfr_remquo(mpfr_t, ref int, mpfr_t, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_remquo(mpfr_t r, ptr<int> /*long **/ q, /*const*/ mpfr_t x, /*const*/ mpfr_t y, mpfr_rnd_t rnd)
        {
            if (r == null) throw new ArgumentNullException("r");
            if (q == null) throw new ArgumentNullException("q");
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_remquo(r.ToIntPtr(), ref q.Value, x.ToIntPtr(), y.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="r"/> to the value of <paramref name="x"/> - n * <paramref name="y"/>, rounded according to the direction <paramref name="rnd"/>, where n is the integer quotient of <paramref name="x"/> divided by <paramref name="y"/>, rounded to the nearest integer (ties rounded to even). 
        /// </summary>
        /// <param name="r">The result remainder floating-point number.</param>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The return value is the ternary value corresponding to <paramref name="r"/>. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in Section F.9.7.1 of the ISO C99 standard:
        /// If <paramref name="x"/> is infinite or <paramref name="y"/> is zero, <paramref name="r"/> is NaN.
        /// If <paramref name="y"/> is infinite and <paramref name="x"/> is finite, <paramref name="r"/> is <paramref name="x"/> rounded to the precision of <paramref name="r"/>.
        /// If <paramref name="r"/> is zero, it has the sign of <paramref name="x"/>.
        /// </para>
        /// <para>
        /// The <see cref="mpfr_remainder"/> and <see cref="O:Math.Mpfr.Native.mpfr_remquo"/> functions are useful for additive argument reduction. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_remainder(mpfr_t r, /*const*/ mpfr_t x, /*const*/ mpfr_t y, mpfr_rnd_t rnd)
        {
            if (r == null) throw new ArgumentNullException("r");
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_remainder(r.ToIntPtr(), x.ToIntPtr(), y.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="r"/> to the value of <paramref name="x"/> - n * <paramref name="y"/>, rounded according to the direction <paramref name="rnd"/>, where n is the integer quotient of <paramref name="x"/> divided by <paramref name="y"/>, rounded toward zero. 
        /// </summary>
        /// <param name="r">The result remainder floating-point number.</param>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The return value is the ternary value corresponding to <paramref name="r"/>. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in Section F.9.7.1 of the ISO C99 standard:
        /// If <paramref name="x"/> is infinite or <paramref name="y"/> is zero, <paramref name="r"/> is NaN.
        /// If <paramref name="y"/> is infinite and <paramref name="x"/> is finite, <paramref name="r"/> is <paramref name="x"/> rounded to the precision of <paramref name="r"/>.
        /// If <paramref name="r"/> is zero, it has the sign of <paramref name="x"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib.mpfr_integer_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fmod(mpfr_t r, /*const*/ mpfr_t x, /*const*/ mpfr_t y, mpfr_rnd_t rnd)
        {
            if (r == null) throw new ArgumentNullException("r");
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            return SafeNativeMethods.mpfr_fmod(r.ToIntPtr(), x.ToIntPtr(), y.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned long when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned long when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_ulong_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_ulong_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) long when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) long when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_slong_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_slong_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned long when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned long when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_get_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_uintmax_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_uintmax_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) long when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) long when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_get_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_intmax_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_intmax_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned int when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) unsigned int when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_uint_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_uint_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) int when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (32-bit) int when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_sint_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_sint_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (16-bit) unsigned short when rounded to an integer in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (16-bit) unsigned short when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sshort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_ushort_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_ushort_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> would fit in the C data type (16-bit) short when rounded to an integer in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return non-zero if <paramref name="op"/> would fit in the C data type (16-bit) short when rounded to an integer in the direction <paramref name="rnd"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_get_si"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ulong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_slong_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_sint_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_ushort_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_uintmax_p"/>
        /// <seealso cref="mpfr_lib.mpfr_fits_intmax_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Conversion-Functions">GNU MPFR - Conversion Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fits_sshort_p(/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_fits_sshort_p(op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Swap the structures pointed to by <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <remarks>
        /// <para>
        /// In particular, the values are exchanged without rounding (this may be different from three <see cref="mpfr_set"/> calls using a third auxiliary variable).
        /// </para>
        /// <para>
        /// Warning! Since the precisions are exchanged, this will affect future assignments.
        /// Moreover, since the significand pointers are also exchanged, you must not use this function if the allocation
        /// method used for <paramref name="x"/> and/or <paramref name="y"/> does not permit it.
        /// This is the case when <paramref name="x"/> and/or <paramref name="y"/> were declared and initialized
        /// with <see cref="mpfr_custom_init_set"/> (see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a>). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_str"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_strtofr"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_swap(mpfr_t x, mpfr_t y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            SafeNativeMethods.mpfr_swap(x.ToIntPtr(), y.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> is NaN. Return zero otherwise.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op"/> is NaN. Return zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_nan_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_nan_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> is an infinity. Return zero otherwise.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op"/> is an infinity. Return zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_inf_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_inf_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> is an ordinary number (i.e., neither NaN nor an infinity). Return zero otherwise.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op"/> is an ordinary number (i.e., neither NaN nor an infinity). Return zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_number_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_number_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero iff <paramref name="op"/> is an integer.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero iff <paramref name="op"/> is an integer.</returns>
        /// <seealso cref="mpfr_lib.mpfr_rint"/>
        /// <seealso cref="mpfr_lib.mpfr_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_round"/>
        /// <seealso cref="mpfr_lib.mpfr_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_ceil"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_floor"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_round"/>
        /// <seealso cref="mpfr_lib.mpfr_rint_trunc"/>
        /// <seealso cref="mpfr_lib.mpfr_frac"/>
        /// <seealso cref="mpfr_lib.mpfr_modf"/>
        /// <seealso cref="mpfr_lib.mpfr_fmod"/>
        /// <seealso cref="mpfr_lib.mpfr_remainder"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_remquo"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Integer-Related-Functions">GNU MPFR - Integer and Remainder Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_integer_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_integer_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> is zero. Return zero otherwise.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op"/> is zero. Return zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_zero_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_zero_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op"/> is a regular number (i.e., neither NaN, nor an infinity nor zero). Return zero otherwise.
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op"/> is a regular number (i.e., neither NaN, nor an infinity nor zero). Return zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_regular_p(/*const*/ mpfr_t op)
        {
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_regular_p(op.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> &gt; <paramref name="op2"/>, and zero otherwise.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> &gt; <paramref name="op2"/>, and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_greater_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_greater_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> &#8805; <paramref name="op2"/>, and zero otherwise.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> &#8805; <paramref name="op2"/>, and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_greaterequal_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_greaterequal_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> &lt; <paramref name="op2"/>, and zero otherwise.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> &lt; <paramref name="op2"/>, and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_less_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_less_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> &#8804; <paramref name="op2"/>, and zero otherwise.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN.</returns>
        /// <remarks>
        /// <para>
        /// Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_lessequal_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_lessequal_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> &lt; <paramref name="op2"/> or <paramref name="op1"/> &gt; <paramref name="op2"/> (i.e., neither <paramref name="op1"/>, nor <paramref name="op2"/> is NaN, and <paramref name="op1"/> &#8800; <paramref name="op2"/>), zero otherwise (i.e., <paramref name="op1"/> and/or <paramref name="op2"/> is NaN, or <paramref name="op1"/> = <paramref name="op2"/>).
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> &lt; <paramref name="op2"/> or <paramref name="op1"/> &gt; <paramref name="op2"/> (i.e., neither <paramref name="op1"/>, nor <paramref name="op2"/> is NaN, and <paramref name="op1"/> &#8800; <paramref name="op2"/>), zero otherwise (i.e., <paramref name="op1"/> and/or <paramref name="op2"/> is NaN, or <paramref name="op1"/> = <paramref name="op2"/>).</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_lessgreater_p(/*const*/ mpfr_t op1,/*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_lessgreater_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> = <paramref name="op2"/>, and zero otherwise.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> = <paramref name="op2"/>, and zero otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Return zero whenever <paramref name="op1"/> and/or <paramref name="op2"/> is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_equal_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_equal_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Return non-zero if <paramref name="op1"/> or <paramref name="op2"/> is a NaN (i.e., they cannot be compared), zero otherwise. 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return non-zero if <paramref name="op1"/> or <paramref name="op2"/> is a NaN (i.e., they cannot be compared), zero otherwise.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_unordered_p(/*const*/ mpfr_t op1, /*const*/ mpfr_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_unordered_p(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the inverse hyperbolic tangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_atanh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_atanh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the inverse hyperbolic cosine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_acosh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_acosh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the inverse hyperbolic sine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_asinh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_asinh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic cosine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cosh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_cosh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic sine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sinh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sinh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic tangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_tanh(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_tanh(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set simultaneously <paramref name="sop"/> to the hyperbolic sine of <paramref name="op"/> and <paramref name="cop"/> to the hyperbolic cosine of <paramref name="op"/>, rounded in the direction <paramref name="rnd"/> with the corresponding precision of <paramref name="sop"/> and <paramref name="cop"/>, which must be different variables.
        /// </summary>
        /// <param name="sop">The result hyperbolic sine.</param>
        /// <param name="cop">The result hyperbolic cosine.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return 0 iff both results are exact (see <see cref="mpfr_sin_cos"/> for a more detailed description of the return value).</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sinh_cosh(mpfr_t sop, mpfr_t cop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (sop == null) throw new ArgumentNullException("sop");
            if (cop == null) throw new ArgumentNullException("cop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sinh_cosh(sop.ToIntPtr(), cop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic secant of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sech(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sech(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic cosecant of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_coth"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_csch(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_csch(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the hyperbolic cotangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh"/>
        /// <seealso cref="mpfr_lib.mpfr_tanh"/>
        /// <seealso cref="mpfr_lib.mpfr_sinh_cosh"/>
        /// <seealso cref="mpfr_lib.mpfr_sech"/>
        /// <seealso cref="mpfr_lib.mpfr_csch"/>
        /// <seealso cref="mpfr_lib.mpfr_acosh"/>
        /// <seealso cref="mpfr_lib.mpfr_asinh"/>
        /// <seealso cref="mpfr_lib.mpfr_atanh"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_coth(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_coth(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the arc-cosine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that since acos(-1) returns the floating-point number closest to Pi according to the given rounding mode,
        /// this number might not be in the output range 0 &#8804; rop &lt; Pi of the arc-cosine function;
        /// still, the result lies in the image of the output range by the rounding function.
        /// The same holds for asin(-1), asin(1), atan(-Inf), atan(+Inf) or for atan(<paramref name="op"/>) with large
        /// <paramref name="op"/> and small precision of <paramref name="rop"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_acos(mpfr_t rop,/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_acos(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the arc-sine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that since acos(-1) returns the floating-point number closest to Pi according to the given rounding mode,
        /// this number might not be in the output range 0 &#8804; rop &lt; Pi of the arc-cosine function;
        /// still, the result lies in the image of the output range by the rounding function.
        /// The same holds for asin(-1), asin(1), atan(-Inf), atan(+Inf) or for atan(<paramref name="op"/>) with large
        /// <paramref name="op"/> and small precision of <paramref name="rop"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_asin(mpfr_t rop,/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_asin(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the arc-tangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Note that since acos(-1) returns the floating-point number closest to Pi according to the given rounding mode,
        /// this number might not be in the output range 0 &#8804; rop &lt; Pi of the arc-cosine function;
        /// still, the result lies in the image of the output range by the rounding function.
        /// The same holds for asin(-1), asin(1), atan(-Inf), atan(+Inf) or for atan(<paramref name="op"/>) with large
        /// <paramref name="op"/> and small precision of <paramref name="rop"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_atan(mpfr_t rop,/*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_atan(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the sine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sin(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sin(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set simultaneously <paramref name="sop"/> to the sine of <paramref name="op"/> and <paramref name="cop"/> to the cosine of <paramref name="op"/>, rounded in the direction <paramref name="rnd"/> with the corresponding precisions of <paramref name="sop"/> and <paramref name="cop"/>, which must be different variables.
        /// </summary>
        /// <param name="sop">The result sine.</param>
        /// <param name="cop">The result cosine.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return 0 iff both results are exact, more precisely it returns s + 4c where s = 0 if <paramref name="sop"/> is exact, s = 1 if <paramref name="sop"/> is larger than the sine of <paramref name="op"/>, s = 2 if <paramref name="sop"/> is smaller than the sine of <paramref name="op"/>, and similarly for c and the cosine of <paramref name="op"/>. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sin_cos(mpfr_t sop, mpfr_t cop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (sop == null) throw new ArgumentNullException("sop");
            if (cop == null) throw new ArgumentNullException("cop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sin_cos(sop.ToIntPtr(), cop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the cosine of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cos(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_cos(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the tangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_tan(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_tan(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the arc-tangent2 of <paramref name="y"/> and <paramref name="x"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="y">The ordinate floating-point value.</param>
        /// <param name="x">The abscissa floating-point value.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="x"/> &gt; 0, atan2(<paramref name="y"/>, <paramref name="x"/>) = atan(<paramref name="y"/>/<paramref name="x"/>);
        /// if <paramref name="x"/> &lt; 0, atan2(<paramref name="y"/>, <paramref name="x"/>) = sign(<paramref name="y"/>) * (Pi - atan(abs(<paramref name="y"/>/<paramref name="x"/>))),
        /// thus a number from -Pi to Pi.
        /// As for atan, in case the exact mathematical result is +Pi or -Pi, its rounded result might be outside the function output range. 
        /// </para>
        /// <para>
        /// atan2(<paramref name="y"/>, 0) does not raise any floating-point exception.
        /// Special values are handled as described in the ISO C99 and IEEE 754-2008 standards for the atan2 function:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        ///  atan2(+0, -0) returns +Pi. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        ///  atan2(-0, -0) returns -Pi. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+0, +0) returns +0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-0, +0) returns -0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+0, x) returns +Pi for x &lt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-0, x) returns -Pi for x &lt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+0, x) returns +0 for x &gt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-0, x) returns -0 for x &gt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, 0) returns -Pi/2 for y &lt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, 0) returns +Pi/2 for y &gt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+Inf, -Inf) returns +3 * Pi/4. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-Inf, -Inf) returns -3 * Pi/4. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+Inf, +Inf) returns +Pi/4. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-Inf, +Inf) returns -Pi/4. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(+Inf, x) returns +Pi/2 for finite x. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(-Inf, x) returns -Pi/2 for finite x. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, -Inf) returns +Pi for finite y &gt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, -Inf) returns -Pi for finite y &lt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, +Inf) returns +0 for finite y &gt; 0. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// atan2(y, +Inf) returns -0 for finite y &lt; 0.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_atan2(mpfr_t rop,/*const*/ mpfr_t y,/*const*/ mpfr_t x, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_atan2(rop.ToIntPtr(), y.ToIntPtr(), x.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the secant of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sec(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_sec(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the cosecant of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_cot"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_csc(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_csc(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the cotangent of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sin"/>
        /// <seealso cref="mpfr_lib.mpfr_tan"/>
        /// <seealso cref="mpfr_lib.mpfr_sin_cos"/>
        /// <seealso cref="mpfr_lib.mpfr_sec"/>
        /// <seealso cref="mpfr_lib.mpfr_csc"/>
        /// <seealso cref="mpfr_lib.mpfr_acos"/>
        /// <seealso cref="mpfr_lib.mpfr_asin"/>
        /// <seealso cref="mpfr_lib.mpfr_atan"/>
        /// <seealso cref="mpfr_lib.mpfr_atan2"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cot(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_cot(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the Euclidean norm of <paramref name="x"/> and <paramref name="y"/>, i.e., the square root of the sum of the squares of <paramref name="x"/> and <paramref name="y"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="x">The first operand floating-point number.</param>
        /// <param name="y">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Special values are handled as described in the ISO C99 (Section F.9.4.3) and IEEE 754-2008 (Section 9.2.1) standards:
        /// If <paramref name="x"/> or <paramref name="y"/> is an infinity, then +Inf is returned in <paramref name="rop"/>, even if the other number is NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_hypot(mpfr_t rop, /*const*/ mpfr_t x, /*const*/ mpfr_t y, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_hypot(rop.ToIntPtr(), x.ToIntPtr(), y.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the error function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_erf(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_erf(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the complementary error function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_erfc(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_erfc(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the cubic root of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cbrt(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_cbrt(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the <paramref name="k"/>th root of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="k">The degree of the root.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// For <paramref name="k"/> = 0, set <paramref name="rop"/> to NaN.
        /// For <paramref name="k"/> odd (resp. even) and <paramref name="op"/> negative (including -Inf),
        /// set <paramref name="rop"/> to a negative number (resp. NaN).
        /// The <paramref name="k"/>th root of -0 is defined to be -0, whatever the parity of <paramref name="k"/> (different from zero).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_root(mpfr_t rop, /*const*/ mpfr_t op, uint /*unsigned long*/ k, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_root(rop.ToIntPtr(), op.ToIntPtr(), k, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the Gamma function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is a negative integer, <paramref name="rop"/> is set to NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_gamma(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_gamma(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the logarithm of the Gamma function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is 1 or 2, set <paramref name="rop"/> to +0 (in all rounding modes).
        /// When <paramref name="op"/> is an infinity or a nonpositive integer, set <paramref name="rop"/> to +Inf,
        /// following the general rules on special values.
        /// When -2k - 1 &lt; op &lt; -2k, k being a nonnegative integer, set <paramref name="rop"/> to NaN.
        /// See also <see cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_lngamma(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_lngamma(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the logarithm of the absolute value of the Gamma function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="signp">The returned sign.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The sign (1 or -1) of Gamma(<paramref name="op"/>) is returned in the object pointed to by <paramref name="signp"/>.
        /// When <paramref name="op"/> is 1 or 2, set <paramref name="rop"/> to +0 (in all rounding modes).
        /// When <paramref name="op"/> is an infinity or a nonpositive integer, set <paramref name="rop"/> to +Inf.
        /// When <paramref name="op"/> is NaN, -Inf or a negative integer, <paramref name="signp"/> is undefined,
        /// and when <paramref name="op"/> is ±0, <paramref name="signp"/> is the sign of the zero.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lgamma(mpfr_t, ptr{int}, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_lgamma(mpfr_t rop, ref int /*int **/ signp, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_lgamma(rop.ToIntPtr(), ref signp, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the logarithm of the absolute value of the Gamma function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="signp">The returned sign.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The sign (1 or -1) of Gamma(<paramref name="op"/>) is returned in the object pointed to by <paramref name="signp"/>.
        /// When <paramref name="op"/> is 1 or 2, set <paramref name="rop"/> to +0 (in all rounding modes).
        /// When <paramref name="op"/> is an infinity or a nonpositive integer, set <paramref name="rop"/> to +Inf.
        /// When <paramref name="op"/> is NaN, -Inf or a negative integer, <paramref name="signp"/> is undefined,
        /// and when <paramref name="op"/> is ±0, <paramref name="signp"/> is the sign of the zero.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lgamma(mpfr_t, ref int, mpfr_t, mpfr_rnd_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_lgamma(mpfr_t rop, ptr<int> /*int **/ signp, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (signp == null) throw new ArgumentNullException("signp");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_lgamma(rop.ToIntPtr(), ref signp.Value, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the Digamma (sometimes also called Psi) function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is a negative integer, set <paramref name="rop"/> to NaN. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_digamma(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_digamma(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the Riemann Zeta function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_zeta(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_zeta(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the Riemann Zeta function on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_zeta_ui(mpfr_t rop, uint /*unsigned long*/ op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_zeta_ui(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the factorial of <paramref name="op"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fac_ui(mpfr_t rop, uint /*unsigned long int*/ op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_fac_ui(rop.ToIntPtr(), op, (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order 0 on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_j0(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_j0(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order 1 on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_j1(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_j1(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order <paramref name="n"/> on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="n">Order of the Bessel function.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// When <paramref name="op"/> is zero, and <paramref name="n"/> is not zero, <paramref name="rop"/>
        /// is set to +0 or -0 depending on the parity and sign of <paramref name="n"/>, and the sign of <paramref name="op"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_jn(mpfr_t rop, int /*long*/ n, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_jn(rop.ToIntPtr(), n, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order 0 on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_y0(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_y0(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order 1 on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_y1(mpfr_t rop, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_y1(rop.ToIntPtr(), op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the first kind Bessel function of order <paramref name="n"/> on <paramref name="op"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="n">Order of the Bessel function.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="op"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="op"/> is plus or minus Infinity, <paramref name="rop"/> is set to +0.
        /// When <paramref name="op"/> is zero, and <paramref name="n"/> is not zero, <paramref name="rop"/>
        /// is set to +0 or -0 depending on the parity and sign of <paramref name="n"/>, and the sign of <paramref name="op"/>. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_yn(mpfr_t rop, int /*long*/ n, /*const*/ mpfr_t op, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op == null) throw new ArgumentNullException("op");
            return SafeNativeMethods.mpfr_yn(rop.ToIntPtr(), n, op.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the value of the Airy function Ai on <paramref name="x"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="x"/> is NaN, <paramref name="rop"/> is always set to NaN.
        /// When <paramref name="x"/> is +Inf or -Inf, <paramref name="rop"/> is +0.
        /// The current implementation is not intended to be used with large arguments.
        /// It works with abs(<paramref name="x"/>) typically smaller than 500.
        /// For larger arguments, other methods should be used and will be implemented in a future version. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_ai(mpfr_t rop, /*const*/ mpfr_t x, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_ai(rop.ToIntPtr(), x.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the minimum of <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op1"/> and <paramref name="op2"/> are both NaN, then <paramref name="rop"/> is set to NaN.
        /// If <paramref name="op1"/> or <paramref name="op2"/> is NaN, then <paramref name="rop"/> is set to the numeric value.
        /// If <paramref name="op1"/> and <paramref name="op2"/> are zeros of different signs, then <paramref name="rop"/> is set to -0. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_max"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_min(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_min(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the maximum of <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="op1"/> and <paramref name="op2"/> are both NaN, then <paramref name="rop"/> is set to NaN.
        /// If <paramref name="op1"/> or <paramref name="op2"/> is NaN, then <paramref name="rop"/> is set to the numeric value.
        /// If <paramref name="op1"/> and <paramref name="op2"/> are zeros of different signs, then <paramref name="rop"/> is set to +0. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_min"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Miscellaneous-Functions">GNU MPFR - Miscellaneous Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_max(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_max(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the positive difference of <paramref name="op1"/> and <paramref name="op2"/>, i.e., <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/> if <paramref name="op1"/> &gt; <paramref name="op2"/>, +0 if <paramref name="op1"/> &#8804; <paramref name="op2"/>, and NaN if <paramref name="op1"/> or <paramref name="op2"/> is NaN. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_dim(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_dim(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_z(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpz_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_mul_z(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_z(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpz_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_div_z(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add_z(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpz_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_add_z(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub_z(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpz_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_sub_z(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_z_sub(mpfr_t rop, /*const*/ mpz_t op1, /*const*/ mpfr_t op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_z_sub(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_z(/*const*/ mpfr_t op1, /*const*/ mpz_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_cmp_z(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> * <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_si"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_d"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_z"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2ui"/>
        /// <seealso cref="mpfr_lib.mpfr_mul_2si"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_mul_q(mpfr_t rop, /*const*/ mpfr_t op1, mpq_t /*mpq_srcptr*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_mul_q(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> / <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// When a result is zero, its sign is the product of the signs of the operands
        /// (for types having no signed zeros, 0 is considered positive).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_div"/>
        /// <seealso cref="mpfr_lib.mpfr_div_d"/>
        /// <seealso cref="mpfr_lib.mpfr_div_z"/>
        /// <seealso cref="mpfr_lib.mpfr_div_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_div_q(mpfr_t rop, /*const*/ mpfr_t op1, mpq_t /*mpq_srcptr*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_div_q(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> + <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) + 0 = (+0) and (-0) + 0 = (-0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib.mpfr_sum"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_add_q(mpfr_t rop, /*const*/ mpfr_t op1, mpq_t /*mpq_srcptr*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_add_q(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to <paramref name="op1"/> - <paramref name="op2"/> rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The IEEE-754 rules are used, in particular for signed zeros.
        /// But for types having no signed zeros, 0 is considered unsigned
        /// (i.e., (+0) - 0 = (+0), (-0) - 0 = (-0), 0 - (+0) = (-0) and 0 - (-0) = (+0)).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_ui_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_si_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_si"/>
        /// <seealso cref="mpfr_lib.mpfr_d_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_d"/>
        /// <seealso cref="mpfr_lib.mpfr_z_sub"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_z"/>
        /// <seealso cref="mpfr_lib.mpfr_sub_q"/>
        /// <seealso cref="mpfr_lib.mpfr_mul"/>
        /// <seealso cref="mpfr_lib.mpfr_sqr"/>
        /// <seealso cref="mpfr_lib.mpfr_div"/>
        /// <seealso cref="mpfr_lib.mpfr_sqrt"/>
        /// <seealso cref="mpfr_lib.mpfr_cbrt"/>
        /// <seealso cref="mpfr_lib.mpfr_root"/>
        /// <seealso cref="mpfr_lib.mpfr_pow"/>
        /// <seealso cref="mpfr_lib.mpfr_neg"/>
        /// <seealso cref="mpfr_lib.mpfr_abs"/>
        /// <seealso cref="mpfr_lib.mpfr_dim"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sub_q(mpfr_t rop, /*const*/ mpfr_t op1, mpq_t /*mpq_srcptr*/ op2, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_sub_q(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_f"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_q(/*const*/ mpfr_t op1, mpq_t /*mpq_srcptr*/ op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_cmp_q(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Compare <paramref name="op1"/> and <paramref name="op2"/>.
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns>Return a positive value if <paramref name="op1"/> &gt; <paramref name="op2"/>, zero if <paramref name="op1"/> = <paramref name="op2"/>, and a negative value if <paramref name="op1"/> &lt; <paramref name="op2"/>.</returns>
        /// <remarks>
        /// <para>
        /// Both <paramref name="op1"/> and <paramref name="op2"/> are considered to their full own precision, which may differ.
        /// If one of the operands is NaN, set the erange flag and return zero. 
        /// </para>
        /// <para>
        /// Note: These functions may be useful to distinguish the three possible cases.
        /// If you need to distinguish two cases only, it is recommended to use the predicate functions
        /// (e.g., <see cref="mpfr_equal_p"/> for the equality) described below; they behave like the IEEE 754 comparisons,
        /// in particular when one or both arguments are NaN.
        /// But only floating-point numbers can be compared (you may need to do a conversion first). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_cmp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_d"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_z"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_q"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmp_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_cmpabs"/>
        /// <seealso cref="mpfr_lib.mpfr_nan_p"/>
        /// <seealso cref="mpfr_lib.mpfr_inf_p"/>
        /// <seealso cref="mpfr_lib.mpfr_number_p"/>
        /// <seealso cref="mpfr_lib.mpfr_zero_p"/>
        /// <seealso cref="mpfr_lib.mpfr_regular_p"/>
        /// <seealso cref="mpfr_lib.mpfr_sgn"/>
        /// <seealso cref="mpfr_lib.mpfr_greater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_greaterequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_less_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessequal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_equal_p"/>
        /// <seealso cref="mpfr_lib.mpfr_lessgreater_p"/>
        /// <seealso cref="mpfr_lib.mpfr_unordered_p"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Comparison-Functions">GNU MPFR - Comparison Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_cmp_f(/*const*/ mpfr_t op1, /*const*/ mpf_t op2)
        {
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            return SafeNativeMethods.mpfr_cmp_f(op1.ToIntPtr(), op2.ToIntPtr());
        }

        /// <summary>
        /// Set <paramref name="rop"/> to (<paramref name="op1"/> * <paramref name="op2"/>) + <paramref name="op3"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3">The third operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Concerning special values (signed zeros, infinities, NaN), these functions behave like a multiplication followed by a separate addition.
        /// That is, the fused operation matters only for rounding. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fms"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fma(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, /*const*/ mpfr_t op3, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            if (op3 == null) throw new ArgumentNullException("op3");
            return SafeNativeMethods.mpfr_fma(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), op3.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to (<paramref name="op1"/> * <paramref name="op2"/>) - <paramref name="op3"/> rounded in the direction <paramref name="rnd"/>. 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3">The third operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// Concerning special values (signed zeros, infinities, NaN), these functions behave like a multiplication followed by a separate subtraction.
        /// That is, the fused operation matters only for rounding. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_fac_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_eint"/>
        /// <seealso cref="mpfr_lib.mpfr_li2"/>
        /// <seealso cref="mpfr_lib.mpfr_gamma"/>
        /// <seealso cref="mpfr_lib.mpfr_lngamma"/>
        /// <seealso cref="O:Math.Mpfr.Native.mpfr_lib.mpfr_lgamma"/>
        /// <seealso cref="mpfr_lib.mpfr_digamma"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta"/>
        /// <seealso cref="mpfr_lib.mpfr_zeta_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_erf"/>
        /// <seealso cref="mpfr_lib.mpfr_erfc"/>
        /// <seealso cref="mpfr_lib.mpfr_j0"/>
        /// <seealso cref="mpfr_lib.mpfr_j1"/>
        /// <seealso cref="mpfr_lib.mpfr_jn"/>
        /// <seealso cref="mpfr_lib.mpfr_y0"/>
        /// <seealso cref="mpfr_lib.mpfr_y1"/>
        /// <seealso cref="mpfr_lib.mpfr_yn"/>
        /// <seealso cref="mpfr_lib.mpfr_fma"/>
        /// <seealso cref="mpfr_lib.mpfr_agm"/>
        /// <seealso cref="mpfr_lib.mpfr_hypot"/>
        /// <seealso cref="mpfr_lib.mpfr_ai"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_fms(mpfr_t rop, /*const*/ mpfr_t op1, /*const*/ mpfr_t op2, /*const*/ mpfr_t op3, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            if (op1 == null) throw new ArgumentNullException("op1");
            if (op2 == null) throw new ArgumentNullException("op2");
            if (op3 == null) throw new ArgumentNullException("op3");
            return SafeNativeMethods.mpfr_fms(rop.ToIntPtr(), op1.ToIntPtr(), op2.ToIntPtr(), op3.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// Set <paramref name="rop"/> to the sum of all elements of <paramref name="tab"/>, whose size is <paramref name="n"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="tab">Array of floating-point numbers.</param>
        /// <param name="n">The number of floating-point numbers in <paramref name="tab"/>.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>The returned int value is zero, <paramref name="rop"/> is guaranteed to be the exact sum; otherwise <paramref name="rop"/> might be smaller than, equal to, or larger than the exact sum.</returns>
        /// <remarks>
        /// <para>
        /// If the returned int value is zero, <paramref name="rop"/> is guaranteed to be the exact sum; otherwise <paramref name="rop"/>
        /// might be smaller than, equal to, or larger than the exact sum (in accordance to the rounding mode).
        /// However, <see cref="mpfr_sum"/> does guarantee the result is correctly rounded. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_add"/>
        /// <seealso cref="mpfr_lib.mpfr_add_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_add_si"/>
        /// <seealso cref="mpfr_lib.mpfr_add_d"/>
        /// <seealso cref="mpfr_lib.mpfr_add_z"/>
        /// <seealso cref="mpfr_lib.mpfr_add_q"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Basic-Arithmetic-Functions">GNU MPFR - Basic Arithmetic Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sum(mpfr_t rop, /*const*/ mpfr_t[] /***/ tab, uint /*unsigned long*/ n, mpfr_rnd_t rnd)
        {
            if (tab == null) throw new ArgumentNullException("tab");
            void_ptr p = gmp_lib.allocate((size_t)(n * IntPtr.Size));
            for (int i = 0; i < n; i++) Marshal.WriteIntPtr(p.ToIntPtr(), i * IntPtr.Size, tab[i].ToIntPtr());
            if (rop == null) throw new ArgumentNullException("rop");
            int result = SafeNativeMethods.mpfr_sum(rop.ToIntPtr(), p.ToIntPtr(), n, (int)rnd);
            gmp_lib.free(p);
            return result;
        }

        /// <summary>
        /// Free various caches used by MPFR internally, in particular the caches used by the functions computing constants (<see cref="mpfr_const_log2"/>, <see cref="mpfr_const_pi"/>, <see cref="mpfr_const_euler"/> and <see cref="mpfr_const_catalan"/>).
        /// </summary>
        /// <remarks>
        /// <para>
        /// You should call this function before terminating a thread, even if you did not call these functions directly (they could have been called internally).
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_const_log2"/>
        /// <seealso cref="mpfr_lib.mpfr_const_pi"/>
        /// <seealso cref="mpfr_lib.mpfr_const_euler"/>
        /// <seealso cref="mpfr_lib.mpfr_const_catalan"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Special-Functions">GNU MPFR - Special Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_free_cache(/*void*/)
        {
            SafeNativeMethods.mpfr_free_cache();
        }

        /// <summary>
        /// This function rounds <paramref name="x"/> emulating subnormal number arithmetic.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="t">The input <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a>.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="x"/> is outside the subnormal exponent range, it just propagates the ternary value <paramref name="t"/>;
        /// otherwise, it rounds <paramref name="x"/> to precision EXP(<paramref name="x"/>) - emin + 1 according to rounding mode <paramref name="rnd"/>
        /// and previous ternary value <paramref name="t"/>, avoiding double rounding problems.
        /// More precisely in the subnormal domain, denoting by e the value of emin, <paramref name="x"/> is rounded in fixed-point arithmetic to an
        /// integer multiple of two to the power e - 1; as a consequence, 1.5 multiplied by two to the power e - 1 when <paramref name="t"/> is zero
        /// is rounded to two to the power e with rounding to nearest.
        /// </para>
        /// <para>
        /// PREC(<paramref name="x"/>) is not modified by this function.
        /// <paramref name="rnd"/> and <paramref name="t"/> must be the rounding mode and the returned
        /// <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> used when computing <paramref name="x"/>
        /// (as in <see cref="mpfr_check_range"/>).
        /// The subnormal exponent range is from emin to emin + PREC(<paramref name="x"/>) - 1.
        /// If the result cannot be represented in the current exponent range (due to a too small emax),
        /// the behavior is undefined.
        /// Note that unlike most functions, the result is compared to the exact one, not the input value <paramref name="x"/>,
        /// i.e., the <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> is propagated. 
        /// </para>
        /// <para>
        /// As usual, if the returned <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> is non zero,
        /// the inexact flag is set.
        /// Moreover, if a second rounding occurred (because the input <paramref name="x"/> was in the subnormal range), the underflow flag is set. 
        /// </para>
        /// <para>
        /// This is an example of how to emulate binary double IEEE 754 arithmetic (binary64 in IEEE 754-2008) using MPFR:
        /// </para>
        /// <code language="C#">
        /// mpfr_t xa, xb; int i; volatile double a, b;
        /// mpfr_set_default_prec(53);
        /// mpfr_set_emin(-1073); mpfr_set_emax(1024);
        /// 
        /// mpfr_init(xa); mpfr_init(xb);
        /// 
        /// b = 34.3; mpfr_set_d(xb, b, MPFR_RNDN);
        /// a = 0x1.1235P-1021; mpfr_set_d(xa, a, MPFR_RNDN);
        /// 
        /// a /= b;
        /// i = mpfr_div(xa, xa, xb, MPFR_RNDN);
        /// i = mpfr_subnormalize(xa, i, MPFR_RNDN); /* new ternary value */
        /// 
        /// mpfr_clear(xa); mpfr_clear(xb);
        /// </code> 
        /// <para>
        /// Warning: this emulates a double IEEE 754 arithmetic with correct rounding in the subnormal range, which may not be the case for your hardware.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_get_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emin"/>
        /// <seealso cref="mpfr_lib.mpfr_set_emax"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emin_max"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_min"/>
        /// <seealso cref="mpfr_lib.mpfr_get_emax_max"/>
        /// <seealso cref="mpfr_lib.mpfr_check_range"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Exception-Related-Functions">GNU MPFR - Exception Related Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_subnormalize(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_subnormalize(x.ToIntPtr(), t, (int)rnd);
        }

        /// <summary>
        /// Read a floating-point number from a string <paramref name="nptr"/> in base <paramref name="base"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="nptr">String containing a floating-point number.</param>
        /// <param name="endptr">On return, points the first character after floating-point number in <paramref name="nptr"/>.</param>
        /// <param name="base">The base.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="base"/> must be either 0 (to detect the base, as described below) or a number from 2 to 62 (otherwise the behavior is undefined).
        /// If <paramref name="nptr"/> starts with valid data, the result is stored in <paramref name="rop"/> and <paramref name="endptr"/> points to the character
        /// just after the valid data (if <paramref name="endptr"/> is not a null pointer); otherwise <paramref name="rop"/> is set to zero (for consistency with
        /// <a href="http://en.cppreference.com/w/c/string/byte/strtof">strtod</a>) and the value of <paramref name="nptr"/> is stored in the location referenced
        /// by <paramref name="endptr"/> (if <paramref name="endptr"/> is not a null pointer).
        /// The usual <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> is returned. 
        /// </para>
        /// <para>
        /// Parsing follows the standard C <a href="http://en.cppreference.com/w/c/string/byte/strtof">strtod</a> function with some extensions.
        /// After optional leading whitespace, one has a subject sequence consisting of an optional sign (+ or -), and either numeric data or special data.
        /// The subject sequence is defined as the longest initial subsequence of the input string, starting with the first non-whitespace character, that is of the expected form. 
        /// </para>
        /// <para>
        /// The form of numeric data is a non-empty sequence of significand digits with an optional decimal point, and an optional exponent consisting
        /// of an exponent prefix followed by an optional sign and a non-empty sequence of decimal digits.
        /// A significand digit is either a decimal digit or a Latin letter (62 possible characters), with A = 10, B = 11, …, Z = 35; case is ignored in
        /// bases less or equal to 36, in bases larger than 36, a = 36, b = 37, …, z = 61.
        /// The value of a significand digit must be strictly less than the base.
        /// The decimal point can be either the one defined by the current locale or the period (the first one is accepted for consistency with the
        /// C standard and the practice, the second one is accepted to allow the programmer to provide MPFR numbers from strings in a way that does
        /// not depend on the current locale).
        /// The exponent prefix can be e or E for bases up to 10, or @ in any base; it indicates a multiplication by a power of the base.
        /// In bases 2 and 16, the exponent prefix can also be p or P, in which case the exponent, called binary exponent, indicates a multiplication
        /// by a power of 2 instead of the base (there is a difference only for base 16); in base 16 for example 1p2 represents 4 whereas 1@2 represents 256.
        /// The value of an exponent is always written in base 10. 
        /// </para>
        /// <para>
        /// If the argument base is 0, then the base is automatically detected as follows.
        /// If the significand starts with 0b or 0B, base 2 is assumed.
        /// If the significand starts with 0x or 0X, base 16 is assumed.
        /// Otherwise base 10 is assumed. 
        /// </para>
        /// <para>
        /// Note: The exponent (if present) must contain at least a digit.
        /// Otherwise the possible exponent prefix and sign are not part of the number (which ends with the significand).
        /// Similarly, if 0b, 0B, 0x or 0X is not followed by a binary/hexadecimal digit, then the subject sequence stops at the character 0, thus 0 is read.
        /// </para>
        /// <para>
        /// Special data (for infinities and NaN) can be @inf@ or @nan@(n-char-sequence-opt), and if base &#8804; 16, it can also be infinity, inf,
        /// nan or nan(n-char-sequence-opt), all case insensitive.
        /// A n-char-sequence-opt is a possibly empty string containing only digits, Latin letters and the underscore (0, 1, 2, …, 9, a, b, …, z, A, B, …, Z, _).
        /// Note: one has an optional sign for all data, even NaN. 
        /// For example, -@nAn@(This_Is_Not_17) is a valid representation for NaN in base 17. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_strtofr(mpfr_t rop, /*const*/ char_ptr /*char **/ nptr, ref char_ptr /*char ***/ endptr, int @base, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            return SafeNativeMethods.mpfr_strtofr(rop.ToIntPtr(), nptr.ToIntPtr(), ref endptr.Pointer, @base, (int)rnd);
        }

        /// <summary>
        /// Read a floating-point number from a string <paramref name="nptr"/> in base <paramref name="base"/>, rounded in the direction <paramref name="rnd"/>.
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="nptr">String containing a floating-point number.</param>
        /// <param name="endptr">On return, points the first character after floating-point number in <paramref name="nptr"/>.</param>
        /// <param name="base">The base.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns>Return zero, a positive, or a negative value if <paramref name="rop"/> is respectively equal to, greater than, or lower than the exact result. See <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">GNU MPFR - Rounding Modes</a> for details.</returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="base"/> must be either 0 (to detect the base, as described below) or a number from 2 to 62 (otherwise the behavior is undefined).
        /// If <paramref name="nptr"/> starts with valid data, the result is stored in <paramref name="rop"/> and <paramref name="endptr"/> points to the character
        /// just after the valid data (if <paramref name="endptr"/> is not a null pointer); otherwise <paramref name="rop"/> is set to zero (for consistency with
        /// <a href="http://en.cppreference.com/w/c/string/byte/strtof">strtod</a>) and the value of <paramref name="nptr"/> is stored in the location referenced
        /// by <paramref name="endptr"/> (if <paramref name="endptr"/> is not a null pointer).
        /// The usual <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Rounding-Modes">ternary value</a> is returned. 
        /// </para>
        /// <para>
        /// Parsing follows the standard C <a href="http://en.cppreference.com/w/c/string/byte/strtof">strtod</a> function with some extensions.
        /// After optional leading whitespace, one has a subject sequence consisting of an optional sign (+ or -), and either numeric data or special data.
        /// The subject sequence is defined as the longest initial subsequence of the input string, starting with the first non-whitespace character, that is of the expected form. 
        /// </para>
        /// <para>
        /// The form of numeric data is a non-empty sequence of significand digits with an optional decimal point, and an optional exponent consisting
        /// of an exponent prefix followed by an optional sign and a non-empty sequence of decimal digits.
        /// A significand digit is either a decimal digit or a Latin letter (62 possible characters), with A = 10, B = 11, …, Z = 35; case is ignored in
        /// bases less or equal to 36, in bases larger than 36, a = 36, b = 37, …, z = 61.
        /// The value of a significand digit must be strictly less than the base.
        /// The decimal point can be either the one defined by the current locale or the period (the first one is accepted for consistency with the
        /// C standard and the practice, the second one is accepted to allow the programmer to provide MPFR numbers from strings in a way that does
        /// not depend on the current locale).
        /// The exponent prefix can be e or E for bases up to 10, or @ in any base; it indicates a multiplication by a power of the base.
        /// In bases 2 and 16, the exponent prefix can also be p or P, in which case the exponent, called binary exponent, indicates a multiplication
        /// by a power of 2 instead of the base (there is a difference only for base 16); in base 16 for example 1p2 represents 4 whereas 1@2 represents 256.
        /// The value of an exponent is always written in base 10. 
        /// </para>
        /// <para>
        /// If the argument base is 0, then the base is automatically detected as follows.
        /// If the significand starts with 0b or 0B, base 2 is assumed.
        /// If the significand starts with 0x or 0X, base 16 is assumed.
        /// Otherwise base 10 is assumed. 
        /// </para>
        /// <para>
        /// Note: The exponent (if present) must contain at least a digit.
        /// Otherwise the possible exponent prefix and sign are not part of the number (which ends with the significand).
        /// Similarly, if 0b, 0B, 0x or 0X is not followed by a binary/hexadecimal digit, then the subject sequence stops at the character 0, thus 0 is read.
        /// </para>
        /// <para>
        /// Special data (for infinities and NaN) can be @inf@ or @nan@(n-char-sequence-opt), and if base &#8804; 16, it can also be infinity, inf,
        /// nan or nan(n-char-sequence-opt), all case insensitive.
        /// A n-char-sequence-opt is a possibly empty string containing only digits, Latin letters and the underscore (0, 1, 2, …, 9, a, b, …, z, A, B, …, Z, _).
        /// Note: one has an optional sign for all data, even NaN. 
        /// For example, -@nAn@(This_Is_Not_17) is a valid representation for NaN in base 17. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_set"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj"/>
        /// <seealso cref="mpfr_lib.mpfr_set_flt"/>
        /// <seealso cref="mpfr_lib.mpfr_set_d"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z"/>
        /// <seealso cref="mpfr_lib.mpfr_set_q"/>
        /// <seealso cref="mpfr_lib.mpfr_set_f"/>
        /// <seealso cref="mpfr_lib.mpfr_set_ui_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_si_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_uj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_sj_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_z_2exp"/>
        /// <seealso cref="mpfr_lib.mpfr_set_nan"/>
        /// <seealso cref="mpfr_lib.mpfr_set_inf"/>
        /// <seealso cref="mpfr_lib.mpfr_set_zero"/>
        /// <seealso cref="mpfr_lib.mpfr_swap"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Assignment-Functions">GNU MPFR - Assignment Functions</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_strtofr(mpfr_t rop, /*const*/ char_ptr /*char **/ nptr, ptr<char_ptr> /*char ***/ endptr, int @base, mpfr_rnd_t rnd)
        {
            if (rop == null) throw new ArgumentNullException("rop");
            IntPtr tmp = IntPtr.Zero;
            if (endptr == null)
            return SafeNativeMethods.mpfr_strtofr(rop.ToIntPtr(), nptr.ToIntPtr(), ref tmp, @base, (int)rnd);
            else
                return SafeNativeMethods.mpfr_strtofr(rop.ToIntPtr(), nptr.ToIntPtr(), ref endptr.Value.Pointer, @base, (int)rnd);
        }

        /// <summary>
        /// Free the space occupied by <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <remarks>
        /// <para>
        /// The behavior of this function for any <see cref="mpfr_t"/> not initialized with <see cref="mpfr_custom_init_set"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_custom_clear(mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            x.Clear();
        }

        /// <summary>
        /// Return the needed size in bytes to store the significand of a floating-point number of precision <paramref name="prec"/>. 
        /// </summary>
        /// <param name="prec">The precision in bits.</param>
        /// <returns>Return the needed size in bytes to store the significand of a floating-point number of precision <paramref name="prec"/>.</returns>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static size_t mpfr_custom_get_size(uint /*mpfr_prec_t*/ prec)
        {
            if (IntPtr.Size == 4)
                return SafeNativeMethods.mpfr_custom_get_size_x86(prec);
            else
                return SafeNativeMethods.mpfr_custom_get_size_x64(prec);
        }

        /// <summary>
        /// Initialize a significand of precision <paramref name="prec"/>.
        /// </summary>
        /// <param name="significand">Pointer to significand.</param>
        /// <param name="prec">The precision in bits.</param>
        /// <remarks>
        /// <para>
        /// Initialize a significand of precision <paramref name="prec"/>, where significand must be an area of
        /// <see cref="mpfr_custom_get_size"/>(<paramref name="prec"/>) bytes at least and be suitably aligned
        /// for an array of mp_limb_t (GMP type, see <a href="http://www.mpfr.org/mpfr-current/mpfr.html#Internals">GNU MPFR - Internals</a>). 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_custom_init(void_ptr /*void **/ significand, uint /*mpfr_prec_t*/ prec)
        {
            SafeNativeMethods.mpfr_custom_init(significand.ToIntPtr(), prec);
        }

        /// <summary>
        /// Return a pointer to the significand used by a <see cref="mpfr_t"/> initialized with <see cref="mpfr_custom_init_set"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <returns>Return a pointer to the significand used by a <see cref="mpfr_t"/> initialized with <see cref="mpfr_custom_init_set"/>.</returns>
        /// <remarks>
        /// <para>
        /// The behavior of this function for any <see cref="mpfr_t"/> not initialized with <see cref="mpfr_custom_init_set"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void_ptr /*void **/ mpfr_custom_get_significand(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return new void_ptr(SafeNativeMethods.mpfr_custom_get_significand(x.ToIntPtr()));
        }

        /// <summary>
        /// Return the exponent of <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <returns>Return the exponent of <paramref name="x"/>.</returns>
        /// <remarks>
        /// <para>
        /// Return the exponent of <paramref name="x"/>, assuming that <paramref name="x"/> is a non-zero ordinary number.
        /// The return value for NaN, Infinity or zero is unspecified but does not produce any trap.
        /// The behavior of this function for any <see cref="mpfr_t"/> not initialized with <see cref="mpfr_custom_init_set"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_exp_t mpfr_custom_get_exp(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return SafeNativeMethods.mpfr_custom_get_exp(x.ToIntPtr());
        }

        /// <summary>
        /// Inform MPFR that the significand of <paramref name="x"/> has moved due to a garbage collect and update its new position to <paramref name="new_position"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="new_position">Pointer to the new address of the significand of <paramref name="x"/>.</param>
        /// <remarks>
        /// <para>
        /// However the application has to move the significand and the <see cref="mpfr_t"/> itself.
        /// The behavior of this function for any <see cref="mpfr_t"/> not initialized with <see cref="mpfr_custom_init_set"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_custom_move(mpfr_t x, void_ptr /*void **/ new_position)
        {
            if (x == null) throw new ArgumentNullException("x");
            SafeNativeMethods.mpfr_custom_move(x.ToIntPtr(), new_position.ToIntPtr());
        }

        /// <summary>
        /// Perform a dummy initialization of a <see cref="mpfr_t"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <param name="kind">The kind of number to initialize.</param>
        /// <param name="exp">The exponent.</param>
        /// <param name="prec">The precision in bits.</param>
        /// <param name="significand">Pointer to the significand.</param>
        /// <remarks>
        /// <para>
        /// Perform a dummy initialization of a <see cref="mpfr_t"/> and set it to:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// if ABS(<paramref name="kind"/>) == <see cref="mpfr_kind_t.MPFR_NAN_KIND"/>, <paramref name="x"/> is set to NaN;
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// if ABS(<paramref name="kind"/>) == <see cref="mpfr_kind_t.MPFR_INF_KIND"/>, <paramref name="x"/> is set to the infinity of sign sign(<paramref name="kind"/>); 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// if ABS(<paramref name="kind"/>) == <see cref="mpfr_kind_t.MPFR_ZERO_KIND"/>, <paramref name="x"/> is set to the zero of sign sign(<paramref name="kind"/>); 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// if ABS(<paramref name="kind"/>) == <see cref="mpfr_kind_t.MPFR_REGULAR_KIND"/>, <paramref name="x"/> is set to a regular number: 
        /// <paramref name="x"/> = sign(<paramref name="kind"/>) * <paramref name="significand"/> * 2^<paramref name="exp"/>. 
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// In all cases, it uses significand directly for further computing involving <paramref name="x"/>.
        /// It will not allocate anything.
        /// A floating-point number initialized with this function cannot be resized using <see cref="mpfr_set_prec"/>
        /// or <see cref="mpfr_prec_round"/>, or cleared using <see cref="mpfr_clear"/>!
        /// The <paramref name="significand"/> must have been initialized with <see cref="mpfr_custom_init"/> using the same precision <paramref name="prec"/>. 
        /// </para>
        /// <para>
        /// The <see cref="mpfr_custom_clear"/> function must be called to free the memory occupied by <paramref name="x"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_kind"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_custom_init_set(mpfr_t x, /*int*/ mpfr_kind_t kind, mpfr_exp_t exp, uint /*mpfr_prec_t*/ prec, void_ptr /*void **/ significand)
        {
            if (x == null) throw new ArgumentNullException("x");
            x.Initializing();
            SafeNativeMethods.mpfr_custom_init_set(x.ToIntPtr(), (int)kind, exp, prec, significand.ToIntPtr());
            x.Initialized();
        }

        /// <summary>
        /// Return the current kind of a <see cref="mpfr_t"/> as created by <see cref="mpfr_custom_init_set"/>.
        /// </summary>
        /// <param name="x">The operand floating-point number.</param>
        /// <returns>Return the current kind of a <see cref="mpfr_t"/> as created by <see cref="mpfr_custom_init_set"/>.</returns>
        /// <remarks>
        /// <para>
        /// The behavior of this function for any <see cref="mpfr_t"/> not initialized with <see cref="mpfr_custom_init_set"/> is undefined. 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_size"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_init_set"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_significand"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_get_exp"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_move"/>
        /// <seealso cref="mpfr_lib.mpfr_custom_clear"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Custom-Interface">GNU MPFR - Custom Interface</a></seealso>
        /// <example>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static mpfr_kind_t /*int*/ mpfr_custom_get_kind(/*const*/ mpfr_t x)
        {
            if (x == null) throw new ArgumentNullException("x");
            return (mpfr_kind_t)SafeNativeMethods.mpfr_custom_get_kind(x.ToIntPtr());
        }

        [SuppressUnmanagedCodeSecurity]
        private static class SafeNativeMethods
        {

            #region "Win32 functions."

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetDllDirectory(string directory);

            #endregion

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_out_str")]
            public static extern uint /*size_t*/ __gmpfr_out_str_x86(IntPtr /*FILE **/ stream, int @base, uint /*size_t*/ n, IntPtr /*mpfr_srcptr*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_out_str")]
            public static extern ulong /*size_t*/ __gmpfr_out_str_x64(IntPtr /*FILE **/ stream, int @base, ulong /*size_t*/ n, IntPtr /*mpfr_srcptr*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_inp_str")]
            public static extern uint /*size_t*/ __gmpfr_inp_str_x86(IntPtr /*mpfr_ptr*/ rop, IntPtr /*FILE **/ stream, int @base, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_inp_str")]
            public static extern ulong /*size_t*/ __gmpfr_inp_str_x64(IntPtr /*mpfr_ptr*/ rop, IntPtr /*FILE **/ stream, int @base, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern long /*intmax_t*/ __gmpfr_mpfr_get_sj(IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern ulong /*uintmax_t*/ __gmpfr_mpfr_get_uj(IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int __gmpfr_set_sj(IntPtr /*mpfr_t*/ rop, long /*intmax_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int __gmpfr_set_uj(IntPtr /*mpfr_t*/ rop, ulong /*uintmax_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int __gmpfr_set_sj_2exp(IntPtr /*mpfr_t*/ rop, long /*intmax_t*/ op, long /*intmax_t*/ e, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int __gmpfr_set_uj_2exp(IntPtr /*mpfr_t*/ rop, ulong /*uintmax_t*/ op, ulong /*uintmax_t*/ e, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern /*const*/ IntPtr /*char **/ mpfr_get_version(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern /*const*/ IntPtr /*char **/ mpfr_get_patches(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_buildopt_tls_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_buildopt_decimal_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_buildopt_gmpinternals_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern /*const*/ IntPtr /*char **/ mpfr_buildopt_tune_case(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emin(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_emin(int /*mpfr_exp_t*/ exp);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emin_min(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emin_max(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emax(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_emax(int /*mpfr_exp_t*/ exp);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emax_min(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_emax_max(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_default_rounding_mode(int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_rnd_t*/ mpfr_get_default_rounding_mode(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern /*const*/ IntPtr /*char **/ mpfr_print_rnd_mode(int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_flags(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_underflow(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_overflow(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_divby0(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_nanflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_inexflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear_erangeflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_underflow(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_overflow(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_divby0(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_nanflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_inexflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_erangeflag(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_underflow_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_overflow_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_divby0_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_nanflag_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_inexflag_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_erangeflag_p(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_check_range(IntPtr /*mpfr_t*/ x, int t, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_init2(IntPtr /*mpfr_t*/ x, uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_init(IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_clear(IntPtr /*mpfr_t*/ x);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern void mpfr_inits2(uint /*mpfr_prec_t*/ prec, IntPtr /*mpfr_t*/ x /*...*/);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern void mpfr_inits(IntPtr /*mpfr_t*/ x, IntPtr args /*...*/);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern void mpfr_clears(IntPtr /*mpfr_t*/ x, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_prec_round(IntPtr /*mpfr_t*/ x, uint /*mpfr_prec_t*/ prec, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_can_round(/*const*/ IntPtr /*mpfr_t*/ b, int /*mpfr_exp_t*/ err, int /*mpfr_rnd_t*/ rnd1, int /*mpfr_rnd_t*/ rnd2, uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint /*mpfr_prec_t*/ mpfr_min_prec(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_exp(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_exp(IntPtr /*mpfr_t*/ x, int /*mpfr_exp_t*/ e);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint /*mpfr_prec_t*/ mpfr_get_prec(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_prec(IntPtr /*mpfr_t*/ x, uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_prec_raw(IntPtr /*mpfr_t*/ x, uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_default_prec(uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint /*mpfr_prec_t*/ mpfr_get_default_prec(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_d(IntPtr /*mpfr_t*/ rop, double op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_flt(IntPtr /*mpfr_t*/ rop, float op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int mpfr_set_decimal64(IntPtr /*mpfr_t*/, _Decimal64, int /*mpfr_rnd_t*/);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int mpfr_set_ld(IntPtr /*mpfr_t*/, long double, int /*mpfr_rnd_t*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpz_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_z_2exp(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpz_t*/ op, int /*mpfr_exp_t*/ e, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_nan(IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_inf(IntPtr /*mpfr_t*/ x, int sign);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_set_zero(IntPtr /*mpfr_t*/ x, int sign);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_f(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpf_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_get_f(IntPtr /*mpf_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_si(IntPtr /*mpfr_t*/ rop, int /*long*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_ui(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_si_2exp(IntPtr /*mpfr_t*/ rop, int /*long*/ op, int /*mpfr_exp_t*/ e, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_ui_2exp(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op, int /*mpfr_exp_t*/ e, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_q(IntPtr /*mpfr_t*/ rop, IntPtr /*mpq_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set_str(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*char **/ s, int @base, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_init_set_str(IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*char **/ s, int @base, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int mpfr_set4(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd, int s);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_abs(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_set(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_neg(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_signbit(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_setsign(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int s, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_copysign(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_get_z_2exp(IntPtr /*mpz_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern float mpfr_get_flt(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double mpfr_get_d(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern _Decimal64 mpfr_get_decimal64(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern long double mpfr_get_ld(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern double mpfr_get_d1(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double mpfr_get_d_2exp(ref int /*long **/ exp, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern long double mpfr_get_ld_2exp(ptr<int> /*long **/ exp, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_frexp(ref int /*mpfr_exp_t **/ exp, IntPtr /*mpfr_t*/ y, /*const*/ IntPtr /*mpfr_t*/ x, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*long*/ mpfr_get_si(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint /*unsigned long*/ mpfr_get_ui(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "mpfr_get_str")]
            public static extern IntPtr /*char **/ mpfr_get_str_x86(IntPtr /*char **/ str, ref int /*mpfr_exp_t **/ expptr, int b, uint /*size_t*/ n, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "mpfr_get_str")]
            public static extern IntPtr /*char **/ mpfr_get_str_x64(IntPtr /*char **/ str, ref int /*mpfr_exp_t **/ expptr, int b, ulong /*size_t*/ n, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_get_z(IntPtr /*mpz_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_free_str(IntPtr /*char **/ str);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_urandom(IntPtr /*mpfr_t*/ rop, IntPtr /*gmp_randstate_t*/ state, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_grandom(IntPtr /*mpfr_t*/ rop1, IntPtr /*mpfr_t*/ rop2, IntPtr /*gmp_randstate_t*/ state, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_urandomb(IntPtr /*mpfr_t*/ rop, IntPtr /*gmp_randstate_t*/ state);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_nextabove(IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_nextbelow(IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_nexttoward(IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*mpfr_t*/ y);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vasprintf")]
            public static extern int mpfr_vasprintf(ref IntPtr /*char ***/ str, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vfprintf")]
            public static extern int mpfr_vfprintf(IntPtr /*FILE */stream, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vprintf")]
            public static extern int mpfr_vprintf(/*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsnprintf")]
            public static extern int mpfr_vsnprintf_x86(IntPtr /*char **/ buf, uint /*size_t*/ n, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsnprintf")]
            public static extern int mpfr_vsnprintf_x64(IntPtr /*char **/ buf, ulong /*size_t*/ n, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsprintf")]
            public static extern int mpfr_vsprintf(IntPtr /*char **/ buf, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_pow(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_pow_si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_pow_ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ui_pow_ui(IntPtr /*mpfr_t*/ rop, uint /*unsigned long int*/ op1, uint /*unsigned long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ui_pow(IntPtr /*mpfr_t*/ rop, uint /*unsigned long int*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_pow_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sqrt(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sqrt_ui(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rec_sqrt(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add_ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub_ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ui_sub(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ui_div(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add_si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub_si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_si_sub(IntPtr /*mpfr_t*/ rop, int /*long int*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long int*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_si_div(IntPtr /*mpfr_t*/ rop, int /*long int*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add_d(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, double op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub_d(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, double op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_d_sub(IntPtr /*mpfr_t*/ rop, double op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_d(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, double op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_d(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, double op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_d_div(IntPtr /*mpfr_t*/ rop, double op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sqr(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_const_pi(IntPtr /*mpfr_t*/ rop, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_const_log2(IntPtr /*mpfr_t*/ rop, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_const_euler(IntPtr /*mpfr_t*/ rop, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_const_catalan(IntPtr /*mpfr_t*/ rop, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_agm(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_log(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_log2(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_log10(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_log1p(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_exp(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_exp2(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_exp10(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_expm1(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_eint(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_li2(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int mpfr_cmp3(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int s);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_d(/*const*/ IntPtr /*mpfr_t*/ op1, double op2);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern int mpfr_cmp_ld(/*const*/ IntPtr /*mpfr_t*/, long double);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmpabs(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_ui(/*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_si(/*const*/ IntPtr /*mpfr_t*/ op1, int /*long*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_ui_2exp(/*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_exp_t*/ e);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_si_2exp(/*const*/ IntPtr /*mpfr_t*/ op1, int /*long*/ op2, int /*mpfr_exp_t*/ e);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_reldiff(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_eq(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, uint /*unsigned long*/ op3);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sgn(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_2exp(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_2exp(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_2ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_2ui(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, uint /*unsigned long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_2si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_2si(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, int /*long*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rint(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_round(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_trunc(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ceil(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_floor(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rint_round(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rint_trunc(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rint_ceil(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_rint_floor(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_frac(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_modf(IntPtr /*mpfr_t*/ iop, IntPtr /*mpfr_t*/ fop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_remquo(IntPtr /*mpfr_t*/ r, ref int /*long **/ q, /*const*/ IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*mpfr_t*/ y, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_remainder(IntPtr /*mpfr_t*/ r, /*const*/ IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*mpfr_t*/ y, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fmod(IntPtr /*mpfr_t*/ r, /*const*/ IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*mpfr_t*/ y, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_ulong_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_slong_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_uint_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_sint_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_ushort_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_sshort_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_uintmax_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fits_intmax_p(/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern void mpfr_extract(IntPtr /*mpz_t*/ y, /*const*/ IntPtr /*mpfr_t*/ p, uint /*unsigned int*/ i);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_swap(IntPtr /*mpfr_t*/ x, IntPtr /*mpfr_t*/ y);

            //[DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern void mpfr_dump(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_nan_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_inf_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_number_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_integer_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_zero_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_regular_p(/*const*/ IntPtr /*mpfr_t*/ op);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_greater_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_greaterequal_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_less_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_lessequal_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_lessgreater_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_equal_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_unordered_p(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_atanh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_acosh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_asinh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cosh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sinh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_tanh(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sinh_cosh(IntPtr /*mpfr_t*/ sop, IntPtr /*mpfr_t*/ cop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sech(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_csch(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_coth(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_acos(IntPtr /*mpfr_t*/ rop,/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_asin(IntPtr /*mpfr_t*/ rop,/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_atan(IntPtr /*mpfr_t*/ rop,/*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sin(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sin_cos(IntPtr /*mpfr_t*/ sop, IntPtr /*mpfr_t*/ cop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cos(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_tan(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_atan2(IntPtr /*mpfr_t*/ rop,/*const*/ IntPtr /*mpfr_t*/ y,/*const*/ IntPtr /*mpfr_t*/ x, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sec(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_csc(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cot(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_hypot(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ x, /*const*/ IntPtr /*mpfr_t*/ y, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_erf(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_erfc(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cbrt(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_root(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, uint /*unsigned long*/ k, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_gamma(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_lngamma(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_lgamma(IntPtr /*mpfr_t*/ rop, ref int /*int **/ signp, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_digamma(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_zeta(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_zeta_ui(IntPtr /*mpfr_t*/ rop, uint /*unsigned long*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fac_ui(IntPtr /*mpfr_t*/ rop, uint /*unsigned long int*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_j0(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_j1(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_jn(IntPtr /*mpfr_t*/ rop, int /*long*/ n, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_y0(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_y1(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_yn(IntPtr /*mpfr_t*/ rop, int /*long*/ n, /*const*/ IntPtr /*mpfr_t*/ op, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_ai(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ x, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_min(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_max(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_dim(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub_z(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_z_sub(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpz_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_z(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpz_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_mul_q(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, IntPtr /*mpq_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_div_q(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, IntPtr /*mpq_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_add_q(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, IntPtr /*mpq_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sub_q(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, IntPtr /*mpq_t*/ op2, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_q(/*const*/ IntPtr /*mpfr_t*/ op1, IntPtr /*mpq_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_cmp_f(/*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpf_t*/ op2);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fma(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, /*const*/ IntPtr /*mpfr_t*/ op3, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_fms(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t*/ op1, /*const*/ IntPtr /*mpfr_t*/ op2, /*const*/ IntPtr /*mpfr_t*/ op3, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_sum(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*mpfr_t[]*/ tab, uint /*unsigned long*/ n, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_free_cache(/*void*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_subnormalize(IntPtr /*mpfr_t*/ x, int t, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_strtofr(IntPtr /*mpfr_t*/ rop, /*const*/ IntPtr /*char **/ nptr, ref IntPtr /*char ***/ endptr, int @base, int /*mpfr_rnd_t*/ rnd);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "mpfr_custom_get_size")]
            public static extern uint /*size_t*/ mpfr_custom_get_size_x86(uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "mpfr_custom_get_size")]
            public static extern ulong /*size_t*/ mpfr_custom_get_size_x64(uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_custom_init(IntPtr /*void **/ significand, uint /*mpfr_prec_t*/ prec);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr /*void **/ mpfr_custom_get_significand(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int /*mpfr_exp_t*/ mpfr_custom_get_exp(/*const*/ IntPtr /*mpfr_t*/ x);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_custom_move(IntPtr /*mpfr_t*/ x, IntPtr /*void **/ new_position);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mpfr_custom_init_set(IntPtr /*mpfr_t*/ x, int kind, int /*mpfr_exp_t*/ exp, uint /*mpfr_prec_t*/ prec, IntPtr /*void **/ significand);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int mpfr_custom_get_kind(/*const*/ IntPtr /*mpfr_t*/ x);

        }

        private class SafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeHandle(IntPtr handle)
                : base(true)
            {
                SetHandle(handle);
            }

            //public IntPtr Handle
            //{
            //    get
            //    {
            //        return handle;
            //    }
            //}

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                mpfr_lib.SafeNativeMethods.FreeLibrary(handle);
                return true;
            }
        }

    }
}
