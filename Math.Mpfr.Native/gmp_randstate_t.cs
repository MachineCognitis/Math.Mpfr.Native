
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Math.Mpfr.Native
{

    /// <summary>
    /// Represents the state of a random number generator.
    /// </summary>
    /// <remarks></remarks>
    public class mpfr_randstate_t
    {

        private IntPtr _pointer;

        /// <summary>
        /// Creates a new random number generator state.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When done with the random number generator state, unmanaged memory must be released with <see cref="mpfr_lib.free(mpfr_randstate_t)"/> .
        /// </para>
        /// </remarks>
        public mpfr_randstate_t()
        {
            // Allocation sizes take into account the members alignment done by the C compiler.
            _pointer = mpfr_lib.allocate(IntPtr.Size == 4 ? 20U : 32U).ToIntPtr();
        }

        internal IntPtr ToIntPtr()
        {
            return _pointer;
        }

    }

}