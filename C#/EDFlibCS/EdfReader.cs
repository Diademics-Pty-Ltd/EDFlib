using EDFlibCS.Enums;
using EDFlibCS.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace EDFlibCS
{
    public class EdfReader : EdfLibObj
    {
        const double DefaultBlockLength = 1.0;
        public string Filename { get; }
        public EdfHeader Header { get; }


        private readonly List<EdfPhysicalSignalReader> physicalSignalReaders = new List<EdfPhysicalSignalReader>();

        public EdfReader(string path, AnnotationRead annotationRead = AnnotationRead.DoNotRead, double blockLength = DefaultBlockLength) : base(DllHandler.CreateReader(path, (int)annotationRead))
        {
            // error handling
            Filename = Path.GetFileName(path);
            Header = new EdfHeader(this);
            for (int i = 0; i < Header.SignalParameters.Count; i++)
                physicalSignalReaders.Add(new EdfPhysicalSignalReader(this, i, blockLength));
        }

        public IReadOnlyList<double>? ReadPhysicalDataFromSingleSignal(int signalIndex, double blockLength = DefaultBlockLength)
        {
            if (signalIndex < 0 || signalIndex >= physicalSignalReaders.Count)
                throw new ArgumentOutOfRangeException(nameof(signalIndex));
            if (blockLength != physicalSignalReaders[signalIndex].BlockLength)
                physicalSignalReaders[signalIndex].BlockLength = blockLength;
            return physicalSignalReaders[signalIndex].ReadSamples();
        }

        protected override void DestroyEdfLibObject(IntPtr obj)
        { }
    }
}
