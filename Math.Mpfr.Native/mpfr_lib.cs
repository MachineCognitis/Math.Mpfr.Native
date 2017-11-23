
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rnd">The rounding direction.</param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        public static void mpfr_clear_overflow(/*void*/)
        {
            SafeNativeMethods.mpfr_clear_overflow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="prec"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
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
        /// <seealso cref="mpfr_lib.mpfr_set_prec(mpfr_t, mpfr_prec_t)"/>
        /// <seealso cref="mpfr_lib.mpfr_get_prec(mpfr_t)"/>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="http://www.mpfr.org/mpfr-current/mpfr.html#Initialization-Functions">GNU MPFR - Initialization Functions</a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="prec"></param>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="prec"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="err"></param>
        /// <param name="rnd1"></param>
        /// <param name="rnd2"></param>
        /// <param name="prec"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="prec"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="prec"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="prec"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="sign"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="sign"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="e"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="s"></param>
        /// <param name="base"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="s"></param>
        /// <param name="base"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="s"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expptr"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expptr"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static void mpfr_free_str(char_ptr /*char **/ str)
        {
            SafeNativeMethods.mpfr_free_str(str.ToIntPtr());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="state"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop1"></param>
        /// <param name="rop2"></param>
        /// <param name="state"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_grandom(mpfr_t rop1, mpfr_t rop2, gmp_randstate_t state, mpfr_rnd_t rnd)
        {
            if (rop1 == null) throw new ArgumentNullException("rop1");
            if (rop2 == null) throw new ArgumentNullException("rop2");
            if (state == null) throw new ArgumentNullException("state");
            return SafeNativeMethods.mpfr_grandom(rop1.ToIntPtr(), rop2 == null ? IntPtr.Zero : rop2.ToIntPtr(), state.ToIntPtr(), (int)rnd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_printf(/*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            return mpfr_vprintf(template, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vprintf(/*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            va_list va_args = new va_list(args);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vprintf(format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_asprintf(ptr<char_ptr> /*char ***/ str, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            return mpfr_vasprintf(str, template, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vasprintf(ref char_ptr /*char ***/ str, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            va_list va_args = new va_list(args);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vasprintf(ref str.Pointer, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vasprintf(ptr<char_ptr> /*char ***/ str, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            if (str == null) throw new ArgumentNullException("str");
            va_list va_args = new va_list(args);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vasprintf(ref str.Value.Pointer, format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_sprintf(char_ptr /*char **/ buf, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            return mpfr_vsprintf(buf, template, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vsprintf(char_ptr /*char **/ buf, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            va_list va_args = new va_list(args);
            char_ptr format = new char_ptr(template);
            int result = SafeNativeMethods.mpfr_vsprintf(buf.ToIntPtr(), format.ToIntPtr(), va_args.ToIntPtr());
            va_args.RetrieveArgumentValues();
            gmp_lib.free(format);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="n"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_snprintf(char_ptr /*char **/ buf, size_t n, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            return mpfr_vsnprintf(buf, n, template, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="n"></param>
        /// <param name="template"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
        /// <code language="C#">
        /// </code> 
        /// <code language="VB.NET">
        /// </code> 
        /// </example>
        public static int mpfr_vsnprintf(char_ptr /*char **/ buf, size_t n, /*const*/ string /*char **/ template, params object[] args /*...*/)
        {
            int result;
            va_list va_args = new va_list(args);
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="iop"></param>
        /// <param name="fop"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="q"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="q"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op">The operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="sop"></param>
        /// <param name="cop"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="sop"></param>
        /// <param name="cop"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="k"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="signp"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="signp"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="n"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="n"></param>
        /// <param name="op">The operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="x"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="op1">The first operand floating-point number.</param>
        /// <param name="op2">The second operand floating-point number.</param>
        /// <param name="op3"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="tab"></param>
        /// <param name="n"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="nptr"></param>
        /// <param name="endptr"></param>
        /// <param name="base"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="rop">The result floating-point number.</param>
        /// <param name="nptr"></param>
        /// <param name="endptr"></param>
        /// <param name="base"></param>
        /// <param name="rnd">The rounding direction.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="prec"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="significand"></param>
        /// <param name="prec"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="new_position"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="kind"></param>
        /// <param name="exp"></param>
        /// <param name="prec"></param>
        /// <param name="significand"></param>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// <seealso cref="mpfr_lib"/>
        /// <seealso cref="mpfr_lib"><a href="">GNU MPFR - </a></seealso>
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

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vprintf")]
            public static extern int mpfr_vprintf(/*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vasprintf")]
            public static extern int mpfr_vasprintf(ref IntPtr /*char ***/ str, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsprintf")]
            public static extern int mpfr_vsprintf(IntPtr /*char **/ buf, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsnprintf")]
            public static extern int mpfr_vsnprintf_x86(IntPtr /*char **/ buf, uint /*size_t*/ n, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

            [DllImport(@"libmpfr-4.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__gmpfr_vsnprintf")]
            public static extern int mpfr_vsnprintf_x64(IntPtr /*char **/ buf, ulong /*size_t*/ n, /*const*/ IntPtr /*char **/ template, IntPtr args /*...*/);

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
