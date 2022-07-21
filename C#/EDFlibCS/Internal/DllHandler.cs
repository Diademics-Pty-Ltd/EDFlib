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
        public static extern int getSignalSamplesInDataRecord(IntPtr reader, int signalIndex, out int samplesInDataRecord);
        
        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern  int ReadPhysicalSamples(IntPtr obj, int signalIndex, int sampleCount, double[] samples);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int getSamplePosition(IntPtr obj, int signalIndex, out ulong samplePosition);

        [DllImport(libname, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern int setSamplePosition(IntPtr obj, int signalIndex, ulong samplePosition);
    }
}
