using System;
using System.Runtime.InteropServices;

namespace EDFlibCS.Internal
{
    internal class DllHandler
    {
        const string libname = "EDFlib";

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr CreateReader(string path, int readAnnotations);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int getHeaderSignalCount(IntPtr reader, out int signalCount);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int getHeaderDataRecordDuration(IntPtr reader, out ulong dataRecordDuration);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int getSignalLabel(IntPtr reader, int signalIndex, byte[] label);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern  int ReadPhysicalSamples(IntPtr obj, int signalIndex, int sampleCount, double[] samples);
    }
}
